using InnoChess.Domain.Models;
using InnoChess.Domain.Primitives;

namespace InnoChess.Domain.RepositoryContracts;

public interface IRepositoryBase<TEntity>
    where TEntity : class, IEntity<Guid>
{
    public IQueryable<TEntity> GetQueryable();
    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<Guid> CreateAsync(TEntity entity, CancellationToken cancellationToken);
    public Task<Guid?> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    public Task<Guid?> DeleteAsync(Guid id, CancellationToken cancellationToken);
    public Task SaveAsync(CancellationToken cancellationToken);
}
