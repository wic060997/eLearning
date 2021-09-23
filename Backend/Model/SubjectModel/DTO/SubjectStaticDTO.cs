using Model.LessonModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SubjectModel.DTO
{
    public class SubjectStaticDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TypeLessonStaticDTO> types { get; set; }
}
}
