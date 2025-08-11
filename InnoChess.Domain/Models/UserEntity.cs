using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoChess.Domain.Models;

public class UserEntity
{
    public string? Role {  get; set; } 
    public string UserName { get; set; } = string.Empty;
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public List<UserInGameEntity>? UsersInGame { get; set; }
}
