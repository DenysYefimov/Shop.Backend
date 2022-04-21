using FluentValidation;
using System;

namespace Shop.Application.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(updateClientCommand => updateClientCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateClientCommand => updateClientCommand.FirstName).NotEmpty();
            RuleFor(updateClientCommand => updateClientCommand.LastName).NotEmpty();
        }
    }
}
