using FluentValidation;

namespace Shop.Application.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandValidatior : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidatior()
        {
            RuleFor(createArticleCommand => createArticleCommand.Name).NotEmpty();
            RuleFor(createArticleCommand => createArticleCommand.Producer).NotEmpty();
        }
    }
}
