using InnoChess.Application.DTO.LocationDto;

namespace InnoChess.Application.ServiceContracts;

public interface ILocationService
{ 
    public Task<LocationResponse?> GetLocationByNameAsync(string name, CancellationToken cancellationToken);
    public Task<LocationResponse?> GetLocationByDescriptionAsync(string description, CancellationToken cancellationToken);

}
