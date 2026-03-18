using InnoNuggetPackage.Primitives;

namespace InnoChess.Domain.Models;

public class LocationEntity : IEntity
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public int MaxPlayers { get; init; }
    public byte[] PosterImageData { get; init; } = [];
    public string PosterImageContentType { get; init; } = string.Empty;
    public string DescriptorFileUrl { get; init; } = string.Empty;

    public List<SessionEntity> Sessions { get; init; } = [];
}
