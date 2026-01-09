using InnoChess.Application.DTO.UserDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Domain.Models;

namespace InnoChess.Application.Mappings;

public class UserMapper : IUserMapper
{
    private static UserRequest.UserRole ParseRole(string? roleString)
    {
        return Enum.TryParse<UserRequest.UserRole>(roleString, true, out var role)
            ? role
            : UserRequest.UserRole.User; 
    }
    
    public UserEntity FromRequestToEntity(UserRequest request)
    {
        return new UserEntity
        {
            Id = Guid.NewGuid(),
            UserName = request.UserName,
            Email = request.Email,
            PasswordHash = request.PasswordHash,
            Role = request.Role.ToString()
        };
    }
    public UserResponse FromEntityToResponse(UserEntity entity)
    {
        return new UserResponse
        {
            Id = entity.Id,
            UserName = entity.UserName,
            Email = entity.Email
        };
    }
}
