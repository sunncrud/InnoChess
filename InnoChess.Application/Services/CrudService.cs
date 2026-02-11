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
    protected readonly TMapper Mapper = mapper;

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
            .Select(Mapper.FromEntityToResponse)
            .ToList();

        return new PagedResult<TResponse>(mappedItems, total);
    }

    public async Task<TResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var key = GetCacheKey(id);

        return await GetCachedResultAsync(
            key,
            ct => repository.GetByIdAsync(id, ct),
            cancellationToken
        );
    }

    public async Task<Guid> CreateAsync(TRequest request, CancellationToken cancellationToken)
    {
        var entity = Mapper.FromRequestToEntity(request);
        await repository.CreateAsync(entity, cancellationToken);
        return entity.Id;   
    }
    
    public async Task<TResponse> UpdateAsync(TRequest request, CancellationToken cancellationToken)
    {
        var entity = Mapper.FromRequestToEntity(request);
        await repository.UpdateAsync(entity, cancellationToken);
        
        InvalidateCache(entity.Id);

        return Mapper.FromEntityToResponse(entity);
    }
    
    public async Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(id, cancellationToken);
        InvalidateCache(id);
        
        return id;
    }
    
    protected async Task<TResponse?> GetCachedResultAsync(
        string key,
        Func<CancellationToken, Task<TEntity?>> fetchEntity,
        CancellationToken cancellationToken,
        TimeSpan? expiration = null)
    {
        return await cacheService.GetOrCreateAsync(key, async ct =>
            {
                var entity = await fetchEntity(ct);
                return entity == null ? null : Mapper.FromEntityToResponse(entity);
            }, 
            expiration, 
            cancellationToken);
    }
    private static string GetCacheKey(Guid id) 
    {
        return $"{typeof(TEntity).Name.ToLower()}-{id}";
    }

    private void InvalidateCache(Guid id)
    {
        var key = GetCacheKey(id);
        cacheService.Remove(key);
    }
}