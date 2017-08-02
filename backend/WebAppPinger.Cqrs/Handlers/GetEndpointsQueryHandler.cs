using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebAppPinger.Cqrs.Domain.Queries;
using WebAppPinger.Cqrs.Domain.Results;
using WebAppPinger.Cqrs.Handlers.Abstract;
using WebAppPinger.Cqrs.Handlers.Interfaces;
using WebAppPinger.Data;
using WebAppPinger.Models;

namespace WebAppPinger.Cqrs.Handlers
{
    public class GetEndpointsQueryHandler : BaseHandler, IGetEndpointsQueryHandler
    {
        public GetEndpointsQueryHandler(WebPingerDbContext context) : base(context)
        {
        }

        public async Task<GetEndpointsQueryResult> Handle(GetEndpointsQuery message)
        {
            var entities = await Context.Endpoints.ToListAsync();
            var results = new List<EndpointModel>();

            foreach (var entity in entities)
            {
                var model = new EndpointModel
                {
                    Interval = entity.Interval,
                    LastPinged = entity.LastPinged,
                    Url = entity.Url,
                    Id = entity.Id
                };
                results.Add(model);
            }
            return new GetEndpointsQueryResult
            {
                Endpoints = results
            };
        }
    }
}