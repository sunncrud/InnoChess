using InnoChess.Application.DTO.SessionDto;
using InnoChess.Application.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoChess.Presentation.Controllers;

[Authorize]
[ApiController]
[Route("sessions")]
public class SessionController(ICrudService<SessionRequest, SessionResponse, Guid> crudService, ISessionService sessionService) 
    : CrudController<SessionRequest, SessionResponse, Guid>(crudService)
{
    [HttpGet("{active}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<SessionResponse>>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await sessionService.GetAllActiveAsync(cancellationToken);
        return entities;
    }
}
