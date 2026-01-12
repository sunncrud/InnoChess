using InnoChess.Application.DTO;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.Mappings;
using InnoChess.Application.Pagination;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Application.Services;

public class CrudService<TRequest, TResponse, TEntity, TMapper, TKey>(IRepositoryBase<TEntity, TKey> repository, TMapper mapper)
    : ICrudService<TRequest, TResponse, TKey>
    where TEntity : Entity<TKey>
    where TRequest : BaseDto
    where TResponse : BaseDto
    where TMapper : IBaseMapper<TRequest, TResponse, TEntity>
{
    public async Task<PagedResult<TResponse>> GetAllAsync(
        PageParams pageParams, 
        CancellationToken cancellationToken)
    {
        var query = repository.GetQueryable();

        // 2. Get Total Count (Database Hit #1)
        var total = await query.CountAsync(cancellationToken);

        // 3. Get Specific Page (Database Hit #2)
        // We apply Skip/Take on the Entity *before* fetching
        var pagedEntities = await query
            .Skip((pageParams.Page - 1) * pageParams.PageSize)
            .Take(pageParams.PageSize)
            .ToListAsync(cancellationToken);

        // 4. Map the small list of results
        var mappedItems = pagedEntities
            .Select(mapper.FromEntityToResponse)
            .ToList();

        // 5. Return wrapper
        return new PagedResult<TResponse>(mappedItems, total);
    }

    public async Task<TResponse?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(id, cancellationToken);
        if (entity == null)
            return null;

        var user = mapper.FromEntityToResponse(entity);
        return user;
    }

    public async Task<TKey> CreateAsync(TRequest request, CancellationToken cancellationToken)
    {
        var entity = mapper.FromRequestToEntity(request);
        await repository.CreateAsync(entity, cancellationToken);
        return entity.Id;   
    }

    public async Task<TResponse> UpdateAsync(TRequest request, CancellationToken cancellationToken)
    {
        var entity = mapper.FromRequestToEntity(request);
        await repository.UpdateAsync(entity, cancellationToken);
        return mapper.FromEntityToResponse(entity);
    }

    public async Task<TKey> DeleteAsync(TKey id, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(id, cancellationToken);
        return id;
    }
}