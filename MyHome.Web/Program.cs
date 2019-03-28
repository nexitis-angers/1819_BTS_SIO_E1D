using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyHome.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration(SetupConfiguration);

        private static void SetupConfiguration(WebHostBuilderContext context, IConfigurationBuilder configurationBuilder)
        {
            // .SetBasePath(environment.ContentRootPath) indique qu'on ira chercher les fichiers de configuration à la racine du site web
            // .AddJsonFile(nomFichier) indique à ASP.Net d'aller chercher le fichier de configuration propre à l'environnement actuel (ici Development)
            //  -   optional:false, indique la présence obligatoire du fichier
            //  -   reloadOnChange:true, indique à ASPNET de relancer le site web en cas de modif.

            var environment = context.HostingEnvironment;
            configurationBuilder.SetBasePath(environment.ContentRootPath)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", 
                optional: false, reloadOnChange: true);
        }
    }
}
