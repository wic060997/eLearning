using Model.MaterialModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ClassesModel.DTO
{
    public class ClassesFileDTO
    {
        public Guid Id { get; set; }
        public string Theme { get; set; }
        public string DataClasses { get; set; }
        public List<MaterialFileDTO> materials { get; set; }
    }
}
