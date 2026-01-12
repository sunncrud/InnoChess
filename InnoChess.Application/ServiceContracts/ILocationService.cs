using InnoChess.Application.DTO.LocationDto;
using InnoChess.Application.Pagination;

namespace InnoChess.Application.ServiceContracts;

public interface ILocationService
{ 
    Task<PagedResult<LocationResponse>> GetAllAsync(PageParams parameters, CancellationToken cancellationToken);
    Task<LocationResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Guid> CreateAsync(LocationRequest request, CancellationToken cancellationToken);
    Task<LocationResponse> UpdateAsync(LocationRequest request, CancellationToken cancellationToken);
    Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken);
    public Task<LocationResponse?> GetLocationByNameAsync(string name, CancellationToken cancellationToken);
    public Task<LocationResponse?> GetLocationByDescriptionAsync(string description, CancellationToken cancellationToken);

}
