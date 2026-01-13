using InnoChess.Application.DTO.UserDto;
using InnoChess.Application.Mappings;
using InnoChess.Application.Pagination;
using InnoChess.Application.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoChess.Presentation.Controllers;

[ApiController]
[Authorize]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[Route("users")]
public class UserController(IUserService userService) 
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<UserResponse>>> GetAll([FromQuery] PageParams pageParams, CancellationToken cancellationToken)
    {
        var entities = userService.GetAllAsync(pageParams, cancellationToken);
        return await entities;
    }

    [HttpGet("{id:guid}")]
    public async Task<UserResponse?> GetById([FromRoute]Guid key, CancellationToken cancellationToken)
    {
        var entity = await userService.GetByIdAsync(key, cancellationToken);
        return entity;
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task Update([FromBody]UserRequest request, CancellationToken cancellationToken)
    {
        await userService.UpdateAsync(request, cancellationToken);
    }
    

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<Guid> Delete([FromRoute]Guid key, CancellationToken cancellationToken)
    {
        await userService.DeleteAsync(key, cancellationToken);
        return key;
    }
}

