using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SystemSp.Intellengece.WebServiceBusiness;
using SystemSP.Intelligence;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using System;
using SystemSp.DTOS.EntitisIndexApp;
using SystemSp.Intellengece.ApplicationBusiness;
using BlazorDownloadFile;
using Rotativa.AspNetCore;
using FluentValidation.AspNetCore;

namespace SystemSP
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
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<Lector>();
            services.AddSingleton<SendEMailUser>();
            services.AddSingleton<ValidarFormularios>();
            services.AddSingleton<SaveIFiles>();
            services.AddSingleton<UserInformationResult>();
            services.AddSingleton<UserSession>();
            services.AddSingleton<SetChangeLanguage>();
            services.AddBlazorDownloadFile();
            services.AddI18nText(opt=> opt.PersistanceLevel 
                                = Toolbelt.Blazor.I18nText.PersistanceLevel.SessionAndLocal );
            services.AddMvc().AddFluentValidation(options=> 
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
            services.AddHttpClient<ProjectsApplication>(client=> 
            {
                client.BaseAddress = new Uri("https://localhost:44395/");
            });
            services.AddApplicationInsightsTelemetry();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default",
                    pattern: "{controller}/{action}");
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
            RotativaConfiguration.Setup(env.WebRootPath.Replace("wwwroot","dlls"));
        }
    }
}
