using InnoChess.Application.DTO.SessionDto;
using InnoChess.Application.DTO.UserInGameDto;
using InnoChess.Application.Pagination;

namespace InnoChess.Application.ServiceContracts;

public interface IUserInSessionService : ICrudService<UserInSessionRequest, UserInSessionResponse>
{
   
}