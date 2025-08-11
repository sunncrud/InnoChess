using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoChess.Domain.Models;

public class UserInGameEntity
{
    public int Id { get; set; }
    
    public Guid SessionId { get; set; }
    public SessionEntity? Session { get; set; }

    public Guid UserId { get; set; }
    public UserEntity? User { get; set; }
}
