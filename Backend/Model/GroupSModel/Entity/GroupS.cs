using Infrastructure;
using Model.SchoolModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GroupSModel.Entity
{
    public class GroupS: AuditableEntity
    {
        public GroupS() : base() { }

        public GroupS(Guid id, int year,int semester,string direction,string specjalize,School school, AuditData auditData)
            : base(id, auditData)
        {
            this.Year = year;
            this.Semester = semester;
            this.Direction = direction;
            this.Specjalize = specjalize;
            this.School = school;
            this.AuditData = auditData;
        }

        public virtual int Year { get; set; }
        public virtual int Semester { get; set; }
        public virtual string Direction { get; set; }
        public virtual string Specjalize { get; set; }
        public virtual School School { get; set; }

    }
}
