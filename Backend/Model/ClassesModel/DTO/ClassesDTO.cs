using Model.LessonModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ClassesModel.DTO
{
    public class ClassesDTO
    {
        public Guid Id { get; set; }
        public LessonDTO Lesson { get; set; }
        public string Theme { get; set; }
        public DateTime DataClasses { get; set; }

    }
}
