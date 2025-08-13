using InnoChess.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoChess.Domain.RepositoryContracts;

public interface IUsersInGameRepository : IRepositoryBase<UserInGameEntity>
{
    public Task<List<UserInGameEntity>> GetAll(CancellationToken cancellationToken);
}
