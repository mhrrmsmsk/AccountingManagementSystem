using AccountSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountSystem.Data.Mappers;

public class StockMovementConfig : IEntityTypeConfiguration<StockMovement>
{
    public void Configure(EntityTypeBuilder<StockMovement> entity)
    {
        entity.ToTable("stock_movements");
        entity.HasKey(sm => sm.Id);

        entity.Property(sm => sm.MovementType)
            .HasMaxLength(20)
            .IsRequired();

        entity.Property(sm => sm.Quantity)
            .HasColumnType("decimal(18,3)")
            .IsRequired();

        entity.Property(sm => sm.UnitPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        entity.Property(sm => sm.TotalAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        entity.Property(sm => sm.DocumentNo)
            .HasMaxLength(50);

        entity.Property(sm => sm.Description)
            .HasMaxLength(500);

        // Relations
        entity.HasOne(sm => sm.Company)
            .WithMany(c => c.StockMovements)
            .HasForeignKey(sm => sm.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(sm => sm.Product)
            .WithMany()
            .HasForeignKey(sm => sm.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(sm => sm.Warehouse)
            .WithMany()
            .HasForeignKey(sm => sm.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(sm => sm.User)
            .WithMany(u => u.StockMovements)
            .HasForeignKey(sm => sm.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes for performance
        entity.HasIndex(sm => sm.MovementDate);
        entity.HasIndex(sm => new { sm.CompanyId, sm.ProductId });
        entity.HasIndex(sm => sm.DocumentNo);
    }
}