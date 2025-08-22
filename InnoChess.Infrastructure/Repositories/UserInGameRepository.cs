using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;

namespace InnoChess.Infrastructure.Repositories;

public class UserInGameRepository(InnoChessDbContext context) : RepositoryBase<UserInGameEntity>(context), IUserInGameRepository
{
    
}
