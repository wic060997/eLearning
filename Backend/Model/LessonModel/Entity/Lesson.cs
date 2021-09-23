using Infrastructure;
using Model.GroupSModel.Entity;
using Model.SubjectModel.Entity;
using Model.TeacherModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LessonModel.Entity
{
    public class Lesson:AuditableEntity
    {
        public Lesson() : base() { }

        public Lesson(Guid id,
            GroupS group,
            Teacher teacher,
            Subject subject,
            int typ,
            int time,
            AuditData auditData)
            : base(id, auditData)
        {
            this.GroupS = group;
            this.Teacher = teacher;
            this.Subject = subject;
            this.TypLesson = typ;
            this.Time = time;
            this.AuditData = auditData;
        }
        public virtual GroupS GroupS { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual int TypLesson { get; set; }
        public virtual int Time { get; set; }
    }
}
