using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Articles.Queries.GetArticleList
{
    public class GetArticleListQueryHandler
        : IRequestHandler<GetArticleListQuery, ArticleListVm>
    {
        private readonly IShopDbContext _shopDbContext;
        private readonly IMapper _mapper;

        public GetArticleListQueryHandler(IShopDbContext shopDbContext,
            IMapper mapper) => (_shopDbContext, _mapper) = (shopDbContext, mapper);

        public async Task<ArticleListVm> Handle(GetArticleListQuery request,
            CancellationToken cancellationToken)
        {
            var articlesQuery = await _shopDbContext.Articles
                .Where(article => article.Id == request.CategoryId)
                .ProjectTo<ArticleLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ArticleListVm { Articles = articlesQuery };
        }
    }
}
