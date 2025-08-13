using InnoChess.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoChess.Domain.RepositoryContracts;

public interface ISessionsRepository : IRepositoryBase<SessionEntity>
{
    public Task<List<SessionEntity>> GetAll(CancellationToken cancellationToken);
}
