using AccountSystem.Entities;

namespace AccountSystem.Interfaces;

public interface IUserRepository
{
    public Task<List<User>> GetAllAsync();
    public Task<User?> GetByIdAsync(int id);
    public Task<User> UpdateAsync(int id,User user);
    public Task<User> DeleteAsync(int id);
}