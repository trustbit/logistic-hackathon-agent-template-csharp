using Microsoft.AspNetCore.Mvc;

namespace LogisticsRestApi.Controllers;

[ApiController]
[Route("")]
[ApiExplorerSettings(IgnoreApi = true)]
public class RedirectController : ControllerBase
{
    [HttpGet]
    public IActionResult Redirect()
    {
        return Redirect("/swagger");
    }
}