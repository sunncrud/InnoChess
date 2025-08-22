using InnoChess.Application.DTO;
using InnoChess.Domain.Models;

namespace InnoChess.Application.ServiceContracts;

public interface IUserService 
{
    Task<Guid> CreateUserAsync(UserRequest user, CancellationToken cancellationToken);
    Task<List<UserResponse>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task<UserEntity?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
}
