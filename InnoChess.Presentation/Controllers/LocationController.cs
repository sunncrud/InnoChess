using FluentValidation;
using InnoChess.Application.DTO.LocationDto;
using InnoChess.Application.Pagination;
using InnoChess.Application.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoChess.Presentation.Controllers;

[ApiController]
[Authorize]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[Route("api/[controller]")]
public class LocationController(ICrudService<LocationRequest, LocationResponse> crudService, 
    ILocationService locationService, IValidator<LocationRequest> locationValidator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<LocationResponse>>> GetAll([FromQuery] PageParams pageParams, CancellationToken cancellationToken)
    {
        var entities = crudService.GetAllAsync(pageParams, cancellationToken);
        return await entities;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<LocationResponse?>> GetById([FromRoute]Guid key, CancellationToken cancellationToken)
    {
        var entity = await crudService.GetByIdAsync(key, cancellationToken);
        return entity;
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Update([FromBody]LocationRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await locationValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ValidationProblem(new ValidationProblemDetails(validationResult.ToDictionary()));
        }   
        
        await crudService.UpdateAsync(request, cancellationToken);
        return Ok();
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Guid>> Create([FromBody]LocationRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await locationValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ValidationProblem(new ValidationProblemDetails(validationResult.ToDictionary()));
        }   
        
        var entity = await crudService.CreateAsync(request, cancellationToken);
        return entity;
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Guid>> Delete([FromRoute]Guid key, CancellationToken cancellationToken)
    {
        await crudService.DeleteAsync(key, cancellationToken);
        return key;
    }
    
    
    [HttpGet("{by-name}")]
    public async Task<ActionResult<LocationResponse?>> GetByNameAsync([FromBody]string name, CancellationToken cancellationToken)
    {
        var entity = await locationService.GetLocationByNameAsync(name, cancellationToken);
        return entity;
    }
    
    [HttpGet("{by-description}")]
    public async Task<ActionResult<LocationResponse?>> GetByDescriptionAsync([FromBody]string description, CancellationToken cancellationToken)
    {
        var entity = await locationService.GetLocationByDescriptionAsync(description, cancellationToken);
        return entity;
    }
}
