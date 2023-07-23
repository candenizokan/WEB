using CoreCrud.Infrastructure.Concrete;
using CoreCrud.Infrastructure.Interfaces.Concrete;
using CoreCrud.Models.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud
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

            services.AddDbContext<ProjectContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("Default"));
                opt.UseLazyLoadingProxies(true);
            });

            //ben senden IDirector dediğimde DirectorRepo ver

            services.AddScoped<IDirector, DirectorRepo>();            

            services.AddScoped<IActorRepo, ActorRepo>();

            services.AddScoped<IMovieRepo, MovieRepo>();

            //Todo : addscoped - addtransiet - addsingleton araştır

            //services.AddSingleton nesneyi bir kere oluşturayım sonsuz kullanayım. DirectorRepo yu bir kere oluşturayım her seslenildiğinde kullanayım. program olutuğunda istediği zaman vereyim. Özetle her istenen nesneden bir kez oluşturur ve çağrıldığun hep aynı nesneyi verir.

            //services.AddTransient => geçici. her istekte bulunduğunda nesneyi oluşturur ve sonrasında dispose eder. her talepte yeni nesne oluşturur

            //services.AddScoped => her istek geldiğinde nesneyi oluşturur ANCAK transietten farklı olarak hala nesne kullanımdayken yeni bir talep gelirse nesne oluşturmaz elindeki kullandırır.

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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
