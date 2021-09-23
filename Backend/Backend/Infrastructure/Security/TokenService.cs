using BarsGroup.CodeGuard;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Model.UserModel.Const;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Security
{
    public class TokenService
    {
        private readonly IConfiguration configuration;
        private readonly TokenProviderOptions options;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
            TokenValidationParameters tokenValidationParameters = new TokenValidationParametersBuilder().Build(configuration.GetSection("Security").GetValue<string>("Key"));
            tokenValidationParameters.ValidateLifetime = configuration.GetSection("Security").GetValue<bool>("EnableTokenExpiration", false);

            options = Options.Create(new TokenProviderOptions
            {
                Audience = tokenValidationParameters.ValidAudience,
                Issuer = tokenValidationParameters.ValidIssuer,
                SigningCredentials = new SigningCredentials(tokenValidationParameters.IssuerSigningKey, SecurityAlgorithms.HmacSha256),
                IsExpired = configuration.GetSection("Security").GetValue<bool>("EnableTokenExpiration", false),
                Expiration = TimeSpan.FromMinutes(configuration.GetSection("Security").GetValue<int>("TokenExpirationInMinutes", 60))
            }).Value;
        }

        public JwtSecurityToken ValidateToken(StringValues token, bool validateExpiration)
        {
            var validationBuilder = new TokenValidationParametersBuilder().Build(configuration.GetSection("Security").GetValue<string>("Key"));
            validationBuilder.ValidateLifetime = validateExpiration;
            var tokenStr = GetTokenStr(token);

            new JwtSecurityTokenHandler().ValidateToken(tokenStr, validationBuilder, out var validatedToken);

            if (validatedToken is JwtSecurityToken)
            {
                var jwtToken = validatedToken as JwtSecurityToken;
                if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");
                return jwtToken;
            }
            else
                throw new SecurityTokenException("Incorrect token type");
        }
        private string GetTokenStr(StringValues token)
        {
            if (token.Count != 1 || token[0].Length < 7)
                throw new Exception("Brak poprawnego tokena (1)");
            var tokenStr = token[0].Substring(7); //remove "Bearer " from the string
            return tokenStr;
        }

        public string GetUserName(JwtSecurityToken token)
        {
            Guard.That(token).IsNotNull();
            return token.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;
        }

        public string GetRolaName(JwtSecurityToken token)
        {
            Guard.That(token).IsNotNull();
            return token.Claims.First(c => c.Type == UserConsts.RolaName).Value;
        }

        public BackendTokenResponse SerializeToken(string username, ClaimsIdentity identity)
        {
            var newJwt = this.GetEncodedJwt(username, identity);
            var response = new BackendTokenResponse
            {
                Result = new BackendTokenResult
                {
                    AccessToken = newJwt,
                    ExpiresIn = configuration.GetSection("Security").GetValue<int>("TokenExpirationInMinutes", 60),
                },

            };
            return response;
        }
        private string GetEncodedJwt(string username, ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;

            var claims = new List<Claim> 
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            if (identity.Claims != null)
            {
                if (identity.Claims.Any(c => c.Type == UserConsts.UserId))
                    claims.Add(identity.Claims.First(c => c.Type == UserConsts.UserId));
                if (identity.Claims.Any(c => c.Type == UserConsts.UserFullName))
                    claims.Add(identity.Claims.First(c => c.Type == UserConsts.UserFullName));
                if (identity.Claims.Any(c => c.Type == UserConsts.RolaName))
                    claims.Add(identity.Claims.First(c => c.Type == UserConsts.RolaName));
            }

            JwtSecurityToken jwt = null;
            var expirationDate = options.IsExpired ? now.Add(options.Expiration) : now.Add(TimeSpan.FromDays(365));
            jwt = new JwtSecurityToken(
                issuer: options.Issuer,
                audience: options.Audience,
                claims: claims,
                notBefore: now,
                expires: expirationDate,
                signingCredentials: options.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}
