using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Shop.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public Guid Id { get; set; }
        public Client Client { get; set; }
        public List<Article> Articles { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? SendingDate { get; set; }
    }
}
