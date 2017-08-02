using System;
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
            var entity = new EndpointEntity
            {
                Interval = message.Interval,
                Url = message.Url,
                LastPinged = DateTime.Now
            };

            await Context.AddAsync(entity);
            var result = await Context.SaveChangesAsync() > 0;

            return new CommandResult
            {
                Success = result,
                Id = entity.Id
            };
        }
    }
}