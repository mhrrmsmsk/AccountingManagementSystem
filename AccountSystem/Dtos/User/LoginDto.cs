using System.ComponentModel.DataAnnotations;

namespace AccountSystem.Dtos.User;

public class LoginDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}