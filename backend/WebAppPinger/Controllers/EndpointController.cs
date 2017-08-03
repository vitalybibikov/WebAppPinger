using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAppPinger.Cqrs.Domain.Commands;
using WebAppPinger.Cqrs.Domain.Queries;
using WebAppPinger.Cqrs.Domain.Results;
using WebAppPinger.Infrastructure.Extensions;
using WebAppPinger.Models;

namespace WebAppPinger.Controllers
{
    [Route("api/[controller]")]
    public class EndpointController
    {
        private readonly IMediator mediator;

        public EndpointController(IMediator mediator)
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
            var result = new CommandResult();
            url = url.Trim('"').Trim();
            if (!url.CheckUrlValid())
            {
                result.Message = "URL is not valid.";
                result.Success = false;
            }
            else
            {
                var command = new CreateEndpointCommand
                {
                    Interval = interval,
                    Url = url
                };
                result = await mediator.Send(command);
            }
            return result;
        }

        [HttpDelete]
        public async Task<CommandResult> Delete(string url)
        {
            url = url.Trim('"').Trim();
            var command = new DeleteEndpointCommand {Url = url};
            var result = await mediator.Send(command);
            return result;
        }
    }
}