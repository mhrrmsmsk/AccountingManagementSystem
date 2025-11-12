using AccountSystem.Dtos.User;
using AccountSystem.Entities;

namespace AccountSystem.Mappers;

public static class UserMapper
{
    public static UserResponseDto ToUserResponseDto(this User user)
    {
        return new UserResponseDto
        {
            Id        = user.Id,
            CompanyId = user.CompanyId,
            FullName  = user.FullName,
            Email     = user.Email,
            RoleId    = user.RoleId,
            Status    = user.Status,
            LastLogin = user.LastLogin,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }

    public static User ToUserFromCreateDto(this RegisterDto dto)
    {
        return new User
        {
            UserName  = dto.Email, 
            Email     = dto.Email,
            FullName  = dto.FullName,
            CompanyId = dto.CompanyId,
            RoleId    = dto.RoleId,
            Status    = true,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            DeletedAt = null
        };
    }
    public static void UpdateUserFromDto(this User user, UpdateUserDto dto)
    {
        user.FullName  = dto.FullName;
        user.Email     = dto.Email;
        user.UserName  = dto.Email; 
        user.CompanyId = dto.CompanyId;
        user.RoleId    = dto.RoleId;
        user.Status    = dto.Status;
        user.UpdatedAt = DateTime.Now;
    }
}