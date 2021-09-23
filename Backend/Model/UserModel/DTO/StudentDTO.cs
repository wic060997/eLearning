using Model.GroupSModel.DTO;
using Model.MaterialModel.DTO;
using Model.SchoolModel.DTO;
using Model.SubjectModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UserModel.DTO
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string ImieNazwisko { get; set; }
        public string Email { get; set; }
        public int NrIndex { get; set; }

        public SchoolDTO School { get; set; }

        public GroupStaticDTO Group { get; set; }

        public List<SubjectTypStudentDTO> Subject { get; set; }

        public List<MaterialStudentDTO> Materials { get; set; }
    }
}
