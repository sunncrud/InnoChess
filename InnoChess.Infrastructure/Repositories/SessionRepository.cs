using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using InnoNuggetPackage.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Infrastructure.Repositories;

public class SessionRepository(InnoChessDbContext context) : BaseRepository<SessionEntity>(context), ISessionRepository
{
    private readonly InnoChessDbContext _context = context;

    public async Task<List<SessionEntity>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        return await _context.Sessions
            .AsNoTracking()
            .Where(s => s.IsActive)
            .ToListAsync(cancellationToken);
    }
}
