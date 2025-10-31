using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;

namespace InnoChess.Infrastructure.Repositories;

public class UserInSessionRepository(InnoChessDbContext context) : RepositoryBase<UserInSession, Guid>(context), IUserInGameRepository
{
    
}
