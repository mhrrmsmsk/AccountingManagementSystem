using AccountSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountSystem.Data.Mappers;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> entity)
    {
        entity.ToTable("roles");
        entity.HasKey(r => r.Id);

        entity.Property(r => r.Name)
            .HasMaxLength(50)
            .IsRequired();

        entity.Property(r => r.Description)
            .HasMaxLength(200);

        // Seed data for roles
        entity.HasData(
            new Role { Id = 1, Name = "Admin", Description = "System administrator with full access" },
            new Role { Id = 2, Name = "Manager", Description = "Company manager with limited admin access" },
            new Role { Id = 3, Name = "User", Description = "Standard user with basic permissions" },
            new Role { Id = 4, Name = "Accountant", Description = "Accounting specialist with financial permissions" }
        );
    }
}