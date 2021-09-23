using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.UserModel.Const;

namespace Backend.Infrastructure.Security
{
    public static class UserHelper
    {
        public static Guid GetCurrentUserId(HttpContext httpContext)
        {
            var userIdClaim = httpContext?.User.Claims.FirstOrDefault(c => c.Type == UserConsts.UserId).Value;
            if (userIdClaim != null)
                return new Guid(userIdClaim);
            return Guid.Empty;
        }
    }
}
