using InnoChess.Application.DTO.UserInGameDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.Pagination;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Application.Services;

public class UserInSessionService(IUserInSessionRepository userInSessionRepository, IUserInSessionMapper userInSessionMapper) 
    : CrudService<UserInSessionRequest,UserInSessionResponse,UserInSessionEntity,IUserInSessionMapper>
        (userInSessionRepository,userInSessionMapper), IUserInSessionService
{
    public async Task<PagedResult<UserInSessionResponse>> GetAllAsync(PageParams pageParams, CancellationToken cancellationToken)
    {
        var query = userInSessionRepository.GetQueryable();
        var total = await query.CountAsync(cancellationToken);
        
        var pagedEntities = await query
            .Skip((pageParams.Page - 1) * pageParams.PageSize)
            .Take(pageParams.PageSize)
            .ToListAsync(cancellationToken);
        
        var mappedItems = pagedEntities
            .Select(userInSessionMapper.FromEntityToResponse)
            .ToList();

        return new PagedResult<UserInSessionResponse>(mappedItems, total);    }

    public async Task<UserInSessionResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await userInSessionRepository.GetByIdAsync(id, cancellationToken);
        if (entity == null)
            return null;

        var user = userInSessionMapper.FromEntityToResponse(entity);
        return user;    
    }

    public async Task<Guid> CreateAsync(UserInSessionRequest request, CancellationToken cancellationToken)
    {
        var entity = userInSessionMapper.FromRequestToEntity(request);
        await userInSessionRepository.CreateAsync(entity, cancellationToken);
        return entity.Id;      
    }

    public async Task<UserInSessionResponse> UpdateAsync(UserInSessionRequest request, CancellationToken cancellationToken)
    {
        var entity = userInSessionMapper.FromRequestToEntity(request);
        await userInSessionRepository.UpdateAsync(entity, cancellationToken);
        return userInSessionMapper.FromEntityToResponse(entity);
    }

    public async Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await userInSessionRepository.DeleteAsync(id, cancellationToken);
        return id;    }
}