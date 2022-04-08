using FluentValidation;
using System;

namespace Shop.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(updateOrderCommand => updateOrderCommand.Client).NotEmpty();
            RuleFor(updateOrderCommand => updateOrderCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateOrderCommand => updateOrderCommand.Articles).NotEmpty();
        }
    }
}
