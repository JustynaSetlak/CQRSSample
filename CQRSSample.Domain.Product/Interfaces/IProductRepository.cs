using System.Threading.Tasks;

namespace CQRSSample.Domain.Product.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> CreateNewProduct(Models.Product product);
    }
}
