using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnoChess.Domain.Primitives;

namespace InnoChess.Domain.Models;

public class SessionEntity : IEntity<Guid>
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int MaxPlayers { get; init; } 
    public bool IsActive { get; init; }
    
    public Guid OwnerId { get; init; } 
    
    public Guid LocationId { get; init; }
    public LocationEntity? Location { get; init; }
    public List<UserInSessionEntity> UsersInGame { get; init; } = [];


}
