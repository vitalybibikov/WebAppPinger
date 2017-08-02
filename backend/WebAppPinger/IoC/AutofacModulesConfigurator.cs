using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacSerilogIntegration;
using Microsoft.Extensions.DependencyInjection;
using WebAppPinger.DI.Modules;
using WebAppPinger.IoC.Modules;

namespace WebAppPinger.IoC
{
    public class AutofacModulesConfigurator
    {
        public IContainer Configure(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterLogger();

            builder.RegisterModule<CommonModule>();
            builder.RegisterModule<MediatrModule>();
            
            builder.Populate(services);
            return builder.Build();
        }
    }
}
