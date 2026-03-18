using InnoChess.Application.DTO.UserInGameDto;
using InnoChess.Domain.Models;
using InnoNuggetPackage.Mappers;

namespace InnoChess.Application.MappingContracts;

public interface IUserInSessionMapper : IBaseMapper<UserInSessionRequest, UserInSessionResponse, UserInSessionEntity>
{
    
}