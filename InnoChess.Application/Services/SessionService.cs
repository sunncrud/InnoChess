using InnoChess.Application.Caching;
using InnoChess.Application.DTO.SessionDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.Pagination;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Application.Services;

public class SessionService(ISessionRepository sessionRepository, ISessionMapper sessionMapper, ICacheService  cacheService) 
    : CrudService<SessionRequest, SessionResponse,SessionEntity,ISessionMapper>
    (sessionRepository, sessionMapper, cacheService), ISessionService
{

    public async Task<List<SessionResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await sessionRepository.GetAllActiveAsync(cancellationToken);
        return entities
            .Select (Mapper.FromEntityToResponse)
            .ToList();
    }
}