
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PingController : Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(true);
    }
}
