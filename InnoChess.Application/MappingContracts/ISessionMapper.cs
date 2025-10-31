using InnoChess.Application.DTO.SessionDto;
using InnoChess.Domain.Models;

namespace InnoChess.Application.MappingContracts;

public interface ISessionMapper : IBaseMapper<SessionRequest, SessionResponse, SessionEntity>
{
    
}