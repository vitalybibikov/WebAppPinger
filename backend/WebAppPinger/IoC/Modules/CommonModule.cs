using Autofac;
using WebAppPinger.Infrastructure;
using WebAppPinger.Infrastructure.Interface;
using WebAppPinger.Infrastructure.Job;

namespace WebAppPinger.IoC.Modules
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JobManager>().As<IJobManager>();
            builder.RegisterType<BackgroundJob>().As<IBackgroundJob>();
            builder.RegisterType<ServiceRequester>().As<IServiceRequester>();
        }
    }
}