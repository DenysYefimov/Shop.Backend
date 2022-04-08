using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommandHandler
        : IRequestHandler<UpdateArticleCommand>
    {
        private readonly IShopDbContext _shopDbContext;

        public UpdateArticleCommandHandler(IShopDbContext shopDbContext) =>
            _shopDbContext = shopDbContext;

        public async Task<Unit> Handle(UpdateArticleCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _shopDbContext.Articles.FirstOrDefaultAsync(article =>
                article.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Article), request.Id);
            }

            entity.Name = request.Name;
            entity.Producer = request.Producer;
            entity.Specifications = request.Specifications;
            entity.Country = request.Country;
            entity.Orders = request.Orders;
            entity.Price = request.Price;
            entity.Amount = request.Amount;

            await _shopDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}