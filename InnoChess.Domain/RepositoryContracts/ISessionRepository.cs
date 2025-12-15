using InnoChess.Domain.Models;

namespace InnoChess.Domain.RepositoryContracts;

public interface ISessionRepository : IRepositoryBase<SessionEntity, Guid>
{
    public Task<List<SessionEntity>> GetAllActiveAsync(CancellationToken cancellationToken);
}
