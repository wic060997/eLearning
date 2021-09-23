using Model.LessonModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ClassesModel.DTO
{
    public class ClassesStudentDTO
    {
        public Guid Id { get; set; }
        public string Theme { get; set; }
        public DateTime DataClasses { get; set; }
        public LessonStudentDTO lessonStudent { get; set; }
    }
}
