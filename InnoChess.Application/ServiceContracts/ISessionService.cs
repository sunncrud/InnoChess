using InnoChess.Application.DTO.SessionDto;

namespace InnoChess.Application.ServiceContracts;

public interface ISessionService
{
    public Task<List<SessionResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
}