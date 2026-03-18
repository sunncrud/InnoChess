using InnoChess.Application.DTO.UserInGameDto;
using InnoNuggetPackage.ServiceContracts;

namespace InnoChess.Application.ServiceContracts;

public interface IUserInSessionService : ICrudService<UserInSessionRequest, UserInSessionResponse>
{
   
}