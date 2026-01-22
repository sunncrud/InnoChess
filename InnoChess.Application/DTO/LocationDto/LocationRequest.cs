namespace InnoChess.Application.DTO.LocationDto;

public record LocationRequest : BaseDto
{
    public string Name { get; init; } = string.Empty;
    public int MaxPlayers { get; init; }
    public string Description {  get; init; } = string.Empty;
    public byte[]? PosterImageData { get; init; }
    public string? PosterImageContentType { get; init; }
    public string? DescriptionFileUrl { get; init; }
}
