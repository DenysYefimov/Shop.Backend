namespace Shop.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(ShopDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}