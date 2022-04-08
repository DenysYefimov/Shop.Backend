using MediatR;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler 
        : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IShopDbContext _shopDbContext;

        public DeleteOrderCommandHandler(IShopDbContext shopDbContext) =>
            _shopDbContext = shopDbContext;

        public async Task<Unit> Handle(DeleteOrderCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _shopDbContext.Orders
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Client != request.Client)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            _shopDbContext.Orders.Remove(entity);
            await _shopDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
