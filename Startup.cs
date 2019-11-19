using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shared.TaskApi.Services.Tasks;
using HibernatingRhinos.Profiler.Appender.EntityFramework;
using Shared.TaskApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.TaskApi.Settings;
using Microsoft.AspNetCore.Server.IISIntegration;
using ErnestoWebApi.Configs;

namespace Shared.TaskApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var settingssection = Configuration.GetSection("Settings");
            var settings = settingssection.Get<SiteSettings>();
            services.Configure<SiteSettings>(settingssection);
            services.AddDbContext<RsuiDbContext>(options => options.UseSqlServer(settings.RsuiDbConnectionString));
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<TaskDataRetriever>();
            services.AddTransient<StackDataRetriever>();
            services.AddCustomAuthentication();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                EntityFrameworkProfiler.Initialize();
            }
            app.UseAuthentication();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
