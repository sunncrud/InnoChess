namespace InnoChess.Application.DTO.SessionDto;

public record SessionResponse : BaseDto
{
    public string Name { get; init; } = string.Empty;
    public int MaxPlayers { get; init; }
}