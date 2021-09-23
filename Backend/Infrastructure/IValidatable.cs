using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public delegate ValidationResult ValidationRuleDelegate(object context, string propertyName = null);

    /// <summary>
    /// Interfejs obiektu podlegającego walidacji
    /// </summary>
    public interface IValidatable
    {
        /// <summary>
        /// Zwraca false jeśli obiekt posiada niespełnione reguły walidacyjne wywołując wcześniej jego walidację (bez wyrzucania wyjątku).
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Waliduje obiekt i jeśli obiekt posiada niespełnione reguły walidacyjne to wyrzuca wyjątek ValidationException.
        /// </summary>
        void Validate();

        /// <summary>
        /// Pobiera wszystkie niespełnione reguły walidacyjne obiektu wywołując wcześniej jego walidację (bez wyrzucania wyjątku).
        /// </summary>
        /// <returns>Lista niespełnionych reguł walidacyjnych</returns>
        IList<ValidationResult> GetBrokenRules();

        /// <summary>
        /// Pobiera niespełnione reguły walidacyjne dla wskazanej właściwości obiektu wywołując wcześniej jego walidację (bez wyrzucania wyjątku).
        /// </summary>
        /// <param name="propertyName">Nazwa właściwości dla której ma się odbyć walidacja</param>
        /// <returns>Lista niespełnionych reguł walidacyjnych</returns>
        IList<ValidationResult> GetBrokenRules(string propertyName);
    }
}
