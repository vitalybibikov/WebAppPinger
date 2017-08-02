using System;
using MediatR;
using WebAppPinger.Cqrs.Domain.Results;

namespace WebAppPinger.Cqrs.Domain.Queries
{
    public class GetEndpointsQuery : IRequest<GetEndpointsQueryResult>
    {
    }
}
