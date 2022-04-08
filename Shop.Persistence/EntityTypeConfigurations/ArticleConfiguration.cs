using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Shop.Persistence.EntityTypeConfigurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(article => article.Id);
            builder.HasIndex(article => article.Id).IsUnique();
            builder.Property(article => article.Name).HasMaxLength(250);
            builder.Property(article => article.Producer).HasMaxLength(250);
            builder.Property(article => article.Country).HasMaxLength(250);
        }
    }
}