using InnoChess.Domain.Models;

namespace InnoChess.Domain.RepositoryContracts;

public interface IRepositoryBase<TEntity, TKey>
    where TEntity : Entity<TKey>
{
    public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken);
    public Task<TKey> CreateAsync(TEntity entity, CancellationToken cancellationToken);
    public Task<TKey?> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    public Task<TKey?> DeleteAsync(TKey id, CancellationToken cancellationToken);
    public Task SaveAsync(CancellationToken cancellationToken);
}
