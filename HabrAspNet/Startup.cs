using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabrAspNet.Models;
using HabrAspNet.Services;
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

            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();

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

            app.UseStaticFiles();

            app.UseMvc(routeBuider =>
            {
                routeBuider.MapRoute(
                    name: "posts",
                    template: "/",
                    defaults: new
                    {
                        controller = "Post",
                        action = "All"
                    });

                routeBuider.MapRoute(
                    name: "getpost",
                    template: "posts/{id:int}",
                    defaults: new
                    {
                        controller = "Post",
                        action = "GetPost"
                    });

                routeBuider.MapRoute(
                    name: "users",
                    template: "users/{id:int}",
                    defaults: new
                    {
                        controller = "User",
                        action = "GetUser"
                    });

                routeBuider.MapRoute(
                    name: "signin",
                    template: "signin",
                    defaults: new
                    {
                        controller = "User",
                        action = "Authorization"
                    });

                routeBuider.MapRoute(
                    name: "me",
                    template: "me",
                    defaults: new
                    {
                        controller = "User",
                        action = "CurrentUser"
                    });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("HTTP ERROR 404: NOT FOUND!");
            });
        }
    }
}
