using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;
using Shared.TaskApi.Configs;

namespace Shared.TaskApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseEnvironment("Development")
                .UseHttpSys(options => 
                {
                    options.Authentication.AllowAnonymous = true;
                    options.Authentication.Schemes = AuthenticationSchemes.NTLM;
                    options.UrlPrefixes.Add("https://*:5001");
                })
                .UseStartup<StartupConfig>();
    }
}
