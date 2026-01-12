using InnoChess.Application.DTO.LocationDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.Pagination;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Application.Services;

public class LocationService(ILocationRepository locationRepository, ILocationMapper locationMapper) : ILocationService
{
    public async Task<PagedResult<LocationResponse>> GetAllAsync(
        PageParams pageParams, 
        CancellationToken cancellationToken)
    {
        var query = locationRepository.GetQueryable();
        var total = await query.CountAsync(cancellationToken);
        
        var pagedEntities = await query
            .Skip((pageParams.Page - 1) * pageParams.PageSize)
            .Take(pageParams.PageSize)
            .ToListAsync(cancellationToken);
        
        var mappedItems = pagedEntities
            .Select(locationMapper.FromEntityToResponse)
            .ToList();

        return new PagedResult<LocationResponse>(mappedItems, total);
    }

    public async Task<LocationResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await locationRepository.GetByIdAsync(id, cancellationToken);
        if (entity == null)
            return null;

        var user = locationMapper.FromEntityToResponse(entity);
        return user;
    }

    public async Task<Guid> CreateAsync(LocationRequest request, CancellationToken cancellationToken)
    {
        var entity = locationMapper.FromRequestToEntity(request);
        await locationRepository.CreateAsync(entity, cancellationToken);
        return entity.Id;   
    }

    public async Task<LocationResponse> UpdateAsync(LocationRequest request, CancellationToken cancellationToken)
    {
        var entity = locationMapper.FromRequestToEntity(request);
        await locationRepository.UpdateAsync(entity, cancellationToken);
        return locationMapper.FromEntityToResponse(entity);
    }

    public async Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await locationRepository.DeleteAsync(id, cancellationToken);
        return id;
    }
    
    
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
