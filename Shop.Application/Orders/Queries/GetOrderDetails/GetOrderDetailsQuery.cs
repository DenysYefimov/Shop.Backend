using MediatR;
using Shop.Domain.Entities;
using System;

namespace Shop.Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQuery : IRequest<OrderDetailsVm>
    {
        public Guid Id { get; set; }
        public Client Client { get; set; }
    }
}
