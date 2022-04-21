using MediatR;
using System;

namespace Shop.Application.Clients.Queries.GetClientDetails
{
    public class GetClientDetailsQuery : IRequest<ClientDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
