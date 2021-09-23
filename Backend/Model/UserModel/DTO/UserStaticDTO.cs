using Model.GroupSModel.DTO;
using Model.SubjectModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UserModel.DTO
{
    public class UserStaticDTO
    {
        public Guid Id { get; set; }
        public string ImieNazwisko { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public RolaDTO Rola { get; set; }

        public int NrIndex { get; set; }
        public GroupSDTO Group { get; set; }

        public string Specjalize { get; set; }
        public List<SubjectStaticDTO> SubjectStatic { get; set; } 
    }
}
