using FluentValidation;
using System;

namespace Shop.Application.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
    {
        public UpdateArticleCommandValidator()
        {
            RuleFor(updateOrderCommand => updateOrderCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateArticleCommand => updateArticleCommand.Name).NotEmpty();
            RuleFor(updateArticleCommand => updateArticleCommand.Producer).NotEmpty();
        }
    }
}
