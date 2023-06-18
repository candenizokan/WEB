using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Intro
{
    public class Program
    {
        /*
            Programımızı default olarak ayağa kaldıran çalışan ilk metod MAIN metoddur.
        .NETCORE ile birlikte web uygulamaları artık her platformda çalışır hale geldi.
        Bu nedenle hangi ortamda çalışmak istersek buradaki CreateHostBuilder() metodunu düzenleyerek farklı server uygulamamızı ayağ kaldırabiliriz. Default olarak ISS (Internet Information Server) üzerinden çalışır.

         */
        public static void Main(string[] args)
        {
            //MAIN içindeki bu metod sayesinde string argumanları alarak komutları çalıştırır.
            CreateHostBuilder(args).Build().Run();
        }

        //CreateHostBuilder() metoduna bakıldığında ise yapacağı işlemleri, okuyacağı konfigurasyonlar için starup sınıfına gider ve orada kullanılan Configure ve ConfigureServices metodlarındaki ayarları okuyarak uygulamayı ayağa kaldırı. build edilir ce çalıştırılır MAIN içinde

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
