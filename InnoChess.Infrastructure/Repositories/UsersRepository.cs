using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;

namespace InnoChess.Infrastructure.Repositories;

public class UsersRepository(InnoChessDbContext context) : RepositoryBase<UserEntity>(context), IUsersRepository
{
    public Task<List<UserEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
