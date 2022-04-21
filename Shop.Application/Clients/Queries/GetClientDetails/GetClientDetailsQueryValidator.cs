using FluentValidation;
using System;

namespace Shop.Application.Clients.Queries.GetClientDetails
{
    public class GetClientDetailsQueryValidator : AbstractValidator<GetClientDetailsQuery>
    {
        public GetClientDetailsQueryValidator()
        {
            RuleFor(getOrderDetailsQuery => getOrderDetailsQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
