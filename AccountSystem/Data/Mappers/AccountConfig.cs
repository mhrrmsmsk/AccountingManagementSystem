using AccountSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountSystem.Data.Mappers;

public class AccountConfig : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> entity)
    {
        entity.ToTable("chart_of_accounts");
        entity.HasKey(a => a.Id);

        entity.Property(a => a.AccountCode)
            .HasMaxLength(20)
            .IsRequired();

        entity.Property(a => a.AccountName)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(a => a.AccountType)
            .HasMaxLength(50)
            .IsRequired();

        entity.Property(a => a.Level)
            .IsRequired();

        // Relations
        entity.HasOne(a => a.Company)
            .WithMany(c => c.Accounts)
            .HasForeignKey(a => a.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(a => a.ParentAccount)
            .WithMany(a => a.ChildAccounts)
            .HasForeignKey(a => a.ParentAccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}