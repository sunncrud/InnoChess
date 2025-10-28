using InnoChess.Application.DTO;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.Mappings;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;

namespace InnoChess.Application.Services;

public class CrudService<TRequest, TResponse, TEntity, TMapper, TKey>(IRepositoryBase<TEntity, TKey> repository, TMapper mapper)
    : ICrudService<TRequest, TResponse, TKey>
    where TEntity : Entity<TKey>
    where TRequest : BaseDto
    where TResponse : BaseDto
    where TMapper : IBaseMapper<TRequest, TResponse, TEntity>
{
    public async Task<List<TResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await repository.GetAllAsync(cancellationToken);
        return entities
            .Select(mapper.FromEntityToResponse)
            .ToList();
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