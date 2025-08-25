using InnoChess.Application.DTO.LocationDto;

namespace InnoChess.Application.ServiceContracts;

public interface ILocationService
{
    public Task<List<LocationResponse>> GetAllLocationsAsync(CancellationToken cancellationToken);
    public Task<LocationResponse?> GetLocationByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<LocationResponse?> GetLocationByNameAsync(string name, CancellationToken cancellationToken);
    public Task<LocationResponse?> GetLocationByDescriptionAsync(string description, CancellationToken cancellationToken);
    public Task<Guid> CreateLocaitonAsync(LocationRequest location, CancellationToken cancellationToken);
    public Task DeleteLocationAsync(Guid id, CancellationToken cancellationToken);
}
