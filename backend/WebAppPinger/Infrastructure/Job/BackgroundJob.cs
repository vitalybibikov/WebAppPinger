using System;
using System.Threading.Tasks;
using Hangfire;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<BackgroundJob> logger;

        public BackgroundJob(IMediator mediator, IServiceRequester requester, ILogger<BackgroundJob> logger)
        {
            this.mediator = mediator;
            this.requester = requester;
            this.logger = logger;
        }

        [AutomaticRetry(Attempts = 1)]
        public async Task<CommandResult> Execute()
        {
            var result = new CommandResult {Success = true};
            var query = new GetEndpointsQuery();
            var results = await mediator.Send(query);
            foreach (var endpoint in results.Endpoints)
            {
                if (endpoint.NeedsRequest)
                {
                    try
                    {
                        await requester.FireAndForget(endpoint);
                        var command = new UpdateEndpointCommand {LastPinged = DateTime.Now};
                        await mediator.Send(command);
                        result.Success = true;
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex.Message);
                        result.Success = false;
                        result.Message = String.Concat(result.Message, Environment.NewLine, ex.Message);
                    }
                }
            }
            return result;
        }
    }
}