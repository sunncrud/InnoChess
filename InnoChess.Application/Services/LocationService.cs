using InnoChess.Application.DTO.LocationDto;
using InnoChess.Application.Mappings;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.RepositoryContracts;

namespace InnoChess.Application.Services;

public class LocationService(ILocationRepository repository, LocationMapper mapper) : ILocationService
{
    public async Task<LocationResponse?> GetLocationByNameAsync(string name, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByNameAsync(name, cancellationToken);
        return mapper.FromEntityToResponse(entity);
    }

    public async Task<LocationResponse?> GetLocationByDescriptionAsync(string description, CancellationToken cancellationToken)
    {
        var entities = await repository.GetByDescriptionAsync(description, cancellationToken);
        return mapper.FromEntityToResponse(entities);
    }
}
