using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Articles.Queries.GetArticleDetails
{
    public class GetArticleDetailsQueryHandler
        : IRequestHandler<GetArticleDetailsQuery, ArticleDetailsVm>
    {
        private readonly IShopDbContext _shopDbContext;
        private readonly IMapper _mapper;

        public GetArticleDetailsQueryHandler(IShopDbContext shopDbContext,
            IMapper mapper) => (_shopDbContext, _mapper) = (shopDbContext, mapper);

        public async Task<ArticleDetailsVm> Handle(GetArticleDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _shopDbContext.Articles
                .FirstOrDefaultAsync(article =>
                    article.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Article), request.Id);
            }

            return _mapper.Map<ArticleDetailsVm>(entity);
        }
    }
}