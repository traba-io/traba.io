using System;
using Domain.Entity;
using Domain.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using Repository.Interface;
using Repository.Service;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IWebHostEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();
        }

        private IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TrabaIoContext>(options =>
            {
                options
                    .UseLazyLoadingProxies()
                    .UseNpgsql(EnvironmentVariables.MainConnectionString ?? Configuration.GetConnectionString("MainConnectionString"));
            });
            
            services.AddIdentity<User, IdentityRole>(opts => { opts.SignIn.RequireConfirmedEmail = true; })
                .AddEntityFrameworkStores<TrabaIoContext>().AddDefaultTokenProviders();
            
            services.AddScoped<IJobOpportunityService, JobOpportunityService>();
            services.AddScoped<ICompanyService, CompanyService>();
            
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });
            
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/conta/entrar";
                options.SlidingExpiration = true;
            });

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc(opts =>
            {
                opts.MapAreaRoute(name: "Partners", areaName: "Partners",
                    template: "parceiros/{controller=Home}/{action=Index}/{id?}");
                opts.MapAreaRoute(name: "Admin", areaName: "Admin",
                    template: "admin/{controller=Home}/{action=Index}/{id?}");
                opts.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}