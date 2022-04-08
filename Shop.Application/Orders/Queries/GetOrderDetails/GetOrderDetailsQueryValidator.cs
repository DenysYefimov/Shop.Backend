using FluentValidation;
using System;

namespace Shop.Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryValidator : AbstractValidator<GetOrderDetailsQuery>
    {
        public GetOrderDetailsQueryValidator()
        {
            RuleFor(getOrderDetailsQuery => getOrderDetailsQuery.Client).NotEmpty();
            RuleFor(getOrderDetailsQuery => getOrderDetailsQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
