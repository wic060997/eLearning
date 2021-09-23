using Model.ClassesModel.DTO;
using Model.SubjectModel.DTO;
using Model.TeacherModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LessonModel.DTO
{
    public class AllLesson
    {
        public Guid Id { get; set; }
        public string Typ { get; set; }
        public int Time { get; set; }
        public SubjectStudentDTO SubjectStudent { get; set; }
        public TeacherInfoDTO UserTeacher { get; set; }
        public List<ClassesStaticDTO> classes { get; set; }
        
    }
}
