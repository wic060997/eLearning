using Model.SubjectModel.DTO;
using Model.TeacherModel.DTO;
using Model.UserModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LessonModel.DTO
{
    public class LessonStudentDTO
    {
        public Guid Id { get; set; }
        public TeacherInfoDTO UserTeacher { get; set; }
        public SubjectStudentDTO SubjectStudent { get; set; }
        public string Typ { get; set; }
        public int Time { get; set; }
    }
}
