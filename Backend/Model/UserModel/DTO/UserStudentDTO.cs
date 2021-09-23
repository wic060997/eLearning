using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UserModel.DTO
{
    public class UserStudentDTO
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string ImieNazwisko { get; set; }
        public string Email { get; set; }
        public int NrIndex { get; set; }
    }
}
