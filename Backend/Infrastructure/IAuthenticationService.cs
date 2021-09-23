using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IAuthenticationService
    {
        string GetCurrentUser();
        Guid GetCurrentUserId();
        void SetUserContext(string userName);
        void SetUserContext(Guid userId, string userName);
    }
}
