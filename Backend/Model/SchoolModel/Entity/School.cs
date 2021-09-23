using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SchoolModel.Entity
{
    public class School: AuditableEntity
    {
        public School() : base() { }

        public School(Guid id, string name, AuditData auditData)
            : base(id, auditData)
        {
            this.Id = id;
            this.Name = name;
            this.AuditData = auditData;
        }

        public School(Guid id, string name,string logo, AuditData auditData)
            : base(id, auditData)
        {
            this.Id = id;
            this.Name = name;
            this.Logo = logo;
            this.AuditData = auditData;
        }

        public virtual string Name { get; set; }
        public virtual string Logo { get; set; }
    }
}
