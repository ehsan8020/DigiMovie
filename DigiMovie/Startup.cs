using DigiMovie.Areas.Identity.Helpers;
using DigiMovie.Data;
using DigiMovie.Helpers;
using DigiMovie.Services.Email;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DigiMovie
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

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DGMCS")));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DGMCSServer")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddErrorDescriber<PersianIdentityErrorDescriber>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services
                .AddAuthentication()
                .AddGoogle(googleConfig =>
                {
                    googleConfig.ClientId = "412203041073-ua084neeengg1frs7oslgrc76irmaibk.apps.googleusercontent.com";
                    googleConfig.ClientSecret = "SHOVDbqacELs8k9DAH-yICDS";
                });
                

            services.Configure<IdentityOptions>(options => {
                //options.User.AllowedUserNameCharacters = "";

                //options.Password.RequireDigit = false;

                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(1);

                options.SignIn.RequireConfirmedEmail = true;
            });

            services.ConfigureApplicationCookie(options => {

                //options.ExpireTimeSpan = TimeSpan.FromDays(7);
                //options.SlidingExpiration = true;
                //options.LoginPath = "";
                //options.LogoutPath = "";
                //options.AccessDeniedPath = "";

            });

            //DI Services
            services.AddTransient<IFileManager, FileManager>();

            //services.AddTransient<IEmailSender, EmailSender>();

            services.AddTransient<ISiteEmailSender, SiteEmailSender>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
    }
}