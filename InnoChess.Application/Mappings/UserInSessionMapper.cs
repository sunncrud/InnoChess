using InnoChess.Application.DTO.UserInGameDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Domain.Models;

namespace InnoChess.Application.Mappings;

public class UserInSessionMapper : IUserInSessionMapper
{
    public UserInSessionEntity FromRequestToEntity(UserInSessionRequest request)
    {
        return new UserInSessionEntity()
        {
            UserId = request.UserId,
        };
    }

    public UserInSessionResponse FromEntityToResponse(UserInSessionEntity entity)
    {
        return new UserInSessionResponse()
        {
            SessionId = entity.Id,
        };
    }
    
}