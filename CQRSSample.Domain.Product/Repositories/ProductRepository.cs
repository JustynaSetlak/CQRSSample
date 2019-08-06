using CQRSSample.Common.Configuration;
using CQRSSample.Domain.Product.Interfaces;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace CQRSSample.Domain.Product.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IDocumentClient _documentClient;
        private Uri _productDocumentCollectionFactory;

        public ProductRepository(IDocumentClient documentClient, IOptions<StoreDatabaseConfiguration> productDatabaseConfiguration)
        {
            _documentClient = documentClient;
            _productDocumentCollectionFactory = UriFactory.CreateDocumentCollectionUri(productDatabaseConfiguration.Value.DatabaseName, Constans.DatabaseConstans.ProductCollection);
        }
            
        public async Task<bool> CreateNewProduct(Models.Product product)
        {
            var result = await _documentClient.CreateDocumentAsync(_productDocumentCollectionFactory, product);

            return result.StatusCode == System.Net.HttpStatusCode.Created;
        }
    }
}
