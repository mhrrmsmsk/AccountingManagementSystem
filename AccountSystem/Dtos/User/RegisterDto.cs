using System.ComponentModel.DataAnnotations;

namespace AccountSystem.Dtos.User;

public class RegisterDto
{
    [Required]
    public int CompanyId { get; set; }

    [Required]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; }  = string.Empty;

    [Required]
    [MinLength(8)]
    public string Password { get; set; }  = string.Empty;

    [Required]
    public int RoleId { get; set; } 
}