using InnoChess.Application.DTO;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Infrastructure.Repositories;

public class UserRepository(InnoChessDbContext context) : RepositoryBase<UserEntity>(context), IUserRepository
{
    //public async Task<UserEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    //{
    //     await _context.Set<UserEntity>() // from RepositoryBase
    //           .AsNoTracking()                    // no change tracking for read-only
    //           .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    //    return 
    //}
}
