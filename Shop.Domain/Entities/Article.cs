using System;
using System.Collections.Generic;

namespace Shop.Domain.Entities
{
    public class Article
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Specifications { get; set; }
        public string Country { get; set; }
        public List<Order> Orders { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }
}
