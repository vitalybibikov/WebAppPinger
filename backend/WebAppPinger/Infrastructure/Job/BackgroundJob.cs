using System;
using System.Threading.Tasks;
using Hangfire;
using MediatR;
using WebAppPinger.Cqrs.Domain.Commands;
using WebAppPinger.Cqrs.Domain.Queries;
using WebAppPinger.Cqrs.Domain.Results;
using WebAppPinger.Infrastructure.Interface;

namespace WebAppPinger.Infrastructure.Job
{
    public class BackgroundJob : IBackgroundJob
    {
        private readonly IMediator mediator;
        private readonly IServiceRequester requester;

        public BackgroundJob(IMediator mediator, IServiceRequester requester)
        {
            this.mediator = mediator;
            this.requester = requester;
        }

        [AutomaticRetry(Attempts = 1)]
        public async Task<CommandResult> Execute()
        {
            var query = new GetEndpointsQuery();
            var results = await mediator.Send(query);
            foreach (var endpoint in results.Endpoints)
            {
                if (endpoint.NeedsRequest)
                {
                    await requester.FireAndForget(endpoint);
                    var command = new UpdateEndpointCommand {LastPinged = DateTime.Now};
                    await mediator.Send(command);
                }
            }
            return new CommandResult {Success = true};
        }
    }
}