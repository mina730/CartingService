using CartingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Data.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(50)
            .IsRequired();
        builder
            .HasKey(b => b.Id);

        builder
            .Property(b => b.Price)
            .IsRequired();
        builder
            .Property(b => b.Quantity).IsRequired();
    }
}
