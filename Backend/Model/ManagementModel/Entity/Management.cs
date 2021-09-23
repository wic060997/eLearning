using Infrastructure;
using Model.UserModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ManagementModel.Entity
{
    public class Management: AuditableEntity
    {
        public Management() : base() { }

        public Management(Guid id, Users u, AuditData auditData)
            : base(id, auditData)
        {
            this.user = u;
            this.AuditData = auditData;
        }
        public virtual Users user { get; set; }
    }
}
