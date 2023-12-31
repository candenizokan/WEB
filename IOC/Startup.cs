﻿using IOC.Infrastructure.Repositories.Abstract;
using IOC.Infrastructure.Repositories.Concrete;
using IOC.Models;
using IOC.Models.Context;
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
using Unity;

namespace IOC
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

            //appstingde connectionstringim var.ismi Default olan cümleciğim var. 
            //bu db contexti ekle. dbcontexten kalıtım alan bir sınıfını ekle. ProjectContext db context sınıfıdır.
            //ProjectContext sınıfıma diyorumki options öyleki bu sql server metodunu kullan UseSqlServer. buda bağlantı cümleciği bekliyor. oda appsettingdeki default adındaki bağlantı cümleciğim. onu getir diyorum GetConnectionString. böylece ProjectContext sınıfına bağlıyorum. eskiden içinde yazıyorumdum şimdi startupda kod sabitlerimi yazıyorum.

            services.AddDbContext<ProjectContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Default")));
        }

        public void ConfigureContainer(IUnityContainer container)
        {
            //ben bu adamın soyut halini (IRepository<Category>) söyleyeceğim bana gerçek tipinden(CategoryRepository) ver diyorum
            container.RegisterType<IRepository<Category>, CategoryRepository>();//şimdi program.cs'e gidip Unity'i kullanmak için gerekli methodu yazacağım
            container.RegisterType<IRepository<Supplier>, SupplierRepository>();
            container.RegisterType<IRepository<Product>, ProductRepository>();
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
