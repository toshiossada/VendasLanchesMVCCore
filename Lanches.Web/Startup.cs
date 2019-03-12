using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lanches.Web.Context;
using Lanches.Web.Models;
using Lanches.Web.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lanches.Web {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<AppDbContext> (options => options.UseSqlServer (Configuration.GetConnectionString ("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<ICategoriaRepository, CategoriaRepository> ();
            services.AddTransient<ILancheRepository, LancheRepository> ();
            services.AddTransient<IPedidoRepository, PedidoRepository> ();

            services.Configure<CookiePolicyOptions> (options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor> ();

            services.AddScoped (cp => CarrinhoCompra.GetCarrinho (cp));

            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

            services.AddMemoryCache ();

            services.AddSession ();
            services.ConfigureApplicationCookie(o => o.AccessDeniedPath = "/Home/AccessDenied");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();
            app.UseStaticFiles ();
            app.UseCookiePolicy ();

            app.UseSession ();
            app.UseAuthentication();

            app.UseMvc (routes => {

                routes.MapRoute("areaRoute", "{area:exists}/{Controller=Admin}/{Action=Index}/{id?}");
                
                routes.MapRoute (
                    name: "FiltrarPorCategoria",
                    template: "Lanche/{action}/{categoria}",
                    defaults : new { Controller = "Lanche", action = "List" }
                );

                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}