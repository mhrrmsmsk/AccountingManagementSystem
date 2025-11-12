using System.ComponentModel.DataAnnotations.Schema;

namespace AccountSystem.Entities;

[Table("chart_of_accounts")]
public class Account
{
    public int Id { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public string AccountCode { get; set; } = string.Empty;
    public string AccountName { get; set; } = string.Empty;
    public string AccountType { get; set; } = string.Empty; 
    
    public int Level { get; set; }

    public int? ParentAccountId { get; set; }
    public Account? ParentAccount { get; set; }
    public ICollection<Account> ChildAccounts { get; set; } = new List<Account>();
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public bool Status { get; set; } = true;
    
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; } = null;
}