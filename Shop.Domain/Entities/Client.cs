using System;
using System.Collections.Generic;

namespace Shop.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
        //public Order CurrentOrder { get; set; }
        public DateTime Birthday { get; set; }
    }
}
