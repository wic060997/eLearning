using Model.UserModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.TeacherModel.DTO
{
    public class TeacherInfoDTO
    {
        public Guid Id { get; set; }
        public UserTeacherDTO user { get; set; }
        public string Specjalize { get; set; }
    }
}
