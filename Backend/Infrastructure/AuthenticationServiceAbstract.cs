using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public abstract class AuthenticationServiceAbstract : IAuthenticationService
    {
        protected IUserDataResolver userDataResolver;

        protected AuthenticationServiceAbstract(IUserDataResolver userDataResolver)
        {
            this.userDataResolver = userDataResolver;
        }

        public string GetCurrentUser()
        {
            return userDataResolver.GetCurrentUser();
        }

        public Guid GetCurrentUserId()
        {
            return userDataResolver.GetCurrentUserId();
        }

        public abstract void SetUserContext(Guid userId, string userName);

        public abstract void SetUserContext(string userName);
    }
}
