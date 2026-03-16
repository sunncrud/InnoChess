using InnoChess.Application.DTO.LocationDto;
using InnoChess.Domain.Models;
using InnoNuggetPackage.Mappers;

namespace InnoChess.Application.MappingContracts;

public interface ILocationMapper : IBaseMapper<LocationRequest, LocationResponse, LocationEntity>
{
    
}