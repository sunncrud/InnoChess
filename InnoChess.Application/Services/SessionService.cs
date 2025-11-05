using InnoChess.Application.DTO.SessionDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.RepositoryContracts;

namespace InnoChess.Application.Services;

public class SessionService(ISessionRepository repository, ISessionMapper mapper) : ISessionService
{
    public async Task<List<SessionResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await repository.GetAllActiveAsync(cancellationToken);
        return entities
            .Select (mapper.FromEntityToResponse)
            .ToList();
    }
}