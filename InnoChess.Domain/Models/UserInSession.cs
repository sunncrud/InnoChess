using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoChess.Domain.Models;

public class UserInSession : Entity<Guid>
{
    public Guid SessionId { get; init; }
    public SessionEntity? Session { get; init; }
    
    public Guid UserId { get; init; }
    public UserEntity? User { get; init; }
}
