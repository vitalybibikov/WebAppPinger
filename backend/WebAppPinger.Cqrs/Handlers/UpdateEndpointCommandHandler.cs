using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppPinger.Cqrs.Domain.Commands;
using WebAppPinger.Cqrs.Domain.Results;
using WebAppPinger.Cqrs.Handlers.Abstract;
using WebAppPinger.Cqrs.Handlers.Interfaces;
using WebAppPinger.Data;

namespace WebAppPinger.Cqrs.Handlers
{
    public class UpdateEndpointCommandHandler : BaseHandler, IUpdateEndpointCommandHandler
    {
        public UpdateEndpointCommandHandler(WebPingerDbContext context) : base(context)
        {
        }

        public async Task<CommandResult> Handle(UpdateEndpointCommand message)
        {
            var result = await Context.Endpoints.SingleAsync(x => x.Url == message.Url);
            if (result != null)
            {
                result.LastPinged = message.LastPinged;
            }

            return new CommandResult
            {
                Success = await Context.SaveChangesAsync() > 0,
                Id = result?.Id ?? 0
            };
        }
    }
}