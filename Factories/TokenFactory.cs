using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ErnestoWebApi.Factories
{
    public static class TokenFactory
    {
        internal static string DefaultAudienceName {get; private set;} = "RSUI";
        internal static string DefaultIssuerName {get; private set;} = Environment.MachineName;


        public static string CreateJwtToken(string userName, ICollection<Claim> claims, out DateTime expires)
        {
            var guid = System.Guid.NewGuid().ToString("N");
            expires = DateTime.UtcNow.AddHours(1);

            // claims
            var securityclaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, guid),
                new Claim(JwtRegisteredClaimNames.UniqueName, userName),
            };
            claims?.ToList().ForEach(securityclaims.Add);

            var enctypedcertbytes = File.ReadAllBytes(@"\\rsuifs00\Department\Development\EVanRensburg\- Certificates\Other\2018 Through 2019\rsui.pfx");
            var encrypredcert = new X509Certificate2(enctypedcertbytes, "rsui");
            var encryptedcreds = new X509EncryptingCredentials(encrypredcert);
            var signingkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("0a2d3e8dcae64b6e90da44c017c81096f8acbbd5e4b14ff79ee1197f80c64c23ccd6b79eeacb430f9b294813a6cfcdb2457bc6af89e8453e8d449c16667ff54f"));
            var signingcreds = new SigningCredentials(signingkey, SecurityAlgorithms.HmacSha256);
            var signingtoken = new SecurityTokenDescriptor()
            {
                Audience = DefaultAudienceName,
                Issuer = DefaultIssuerName,
                Subject = new ClaimsIdentity(securityclaims),
                NotBefore = DateTime.UtcNow,
                Expires = expires,
                SigningCredentials = signingcreds,
                EncryptingCredentials = encryptedcreds
            };
            var tokenhandler = new JwtSecurityTokenHandler();
            var token = tokenhandler.CreateEncodedJwt(signingtoken);
            return token;
        }

        public static void ValidateJwtToken(JwtBearerOptions options)
        {
            var dencrypedcertbytes = File.ReadAllBytes(@"\\rsuifs00\Department\Development\EVanRensburg\- Certificates\Other\2018 Through 2019\rsui.pfx");
            var decryptedkey = new X509SecurityKey(new X509Certificate2(dencrypedcertbytes, "rsui"));
            var securitykey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("0a2d3e8dcae64b6e90da44c017c81096f8acbbd5e4b14ff79ee1197f80c64c23ccd6b79eeacb430f9b294813a6cfcdb2457bc6af89e8453e8d449c16667ff54f"));
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                RequireSignedTokens = false,
                IssuerSigningKey = securitykey,
                TokenDecryptionKey = decryptedkey,
                ValidateAudience = true,
                ValidAudience = DefaultAudienceName,
                ValidateIssuer = true,
                ValidIssuer = DefaultIssuerName,
                ValidateLifetime = true,
                LifetimeValidator = (DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters) => {
                    return DateTime.UtcNow >= notBefore && DateTime.UtcNow <= expires;
                }
            };
        }
    }
}