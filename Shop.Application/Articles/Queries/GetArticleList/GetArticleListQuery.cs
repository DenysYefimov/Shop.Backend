using MediatR;
using Shop.Application.Articles.Queries.GetArticleList;
using System;

namespace Shop.Application.Articles.Queries.GetArticleList
{
    public class GetArticleListQuery : IRequest<ArticleListVm>
    {
        public Guid CategoryId { get; set; }
    }
}