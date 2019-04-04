using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyHome.Infrastructure;

namespace MyHome.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            #region Configuration Entity Framework
            // Projet dans lequel les migrations seront stockées
            var webHostAssembly = typeof(Startup).Assembly.GetName().Name;
            // Obtention de la chaine de connexion à la bdd
            var connectionString = Configuration.GetConnectionString("MyHomeDb");

            // Configuration du contexte de base de données<
            services.AddDbContext<MyHomeDbContext>(
                options => options.UseSqlServer(connectionString,
                    builder => builder.MigrationsAssembly(webHostAssembly)));
            #endregion

            #region Configuration de la gestion des sessions et de l'authentification
            // On indique ici que l'authentification sera gérée par un cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();
            app.UseAuthentication(); // Activation de l'authenfication

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
