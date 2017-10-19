using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyToDoList.Middleware;
using MyToDoList.Services;
using MyToDoList.DbContexts;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MyToDoList
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<MyToDoListDbContext>(options =>
                                                            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDutyRepository,DutyRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDbContextService,DbContextService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseNodeModules(env.ContentRootPath);
            app.UseMvcWithDefaultRoute();
        }
    }
}
