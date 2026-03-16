using InnoChess.Application.DTO.LocationDto;
using InnoNuggetPackage.ServiceContracts;

namespace InnoChess.Application.ServiceContracts;

public interface ILocationService : ICrudService<LocationRequest, LocationResponse>
{
    public Task<LocationResponse?> GetLocationByNameAsync(string name, CancellationToken cancellationToken);
    public Task<LocationResponse?> GetLocationByDescriptionAsync(string description, CancellationToken cancellationToken);

}
