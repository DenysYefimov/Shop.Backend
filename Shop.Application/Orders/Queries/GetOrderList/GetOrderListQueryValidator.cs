using FluentValidation;

namespace Shop.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryValidator : AbstractValidator<GetOrderListQuery>
    {
        public GetOrderListQueryValidator()
        {
            RuleFor(getOrderListQuery => getOrderListQuery.Client).NotEmpty();
        }
    }
}
