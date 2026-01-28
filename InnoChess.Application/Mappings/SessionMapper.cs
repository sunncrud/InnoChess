using InnoChess.Application.DTO.SessionDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Domain.Models;

namespace InnoChess.Application.Mappings;

public class SessionMapper : ISessionMapper
{
    public SessionEntity FromRequestToEntity(SessionRequest request)
    {
        return new SessionEntity()
        {
            Name = request.Name,
        };
    }

    public SessionResponse FromEntityToResponse(SessionEntity entity)
    {
        return new SessionResponse()
        {
            Name = entity.Name,
            MaxPlayers = entity.MaxPlayers,
        };
    }
}