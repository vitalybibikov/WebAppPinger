using System;
using System.Linq;
using System.Threading.Tasks;
using WebAppPinger.Cqrs.Domain.Commands;
using WebAppPinger.Cqrs.Domain.Results;
using WebAppPinger.Cqrs.Handlers.Abstract;
using WebAppPinger.Cqrs.Handlers.Interfaces;
using WebAppPinger.Data;
using WebAppPinger.Data.Entities;

namespace WebAppPinger.Cqrs.Handlers
{
    public class CreateEndpointCommandHandler : BaseHandler, ICreateEndpointCommandHandler
    {
        public CreateEndpointCommandHandler(WebPingerDbContext context) : base(context)
        {
        }

        public async Task<CommandResult> Handle(CreateEndpointCommand message)
        {
            var command = new CommandResult();
            var entity = new EndpointEntity
            {
                Interval = message.Interval,
                Url = message.Url,
                LastPinged = DateTime.Now
            };
            if (!Context.Endpoints.Any(x => x.Url == message.Url))
            {
                await Context.AddAsync(entity);
            }
            else
            {
                command.Message = "Url has already been registered in the application.";
            }

            command.Success = await Context.SaveChangesAsync() > 0;
            command.Id = entity.Id;
            return command;
        }
    }
}