using Model.GroupSModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LessonModel.DTO
{
    public class LessonStaticDTO
    {
        public Guid Id { get; set; }
        public int Time { get; set; }
        public GroupStaticDTO GroupStatic { get; set; }
}
}
