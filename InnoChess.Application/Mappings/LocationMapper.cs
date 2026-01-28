using InnoChess.Application.DTO.LocationDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Domain.Models;

namespace InnoChess.Application.Mappings;

public class LocationMapper : ILocationMapper
{
    public LocationEntity FromRequestToEntity(LocationRequest request)
    {
        return new LocationEntity()
        {
            Name = request.Name,
            Description = request.Description,
            MaxPlayers = request.MaxPlayers,
            PosterImageData = request.PosterImageData,
            PosterImageContentType = request.PosterImageContentType,
            DescriptorFileUrl = request.DescriptionFileUrl
        };
    }
    
    public LocationResponse FromEntityToResponse(LocationEntity entity)
    {
        return new LocationResponse()
        {
            Name = entity.Name,
            Description = entity.Description,
            MaxPlayers = entity.MaxPlayers,
        };
    }
}
