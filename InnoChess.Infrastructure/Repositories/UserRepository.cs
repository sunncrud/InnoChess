using InnoChess.Application.DTO;
using InnoChess.Domain.Models;
using InnoChess.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace InnoChess.Infrastructure.Repositories;

public class UserRepository(InnoChessDbContext context) : RepositoryBase<UserEntity, Guid>(context), IUserRepository
{
   
}
