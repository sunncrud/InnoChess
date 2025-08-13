using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;

namespace InnoChess.Infrastructure.Repositories;

public class SessionsRepository(InnoChessDbContext context) : RepositoryBase<SessionEntity>(context), ISessionsRepository
{
    public Task<List<SessionEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
