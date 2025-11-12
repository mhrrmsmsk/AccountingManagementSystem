using AccountSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountSystem.Data.Mappers;

public class WarehouseConfig : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> entity)
    {
        entity.ToTable("warehouses");
        entity.HasKey(w => w.Id);

        entity.Property(w => w.WarehouseName)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(w => w.WarehouseCode)
            .HasMaxLength(20)
            .IsRequired();

        entity.Property(w => w.Address)
            .HasMaxLength(500);

        entity.Property(w => w.ResponsiblePerson)
            .HasMaxLength(100);

        entity.Property(w => w.PhoneNumber)
            .HasMaxLength(20);

        // Relations
        entity.HasOne(w => w.Company)
            .WithMany(c => c.Warehouses)
            .HasForeignKey(w => w.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        entity.HasIndex(w => new { w.CompanyId, w.WarehouseCode })
            .IsUnique();
    }
}