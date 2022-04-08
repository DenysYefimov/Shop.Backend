using MediatR;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Articles.Commands.DeleteArticle
{
    public class DeleteArticleCommandHandler
        : IRequestHandler<DeleteArticleCommand>
    {
        private readonly IShopDbContext _shopDbContext;

        public DeleteArticleCommandHandler(IShopDbContext shopDbContext) =>
            _shopDbContext = shopDbContext;

        public async Task<Unit> Handle(DeleteArticleCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _shopDbContext.Articles
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Article), request.Id);
            }

            _shopDbContext.Articles.Remove(entity);
            await _shopDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}