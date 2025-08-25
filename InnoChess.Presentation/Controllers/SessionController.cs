using Microsoft.AspNetCore.Mvc;

namespace InnoChess.Controllers;

[ApiController]
[Route("sessions")]
public class SessionController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetController(string id)
    {
        return Ok();
    }

}
