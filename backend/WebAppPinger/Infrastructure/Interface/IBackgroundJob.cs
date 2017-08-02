using System.Threading.Tasks;
using WebAppPinger.Cqrs.Domain.Results;

namespace WebAppPinger.Infrastructure.Interface
{
    public interface IBackgroundJob
    {
        Task<CommandResult> Execute();
    }
}
