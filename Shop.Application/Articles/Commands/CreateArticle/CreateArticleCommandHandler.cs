using MediatR;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandHandler
        : IRequestHandler<CreateArticleCommand, Guid>
    {
        private readonly IShopDbContext _shopDbContext;

        public CreateArticleCommandHandler(IShopDbContext shopDbContext) =>
            _shopDbContext = shopDbContext;

        public async Task<Guid> Handle(CreateArticleCommand request,
            CancellationToken cancellationToken)
        {
            var article = new Article
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Producer = request.Producer,
                Specifications = request.Specifications,
                Country = request.Country,
                Price = request.Price,
                Amount = request.Amount
            };

            await _shopDbContext.Articles.AddAsync(article, cancellationToken);
            await _shopDbContext.SaveChangesAsync(cancellationToken);

            return article.Id;
        }
    }
}
