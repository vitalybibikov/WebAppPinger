using System.Collections.Generic;
using WebAppPinger.Models;

namespace WebAppPinger.Cqrs.Domain.Results
{
    public class GetEndpointsQueryResult
    {
        public IEnumerable<EndpointModel> Endpoints;
    }
}