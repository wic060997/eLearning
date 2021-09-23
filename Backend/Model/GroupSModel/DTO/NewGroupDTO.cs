using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.GroupSModel.DTO
{
    public class NewGroupDTO
    {
        public int Year { get; set; }
        public int Semester { get; set; }
        public string Direction { get; set; }
        public string Specjalize { get; set; }
        public Guid school { get; set; }
    }
}
