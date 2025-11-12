using AccountSystem.Entities;
using AccountSystem.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AccountSystem.Repository;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;

    public UserRepository(UserManager<User> usermanager)
    {
        _userManager = usermanager;
    }
    public async Task<List<User>> GetAllAsync()
    {
        return await _userManager.Users.Where(u => u.DeletedAt == null).ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _userManager.Users.Where(u=>u.DeletedAt==null).SingleOrDefaultAsync(u => u.Id == id);
        if (user == null)
            return null;
        return user;
    }

    public async Task<User?> UpdateAsync(int id, User updatedUser)
    {
        var existingUser = await _userManager.Users
            .Where(u => u.DeletedAt == null)
            .SingleOrDefaultAsync(u => u.Id == id);

        if (existingUser == null)
            return null;
        
        existingUser.FullName  = updatedUser.FullName;
        existingUser.Email     = updatedUser.Email;
        existingUser.UserName  = updatedUser.Email;
        existingUser.CompanyId = updatedUser.CompanyId;
        existingUser.RoleId    = updatedUser.RoleId;
        existingUser.Status    = updatedUser.Status;
        existingUser.UpdatedAt = DateTime.Now;

        var result = await _userManager.UpdateAsync(existingUser);

        if (!result.Succeeded)
            throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

        return existingUser;
    }

    public async Task<User?> DeleteAsync(int id)
    {
        var user = await _userManager.Users
            .SingleOrDefaultAsync(u => u.Id == id && u.DeletedAt == null);

        if (user == null)
            return null;

        user.DeletedAt = DateTime.Now;
        user.Status = false;

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
            throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

        return user;
    }
}