using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using SolarSystem_GRP5.DAL;
using SolarSystem_GRP5.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SolarSystem_GRP5
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
            //services.AddScoped<ILanguageService, LanguageService>();
            //services.AddScoped<ILocalizationService, LocalizationService>();
            services.AddSession();
            services.AddDistributedMemoryCache();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddLocalization();

            services.AddControllersWithViews().AddViewLocalization();

            DBManager dbContext = new DBManager(Configuration);
            //var serviceProvider = BuildServiceProvider(services);
            //var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            //var languages = languageService.GetLanguages();
            var languages = dbContext.GetLanguages();
            List<CultureInfo> cultures = new List<CultureInfo>();
            foreach (var lang in languages)
            {
                cultures.Add(new CultureInfo(lang.Culture));
            }

            services.Configure<RequestLocalizationOptions>(options =>
            {

                var englishCulture = cultures.FirstOrDefault(x => x.Name == "en-US");
                options.DefaultRequestCulture = new RequestCulture(englishCulture?.Name ?? "en-US");

                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
                Thread.CurrentThread.CurrentCulture = englishCulture;
                Thread.CurrentThread.CurrentUICulture = englishCulture;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseRequestLocalization();


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

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }


    }
}
