using System.Threading.Tasks;
using WebAppPinger.Models;

namespace WebAppPinger.Infrastructure.Interface
{
    public interface IServiceRequester
    {
        Task FireAndForget(EndpointModel model);
    }
}
