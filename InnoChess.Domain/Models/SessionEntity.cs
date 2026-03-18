using InnoNuggetPackage.Primitives;

namespace InnoChess.Domain.Models;

public class SessionEntity : IEntity
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
