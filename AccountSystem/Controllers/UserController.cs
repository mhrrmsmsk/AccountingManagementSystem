using AccountSystem.Dtos.User;
using AccountSystem.Entities;
using AccountSystem.Interfaces;
using AccountSystem.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccountSystem.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepo;
    public UserController(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userRepo.GetAllAsync();
        var userDto = users.Select(u => u.ToUserResponseDto());
        return Ok(userDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userRepo.GetByIdAsync(id);
        if (user == null)
            return NotFound(new { message = "User not found" });

        return Ok(user.ToUserResponseDto());
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto dto)
    {
        var existingUser = await _userRepo.GetByIdAsync(id);
        if (existingUser == null)
            return NotFound("User not found");

        
        existingUser.UpdateUserFromDto(dto);

        var user = await _userRepo.UpdateAsync(id, existingUser);
        return Ok(user.ToUserResponseDto());
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _userRepo.DeleteAsync(id);
        if (user == null)
            return NotFound("User not found");

        return Ok(user.ToUserResponseDto());
    }
}