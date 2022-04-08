using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using Shop.Persistence.EntityTypeConfigurations;

namespace Shop.Persistence
{
    public class ShopDbContext : DbContext, IShopDbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ArticleConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new ClientConfiguration());
            base.OnModelCreating(builder);
        }
    }
}