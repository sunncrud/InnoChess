using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoChess.Domain.Models;

public class UsersEntity
{
    public string? Role {  get; set; } 
    public string UserName { get; set; }
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public Guid SessionId { get; set; }
    public SessionsEntity? Session { get; set; }
}
