using MediatR;
using System;

namespace Shop.Application.Articles.Queries.GetArticleDetails
{
    public class GetArticleDetailsQuery : IRequest<ArticleDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
