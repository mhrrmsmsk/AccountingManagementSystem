using AccountSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountSystem.Data.Mappers;

public class CompanyConfig : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> entity)
    {
        entity.ToTable("companies");

        entity.HasKey(c => c.Id);

        entity.Property(c => c.CompanyName)
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(c => c.TaxNumber)
            .HasMaxLength(20)
            .IsRequired();

        entity.Property(c => c.Address)
            .HasMaxLength(500);

        entity.Property(c => c.PhoneNumber)
            .HasMaxLength(20);

        entity.Property(c => c.Email)
            .HasMaxLength(100);

        entity.Property(c => c.Website)
            .HasMaxLength(100);

        entity.Property(c => c.CreatedAt)
            .HasColumnType("datetime2");

        entity.Property(c => c.UpdatedAt)
            .HasColumnType("datetime2");

        entity.Property(c => c.DeletedAt)
            .HasColumnType("datetime2");
    }
}