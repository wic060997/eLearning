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
    public class LessonFileDTO
    {
        public Guid Id { get; set; }
        public TeacherInfoDTO teacherInfo { get; set; }
        public SubjectStudentDTO subjectStudent { get; set; }
        public string typLesson { get; set; }
        public int time { get; set; }
        public List<ClassesFileDTO> classes { get; set; }
    }
}
