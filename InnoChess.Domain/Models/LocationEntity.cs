using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnoChess.Domain.Primitives;

namespace InnoChess.Domain.Models;

public class LocationEntity : IEntity<Guid>
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
