using InnoChess.Application.DTO.UserInGameDto;
using InnoChess.Application.ServiceContracts;

namespace InnoChess.Presentation.Controllers;

public class UserInGameController(ICrudService<UserInGameRequest, UserInGameResponse, Guid> crudService) 
    : CrudController<UserInGameRequest, UserInGameResponse, Guid>(crudService)
{
    
}
