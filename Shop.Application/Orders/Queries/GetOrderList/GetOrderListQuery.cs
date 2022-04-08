using MediatR;
using Shop.Domain.Entities;
using System;

namespace Shop.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListQuery : IRequest<OrderListVm>
    {
        public Client Client { get; set; }
    }
}
