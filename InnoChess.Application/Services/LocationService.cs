using InnoChess.Application.DTO.LocationDto;
using InnoChess.Application.DTO.UserDto;
using InnoChess.Application.Mappings;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;

namespace InnoChess.Infrastructure.Services;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;

    public LocationService(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<List<LocationResponse>> GetAllLocationsAsync(CancellationToken cancellationToken)
    {
        var locations = await _locationRepository.GetAllAsync(cancellationToken);
        return locations
            .Select(LocationMapper.FromEntityToResponse)
            .ToList();
    }
    public async Task<LocationResponse?> GetLocationByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _locationRepository.GetByIdAsync(id, cancellationToken);

        if (entity == null) return null;

        var location = LocationMapper.FromEntityToResponse(entity);

        return location;
    }
    public async Task<LocationResponse?> GetLocationByNameAsync(string name, CancellationToken cancellationToken)
    {
        var entity = await _locationRepository.GetByNameAsync(name, cancellationToken);

        if (entity == null) return null;

        var location = LocationMapper.FromEntityToResponse(entity);

        return location;
    }
    public async Task<LocationResponse?> GetLocationByDescriptionAsync(string description, CancellationToken cancellationToken)
    {
        var entity = await _locationRepository.GetByDescriptionAsync(description, cancellationToken);

        if (entity == null) return null;

        var location = new LocationResponse
        {
            Name = entity.Name,
            Description = entity.Description,
            MaxPlayers = entity.MaxPlayers,
        };

        return location;
    }
    public async Task<Guid> CreateLocaitonAsync(LocationRequest location, CancellationToken cancellationToken)
    {
        var entity = LocationMapper.FromRequestToEntity(location);

        await _locationRepository.CreateAsync(entity, cancellationToken);
        return entity.Id;
    }

    public async Task DeleteLocationAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _locationRepository.GetByIdAsync(id, cancellationToken);

        if (entity == null)
        {
            throw new KeyNotFoundException($"Location with ID {id} was not found.");
        }

        await _locationRepository.DeleteAsync(entity, cancellationToken);
    }

}
