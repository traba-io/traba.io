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

            app.UseAuthorization();

            app.UseMvc(opts =>
            {
                opts.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}