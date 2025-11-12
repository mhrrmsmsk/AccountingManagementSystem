using AccountSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountSystem.Data.Mappers;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.ToTable("products");

        entity.HasKey(p => p.Id);

        entity.Property(p => p.ProductCode)
            .HasMaxLength(50)
            .IsRequired();

        entity.Property(p => p.ProductName)
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(p => p.Barcode)
            .HasMaxLength(50);

        entity.Property(p => p.Description)
            .HasMaxLength(500);

        entity.Property(p => p.PurchasePrice)
            .HasColumnType("decimal(18,2)");

        entity.Property(p => p.SalePrice)
            .HasColumnType("decimal(18,2)");

        entity.Property(p => p.VatRate)
            .HasColumnType("decimal(5,2)");

        entity.Property(p => p.CreatedAt)
            .HasColumnType("datetime2");

        entity.Property(p => p.UpdatedAt)
            .HasColumnType("datetime2");

        // Relations
        entity.HasOne(p => p.Company)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(p => p.Unit)
            .WithMany(u => u.Products)
            .HasForeignKey(p => p.UnitId)
            .OnDelete(DeleteBehavior.Restrict);
        
        entity.HasIndex(p => new { p.CompanyId, p.ProductCode })
            .IsUnique();

        entity.HasIndex(p => p.Barcode);
        entity.HasIndex(p => p.ProductName);
    }
}