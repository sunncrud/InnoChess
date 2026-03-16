using InnoChess.Application.DTO.SessionDto;
using InnoNuggetPackage.ServiceContracts;

namespace InnoChess.Application.ServiceContracts;

public interface ISessionService : ICrudService<SessionRequest, SessionResponse>
{
    public Task<List<SessionResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
}