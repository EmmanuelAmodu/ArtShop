﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emptProj.Data;
using emptProj.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace emptProj
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            this._config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EmptProjContext>(cfg => 
                cfg.UseSqlServer(_config.GetConnectionString("emptProjConnectionString")));

            services.AddTransient<EmptProjSeeder>();
            services.AddTransient<IMailService, NullMailService>();

            services.AddScoped<IEmptProjRepository, EmptProjRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else 
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();
            app.UseNodeModules(env);

            app.UseMvc(cfg => {
                cfg.MapRoute("Default", "/{controller}/{action}/{id?}", new {
                    controller = "App", 
                    Action = "Index"
                });
            });
        }
    }
}
