using InnoChess.Application.DTO.LocationDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Domain.Models;

namespace InnoChess.Application.Mappings;

public class LocationMapper : IBaseMapper<LocationRequest, LocationResponse, LocationEntity>
{
    public LocationEntity FromResponseToEntity(LocationResponse response)
    {
        return new LocationEntity
        {
            Name = response.Name,
            Description = response.Description,
            MaxPlayers = response.MaxPlayers,
        };
    }

    public LocationEntity FromRequestToEntity(LocationRequest request)
    {
        return new LocationEntity
        {
            Name = request.Name,
            Description = request.Description,
            MaxPlayers = request.MaxPlayers,
            PosterImageData = request.PosterImageData,
            PosterImageContentType = request.PosterImageContentType,
            DescriptorFileUrl = request.DescriptionFileUrl
        };
    }

    public LocationRequest FromEntityToRequest(LocationEntity entity)
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

    public LocationResponse FromEntityToResponse(LocationEntity entity)
    {
        return new LocationResponse
        {
            Name = entity.Name,
            Description = entity.Description,
            MaxPlayers = entity.MaxPlayers,
        };
    }
}
