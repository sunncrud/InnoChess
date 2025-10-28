using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoChess.Domain.Models;

public class SessionEntity : Entity<Guid>
{
    public string Name { get; init; } = string.Empty;
    public int MaxPlayers { get; init; } 
    public bool IsActive { get; init; }

    public Guid LocationId { get; init; }
    public LocationEntity? Location { get; init; }
    public List<UserInGameEntity> UsersInGame { get; init; } = [];
    public Guid UserCreatorId { get; init; } 

}
