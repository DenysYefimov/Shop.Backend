using MediatR;
using Shop.Domain.Entities;
using System;

namespace Shop.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public Guid Id { get; set; }
        public Client Client { get; set; }
    }
}
