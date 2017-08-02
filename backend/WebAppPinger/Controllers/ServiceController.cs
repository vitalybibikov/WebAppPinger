using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAppPinger.Cqrs.Domain.Commands;
using WebAppPinger.Cqrs.Domain.Queries;
using WebAppPinger.Cqrs.Domain.Results;
using WebAppPinger.Models;

namespace WebAppPinger.Controllers
{
    [Route("api/[controller]")]
    public class ServiceController
    {
        private readonly IMediator mediator;

        public ServiceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<EndpointModel>> Get()
        {
            var query = new GetEndpointsQuery();
            var result = await mediator.Send(query);
            return result.Endpoints;
        }

        [HttpPost]
        public async Task<CommandResult> Create(string url, int interval)
        {
            var command = new CreateEndpointCommand
            {
                Interval = interval,
                Url = url
            };
            var result = await mediator.Send(command);
            return result;
        }

        [HttpDelete]
        public async Task<CommandResult> Delete(string url)
        {
            var command = new DeleteEndpointCommand();
            command.Url = url;
            var result = await mediator.Send(command);
            return result;
        }
    }
}