using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using WebAppPinger.Cqrs.Domain.Queries;
using WebAppPinger.Cqrs.Domain.Results;

namespace WebAppPinger.Cqrs.Handlers.Interfaces
{
    public interface IGetEndpointsQueryHandler: IAsyncRequestHandler<GetEndpointsQuery, GetEndpointsQueryResult>
    {
    }
}
