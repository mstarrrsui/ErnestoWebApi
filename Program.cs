using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Hosting;
using Shared.TaskApi.Configs;

namespace Shared.TaskApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseEnvironment("Development")
            .ConfigureWebHostDefaults(webHost =>
            {
                webHost.UseHttpSys(options =>
                {
                    options.Authentication.AllowAnonymous = true;
                    options.Authentication.Schemes = AuthenticationSchemes.NTLM;
                    options.UrlPrefixes.Add("https://*:5001");
                });
                webHost.UseStartup<StartupConfig>();
            });
    }
}