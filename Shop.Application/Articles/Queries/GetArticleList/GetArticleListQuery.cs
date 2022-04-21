using MediatR;
using System;

namespace Shop.Application.Articles.Queries.GetArticleList
{
    public class GetArticleListQuery : IRequest<ArticleListVm>
    {
        public Guid CategoryId { get; set; }
    }
}
