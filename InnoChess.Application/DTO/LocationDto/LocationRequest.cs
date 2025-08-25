namespace InnoChess.Application.DTO.LocationDto;

public class LocationRequest
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int MaxPlayers { get; set; }
    public string Description {  get; set; } = string.Empty;
    public byte[]? PosterImageData { get; set; }
    public string? PosterImageContentType { get; set; }
    public string? DescriptionFileUrl { get; set; }
}
