using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
    {
        private readonly IShopDbContext _shopDbContext;

        public UpdateClientCommandHandler(IShopDbContext shopDbContext) =>
            _shopDbContext = shopDbContext;

        public async Task<Unit> Handle(UpdateClientCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _shopDbContext.Clients.FirstOrDefaultAsync(client =>
                client.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Client), request.Id);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Patronymic = request.Patronymic;
            entity.Address = request.Address;
            entity.PhoneNumber = request.PhoneNumber;
            entity.Birthday = request.Birthday;
            entity.Orders = request.Orders;


            await _shopDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
