using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using WebAppPinger.Cqrs.Domain.Results;

namespace WebAppPinger.Cqrs.Domain.Commands
{
    public class CreateEndpointCommand : IRequest<CommandResult>
    {
        public string Url { get; set; }

        public int Interval { get; set; }
    }
}
