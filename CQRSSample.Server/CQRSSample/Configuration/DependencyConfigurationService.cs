using CQRSSample.Common.Configuration;
using CQRSSample.Domain.Product.Interfaces;
using CQRSSample.Domain.Product.Repositories;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CQRSSample.Api.Config
{
    public static class DependencyConfigurationService
    {
        public static void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IDatabaseConfigurationService, DatabaseConfigurationService>();

            RegisterQueueClient(services, configuration);
            RegisterDatabaseClient(services, configuration);
        }

        private static void RegisterDatabaseClient(IServiceCollection services, IConfiguration configuration)
        {
            var storeDatabaseConfiguration = configuration
                .GetSection(nameof(StoreDatabaseConfiguration))
                .Get<StoreDatabaseConfiguration>();

            services.AddScoped<IDocumentClient>(x => new DocumentClient(new Uri(storeDatabaseConfiguration.Url), storeDatabaseConfiguration.Key));
        }

        private static void RegisterQueueClient(IServiceCollection services, IConfiguration configuration)
        {
            var queueConfiguration = configuration
                .GetSection(nameof(QueueConfiguration))
                .Get<QueueConfiguration>();

            services.AddSingleton<IMessageSender>(new MessageSender(queueConfiguration.ConnectionString, queueConfiguration.Name));
        }
    }
}
