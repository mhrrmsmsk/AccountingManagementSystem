using AccountSystem.Entities;

namespace AccountSystem.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}