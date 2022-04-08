using Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace Shop.Application.Interfaces
{
    public interface IShopDbContext
    {
        DbSet<Article> Articles { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Client> Clients { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}