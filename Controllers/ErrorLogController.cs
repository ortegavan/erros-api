using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class ErrorLogController : ControllerBase
{
    private readonly JsonDataService<ErrorLog> ds;

    public ErrorLogController()
    {
        this.ds = new JsonDataService<ErrorLog>("Data/Errors.json");
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(ds.GetAll());
    }

    [HttpPost]
    public IActionResult Post([FromBody] ErrorLog error)
    {
        ds.Save(error);
        return CreatedAtAction(nameof(Get), new { id = error.Id }, error);
    }

    [HttpPost("bulk")]
    public IActionResult PostBulk([FromBody] IList<ErrorLog> errors)
    {
        foreach (var error in errors)
        {
            ds.Save(error);
        }
        return CreatedAtAction(nameof(Get), new { id = errors.First().Id }, errors);
    }
}