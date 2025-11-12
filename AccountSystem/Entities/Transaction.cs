using System.ComponentModel.DataAnnotations.Schema;

namespace AccountSystem.Entities;

[Table("financial_transactions")]
public class Transaction
{
    public int Id { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public string TransactionType { get; set; } = string.Empty; // "income" veya "expense"
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
    public int ContactId { get; set; }
    public Contact Contact { get; set; } = null!;

    public decimal Amount { get; set; }
    public string Currency { get; set; } = "TRY";
    public decimal ExchangeRate { get; set; } = 1;
    public DateTime TransactionDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public string DocumentNo { get; set; } = string.Empty;

    public int UserId { get; set; }
    public User User { get; set; } = null!;
    
    // Navigation
    public ICollection<CashRegisterTransaction> CashTransactions { get; set; } = new List<CashRegisterTransaction>();

    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; } = null;
}