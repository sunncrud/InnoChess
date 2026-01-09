using InnoChess.Application.DTO.UserInGameDto;
using InnoChess.Application.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoChess.Presentation.Controllers;

public class UserInSessionController(ICrudService<UserInSessionRequest, UserInSessionResponse, Guid> crudService) 
    : CrudController<UserInSessionRequest, UserInSessionResponse, Guid>(crudService)
{
    
}
