using AccountSystem.Dtos.User;
using AccountSystem.Entities;
using AccountSystem.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccountSystem.Controllers;
[Route("api/auth")]
[ApiController]
public class AuthController:ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    
    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = dto.ToUserFromCreateDto();
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }
        return Ok(new { message = "User created successfully", userId = user.Id }); 
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        var user = await _userManager.Users.Where(u=>u.DeletedAt==null).FirstOrDefaultAsync(u=>u.UserName.ToLower()==dto.Username.ToLower());
        if(user==null)
            return Unauthorized("Invalid username");
        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

        if (!result.Succeeded)
        {
            return Unauthorized("Username not found or/and password not correct!");
        }
        else
        {
            return Ok(
                new NewUserDto
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Token = "1234"
                }
            );
        }
    }
    
}