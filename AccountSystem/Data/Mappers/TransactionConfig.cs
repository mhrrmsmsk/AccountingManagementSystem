using AccountSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountSystem.Data.Mappers;

public class TransactionConfig : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> entity)
    {
        entity.ToTable("financial_transactions");
        entity.HasKey(t => t.Id);

        entity.Property(t => t.TransactionType)
            .HasMaxLength(10)
            .IsRequired();

        entity.Property(t => t.Amount)
            .HasColumnType("decimal(18,2)");

        entity.Property(t => t.Currency)
            .HasMaxLength(3)
            .IsRequired();

        entity.Property(t => t.ExchangeRate)
            .HasColumnType("decimal(18,4)");

        entity.Property(t => t.Description)
            .HasMaxLength(500);

        entity.Property(t => t.DocumentNo)
            .HasMaxLength(50);

        // Relations
        entity.HasOne(t => t.Company)
            .WithMany(c => c.Transactions)
            .HasForeignKey(t => t.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(t => t.Account)
            .WithMany(a => a.Transactions)
            .HasForeignKey(t => t.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(t => t.Contact)
            .WithMany()
            .HasForeignKey(t => t.ContactId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(t => t.User)
            .WithMany(u => u.Transactions)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}