using Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Security
{
    public class HttpContextUserDataResolver : IUserDataResolver
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public HttpContextUserDataResolver(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUser()
        {
            return SecurityHelper.GetCurrentUser(this.httpContextAccessor.HttpContext);
        }

        public Guid GetCurrentUserId()
        {
            return UserHelper.GetCurrentUserId(this.httpContextAccessor.HttpContext);
        }
    }
}
