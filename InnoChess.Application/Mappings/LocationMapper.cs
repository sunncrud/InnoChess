using InnoChess.Application.DTO.LocationDto;
using InnoChess.Domain.Models;

namespace InnoChess.Application.Mappings;

public class LocationMapper
{
    public static LocationEntity FromResponseToEntity(LocationResponse location)
    {
        return new LocationEntity
        {
            Name = location.Name,
            Description = location.Description,
            MaxPlayers = location.MaxPlayers,
        };
    }

    public static LocationEntity FromRequestToEntity(LocationRequest location)
    {
        return new LocationEntity
        {
            Name = location.Name,
            Description = location.Description,
            MaxPlayers = location.MaxPlayers,
            PosterImageData = location.PosterImageData,
            PosterImageContentType = location.PosterImageContentType,
            DescriptorFileUrl = location.DescriptionFileUrl
        };
    }

    public static LocationRequest FromEntityToRequest(LocationEntity entity)
    {
        return new LocationRequest
        {
            Name = entity.Name,
            Description = entity.Description,
            MaxPlayers = entity.MaxPlayers,
            PosterImageData = entity.PosterImageData,
            PosterImageContentType = entity.PosterImageContentType,
            DescriptionFileUrl = entity.DescriptorFileUrl,
        };
    }

    public static LocationResponse FromEntityToResponse(LocationEntity entity)
    {
        return new LocationResponse
        {
            Name = entity.Name,
            Description = entity.Description,
            MaxPlayers = entity.MaxPlayers,
        };
    }
}
