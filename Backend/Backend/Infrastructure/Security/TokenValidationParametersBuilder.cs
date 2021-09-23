using BarsGroup.CodeGuard;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Security
{
    internal class TokenValidationParametersBuilder
    {
        internal TokenValidationParameters Build(string key)
        {
            Guard.That(key).IsNotNullOrWhiteSpace();
            // Add JWT Auth
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = "Backend",

                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = "Backend",

                // Validate the token expiry
                ValidateLifetime = true,

                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero
            };

            return tokenValidationParameters;
        }
    }
}
