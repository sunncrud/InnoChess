using InnoChess.Application.DTO.LocationDto;
using InnoChess.Application.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoChess.Presentation.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class LocationController(ICrudService<LocationRequest, LocationResponse, Guid> crudService, 
    ILocationService locationService)
    : CrudController<LocationRequest, LocationResponse, Guid>(crudService)
{
    [HttpGet("{by-name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LocationResponse?>> GetByNameAsync([FromBody]string name, CancellationToken cancellationToken)
    {
        var entity = await locationService.GetLocationByNameAsync(name, cancellationToken);
        return entity;
    }
    
    [HttpGet("{by-description}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LocationResponse?>> GetByDescriptionAsync([FromBody]string description, CancellationToken cancellationToken)
    {
        var entity = await locationService.GetLocationByDescriptionAsync(description, cancellationToken);
        return entity;
    }
}
