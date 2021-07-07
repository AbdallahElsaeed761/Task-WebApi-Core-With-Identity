using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_WebApi_Core_With_Identity.Helper;
using Task_WebApi_Core_With_Identity.Interfaces;
using Task_WebApi_Core_With_Identity.Models;
using Task_WebApi_Core_With_Identity.Services;

namespace Task_WebApi_Core_With_Identity
{
    public class Startup
    {
        string MyAllowSpecificOrigins = "m";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(op =>
            {
                op.UseSqlServer(Configuration.GetConnectionString("myconnection"));
                // op.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("myconnection"));

            });

           
            //services.AddDbContext<DbContext>(options =>
            //       options.UseLazyLoadingProxies().UseSqlServer(
            //           Configuration.GetConnectionString("myconnection")));

            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<MyDbContext>();

           

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
                                                               Newtonsoft.Json.ReferenceLoopHandling.Ignore);




            //services.AddScoped<AuthenticationRep>();
            services.AddTransient<IBook, BookServices>();
           // services.AddScoped<ManageRole>();
            
            services.AddHttpClient();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task_WebApi_Core_With_Identity", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task_WebApi_Core_With_Identity v1"));
            }

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
