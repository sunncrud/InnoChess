using InnoChess.Application.ServiceContracts;
using InnoChess.Application.DTO.LocationDto;
using Microsoft.AspNetCore.Mvc;
using InnoChess.Domain.Models;
using InnoChess.Application.Mappings;

namespace InnoChess.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;
    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    public async Task<ActionResult<List<LocationResponse>>> GetAllLocations(CancellationToken cancellationToken)
    {
        var locations = await _locationService.GetAllLocationsAsync(cancellationToken);
        return locations;
    }

    [HttpGet("{id:guid}")]
    public async Task<LocationResponse?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _locationService.GetLocationByIdAsync(id, cancellationToken);
        return entity;
    }

    [HttpGet("{name}")]
    public async Task<LocationResponse?> GetByName(string name, CancellationToken cancellationToken)
    {
        var entity = await _locationService.GetLocationByNameAsync(name, cancellationToken);
        return entity;
    }

    [HttpPost]
    public async Task<Guid> CreateLocation([FromBody]LocationRequest location, CancellationToken cancellationToken)
    {
        var entity = await _locationService.CreateLocaitonAsync(location, cancellationToken);
        return entity;
    }

    [HttpDelete]
    public async Task DeleteLocation(Guid id, CancellationToken cancellationToken)
    {
        await _locationService.DeleteLocationAsync(id, cancellationToken);
    }
}
