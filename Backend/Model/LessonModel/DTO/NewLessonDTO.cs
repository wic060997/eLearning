using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LessonModel.DTO
{
    public class NewLessonDTO
    {
        public Guid Subject { get; set; }
        public int Typ { get; set; }
        public Guid Teacher { get; set; }
        public Guid Group { get; set; }
        public int  Time { get; set; }
    }
}
