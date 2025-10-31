using InnoChess.Domain.Models;

namespace InnoChess.Domain.RepositoryContracts;

public interface IUserInGameRepository : IRepositoryBase<UserInSession, Guid>
{
    
}
