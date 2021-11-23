using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Asignar aqui la cadena de conexion al motor de base de datos Sql Server
            Models.RealDBContext.ConnectionString = "Data Source=SERVIDOR;Initial Catalog=BASE_DATOS;Persist Security Info=True;User ID=USUARIO;Password=PASSWORD;Connection timeout=7200;";

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


}
}
