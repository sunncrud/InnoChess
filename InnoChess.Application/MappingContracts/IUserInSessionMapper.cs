using InnoChess.Application.DTO.UserInGameDto;
using InnoChess.Domain.Models;

namespace InnoChess.Application.MappingContracts;

public interface IUserInSessionMapper : IBaseMapper<UserInSessionRequest, UserInSessionResponse, UserInSessionEntity>
{
    
}