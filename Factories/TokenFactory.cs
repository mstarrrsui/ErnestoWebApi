using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ErnestoWebApi.Factories
{
    public static class TokenFactory
    {
        public static string CreateJwtToken(string userName, params Claim[] claims)
        {
            var guid = System.Guid.NewGuid().ToString("N");

            // claims
            var securityclaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, guid),
                new Claim(JwtRegisteredClaimNames.UniqueName, userName),
            };
            // custom claims
            claims?.ToList().ForEach(securityclaims.Add);

            // security key
            var securitykey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("0a2d3e8dcae64b6e90da44c017c81096f8acbbd5e4b14ff79ee1197f80c64c23ccd6b79eeacb430f9b294813a6cfcdb2457bc6af89e8453e8d449c16667ff54f"));
            // security creds (uses key)
            var securitycreds = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            // security token (uses credentials) // FIXME add more things to beef up this token so invalidation is more likely to occur
            var securitytoken = new JwtSecurityToken(
                claims: securityclaims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: securitycreds
            );
            // token handler
            var tokenhandler = new JwtSecurityTokenHandler();
            // token
            var token = tokenhandler.WriteToken(securitytoken);
            return token;
        }

        public static void ValidateJwtToken(JwtBearerOptions options)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("0a2d3e8dcae64b6e90da44c017c81096f8acbbd5e4b14ff79ee1197f80c64c23ccd6b79eeacb430f9b294813a6cfcdb2457bc6af89e8453e8d449c16667ff54f"));
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                // FIXME this token is almost wide open, lock it down now that we have a simple working example
                IssuerSigningKey = securitykey,
                ValidateAudience = false,
                ValidateIssuer = false
            };
        }
    }
}