using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Security
{
    public class SecurityHelper
    {
        public static string GetCurrentUser(HttpContext httpContext)
        {
            var nameIdentifierClaim = httpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (nameIdentifierClaim != null)
                return nameIdentifierClaim;

#if DEBUG
            return "Anonymous";
#endif
            return null;
        }
    }
}
