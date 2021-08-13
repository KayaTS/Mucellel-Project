using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using kayaseker.DAL.Entities;
using kayaseker.DAL.Contexts;
using kayaseker_BL.Repositories;


namespace kayaseker
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly IConfiguration configuration;

        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(Repository<>));
            services.AddControllersWithViews();
            //services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MyContext>();
            //services.AddSession();
            services.AddDbContext<MyContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyCon1")));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.AccessDeniedPath = "/yetkilendirme";
                options.LoginPath = "/giris";
                options.LogoutPath = "/cikis";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(ep => {
                ep.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                ep.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
