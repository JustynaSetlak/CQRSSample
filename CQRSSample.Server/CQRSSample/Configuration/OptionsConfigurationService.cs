using CQRSSample.Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSSample.Api.Configuration
{
    public static class OptionsConfigurationService
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<StoreDatabaseConfiguration>(configuration.GetSection(nameof(StoreDatabaseConfiguration)));
            services.Configure<CustomerNotificationConfiguration>(configuration.GetSection(nameof(CustomerNotificationConfiguration)));

            services.AddOptions();
        }
    }
}
