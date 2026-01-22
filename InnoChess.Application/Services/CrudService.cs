﻿using InnoChess.Application.DTO;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.Mappings;
using InnoChess.Application.Pagination;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.Models;
using InnoChess.Domain.Primitives;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Application.Services;

public class CrudService<TRequest, TResponse, TEntity, TMapper>(IRepositoryBase<TEntity> repository, TMapper mapper)
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
        var entity = await repository.GetByIdAsync(id, cancellationToken);
        if (entity == null)
            return null;

        var user = mapper.FromEntityToResponse(entity);
        return user;
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
        return mapper.FromEntityToResponse(entity);
    }

    public async Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(id, cancellationToken);
        return id;
    }
}