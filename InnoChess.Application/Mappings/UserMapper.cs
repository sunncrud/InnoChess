using InnoChess.Application.DTO.UserDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Domain.Models;

namespace InnoChess.Application.Mappings;

public class UserMapper : IUserMapper
{
    
    public UserEntity FromRequestToEntity(UserRequest request)
    {
        return new UserEntity
        {
            UserName = request.UserName,
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
