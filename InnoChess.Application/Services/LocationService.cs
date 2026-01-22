using InnoChess.Application.DTO.LocationDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.Pagination;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Application.Services;

public class LocationService(ILocationRepository locationRepository, ILocationMapper locationMapper) : ILocationService
{
    
    public async Task<LocationResponse?> GetLocationByNameAsync(string name, CancellationToken cancellationToken)
    {
        var entity = await locationRepository.GetByNameAsync(name, cancellationToken);
        return locationMapper.FromEntityToResponse(entity);
    }

    public async Task<LocationResponse?> GetLocationByDescriptionAsync(string description, CancellationToken cancellationToken)
    {
        var entities = await locationRepository.GetByDescriptionAsync(description, cancellationToken);
        return locationMapper.FromEntityToResponse(entities);
    }
}
