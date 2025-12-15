using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoChess.Domain.Models;

public class UserEntity : Entity<Guid>
{
    public string? Role {  get; init; } 
    public string UserName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string PasswordHash { get; init; } = string.Empty;

    public List<UserInSessionEntity>? UsersInGame { get; init; }
    public static UserEntity CreateUser(Guid id, string userName, string email, string passwordHash)
    {
        return new UserEntity
        {
            Id = id,
            UserName = userName,
            Email = email,
            PasswordHash = passwordHash,
        };
    }
}
