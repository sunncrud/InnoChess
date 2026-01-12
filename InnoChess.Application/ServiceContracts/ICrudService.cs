using InnoChess.Application.Pagination;

namespace InnoChess.Application.ServiceContracts;

public interface ICrudService<in TRequest, TResponse, TKey>
{
    Task<PagedResult<TResponse>> GetAllAsync(PageParams parameters, CancellationToken cancellationToken);
    Task<TResponse?> GetByIdAsync(TKey id, CancellationToken cancellationToken);
    Task<TKey> CreateAsync(TRequest request, CancellationToken cancellationToken);
    Task<TResponse> UpdateAsync(TRequest request, CancellationToken cancellationToken);
    Task<TKey> DeleteAsync(TKey id, CancellationToken cancellationToken);
}