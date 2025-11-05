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
    public string Password { get; init; } = string.Empty;

    public List<UserInSessionEntity>? UsersInGame { get; init; }
}
