using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Model.InfrastructureModel.Security
{
    public interface IClaimsService
    {
        ClaimsIdentity GetIdentity(string username, string password);
    }
}
