using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoChess.Domain.Models;

public class LocationEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public byte[] PosterImageData { get; set; } = [];
    public string PosterImageContentType { get; set; } = string.Empty;
    public int MaxPlayers { get; set; }
    public string DescriptorFileUrl { get; set; } = string.Empty;


    public List<SessionEntity> Sessions { get; set; } = [];


}
