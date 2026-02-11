using InnoChess.Application.Caching;
using InnoChess.Application.DTO.UserInGameDto;
using InnoChess.Application.MappingContracts;
using InnoChess.Application.Pagination;
using InnoChess.Application.ServiceContracts;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Application.Services;

public class UserInSessionService(IUserInSessionRepository userInSessionRepository, 
    IUserInSessionMapper userInSessionMapper, ICacheService cacheService) 
    : CrudService<UserInSessionRequest,UserInSessionResponse,UserInSessionEntity,IUserInSessionMapper>
        (userInSessionRepository, userInSessionMapper, cacheService), IUserInSessionService
{
   
}