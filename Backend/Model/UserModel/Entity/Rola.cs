using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UserModel.Entity
{
    public class Rola : AuditableEntity
    {
        public Rola() : base() { }

        public Rola(Guid id, string nazwa, AuditData auditData)
            : base(id, auditData)
        {
            this.Nazwa = nazwa;
            this.AuditData = auditData;
        }
        public virtual string Nazwa { get; set; }
    }
}
