using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppPinger.Cqrs.Domain.Commands;
using WebAppPinger.Cqrs.Domain.Results;
using WebAppPinger.Cqrs.Handlers.Abstract;
using WebAppPinger.Cqrs.Handlers.Interfaces;
using WebAppPinger.Data;

namespace WebAppPinger.Cqrs.Handlers
{
    public class DeleteEndpointCommandHandler : BaseHandler, IDeleteEndpointCommandHandler
    {
        public DeleteEndpointCommandHandler(WebPingerDbContext context) : base(context)
        {
        }

        public async Task<CommandResult> Handle(DeleteEndpointCommand message)
        {
            var result = await Context.Endpoints.FirstOrDefaultAsync(x => x.Url == message.Url);
            if (result != null)
            {
                Context.Remove(result);
            }
            return new CommandResult
            {
                Success = await Context.SaveChangesAsync() > 0,
                Id = result?.Id ?? 0
            };
        }
    }
}