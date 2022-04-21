using MediatR;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
    {
        private readonly IShopDbContext _shopDbContext;

        public DeleteClientCommandHandler(IShopDbContext shopDbContext) =>
            _shopDbContext = shopDbContext;

        public async Task<Unit> Handle(DeleteClientCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _shopDbContext.Clients
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Client), request.Id);
            }

            _shopDbContext.Clients.Remove(entity);
            await _shopDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
