using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IShopDbContext _shopDbContext;

        public UpdateOrderCommandHandler(IShopDbContext shopDbContext) =>
            _shopDbContext = shopDbContext;

        public async Task<Unit> Handle(UpdateOrderCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _shopDbContext.Orders.FirstOrDefaultAsync(order =>
                order.Id == request.Id, cancellationToken);

            if (entity == null || entity.Client != request.Client)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            entity.Client = request.Client;
            entity.Articles = request.Articles;
            entity.OrderDate = request.OrderDate;
            entity.SendingDate = request.SendingDate;
            

            await _shopDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
