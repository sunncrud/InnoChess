using InnoChess.Application.Auth;
using InnoChess.Application.DTO.UserDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using InnoChess.Infrastructure;

namespace InnoChess.Application.Services;

public class UserService(IUserMapper userMapper,IUserRepository userRepository,IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
{
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