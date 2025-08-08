using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InnoChess.Controllers;

[ApiController]
[Route("sessions")]
public class SessionsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetController(string id)
    {
        return await GetController(id);
    }

}
