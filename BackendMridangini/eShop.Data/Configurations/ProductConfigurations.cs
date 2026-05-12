using BackendMridangini.eShop.Core.Products.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendMridangini.eShop.Data.Configurations;

public class ProductConfiguration
    : IEntityTypeConfiguration<Product>
{
    public void Configure(
        EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(4000);

        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(p => p.Stock)
            .IsRequired();

        builder.Property(p => p.TypeCategory)
            .IsRequired();

        builder.Property(p => p.IsActive)
            .IsRequired();

        builder.Property(p => p.CreatedAtUtc)
            .IsRequired();

        builder.Property(p => p.UpdatedAtUtc)
            .IsRequired();
        builder.Property(p => p.RowVersion)
               .IsRowVersion();

        builder.HasIndex(p => p.Name);

        builder.HasIndex(p => p.TypeCategory);

        builder.HasIndex(p => p.Price);

        builder.ToTable(t =>
        {
            t.HasCheckConstraint(
                "CHK_Product_Stock_NonNegative",
                "\"Stock\" >= 0");
        });
    }
}