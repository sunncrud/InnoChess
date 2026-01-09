using InnoChess.Application.DTO.UserDto;
using InnoChess.Application.Mappings;
using InnoChess.Application.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoChess.Presentation.Controllers;

[Authorize]
[ApiController]
[Route("users")]
public class UserController(ICrudService<UserRequest, UserResponse, Guid> crudService) 
    : CrudController<UserRequest, UserResponse, Guid>(crudService)
{
    
}

