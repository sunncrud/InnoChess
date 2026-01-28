using InnoChess.Application.Auth;
using InnoChess.Application.DTO.UserDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.Pagination;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Application.Services;

public class UserService(IUserRepository userRepository, IUserMapper userMapper, 
    IPasswordHasher passwordHasher, IJwtProvider jwtProvider) 
    : CrudService<UserRequest,UserResponse,UserEntity,IUserMapper>
    (userRepository,userMapper),IUserService
{
    public async Task<PagedResult<UserResponse>> GetAllAsync(
        PageParams pageParams, 
        CancellationToken cancellationToken)
    {
        var query = userRepository.GetQueryable();
        var total = await query.CountAsync(cancellationToken);
        
        var pagedEntities = await query
            .Skip((pageParams.Page - 1) * pageParams.PageSize)
            .Take(pageParams.PageSize)
            .ToListAsync(cancellationToken);
        
        var mappedItems = pagedEntities
            .Select(userMapper.FromEntityToResponse)
            .ToList();

        return new PagedResult<UserResponse>(mappedItems, total);
    }

    public async Task<UserResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await userRepository.GetByIdAsync(id, cancellationToken);
        if (entity == null)
            return null;

        var user = userMapper.FromEntityToResponse(entity);
        return user;
    }

    public async Task<Guid> CreateAsync(UserRequest request, CancellationToken cancellationToken)
    {
        var entity = userMapper.FromRequestToEntity(request);
        await userRepository.CreateAsync(entity, cancellationToken);
        return entity.Id;   
    }

    public async Task<UserResponse> UpdateAsync(UserRequest request, CancellationToken cancellationToken)
    {
        var entity = userMapper.FromRequestToEntity(request);
        await userRepository.UpdateAsync(entity, cancellationToken);
        return userMapper.FromEntityToResponse(entity);
    }

    public async Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await userRepository.DeleteAsync(id, cancellationToken);
        return id;
    }
    
    public async Task Register(string userName, string email, string password, CancellationToken cancellationToken)
    {
        var passwordHash = passwordHasher.Generate(password);
        var user = UserEntity.CreateUser(Guid.NewGuid(), userName, email, passwordHash);
        
        await userRepository.CreateAsync(user, cancellationToken);
    }

    public async Task<string> Login(string email, string password, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmail(email, cancellationToken);
        if (user != null)
        {
            var result = passwordHasher.Verify(password, user.PasswordHash);
        }
        var token = jwtProvider.GenerateJwtToken(user);
        return token;
    }
}