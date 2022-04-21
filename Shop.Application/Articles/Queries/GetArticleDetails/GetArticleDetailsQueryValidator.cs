using FluentValidation;
using System;

namespace Shop.Application.Articles.Queries.GetArticleDetails
{
    public class GetArticleDetailsQueryValidator : AbstractValidator<GetArticleDetailsQuery>
    {
        public GetArticleDetailsQueryValidator()
        {
            RuleFor(getArticleDetailsQuery => getArticleDetailsQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
