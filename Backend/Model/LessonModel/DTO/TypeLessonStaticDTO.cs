using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LessonModel.DTO
{
    public class TypeLessonStaticDTO
    {
        public string Name { get; set; }
        public List<LessonStaticDTO> LessonStatic { get; set; }
    }
}
