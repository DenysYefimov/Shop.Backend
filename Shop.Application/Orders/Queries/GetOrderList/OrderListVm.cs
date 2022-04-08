using System.Collections.Generic;

namespace Shop.Application.Orders.Queries.GetOrderList
{
    public class OrderListVm
    {
        public IList<OrderLookUpDto> Orders { get; set; }
    }
}
