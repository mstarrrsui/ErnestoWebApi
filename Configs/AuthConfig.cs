using ErnestoWebApi.Factories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.DependencyInjection;

namespace ErnestoWebApi.Configs
{
    public static class AuthConfig
    {
        public static void AddCustomAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            var builder = services.AddAuthentication(options => 
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });
            builder.AddJwtBearer(options => TokenFactory.ValidateJwtToken(options));
        }
    }
}