using Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Security
{
    public class RestAuthenticationService : AuthenticationServiceAbstract
    {
        public RestAuthenticationService(IHttpContextAccessor httpContextAccessor) : base(new HttpContextUserDataResolver(httpContextAccessor))
        {
        }

        public override void SetUserContext(string userName)
        {
            userDataResolver = new StaticUserDataResolver(userName);
        }

        public override void SetUserContext(Guid userId, string userName)
        {
            userDataResolver = new StaticUserDataResolver(userId, userName);
        }

    }
}
