using System;
using System.Collections.Generic;

namespace Shop.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Client Client { get; set; }
        public List<Article> Articles { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? SendingDate { get; set; }
    }
}
