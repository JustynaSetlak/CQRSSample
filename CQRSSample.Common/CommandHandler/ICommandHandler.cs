using CQRSSample.Common.Command;
using System.Threading.Tasks;

namespace CQRSSample.Common.Handler
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
