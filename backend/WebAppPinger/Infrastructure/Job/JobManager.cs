using Hangfire;
using Microsoft.Extensions.Options;
using WebAppPinger.Cqrs.Domain.Results;
using WebAppPinger.Infrastructure.Interface;
using WebAppPinger.Settings;

namespace WebAppPinger.Infrastructure.Job
{
    public class JobManager : IJobManager
    {
        private readonly IOptions<HangfireSettings> settings;

        public JobManager(IOptions<HangfireSettings> settings)
        {
            this.settings = settings;
        }

        public CommandResult Start()
        {
            RecurringJob.AddOrUpdate<IBackgroundJob>(
                $"{settings.Value.ServerName}-{settings.Value.QueueName}".ToLower(),
                x => x.Execute(),
                Cron.MinuteInterval(settings.Value.HangfireTaskInterval),
                queue: settings.Value.QueueName);
            return new CommandResult {Success = true};
        }
    }
}