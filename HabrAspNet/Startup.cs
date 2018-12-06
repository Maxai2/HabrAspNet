using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabrAspNet.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HabrAspNet
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<HabrContext>(options =>
            {
                string connStr = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connStr);
                options.UseLazyLoadingProxies();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("HTTP ERROR 404: NOT FOUND!");
            });
        }
    }
}
