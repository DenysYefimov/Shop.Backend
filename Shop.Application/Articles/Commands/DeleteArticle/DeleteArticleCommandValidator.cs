using FluentValidation;
using System;

namespace Shop.Application.Articles.Commands.DeleteArticle
{
    public class DeleteArticleCommandValidator : AbstractValidator<DeleteArticleCommand>
    {
        public DeleteArticleCommandValidator()
        {
            RuleFor(deleteArticleCommand => deleteArticleCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
