using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("401")]
    public IActionResult Get401()
    {
        return Unauthorized();
    }

    [HttpGet("403")]
    public IActionResult Get403()
    {
        return StatusCode(403, "Forbidden");
    }

    [HttpGet("404")]
    public IActionResult Get404()
    {
        return NotFound();
    }

    [HttpGet("500")]
    public IActionResult Get500()
    {
        return StatusCode(500, "Internal Server Error");
    }
}

