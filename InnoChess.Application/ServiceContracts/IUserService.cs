using InnoChess.Application.DTO.UserDto;
using InnoChess.Application.Pagination;

namespace InnoChess.Application.ServiceContracts;

public interface IUserService : ICrudService<UserRequest, UserResponse>
{
    public Task Register(string userName, string email, string password, CancellationToken cancellationToken);
    public Task<string> Login(string email, string password, CancellationToken cancellationToken);
}