using InnoChess.Domain.Models;

namespace InnoChess.Domain.RepositoryContracts;

public interface IUserRepository : IRepositoryBase<UserEntity>
{
    public Task<UserEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
