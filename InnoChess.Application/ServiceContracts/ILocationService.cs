using InnoChess.Application.DTO.LocationDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.Pagination;
using InnoChess.Application.Services;
using InnoChess.Domain.Models;

namespace InnoChess.Application.ServiceContracts;

public interface ILocationService : ICrudService<LocationRequest, LocationResponse>
{
    public Task<LocationResponse?> GetLocationByNameAsync(string name, CancellationToken cancellationToken);
    public Task<LocationResponse?> GetLocationByDescriptionAsync(string description, CancellationToken cancellationToken);

}
