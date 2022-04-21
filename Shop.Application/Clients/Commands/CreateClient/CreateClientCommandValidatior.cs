using FluentValidation;

namespace Shop.Application.Clients.Commands.CreateClient
{
    public class CreateClientCommandValidatior : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidatior()
        {
            RuleFor(createClientCommand => createClientCommand.FirstName).NotEmpty();
            RuleFor(createClientCommand => createClientCommand.LastName).NotEmpty();
        }
    }
}
