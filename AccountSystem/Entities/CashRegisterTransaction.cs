using System.ComponentModel.DataAnnotations.Schema;

namespace AccountSystem.Entities;

[Table("cash_transactions")]
public class CashRegisterTransaction
{
    public int Id { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public string CashRegisterName { get; set; } = string.Empty;
    public string TransactionType { get; set; } = string.Empty; // "in" veya "out"
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Description { get; set; } = string.Empty;

    public int? ReferenceId { get; set; } // Finansal işlem bağlantısı
    public Transaction? ReferenceTransaction { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; } = null;
}