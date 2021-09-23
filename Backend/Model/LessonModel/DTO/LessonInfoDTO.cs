using Model.GroupSModel.DTO;
using Model.TeacherModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LessonModel.DTO
{
    public class LessonInfoDTO
    {
        public Guid id { get; set; }
        public TeacherInfoDTO Teacher { get; set; }
        public int Time { get; set; }
        public GroupStaticDTO GroupStatic { get; set; }
    }
}
