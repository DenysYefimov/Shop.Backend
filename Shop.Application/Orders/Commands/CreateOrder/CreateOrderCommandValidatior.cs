using FluentValidation;

namespace Shop.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidatior : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidatior()
        {
            RuleFor(createOrderCommand => createOrderCommand.Client).NotEmpty();
            RuleFor(createOrderCommand => createOrderCommand.Articles).NotEmpty();
        }
    }
}
