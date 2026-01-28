using InnoChess.Application.DTO;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.Pagination;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.Primitives;
using InnoChess.Domain.RepositoryContracts;
using InnoChess.Application.Caching; 
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Application.Services;

public class CrudService<TRequest, TResponse, TEntity, TMapper>(
    IRepositoryBase<TEntity> repository, 
    TMapper mapper,
    ICacheService cacheService) 
    : ICrudService<TRequest, TResponse>
    where TEntity : IEntity
    where TRequest : BaseDto
    where TResponse : BaseDto
    where TMapper : IBaseMapper<TRequest, TResponse, TEntity>
{
    public async Task<PagedResult<TResponse>> GetAllAsync(
        PageParams pageParams, 
        CancellationToken cancellationToken)
    {
        var query = repository.GetQueryable();
        var total = await query.CountAsync(cancellationToken);
        
        var pagedEntities = await query
            .Skip((pageParams.Page - 1) * pageParams.PageSize)
            .Take(pageParams.PageSize)
            .ToListAsync(cancellationToken);

        var mappedItems = pagedEntities
            .Select(mapper.FromEntityToResponse)
            .ToList();

        return new PagedResult<TResponse>(mappedItems, total);
    }

    public async Task<TResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        string key = $"{typeof(TEntity).Name.ToLower()}-{id}";

        return await cacheService.GetOrCreateAsync(
            key,
            async (ct) => 
            {
                var entity = await repository.GetByIdAsync(id, ct);
                if (entity == null)
                    return null;

                return mapper.FromEntityToResponse(entity);
            },
            null, 
            cancellationToken);
    }

    public async Task<Guid> CreateAsync(TRequest request, CancellationToken cancellationToken)
    {
        var entity = mapper.FromRequestToEntity(request);
        await repository.CreateAsync(entity, cancellationToken);
        return entity.Id;   
    }
    
    public async Task<TResponse> UpdateAsync(TRequest request, CancellationToken cancellationToken)
    {
        var entity = mapper.FromRequestToEntity(request);
        await repository.UpdateAsync(entity, cancellationToken);
        
        string key = $"{typeof(TEntity).Name.ToLower()}-{entity.Id}";
        cacheService.Remove(key);

        return mapper.FromEntityToResponse(entity);
    }
    
    public async Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(id, cancellationToken);
        
        string key = $"{typeof(TEntity).Name.ToLower()}-{id}";
        cacheService.Remove(key);
        
        return id;
    }
}