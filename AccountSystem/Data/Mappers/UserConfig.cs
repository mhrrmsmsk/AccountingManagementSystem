using AccountSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountSystem.Data.Mappers;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.ToTable("users");
        entity.HasKey(u => u.Id);

        entity.Property(u => u.FullName)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(u => u.Email)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(u => u.PasswordHash)
            .HasMaxLength(255)
            .IsRequired();

        // Relations
        entity.HasOne(u => u.Company)
            .WithMany(c => c.Users)
            .HasForeignKey(u => u.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}