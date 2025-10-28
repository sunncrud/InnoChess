namespace InnoChess.Application.DTO.LocationDto;

public record LocationResponse : BaseDto
{
    public string Name { get; init; } = string.Empty;
    public string Description {  get; init; } = string.Empty;
    public int MaxPlayers { get; init; }
}
