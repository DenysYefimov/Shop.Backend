using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Interfaces;

namespace Shop.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ShopDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IShopDbContext>(provider =>
                provider.GetService<ShopDbContext>());
            return services;
        }
    }
}
