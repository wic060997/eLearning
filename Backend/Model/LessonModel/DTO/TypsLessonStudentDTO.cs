using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LessonModel.DTO
{
   public  class TypsLessonStudentDTO
    {
        public string Name { get; set; }
        public List<LessonTypsDTO> lessonTyps { get; set; }
    }
}
