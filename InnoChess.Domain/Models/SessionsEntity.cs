using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoChess.Domain.Models;

public class SessionsEntity
{
    public Guid SessionId { get; set; }
    public string SessionName { get; set; }
    public int MaxPlayers { get; set; } 
    public bool IsActive { get; set; }

    public Guid LocationId {  get; set; }
    public List<UsersEntity> Users { get; set; } = [];
    public Guid UserId { get; set; } // Creator of the Session

}
