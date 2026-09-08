using Microsoft.AspNetCore.Mvc;

namespace HanziRush.Api.Controllers;

public class ResultDTO<T>
{
    public bool IsSuccess {get; set;} = true;
    public string Message {get; set;} = "";
    public T? Data {get; set; }

}

[Route("api/test")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet("ci")]
    public Task<ActionResult<ResultDTO<string>>> TestCI()
    {

        var res = new ResultDTO<string>
        {
            IsSuccess = true,
            Message = "Test CI OK",
            Data = "Ok!"
        };
        return Task.FromResult<ActionResult<ResultDTO<string>>>(Ok(res));

    }
}