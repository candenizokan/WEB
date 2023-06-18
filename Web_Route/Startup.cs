using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Route
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
                //varsayılan route
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //static route
                endpoints.MapControllerRoute(
                    name: "test",
                    pattern: "test",
                    defaults: new {Controller="Home",Action="Test"});

                //dynamic route

                endpoints.MapControllerRoute(
                    name: "dinamic",
                    pattern: "{controller=Kategori}/{action=Detay}/{name}/{id}");

                //olası bir hata durumunda: az/çok parametreli bir durum yada elimizde olmayan bir kontola gitme isteği vb.. gibi durumlarda geçersiz bir adresle karşılaştığımızı yönlendirelecek bir action ve view oluşturabiliriz.
                endpoints.MapControllerRoute(
                    name: "found",
                    pattern: "url",
                    defaults: new { Controller = "Home", Action = "NotFound" });

            });
        }
    }
}
