using AutoMapper;
using Shop.Application.Orders.Queries.GetOrderDetails;
using Shop.Domain.Entities;
using Shop.Persistence;
using Shop.Tests.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Tests.Orders.Queries
{
    [Collection("QueryCollection")]
    public class GetOrderDetailsQueryHandlerTests
    {
        private readonly ShopDbContext Context;
        private readonly IMapper Mapper;

        public GetOrderDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetOrderDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetOrderDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetOrderDetailsQuery
                {
                    Client = ShopContextFactory.UserB,
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<OrderDetailsVm>();
            result.Articles.ShouldBe(new List<Article>());
            result.OrderDate.ShouldBe(DateTime.Today);
        }
    }
}
