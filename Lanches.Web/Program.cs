using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lanches.Web.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lanches.Web {
    public class Program {
        public static void Main (string[] args) {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope ()) {
                var services = scope.ServiceProvider;
                try {
                    var serviceProvider = services.GetRequiredService<IServiceProvider> ();
                    var configuration = services.GetRequiredService<IConfiguration> ();
                    //chama o método para criar os perfis 
                    //e atribuir o perfil admin ao superusuario
                    SeedData.CreateRoles (serviceProvider, configuration).Wait ();
                } catch (Exception exception) {
                    var logger = services.GetRequiredService<ILogger<Program>> ();
                    logger.LogError (exception, "Ocorreu um erro na criação dos perfis dos usuários");
                }
            }
            host.Run ();
        }

        public static IWebHostBuilder CreateWebHostBuilder (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseStartup<Startup> ();
    }
}