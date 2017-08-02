using System;
using WebAppPinger.Cqrs.Domain.Results;

namespace WebAppPinger.Infrastructure.Interface
{
    public interface IJobManager
    {
        CommandResult Start();
    }
}
