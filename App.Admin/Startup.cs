using App.Infrastructure.CrossCutting.Identity.Authorization;
using App.Infrastructure.CrossCutting.Identity.Data;
using App.Infrastructure.CrossCutting.Identity.Models;
using App.Infrastructure.CrossCutting.IoC;
using App.Admin.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace App.Admin
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

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                            .AddCookie(o =>
                            {
                                o.LoginPath = new PathString("/login");
                                o.AccessDeniedPath = new PathString("/home/access-denied");
                            })
                            .AddFacebook(o =>
                            {
                                o.AppId = Configuration["Authentication:Facebook:AppId"];
                                o.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                            })
                            .AddGoogle(googleOptions =>
                            {
                                googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                                googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAutoMapperSetup();

            services.AddMvc(options =>
                options.EnableEndpointRouting = false
            )
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanWriteCategoryData", policy => policy.Requirements.Add(new ClaimRequirement("Seller", "Write")));
                options.AddPolicy("CanRemoveCategoryData", policy => policy.Requirements.Add(new ClaimRequirement("Seller", "Remove")));
            });

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseDatabaseErrorPage();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
            ShopNativeInjectorBootStrapper.RegisterShopServices(services);
        }
    }
}
