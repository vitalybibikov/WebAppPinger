using MediatR;
using WebAppPinger.Cqrs.Domain.Results;

namespace WebAppPinger.Cqrs.Domain.Commands
{
    public class DeleteEndpointCommand : IRequest<CommandResult>
    {
        public string Url { get; set; }
    }
}
