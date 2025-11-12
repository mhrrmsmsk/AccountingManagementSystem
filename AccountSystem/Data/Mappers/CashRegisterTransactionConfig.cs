using AccountSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountSystem.Data.Mappers;

public class CashRegisterTransactionConfig : IEntityTypeConfiguration<CashRegisterTransaction>
{
    public void Configure(EntityTypeBuilder<CashRegisterTransaction> entity)
    {
        entity.ToTable("cash_transactions");
        entity.HasKey(c => c.Id);

        entity.Property(c => c.CashRegisterName)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(c => c.TransactionType)
            .HasMaxLength(10)
            .IsRequired();

        entity.Property(c => c.Amount)
            .HasColumnType("decimal(18,2)");

        entity.Property(c => c.Description)
            .HasMaxLength(500);

        // Relations
        entity.HasOne(c => c.Company)
            .WithMany(co => co.CashTransactions)
            .HasForeignKey(c => c.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(c => c.User)
            .WithMany(u => u.CashTransactions)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(c => c.ReferenceTransaction)
            .WithMany(t => t.CashTransactions)
            .HasForeignKey(c => c.ReferenceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}