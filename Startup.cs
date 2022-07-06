using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_EF.DataAccessLayer_EF;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebApp_EF.Repository;
namespace WebApp_EF
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
            services.AddControllersWithViews();
         //   services.AddMvc();
           // services.AddMvcCore();

            services.AddDbContextPool<DataAccessLayer_LMS>(options => options.UseSqlServer(Configuration.GetConnectionString("MYConnection")));

            // services.AddDbContextPool<DataAccessLayer_LMS>(options => options.UseSqlServer("server=RAJEEV;database=LMS;uid=sa;pwd=Raj@123"));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1);

            });
            services.AddAutoMapper(typeof(Startup));
            //DI
            services.AddScoped<IUserModelRepo, UserModelRepo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
