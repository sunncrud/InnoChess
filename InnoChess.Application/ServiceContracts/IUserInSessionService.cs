using InnoChess.Application.DTO.SessionDto;
using InnoChess.Application.DTO.UserInGameDto;
using InnoChess.Application.Pagination;

namespace InnoChess.Application.ServiceContracts;

public interface IUserInSessionService
{
    Task<PagedResult<UserInSessionResponse>> GetAllAsync(PageParams parameters, CancellationToken cancellationToken);
    Task<UserInSessionResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Guid> CreateAsync(UserInSessionRequest request, CancellationToken cancellationToken);
    Task<UserInSessionResponse> UpdateAsync(UserInSessionRequest request, CancellationToken cancellationToken);
    Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken);
}