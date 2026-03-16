using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using InnoNuggetPackage.Repositories;

namespace InnoChess.Infrastructure.Repositories;

public class UserInSessionRepository(InnoChessDbContext context) : BaseRepository<UserInSessionEntity>(context), IUserInSessionRepository
{
    
}
