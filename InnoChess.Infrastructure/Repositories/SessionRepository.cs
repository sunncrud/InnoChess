﻿using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Infrastructure.Repositories;

public class SessionRepository(InnoChessDbContext context) : RepositoryBase<SessionEntity>(context), ISessionRepository
{
    public async Task<List<SessionEntity>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        return await _context.Sessions
            .AsNoTracking()
            .Where(s => s.IsActive)
            .ToListAsync(cancellationToken);
    }
}
