using HolidayRental.Common;
using HoliDayRental.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });      //permet de configurer les sessions pour mon application

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();

            services.AddScoped<IAllRepositoryBASE<HolidayRental.DAL.Models.Membre>, HolidayRental.DAL.Repository.MembreServices>();
            services.AddScoped<IAllRepositoryBASE<HolidayRental.BLL.Models.Membre>, HolidayRental.BLL.Repository.MembreServices>();

            services.AddScoped<IAllRepositoryBIEN<HolidayRental.DAL.Models.BienEchange>, HolidayRental.DAL.Repository.BienEchangeServices>();
            services.AddScoped<IAllRepositoryBIEN<HolidayRental.BLL.Models.BienEchange>, HolidayRental.BLL.Repository.BienEchangeServices>();

            services.AddScoped<IAllRepositoryBASE<HolidayRental.DAL.Models.Pays>, HolidayRental.DAL.Repository.PaysServeces>();
            services.AddScoped<IAllRepositoryBASE<HolidayRental.BLL.Models.Pays>, HolidayRental.BLL.Repository.PaysServices>();

            services.AddScoped<IGetRepository<HolidayRental.DAL.Models.BienAvecNomPAYS>, HolidayRental.DAL.Repository.BienAvecNomPAYSservices>();
            services.AddScoped<IGetRepository<HolidayRental.BLL.Models.BienAvecNomPAYS>, HolidayRental.BLL.Repository.BienAvecNomPAYSservices>();

            services.AddScoped<IGetRepository<HolidayRental.DAL.Models.Options>, HolidayRental.DAL.Repository.OptionServices>();
            services.AddScoped<IGetRepository<HolidayRental.BLL.Models.Options>, HolidayRental.BLL.Repository.OptionsServices>();

            services.AddScoped<IGetRepositotyTwoInt<HolidayRental.DAL.Models.OptionsBien, int, int>, HolidayRental.DAL.Repository.OptionBienServices>();
            services.AddScoped<IGetRepositotyTwoInt<HolidayRental.BLL.Models.OptionsBien, int, int>, HolidayRental.BLL.Repository.OptionBienServices>();

            services.AddScoped<IRepoOptionsONEbien<HolidayRental.DAL.Models.OptionsBienWithLabel_forONEBien>, HolidayRental.DAL.Repository.OptionsBienWithLabel_forONEBienServices>();
            services.AddScoped<IRepoOptionsONEbien<HolidayRental.BLL.Models.OptionsBienWithLabel_forONEBien>, HolidayRental.BLL.Repository.OptionsBienWithLabel_forONEBienServices>();

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
            app.UseSession(); //Permet d'utiliser le middlewate session pour notre application
            app.UseStaticFiles();

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
