using InnoChess.Application.Pagination;

namespace InnoChess.Application.ServiceContracts;

public interface ICrudService<in TRequest, TResponse>
{
    Task<PagedResult<TResponse>> GetAllAsync(PageParams parameters, CancellationToken cancellationToken);
    Task<TResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Guid> CreateAsync(TRequest request, CancellationToken cancellationToken);
    Task<TResponse> UpdateAsync(TRequest request, CancellationToken cancellationToken);
    Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken);
}