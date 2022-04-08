using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler
        : IRequestHandler<GetOrderListQuery, OrderListVm>
    {
        private readonly IShopDbContext _shopDbContext;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IShopDbContext shopDbContext,
            IMapper mapper) => (_shopDbContext, _mapper) = (shopDbContext, mapper);

        public async Task<OrderListVm> Handle(GetOrderListQuery request,
            CancellationToken cancellationToken)
        {
            var ordersQuery = await _shopDbContext.Orders
                .Where(order => order.Client == request.Client)
                .ProjectTo<OrderLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderListVm { Orders = ordersQuery };
        }
    }
}
