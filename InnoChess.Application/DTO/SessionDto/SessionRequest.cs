namespace InnoChess.Application.DTO.SessionDto;

public record SessionRequest : BaseDto
{
    public string Name { get; init; } = string.Empty;
    public int MaxPlayers { get; init; }
    public bool IsActive { get; init; }
    public Guid OwnerId { get; init; }
}