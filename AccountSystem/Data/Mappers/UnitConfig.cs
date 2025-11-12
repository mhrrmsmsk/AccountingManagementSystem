using AccountSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountSystem.Data.Mappers;

public class UnitConfig : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> entity)
    {
        entity.ToTable("units");
        entity.HasKey(u => u.Id);

        entity.Property(u => u.UnitName)
            .HasMaxLength(50)
            .IsRequired();

        entity.Property(u => u.Abbreviation)
            .HasMaxLength(10)
            .IsRequired();

        // Seed data for units
        entity.HasData(
            new Unit { Id = 1, UnitName = "Piece", Abbreviation = "pcs", CreatedAt = new DateTime(2025, 1, 1), UpdatedAt = new DateTime(2025, 1, 1) },
            new Unit { Id = 2, UnitName = "Kilogram", Abbreviation = "kg", CreatedAt = new DateTime(2025, 1, 1), UpdatedAt = new DateTime(2025, 1, 1) },
            new Unit { Id = 3, UnitName = "Meter", Abbreviation = "m", CreatedAt = new DateTime(2025, 1, 1), UpdatedAt = new DateTime(2025, 1, 1) },
            new Unit { Id = 4, UnitName = "Liter", Abbreviation = "L", CreatedAt = new DateTime(2025, 1, 1), UpdatedAt = new DateTime(2025, 1, 1) },
            new Unit { Id = 5, UnitName = "Box", Abbreviation = "box", CreatedAt = new DateTime(2025, 1, 1), UpdatedAt = new DateTime(2025, 1, 1) },
            new Unit { Id = 6, UnitName = "Package", Abbreviation = "pkg", CreatedAt = new DateTime(2025, 1, 1), UpdatedAt = new DateTime(2025, 1, 1) }
        );
    }
}