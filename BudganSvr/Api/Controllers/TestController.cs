using Microsoft.AspNetCore.Mvc;

namespace BudganSvr.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> GetValue()
    {
        return "Hello World!";
    }
}
