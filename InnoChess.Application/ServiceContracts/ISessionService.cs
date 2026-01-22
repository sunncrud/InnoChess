using InnoChess.Application.DTO.SessionDto;
using InnoChess.Application.Pagination;

namespace InnoChess.Application.ServiceContracts;

public interface ISessionService
{
    public Task<List<SessionResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
}