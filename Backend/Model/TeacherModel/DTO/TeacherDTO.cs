using Model.UserModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.TeacherModel.DTO
{
    public class TeacherDTO
    {
        public Guid Id { get; set; }
        public UserDTO user { get; set; }
        public string Specjalize { get; set; }
    }
}
