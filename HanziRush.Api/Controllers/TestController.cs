using Microsoft.AspNetCore.Mvc;

namespace HanziRush.Api.Controllers;

public class TestController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<string>> TestCI()
    {
        return StatusCode(StatusCodes.Status200OK, "Test OK =)))");
    }
}