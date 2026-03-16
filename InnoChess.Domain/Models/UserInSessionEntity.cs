using InnoNuggetPackage.Primitives;

namespace InnoChess.Domain.Models;

public class UserInSessionEntity : IEntity
{
    public Guid Id { get; init; }
    public Guid SessionId { get; init; }
    public SessionEntity? Session { get; init; }
    
    public Guid UserId { get; init; }
    public UserEntity? User { get; init; }
}
