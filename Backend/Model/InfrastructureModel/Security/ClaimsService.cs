using Model.UserModel.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Model.InfrastructureModel.Security
{
    public class ClaimsService : IClaimsService
    {
        private readonly IUserService uzytkownikService;

        public ClaimsService(IUserService uzytkownikService)
        {
            this.uzytkownikService = uzytkownikService;
        }

        public ClaimsIdentity GetIdentity(string username, string password)
        {
            var claimsIdentity = uzytkownikService.Login(username, password);
            if (claimsIdentity != null)
            {
                return claimsIdentity;
            }

            return null;
        }
    }
}
