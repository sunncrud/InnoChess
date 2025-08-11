using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoChess.Domain.Models;

public class LocationEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int MaxPlayers { get; set; } // Different compare to MaxPlayers in SessionsEntity

    // Property for "Typed file describing the location"
    public List<SessionEntity> Sessions { get; set; } = [];


}
