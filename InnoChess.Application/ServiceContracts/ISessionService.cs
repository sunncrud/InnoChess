using InnoChess.Application.DTO.SessionDto;
using InnoChess.Application.Pagination;

namespace InnoChess.Application.ServiceContracts;

public interface ISessionService
{
    Task<PagedResult<SessionResponse>> GetAllAsync(PageParams parameters, CancellationToken cancellationToken);
    Task<SessionResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Guid> CreateAsync(SessionRequest request, CancellationToken cancellationToken);
    Task<SessionResponse> UpdateAsync(SessionRequest request, CancellationToken cancellationToken);
    Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken);
    public Task<List<SessionResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
}