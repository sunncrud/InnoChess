using InnoChess.Domain.Models;

namespace InnoChess.Application.Auth;

public interface IJwtProvider
{
    public string GenerateJwtToken(UserEntity user);
}