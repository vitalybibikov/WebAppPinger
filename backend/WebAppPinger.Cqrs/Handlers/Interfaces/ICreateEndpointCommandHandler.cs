using System;
using MediatR;
using WebAppPinger.Cqrs.Domain.Commands;
using WebAppPinger.Cqrs.Domain.Results;

namespace WebAppPinger.Cqrs.Handlers.Interfaces
{
    public interface ICreateEndpointCommandHandler : IAsyncRequestHandler<CreateEndpointCommand, CommandResult>
    {
    }
}