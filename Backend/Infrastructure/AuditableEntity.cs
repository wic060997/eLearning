using Seterlund.CodeGuard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public abstract class AuditableEntity : Entity
    {
        protected AuditableEntity() { }

        public AuditableEntity(Guid id, AuditData auditData) : base(id)
        {
            this.AuditData = auditData;
        }

        public virtual AuditData AuditData { get; set; }

        /// <summary>
        /// Sets the modification user and time in the audit data
        /// </summary>
        /// <param name="modifiedBy"></param>
        /// <param name="modifiedDate"></param>
        public virtual void SetAuditModified(string modifiedBy, DateTime modifiedDate)
        {
            Guard.That(modifiedBy).IsNotNullOrWhiteSpace();

            this.AuditData = new AuditData(
              this.AuditData.CreatedBy,
              this.AuditData.CreatedDate,
              modifiedBy,
              modifiedDate);
        }


        /// <summary>
        /// Sets the modification user in the audit data, sets the modification time to DateTime.Now
        /// </summary>
        /// <param name="modifiedBy">Usually set this param to this.GetCurrentUser()</param>
        public virtual void SetAuditModified(string modifiedBy)
        {
            this.SetAuditModified(modifiedBy, DateTime.Now);
        }
    }
}
