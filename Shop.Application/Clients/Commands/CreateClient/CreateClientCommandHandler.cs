using MediatR;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandler
        : IRequestHandler<CreateClientCommand, Guid>
    {
        private readonly IShopDbContext _shopDbContext;

        public CreateClientCommandHandler(IShopDbContext shopDbContext) =>
            _shopDbContext = shopDbContext;

        public async Task<Guid> Handle(CreateClientCommand request,
            CancellationToken cancellationToken)
        {
            var client = new Client
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Patronymic = request.Patronymic,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Birthday = request.Birthday,
                Orders = request.Orders
            };

            await _shopDbContext.Clients.AddAsync(client, cancellationToken);
            await _shopDbContext.SaveChangesAsync(cancellationToken);

            return client.Id;
        }
    }
}
