using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Application.Interfaces;
using Shop.Persistence;
using System;
using Xunit;

namespace Shop.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public ShopDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = ShopContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IShopDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            ShopContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
