using Infrastructure;
using Model.LessonModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ClassesModel.Entity
{
    public class Classes: AuditableEntity
    {
        public Classes() : base() { }

        public Classes(Guid id,
            Lesson lesson,
            string theme,
            DateTime data,
            AuditData auditData)
            : base(id, auditData)
        {
            this.Lesson = lesson;
            this.Theme = theme;
            this.DataClasses = data;
            this.AuditData = auditData;
        }

        public virtual Lesson Lesson { get; set; }
        public virtual string Theme { get; set; }
        public virtual DateTime DataClasses { get; set; }
    }
}
