using InnoChess.Application.Caching; 
using InnoChess.Application.DTO.LocationDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;

namespace InnoChess.Application.Services;

public class LocationService(
    ILocationRepository locationRepository,
    ILocationMapper locationMapper, 
    ICacheService cacheService) 
    : CrudService<LocationRequest, LocationResponse, LocationEntity, ILocationMapper>
        (locationRepository, locationMapper, cacheService), ILocationService
{

    public async Task<LocationResponse?> GetLocationByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await GetCachedResultAsync(
            $"location-name-{name}", 
            ct => locationRepository.GetByNameAsync(name, ct), 
            cancellationToken);
    }

    public async Task<LocationResponse?> GetLocationByDescriptionAsync(string description, CancellationToken cancellationToken)
    {
        return await GetCachedResultAsync(
            $"location-description-{description}",
            ct => locationRepository.GetByDescriptionAsync(description, ct),
            cancellationToken);
    }
}