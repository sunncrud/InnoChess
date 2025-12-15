using InnoChess.Domain.Models;

namespace InnoChess.Domain.RepositoryContracts;

public interface IUserRepository : IRepositoryBase<UserEntity, Guid>
{
    
}
