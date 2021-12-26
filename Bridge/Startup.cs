using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bridge.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Bridge.Core;
using System.IO;
using System.Diagnostics;
using Bridge.Core;

namespace Bridge
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
            Debug.WriteLine($"Connexion string : {AppSettings.ConnectionString}");
            services.AddControllersWithViews();

            services.AddDbContext<NorthwindContext>(options=>{
                options.UseSqlServer(Configuration.GetConnectionString("Northwind"));
            });

            services.AddTransient<IErrorLogger, TextFileErrorLogger>();
            services.AddTransient<IDataImporter, DataImporterBasic>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            AppSettings.ConnectionString = Configuration.GetConnectionString("Northwind");
            AppSettings.LogFileFolder = Path.Combine(env.WebRootPath, "ErrorLogs");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
