using InnoChess.Application.DTO.SessionDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.Pagination;
using InnoChess.Domain.Models;

namespace InnoChess.Application.ServiceContracts;

public interface ISessionService : ICrudService<SessionRequest, SessionResponse>
{
    public Task<List<SessionResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
}