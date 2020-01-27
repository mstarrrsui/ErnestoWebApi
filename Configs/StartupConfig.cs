using AutoMapper;
using HibernatingRhinos.Profiler.Appender.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.TaskApi.Data.Contexts;
using Shared.TaskApi.Services.Tasks;
using Shared.TaskApi.Settings;


namespace Shared.TaskApi.Configs
{
    public class StartupConfig
    {
        public StartupConfig(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var settingssection = Configuration.GetSection("Settings");
            var settings = settingssection.Get<SiteSettings>();
            services.Configure<SiteSettings>(settingssection);
            services.AddDbContext<RsuiDbContext>(options => options.UseSqlServer(settings.RsuiDbConnectionString));
            services.AddAutoMapper(typeof(StartupConfig));
            services.AddTransient<TaskDataRetriever>();
            services.AddTransient<StackDataRetriever>();
            services.AddAuthentication(settings);
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                EntityFrameworkProfiler.Initialize();
            }
            app.UseCors(options => {});
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endPoints => endPoints.MapControllers());
        }
    }
}
