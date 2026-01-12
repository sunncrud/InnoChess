using InnoChess.Application.DTO.SessionDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.Pagination;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Application.Services;

public class SessionService(ISessionRepository sessionRepository, ISessionMapper sessionMapper) : ISessionService
{
    public async Task<PagedResult<SessionResponse>> GetAllAsync(
        PageParams pageParams, 
        CancellationToken cancellationToken)
    {
        var query = sessionRepository.GetQueryable();
        var total = await query.CountAsync(cancellationToken);
        
        var pagedEntities = await query
            .Skip((pageParams.Page - 1) * pageParams.PageSize)
            .Take(pageParams.PageSize)
            .ToListAsync(cancellationToken);
        
        var mappedItems = pagedEntities
            .Select(sessionMapper.FromEntityToResponse)
            .ToList();

        return new PagedResult<SessionResponse>(mappedItems, total);
    }

    public async Task<SessionResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await sessionRepository.GetByIdAsync(id, cancellationToken);
        if (entity == null)
            return null;

        var user = sessionMapper.FromEntityToResponse(entity);
        return user;
    }

    public async Task<Guid> CreateAsync(SessionRequest request, CancellationToken cancellationToken)
    {
        var entity = sessionMapper.FromRequestToEntity(request);
        await sessionRepository.CreateAsync(entity, cancellationToken);
        return entity.Id;   
    }

    public async Task<SessionResponse> UpdateAsync(SessionRequest request, CancellationToken cancellationToken)
    {
        var entity = sessionMapper.FromRequestToEntity(request);
        await sessionRepository.UpdateAsync(entity, cancellationToken);
        return sessionMapper.FromEntityToResponse(entity);
    }

    public async Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await sessionRepository.DeleteAsync(id, cancellationToken);
        return id;
    }
    
    public async Task<List<SessionResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await sessionRepository.GetAllActiveAsync(cancellationToken);
        return entities
            .Select (sessionMapper.FromEntityToResponse)
            .ToList();
    }
}