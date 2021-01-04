using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoursAspNETCORE
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
            services.AddControllersWithViews();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
               

                endpoints.MapControllerRoute("Home", "accueil", 
                    new { controller = "Home", action = "index" });

                endpoints.MapControllerRoute("HomeContact", "Accueil-contact",
                    new { controller = "Contact", action = "Index" });

                endpoints.MapControllerRoute("DetailContact", "Detail-contact/{id}",
                    new { controller = "Contact", action = "Detail" });

                endpoints.MapControllerRoute("FormContact", "formulaire-contact",
                    new { controller = "Contact", action = "Form" });

                endpoints.MapControllerRoute("SearchContact", "Recherche-contact",
                    new { controller = "Contact", action = "Search" });
                
                endpoints.MapControllerRoute("getdataFromGet", "personne/{nom}/{prenom}",
                   new { controller = "First", action = "ActionGetDataFromGet" });

                endpoints.MapControllerRoute("default", "{controller}/{action}/{id?}",
                   new { controller = "Home", action = "Index" });
            });
        }
    }
}
