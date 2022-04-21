using FluentValidation;
using System;

namespace Shop.Application.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandValidator : AbstractValidator<DeleteClientCommand>
    {
        public DeleteClientCommandValidator()
        {
            RuleFor(deleteClientCommand => deleteClientCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
