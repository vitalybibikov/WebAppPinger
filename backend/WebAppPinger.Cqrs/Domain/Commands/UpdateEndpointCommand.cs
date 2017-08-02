using System;
using MediatR;
using WebAppPinger.Cqrs.Domain.Results;

namespace WebAppPinger.Cqrs.Domain.Commands
{
    public class UpdateEndpointCommand : IRequest<CommandResult>
    {
        public DateTime LastPinged { get; set; }

        public string Url { get; set; }
    }
}
