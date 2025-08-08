using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoChess.Domain.Models;

public class LocationsEntity
{
    public Guid LocationId { get; set; }
    public string LocationName { get; set; }
    public string LocationDescription { get; set; }
    public int MaxPlayers { get; set; } // Different compare to MaxPlayers in SessionsEntity

    // Property for "Typed file describing the location"


}
