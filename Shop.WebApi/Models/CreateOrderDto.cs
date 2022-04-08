using Shop.Application.Common.Mappings;
using Shop.Application.Orders.Commands.CreateOrder;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.WebApi.Models
{
    public class CreateOrderDto : IMapWith<CreateOrderCommand>
    {
        public List<Article> Articles { get; set; }
    }
}
