using InnoChess.Domain.Models;
using InnoNuggetPackage.RepositoryContracts;

namespace InnoChess.Domain.RepositoryContracts;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    public Task<UserEntity?> GetByEmail(string email, CancellationToken cancellationToken);
}
