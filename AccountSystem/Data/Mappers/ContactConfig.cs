using AccountSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountSystem.Data.Mappers;

public class ContactConfig : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> entity)
    {
        entity.ToTable("contacts");
        entity.HasKey(c => c.Id);

        entity.Property(c => c.ContactCode)
            .HasMaxLength(20)
            .IsRequired();

        entity.Property(c => c.ContactType)
            .HasMaxLength(10)
            .IsRequired();

        entity.Property(c => c.CompanyName)
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(c => c.TaxOffice)
            .HasMaxLength(50);

        entity.Property(c => c.TaxNumber)
            .HasMaxLength(20);

        entity.Property(c => c.Address)
            .HasMaxLength(500);

        entity.Property(c => c.Phone)
            .HasMaxLength(20);

        entity.Property(c => c.Email)
            .HasMaxLength(100);

        entity.Property(c => c.Balance)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0);

        // Relations
        entity.HasOne(c => c.Company)
            .WithMany(co => co.Contacts)
            .HasForeignKey(c => c.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        entity.HasIndex(c => new { c.CompanyId, c.ContactCode })
            .IsUnique();

        entity.HasIndex(c => c.TaxNumber);
        entity.HasIndex(c => c.CompanyName);
    }
}