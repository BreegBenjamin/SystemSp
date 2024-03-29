using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SystemSp.Core.Interfaces;
using SystemSp.Infrastructure.AzureBlob;
using SystemSp.Infrastructure.Data;
using SystemSp.Infrastructure.Repositories;
using Microsoft.Extensions.Azure;
using Azure.Storage.Queues;
using Azure.Storage.Blobs;
using Azure.Core.Extensions;
using System;

namespace SystemSP.WebService
{
    public class Startup
    {
        private readonly string _myCors = "MyCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy(name: _myCors, builder =>
                {
                    builder.WithOrigins("*");
                    builder.WithHeaders("*");
                    builder.WithMethods("*");
                });
            });
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddControllers();
            services.AddTransient<ISystemSPConecction, SqlServerAppImplementation>();
            //instancia del azure blob.
            services.AddTransient<ISystemSpAzureBlob>(opt=> new SetCloudStorageComunication(Configuration.GetConnectionString("azureBlob")));
            services.AddDbContext<SystemSpContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SystemSP"));
            });
            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration["ConnectionStrings:azureBlob:blob"], preferMsi: true);
                builder.AddQueueServiceClient(Configuration["ConnectionStrings:azureBlob:queue"], preferMsi: true);
            });
            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration["ConnectionStrings:azureBlob:blob"], preferMsi: true);
                builder.AddQueueServiceClient(Configuration["ConnectionStrings:azureBlob:queue"], preferMsi: true);
            });
            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration["ConnectionStrings:azureBlob:blob"], preferMsi: true);
                builder.AddQueueServiceClient(Configuration["ConnectionStrings:azureBlob:queue"], preferMsi: true);
            });
            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration["ConnectionStrings:azureBlob:blob"], preferMsi: true);
                builder.AddQueueServiceClient(Configuration["ConnectionStrings:azureBlob:queue"], preferMsi: true);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(_myCors);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToFile("_Host.cshtml");
            });
        }
    }
    internal static class StartupExtensions
    {
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddBlobServiceClient(serviceUri);
            }
            else
            {
                return builder.AddBlobServiceClient(serviceUriOrConnectionString);
            }
        }
        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddQueueServiceClient(serviceUri);
            }
            else
            {
                return builder.AddQueueServiceClient(serviceUriOrConnectionString);
            }
        }
    }
}
