using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoChess.Domain.Models;

public class SessionEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int MaxPlayers { get; set; } 
    public bool IsActive { get; set; }

    public Guid LocationId { get; set; }
    public LocationEntity? Location { get; set; }
    public List<UserInGameEntity> UsersInGame { get; set; } = [];
    public Guid OwnerId { get; set; } // Creator of the Session

}
