using InnoChess.Application.DTO;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Infrastructure.Repositories;

public class UserRepository(InnoChessDbContext context) : RepositoryBase<UserEntity, Guid>(context), IUserRepository
{
    private readonly InnoChessDbContext _context = context;

    public async Task<UserEntity?> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.Equals(email), cancellationToken);
    }
}
