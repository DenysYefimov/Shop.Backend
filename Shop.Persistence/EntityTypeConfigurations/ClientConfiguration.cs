using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Shop.Persistence.EntityTypeConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(client => client.Id);
            builder.HasIndex(client => client.Id).IsUnique();
            builder.Property(client => client.FirstName).HasMaxLength(50);
            builder.Property(client => client.LastName).HasMaxLength(50);
            builder.Property(client => client.Patronymic).HasMaxLength(50);
            builder.Property(client => client.Address).HasMaxLength(250);
            builder.Property(client => client.PhoneNumber).HasMaxLength(20);
        }
    }
}