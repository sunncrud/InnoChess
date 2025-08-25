using InnoChess.Application.DTO.UserDto;
using InnoChess.Domain.Models;

namespace InnoChess.Application.ServiceContracts;

public interface IUserService 
{
    Task<List<UserResponse>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task<UserResponse?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Guid> CreateUserAsync(UserEntity user, CancellationToken cancellationToken);
    Task DeleteUserAsync(Guid id, CancellationToken cancellationToken);
}
