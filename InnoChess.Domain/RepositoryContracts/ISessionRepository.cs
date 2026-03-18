using InnoChess.Domain.Models;
using InnoNuggetPackage.RepositoryContracts;

namespace InnoChess.Domain.RepositoryContracts;

public interface ISessionRepository : IBaseRepository<SessionEntity>
{
    public Task<List<SessionEntity>> GetAllActiveAsync(CancellationToken cancellationToken);
}
