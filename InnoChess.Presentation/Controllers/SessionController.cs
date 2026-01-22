using FluentValidation;
using InnoChess.Application.DTO.SessionDto;
using InnoChess.Application.Pagination;
using InnoChess.Application.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoChess.Presentation.Controllers;

[ApiController]
[Authorize]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[Route("sessions")]
public class SessionController(ICrudService<SessionRequest, SessionResponse> crudService, 
    ISessionService sessionService, IValidator<SessionRequest> sessionValidator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<SessionResponse>>> GetAll([FromQuery] PageParams pageParams, CancellationToken cancellationToken)
    {
        var entities = crudService.GetAllAsync(pageParams, cancellationToken);
        return await entities;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SessionResponse?>> GetById([FromRoute]Guid key, CancellationToken cancellationToken)
    {
        var entity = await crudService.GetByIdAsync(key, cancellationToken);
        return entity;
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update([FromBody]SessionRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await sessionValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ValidationProblem(new ValidationProblemDetails(validationResult.ToDictionary()));
        }   
        
        await crudService.UpdateAsync(request, cancellationToken);
        return Ok();
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody]SessionRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await sessionValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ValidationProblem(new ValidationProblemDetails(validationResult.ToDictionary()));
        }   
        
        var entity = await crudService.CreateAsync(request, cancellationToken);
        return entity;
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> Delete([FromRoute]Guid key, CancellationToken cancellationToken)
    {
        await crudService.DeleteAsync(key, cancellationToken);
        return key;
    }
    
    [HttpGet("{active}")]
    public async Task<ActionResult<List<SessionResponse>>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await sessionService.GetAllActiveAsync(cancellationToken);
        return entities;
    }
}
