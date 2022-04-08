using Shop.Application.Common.Mappings;
using Shop.Application.Orders.Commands.UpdateOrder;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.WebApi.Models
{
    public class UpdateOrderDto : IMapWith<UpdateOrderCommand>
    {
        public Guid Id { get; set; }
        public List<Article> Articles { get; set; }
    }
}
