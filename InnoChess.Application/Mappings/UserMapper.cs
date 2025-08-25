using InnoChess.Application.DTO.UserDto;
using InnoChess.Domain.Models;

namespace InnoChess.Application.Mappings;

public class UserMapper
{
    private static UserRequest.UserRole ParseRole(string? roleString)
    {
        return Enum.TryParse<UserRequest.UserRole>(roleString, true, out var role)
            ? role
            : UserRequest.UserRole.User; 
    }
    public static UserRequest ToRequest(UserEntity entity)
    {
        return new UserRequest
        {
            UserName = entity.UserName,
            Email = entity.Email,
            PasswordHash = entity.Password,
            Role = ParseRole(entity.Role)
        };
    }
    public static UserEntity ToEntity(UserRequest request)
    {
        return new UserEntity
        {
            Id = Guid.NewGuid(),
            UserName = request.UserName,
            Email = request.Email,
            Password = request.PasswordHash,
            Role = request.Role.ToString()
        };
    }
    public static UserResponse ToResponse(UserEntity entity)
    {
        return new UserResponse
        {
            Id = entity.Id,
            UserName = entity.UserName,
            Email = entity.Email
        };
    }
}
