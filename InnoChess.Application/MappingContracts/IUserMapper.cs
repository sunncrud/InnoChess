using InnoChess.Application.DTO.UserDto;
using InnoChess.Domain.Models;
using InnoNuggetPackage.Mappers;

namespace InnoChess.Application.MappingContracts;

public interface IUserMapper : IBaseMapper<UserRequest, UserResponse, UserEntity>
{
    
}