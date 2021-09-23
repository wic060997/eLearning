using Infrastructure;
using Model.UserModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.TeacherModel.Entity
{
    public class Teacher: AuditableEntity
    {
        public Teacher() : base() { }

        public Teacher(Guid id, Users user, string specjalize, AuditData auditData)
            : base(id, auditData)
        {
            this.Users = user;
            this.Specjalize = specjalize;
            this.AuditData = auditData;
        }

        public virtual Users Users { get; set; }
        public virtual string Specjalize { get; set; }
    }
}
