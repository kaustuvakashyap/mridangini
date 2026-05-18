using BackendMridangini.eShop.Core.Cart.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendMridangini.eShop.Data.Configurations;

/*
 * This class configures the Cart entity for Entity Framework Core. It specifies the table name, primary key, required properties, unique index on UserId,
 * and the relationship with CartItem entities. The configuration ensures that when a Cart is deleted,
 * its associated CartItems are also deleted (cascade delete).
 */
public class CartConfiguration
    : IEntityTypeConfiguration<Cart>
{
    public void Configure(
        EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("carts");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.State)
            .IsRequired();

        builder.Property(c => c.CreatedAtUtc)
            .IsRequired();

        builder.Property(c => c.UpdatedAtUtc)
            .IsRequired();

        builder.HasIndex(c => c.UserId)
            .IsUnique();

        builder.HasMany(c => c.Items)
            .WithOne(i => i.Cart)
            .HasForeignKey(i => i.CartId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}