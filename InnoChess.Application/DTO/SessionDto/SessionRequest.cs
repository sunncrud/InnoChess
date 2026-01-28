namespace InnoChess.Application.DTO.SessionDto;

public record SessionRequest : BaseDto
{
    public string Name { get; init; } = string.Empty;
    public int MaxPlayers { get; init; }
    public string Description { get; init; } = string.Empty;
    public string Location { get; init; } = string.Empty;
}