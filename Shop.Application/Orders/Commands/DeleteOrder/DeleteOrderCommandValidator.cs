using FluentValidation;
using System;

namespace Shop.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(deleteOrderCommand => deleteOrderCommand.Client).NotEmpty();
            RuleFor(deleteOrderCommand => deleteOrderCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
