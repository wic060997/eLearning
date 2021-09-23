using Model.SchoolModel.DTO;
using Model.UserModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Auth.Models
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public RolaDTO Rola { get; set; }
        public SchoolDTO School { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(UserDTO user, string token)
        {
            Id = user.Id;
            Login = user.Login;
            Rola = user.Rola;
            School = user.School;
            Token = token;
        }
    }
}
