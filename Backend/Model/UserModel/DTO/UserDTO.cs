using Model.GroupSModel.DTO;
using Model.SchoolModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UserModel.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string ImieNazwisko { get; set; }
        public bool CzyAktywny { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public RolaDTO Rola { get; set; }
        public SchoolDTO School { get; set; }
        public int NrIndex { get; set; }
        public string Image { get; set; }
        public GroupSDTO GroupS { get; set; }

        public object Clone()
        {
            UserDTO copy = (UserDTO)this.MemberwiseClone();
            return copy;
        }
    }
}
