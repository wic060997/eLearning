using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    [ValueObject]
    public class AuditData : ValueObject
    {
        private string createdBy;
        private DateTime createdDate;
        private string modifiedBy;
        private DateTime? modifiedDate;

        /// <summary>
        /// For NHibernate.
        /// </summary>
        protected AuditData() { }

        public AuditData(string createdBy, DateTime createdDate)
        {
            this.createdBy = createdBy;
            this.createdDate = createdDate;
        }

        public AuditData(string createdBy, DateTime createdDate, string modifiedBy, DateTime? modifiedDate)
        {
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.modifiedBy = modifiedBy;
            this.modifiedDate = modifiedDate;
        }

        public virtual string CreatedBy { get { return createdBy; } private set { createdBy = value; } }

        public virtual DateTime CreatedDate { get { return createdDate; } private set { createdDate = value; } }

        public virtual string ModifiedBy { get { return modifiedBy; } private set { modifiedBy = value; } }

        public virtual DateTime? ModifiedDate { get { return modifiedDate; } private set { modifiedDate = value; } }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return createdBy;
            yield return createdDate;
            yield return modifiedBy;
            yield return modifiedDate;
        }
    }
}
