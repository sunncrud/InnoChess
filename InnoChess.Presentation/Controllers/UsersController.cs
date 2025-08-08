using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InnoChess.Presetnation.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok();
    }
}
