using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Clients.Queries.GetClientDetails
{
    public class GetClientDetailsQueryHandler
        : IRequestHandler<GetClientDetailsQuery, ClientDetailsVm>
    {
        private readonly IShopDbContext _shopDbContext;
        private readonly IMapper _mapper;

        public GetClientDetailsQueryHandler(IShopDbContext shopDbContext,
            IMapper mapper) => (_shopDbContext, _mapper) = (shopDbContext, mapper);

        public async Task<ClientDetailsVm> Handle(GetClientDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _shopDbContext.Orders
                .FirstOrDefaultAsync(order =>
                    order.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Client), request.Id);
            }

            return _mapper.Map<ClientDetailsVm>(entity);
        }
    }
}
