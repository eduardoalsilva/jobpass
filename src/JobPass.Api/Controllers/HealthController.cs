using Microsoft.AspNetCore.Mvc;

namespace JobPass.Api.Controllers;

[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("JobPass API está rodando 🚀");
    }
}
