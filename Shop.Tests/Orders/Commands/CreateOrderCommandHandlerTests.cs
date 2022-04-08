using Microsoft.EntityFrameworkCore;
using Shop.Application.Orders.Commands.CreateOrder;
using Shop.Domain.Entities;
using Shop.Tests.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Tests.Orders.Commands
{
    public class CreateOrderCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateOrderCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateOrderCommandHandler(Context);
            var orderArticles = new List<Article>() { ShopContextFactory.oldArticle };

            // Act
            var orderId = await handler.Handle(
                new CreateOrderCommand
                {
                    Articles = orderArticles,
                    Client = ShopContextFactory.UserA
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Orders.SingleOrDefaultAsync(order =>
                    order.Id == orderId && order.Articles == orderArticles));
        }
    }
}
