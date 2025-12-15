using InnoChess.Application.DTO.UserDto;
using InnoChess.Application.Mappings;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;

namespace InnoChess.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    
}
