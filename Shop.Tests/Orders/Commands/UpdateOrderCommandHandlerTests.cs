using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Orders.Commands.UpdateOrder;
using Shop.Domain.Entities;
using Shop.Tests.Common;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Tests.Orders.Commands
{
    public class UpdateOrderCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateOrderCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateOrderCommandHandler(Context);
            var updatedArticles = new List<Article>() { ShopContextFactory.newArticle };

            // Act
            await handler.Handle(new UpdateOrderCommand
            {
                Id = ShopContextFactory.OrderIdForUpdate,
                Client = ShopContextFactory.UserB,
                Articles = updatedArticles
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Orders.SingleOrDefaultAsync(order =>
                order.Id == ShopContextFactory.OrderIdForUpdate &&
                order.Articles == updatedArticles));
        }

        [Fact]
        public async Task UpdateOrderCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateOrderCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateOrderCommand
                    {
                        Id = Guid.NewGuid(),
                        Client = ShopContextFactory.UserA
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateOrderCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateOrderCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateOrderCommand
                    {
                        Id = ShopContextFactory.OrderIdForUpdate,
                        Client = ShopContextFactory.UserA
                    },
                    CancellationToken.None);
            });
        }
    }
}
