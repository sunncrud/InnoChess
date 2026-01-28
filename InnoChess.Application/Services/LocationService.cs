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
    private readonly ICacheService _cacheService = cacheService;
    private readonly ILocationMapper _locationMapper = locationMapper;

    public async Task<LocationResponse?> GetLocationByNameAsync(string name, CancellationToken cancellationToken)
    {
        string key = $"location-name-{name}";
        
        return await _cacheService.GetOrCreateAsync(key, async ct => 
            {
                var entity = await locationRepository.GetByNameAsync(name, ct);
                if (entity == null) return null;
            
                return _locationMapper.FromEntityToResponse(entity);
            }, 
            null, 
            cancellationToken);
    }

    public async Task<LocationResponse?> GetLocationByDescriptionAsync(string description, CancellationToken cancellationToken)
    {
        string key = $"location-description-{description}";
        
        return await _cacheService.GetOrCreateAsync(key, async ct => 
            {
                var entity = await locationRepository.GetByDescriptionAsync(description, ct);
                if (entity == null) return null;
            
                return _locationMapper.FromEntityToResponse(entity);
            }, 
            null, 
            cancellationToken);
    }
}