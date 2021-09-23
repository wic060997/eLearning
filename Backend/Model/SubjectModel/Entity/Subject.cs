using Infrastructure;
using Model.SchoolModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SubjectModel.Entity
{
    public class Subject: AuditableEntity
    {
        public virtual string Name { get; set; }
        public virtual School School { get; set; }

        public Subject() : base() { }

        public Subject(Guid id, string nazwa, School school, AuditData auditData)
            : base(id, auditData)
        {
            this.Name = nazwa;
            this.School = school;
            this.AuditData = auditData;
        }
    }
}
