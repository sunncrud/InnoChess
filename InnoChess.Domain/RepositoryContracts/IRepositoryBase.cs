namespace InnoChess.Domain.RepositoryContracts;

public interface IRepositoryBase<T> where T : class
{
    public Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    //public Task GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task CreateAsync(T entity, CancellationToken cancellationToken);
    public Task UpdateAsync(T entity, CancellationToken cancellationToken);
    public Task DeleteAsync(T entity, CancellationToken cancellationToken);
}
