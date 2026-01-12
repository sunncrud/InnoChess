using InnoChess.Application.DTO.UserDto;
using InnoChess.Application.Pagination;

namespace InnoChess.Application.ServiceContracts;

public interface IUserService
{
    Task<PagedResult<UserResponse>> GetAllAsync(PageParams parameters, CancellationToken cancellationToken);
    Task<UserResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Guid> CreateAsync(UserRequest request, CancellationToken cancellationToken);
    Task<UserResponse> UpdateAsync(UserRequest request, CancellationToken cancellationToken);
    Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken);
    public Task Register(string userName, string email, string password, CancellationToken cancellationToken);
    public Task<string> Login(string email, string password, CancellationToken cancellationToken);
}