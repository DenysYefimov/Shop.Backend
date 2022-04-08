using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Shop.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Client Client { get; set; }
        public List<Article> Articles { get; set; }
    }
}
