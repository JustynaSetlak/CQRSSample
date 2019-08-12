using CQRSSample.Common.Configuration;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace CQRSSample.Api.Config
{
    public class DatabaseConfigurationService : IDatabaseConfigurationService
    {
        private readonly IDocumentClient _documentClient;
        private readonly StoreDatabaseConfiguration _storeDatabaseConfiguration;

        public DatabaseConfigurationService(IDocumentClient documentClient, IOptions<StoreDatabaseConfiguration> storeDatabaseConfiguration)
        {
            _documentClient = documentClient;
            _storeDatabaseConfiguration = storeDatabaseConfiguration.Value;
        }

        public async Task CreateDatabaseIfNotExist()
        {
            await _documentClient.CreateDatabaseIfNotExistsAsync(new Database { Id = _storeDatabaseConfiguration.DatabaseName });
            await _documentClient.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(_storeDatabaseConfiguration.DatabaseName), new DocumentCollection { Id = Domain.Product.Constans.DatabaseConstans.ProductCollection });
        }
    }
}
