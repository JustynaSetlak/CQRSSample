using System.Reflection;
using AutoMapper;
using CQRSSample.Api.Config;
using CQRSSample.CommandHandlers;
using CQRSSample.Common.Configuration;
using CQRSSample.Domain.Customer.EventHandlers;
using CQRSSample.Domain.Product.MappingProfiles;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSSample.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.Configure<StoreDatabaseConfiguration>(Configuration.GetSection(nameof(StoreDatabaseConfiguration)));
            services.AddOptions();
            DependencyConfigurationService.RegisterDependencies(services, Configuration);

            //tochange
            //services.AddAutoMapper(new[] { Assembly.GetExecutingAssembly(), typeof(ProductProfile).Assembly  });
            //services.AddMediatR(new[] { Assembly.GetExecutingAssembly(), typeof(CreateProductCommandHandler).Assembly, typeof(NewProductAddedEventHandler).Assembly});

            services.AddMvc();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDatabaseConfigurationService databaseConfigurationService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            databaseConfigurationService.CreateDatabaseIfNotExist().GetAwaiter().GetResult();

            app.UseMvc();
        }
    }
}
