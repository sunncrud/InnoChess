namespace InnoChess.Application.ServiceContracts;

public interface ICrudService<in TRequest, TResponse, TKey>
{
    Task<List<TResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<TResponse?> GetByIdAsync(TKey id, CancellationToken cancellationToken);
    Task<TKey> CreateAsync(TRequest request, CancellationToken cancellationToken);
    Task<TResponse> UpdateAsync(TRequest request, CancellationToken cancellationToken);
    Task<TKey> DeleteAsync(TKey id, CancellationToken cancellationToken);
}