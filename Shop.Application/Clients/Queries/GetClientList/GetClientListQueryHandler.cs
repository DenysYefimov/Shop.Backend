using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Clients.Queries.GetClientList
{
    public class GetClientListQueryHandler : IRequestHandler<GetClientListQuery, ClientListVm>
    {
        private readonly IShopDbContext _shopDbContext;
        private readonly IMapper _mapper;

        public GetClientListQueryHandler(IShopDbContext shopDbContext,
            IMapper mapper) => (_shopDbContext, _mapper) = (shopDbContext, mapper);

        public async Task<ClientListVm> Handle(GetClientListQuery _, CancellationToken cancellationToken)
        {
            var clientsQuery = await _shopDbContext.Clients
                .Where(client => true)
                .ProjectTo<ClientLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ClientListVm { Clients = clientsQuery };
        }
    }
}
