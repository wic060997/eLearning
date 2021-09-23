using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.MaterialModel.DTO
{
    public class MaterialFileDTO
    {
        public Guid Id { get; set; }
        public string DataActive { get; set; }
        public string Localization { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
