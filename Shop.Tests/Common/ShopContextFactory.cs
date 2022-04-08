using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Persistence;
using System;
using System.Collections.Generic;

namespace Shop.Tests.Common
{
    public class ShopContextFactory
    {
        public static Client UserA = new Client()
        {
            Id = Guid.NewGuid()
        };
    
        public static Client UserB = new Client()
        {
            Id = Guid.NewGuid()
        };

        public static Guid OrderIdForDelete = Guid.NewGuid();
        public static Guid OrderIdForUpdate = Guid.NewGuid();

        public static Article oldArticle = new Article()
        {
            Id = Guid.NewGuid(),
            Country = "",
            Name = "",
            Producer = "",
            Specifications = ""
        };
        public static Article newArticle = new Article()
        {
            Id = Guid.NewGuid(),
            Country = "",
            Name = "",
            Producer = "",
            Specifications = ""
        };

        public static ShopDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ShopDbContext(options);
            context.Database.EnsureCreated();

            context.Articles.AddRange(oldArticle, newArticle);

            context.Orders.AddRange(
                new Order
                {
                    Id = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    Client = UserA,
                    Articles = new List<Article>(),
                    OrderDate = DateTime.Today,
                    SendingDate = null
                    
                },
                new Order
                {
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                    Client = UserB,
                    Articles = new List<Article>(),
                    OrderDate = DateTime.Today,
                    SendingDate = null
                },
                new Order
                {
                    Id = OrderIdForDelete,
                    Client = UserA,
                    Articles = new List<Article>(),
                    OrderDate = DateTime.Today,
                    SendingDate = null
                },
                new Order
                {
                    Id = OrderIdForUpdate,
                    Client = UserB,
                    Articles = new List<Article>(),
                    OrderDate = DateTime.Today,
                    SendingDate = null
                }
            );
            
            context.SaveChanges();
            return context;
        }

        public static void Destroy(ShopDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
