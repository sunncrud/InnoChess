using InnoChess.Application.DTO;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

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

        return users.Select(u => new UserResponse
        {
            Id = u.Id,
            UserName = u.UserName,
            Email = u.Email
        }).ToList();
    }
    public async Task<Guid> CreateUserAsync(UserRequest user, CancellationToken cancellationToken)
    {
        var entity = new UserEntity
        {
            Id = Guid.NewGuid(),
            Email = user.Email,
            UserName = user.UserName,
            Password = user.PasswordHash
        };
        await _userRepository.CreateAsync(entity, cancellationToken);

        return entity.Id;   
    }



    public Task<UserEntity?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
