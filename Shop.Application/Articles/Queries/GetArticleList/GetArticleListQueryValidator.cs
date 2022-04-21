using FluentValidation;
using System;

namespace Shop.Application.Articles.Queries.GetArticleList
{
    public class GetArticleListQueryValidator : AbstractValidator<GetArticleListQuery>
    {
        public GetArticleListQueryValidator()
        {
            RuleFor(getArticleListQuery => getArticleListQuery.CategoryId).NotEqual(Guid.Empty);
        }
    }
}
