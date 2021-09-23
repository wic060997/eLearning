using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Security
{
    public class TokenProviderOptions
    {
        public HashSet<string> Paths { get; set; } = new HashSet<string>(StringComparer.Ordinal) { "/token" };

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public bool IsExpired { get; set; } = false;

        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(60);

        public SigningCredentials SigningCredentials { get; set; }
    }
}
