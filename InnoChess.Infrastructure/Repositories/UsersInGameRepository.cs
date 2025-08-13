using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;

namespace InnoChess.Infrastructure.Repositories;

public class UsersInGameRepository(InnoChessDbContext context) : RepositoryBase<UsersInGameRepository>(context), IUsersInGameRepository
{
    public Task CreateAsync(UserInGameEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(UserInGameEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserInGameEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(UserInGameEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
