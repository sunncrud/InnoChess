using InnoChess.Application.DTO.UserDto;
using InnoChess.Application.Mappings;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;

namespace InnoChess.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<List<UserResponse>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        return users
            .Select(UserMapper.ToResponse)
            .ToList();
    }
    public async Task<Guid> CreateUserAsync(UserEntity user, CancellationToken cancellationToken)
    {
        await _userRepository.CreateAsync(user, cancellationToken);
        return user.Id;   
    }
    public async Task<UserResponse?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _userRepository.GetByIdAsync(id, cancellationToken);

        if (entity == null)
            return null;

        var user = UserMapper.ToResponse(entity);

        return user;
    }

    public async Task DeleteUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);

        if (user == null)
        {
            throw new KeyNotFoundException($"User with ID {id} was not found.");
        }

        await _userRepository.DeleteAsync(user, cancellationToken);
    }
}
