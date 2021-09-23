using Model.TeacherModel.DTO;
using Model.UserModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LessonModel.DTO
{
    public class LessonTypsDTO
    { 
        public Guid Id { get; set; }
        public TeacherInfoDTO userTeacher { get; set; }
        public int Time { get; set; }
    }
}
