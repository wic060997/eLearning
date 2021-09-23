using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ValidatableObject : IValidatable
    {
        public ValidatableObject()
        {
            this.RegisterCustomValidationRules();
        }

        /// <summary>
        /// Zwraca false jeśli obiekt posiada niespełnione reguły walidacyjne wywołując wcześniej jego walidację (bez wyrzucania wyjątku).
        /// </summary>
        public virtual bool IsValid
        {
            get { return GetBrokenRules().Count == 0; }
        }

        /// <summary>
        /// Waliduje obiekt i jeśli obiekt posiada niespełnione reguły walidacyjne to wyrzuca wyjątek ValidationException.
        /// </summary>
        /// <exception>ValidationException</exception>
        public virtual void Validate()
        {
            ValidationContext validationContext = new ValidationContext(this, null, null);
            Validator.ValidateObject(this, validationContext, true);

            // Walidacja reguł customowych
            foreach (var validationRule in customValidationRules.SelectMany(v => v.Value))
            {
                var validationResult = validationRule(this);
                if (validationResult != null && !String.IsNullOrEmpty(validationResult.ErrorMessage))
                    throw new ValidationException(validationResult.ErrorMessage);
            }
        }

        /// <summary>
        /// Pobiera wszystkie niespełnione reguły walidacyjne obiektu wywołując wcześniej jego walidację (bez wyrzucania wyjątku).
        /// </summary>
        /// <returns>Lista niespełnionych reguł walidacyjnych</returns>
        public virtual IList<ValidationResult> GetBrokenRules()
        {
            IList<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this, validationContext, validationResults, true);

            // Walidacja reguł customowych
            foreach (var propertyNameKey in customValidationRules)
            {
                foreach (var validationRule in propertyNameKey.Value)
                {
                    var validationResult = validationRule(this, propertyNameKey.Key);
                    if (validationResult != null)
                        validationResults.Add(validationResult);
                }
            }
            return validationResults;
        }

        /// <summary>
        /// Pobiera niespełnione reguły walidacyjne dla wskazanej właściwości obiektu wywołując wcześniej jego walidację (bez wyrzucania wyjątku).
        /// </summary>
        /// <param name="propertyName">Nazwa właściwości dla której ma się odbyć walidacja</param>
        /// <returns>Lista niespełnionych reguł walidacyjnych</returns>
        public virtual IList<ValidationResult> GetBrokenRules(string propertyName)
        {
            IList<ValidationResult> validationResults = new List<ValidationResult>();
            PropertyInfo property = this.GetType().GetProperty(propertyName);
            if (property != null && property.CanRead)
            {
                ValidationContext validationContext = new ValidationContext(this, null, null);
                validationContext.MemberName = propertyName;
                object propertyValue = property.GetValue(this, null);
                Validator.TryValidateProperty(propertyValue, validationContext, validationResults);
            }

            // Walidacja reguł customowych
            if (customValidationRules.ContainsKey(propertyName))
            {
                foreach (var validationRule in customValidationRules[propertyName])
                {
                    var validationResult = validationRule(this, propertyName);
                    if (validationResult != null)
                        validationResults.Add(validationResult);
                }
            }

            return validationResults;
        }

        private IDictionary<string, IList<ValidationRuleDelegate>> customValidationRules = new Dictionary<string, IList<ValidationRuleDelegate>>();

        /// <summary>
        /// Rejestruje metodę reguły walidacyjnej dla wskazanej właściwości
        /// </summary>
        /// <param name="validationMethod">Metoda walidująca</param>
        /// <param name="propertyName">Opcjonalna nazwa właściwości która podlega walidacji</param>
        protected virtual void AddCustomValidationRule(ValidationRuleDelegate validationMethod, string propertyName = null)
        {
            if (!customValidationRules.ContainsKey(propertyName))
                customValidationRules.Add(propertyName, new List<ValidationRuleDelegate>());

            customValidationRules[propertyName].Add(validationMethod);
        }

        /// <summary>
        /// Rejestruje customowe reguły walidacyjne
        /// </summary>
        protected virtual void RegisterCustomValidationRules()
        {

        }
    }
}
