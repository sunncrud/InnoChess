using Microsoft.AspNetCore.Mvc;

namespace InnoChess.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    public LocationController()
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetLocation(string location)
    {
        return Ok();
    }
}
