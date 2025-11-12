using AccountSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountSystem.Data.Mappers;

public class StockBalanceConfig : IEntityTypeConfiguration<StockBalance>
{
    public void Configure(EntityTypeBuilder<StockBalance> entity)
    {
        entity.ToTable("stock_balances");
        entity.HasKey(sb => sb.Id);

        entity.Property(sb => sb.Quantity)
            .HasColumnType("decimal(18,3)")
            .IsRequired();

        entity.Property(sb => sb.AverageCost)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        // Relations
        entity.HasOne(sb => sb.Company)
            .WithMany(c => c.StockBalances)
            .HasForeignKey(sb => sb.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(sb => sb.Product)
            .WithMany()
            .HasForeignKey(sb => sb.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(sb => sb.Warehouse)
            .WithMany()
            .HasForeignKey(sb => sb.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Composite unique index - Bir ürün bir depoda sadece bir kez olabilir
        entity.HasIndex(sb => new { sb.CompanyId, sb.ProductId, sb.WarehouseId })
            .IsUnique();
    }
}