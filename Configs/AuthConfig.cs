using Shared.TaskApi.Factories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.DependencyInjection;
using Shared.TaskApi.Settings;

namespace Shared.TaskApi.Configs
{
    public static class AuthConfig
    {
        public static void AddAuthentication(this IServiceCollection services, SiteSettings siteSettings)
        {
            services.AddAuthentication(HttpSysDefaults.AuthenticationScheme);
            var builder = services.AddAuthentication(options => 
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });
            builder.AddJwtBearer(options => TokenFactory.ValidateJwtToken(options));
        }
    }
}