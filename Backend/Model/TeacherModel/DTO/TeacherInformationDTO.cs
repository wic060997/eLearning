using Model.SubjectModel.DTO;
using Model.UserModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.TeacherModel.DTO
{
    public class TeacherInformationDTO
    {
        public Guid Id { get; set; }
        public string Specjalize { get; set; }
        public UserDTO User { get; set; }
        public List<SubjectStaticDTO> subject{get;set;}
    }
}
