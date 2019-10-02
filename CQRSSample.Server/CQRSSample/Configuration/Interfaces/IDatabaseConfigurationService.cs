using System.Threading.Tasks;

namespace CQRSSample.Api.Config
{
    public interface IDatabaseConfigurationService
    {
        Task CreateDatabaseIfNotExist();
    }
}
