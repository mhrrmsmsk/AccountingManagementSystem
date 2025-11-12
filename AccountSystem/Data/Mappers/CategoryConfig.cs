using AccountSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountSystem.Data.Mappers;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.ToTable("categories");
        entity.HasKey(c => c.Id);

        entity.Property(c => c.CategoryName)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(c => c.CategoryDescription)
            .HasMaxLength(500);

        // Relations
        entity.HasOne(c => c.Company)
            .WithMany(co => co.Categories)
            .HasForeignKey(c => c.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(c => c.ParentCategory)
            .WithMany(c => c.ChildCategories)
            .HasForeignKey(c => c.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}