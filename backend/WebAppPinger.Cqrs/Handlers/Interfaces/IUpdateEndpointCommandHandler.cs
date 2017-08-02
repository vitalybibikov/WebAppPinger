using MediatR;
using WebAppPinger.Cqrs.Domain.Commands;
using WebAppPinger.Cqrs.Domain.Results;

namespace WebAppPinger.Cqrs.Handlers.Interfaces
{
    public interface IUpdateEndpointCommandHandler : IAsyncRequestHandler<UpdateEndpointCommand, CommandResult>
    {
    }
}