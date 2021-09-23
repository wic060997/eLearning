using Model.SchoolModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SubjectModel.DTO
{
    public class SubjectDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public SchoolDTO School { get; set; }
    }
}
