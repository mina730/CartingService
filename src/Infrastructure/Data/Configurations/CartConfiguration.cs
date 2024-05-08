using System.Reflection.Emit;
using CartingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Data.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(a => a.CartId);
        builder.Property(t => t.CartId)
            .HasMaxLength(50)
        .IsRequired();

    }
}
