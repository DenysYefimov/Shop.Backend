using AutoMapper;
using Shop.Application.Orders.Queries.GetOrderList;
using Shop.Persistence;
using Shop.Tests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Tests.Orders.Queries
{
    [Collection("QueryCollection")]
    public class GetOrderListQueryHandlerTests
    {
        private readonly ShopDbContext Context;
        private readonly IMapper Mapper;

        public GetOrderListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetOrderListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetOrderListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetOrderListQuery
                {
                    Client = ShopContextFactory.UserB
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<OrderListVm>();
            result.Orders.Count.ShouldBe(2);
        }
    }
}
