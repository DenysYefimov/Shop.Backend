using MediatR;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler
        : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IShopDbContext _shopDbContext;

        public CreateOrderCommandHandler(IShopDbContext shopDbContext) =>
            _shopDbContext = shopDbContext;

        public async Task<Guid> Handle(CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Client = request.Client,
                Articles = request.Articles,
                OrderDate = DateTime.Now
            };

            await _shopDbContext.Orders.AddAsync(order, cancellationToken);
            await _shopDbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
