using Shop.Application.Common.Exceptions;
using Shop.Application.Orders.Commands.CreateOrder;
using Shop.Application.Orders.Commands.DeleteOrder;
using Shop.Domain.Entities;
using Shop.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Tests.Orders.Commands
{
    public class DeleteOrderCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteOrderCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteOrderCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteOrderCommand
            {
                Id = ShopContextFactory.OrderIdForDelete,
                Client = ShopContextFactory.UserA
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Orders.SingleOrDefault(order =>
                order.Id == ShopContextFactory.OrderIdForDelete));
        }

        [Fact]
        public async Task DeleteOrderCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteOrderCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteOrderCommand
                    {
                        Id = Guid.NewGuid(),
                        Client = ShopContextFactory.UserA
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteOrderCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteOrderCommandHandler(Context);
            var createHandler = new CreateOrderCommandHandler(Context);
            var orderId = await createHandler.Handle(
                new CreateOrderCommand
                {
                    Articles = new List<Article>(),
                    Client = ShopContextFactory.UserA
                }, CancellationToken.None);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteOrderCommand
                    {
                        Id = orderId,
                        Client = ShopContextFactory.UserB
                    }, CancellationToken.None));
        }
    }
}
