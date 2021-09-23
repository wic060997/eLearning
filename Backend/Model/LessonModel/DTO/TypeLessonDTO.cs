using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LessonModel.DTO
{
    public class TypeLessonDTO
    {
        public string Name { get; set; }
        public List<LessonInfoDTO> LessonInfo { get; set; }
    }
}
