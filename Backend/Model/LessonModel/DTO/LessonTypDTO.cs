using Model.GroupSModel.DTO;
using Model.SubjectModel.DTO;
using Model.TeacherModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LessonModel.DTO
{
    public class LessonTypDTO
    {
        public Guid Id { get; set; }
        public GroupSDTO GroupS { get; set; }
        public TeacherDTO Teacher { get; set; }
        public SubjectDTO Subject { get; set; }
        public string TypLesson { get; set; }
        public int Time { get; set; }
    }
}
