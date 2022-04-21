using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Shop.Application.Clients.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
        public DateTime Birthday { get; set; }
    }
}
