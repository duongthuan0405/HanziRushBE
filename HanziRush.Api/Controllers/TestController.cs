using Microsoft.AspNetCore.Mvc;

namespace HanziRush.Api.Controllers;

public class ResultDTO<T>
{
    public bool IsSuccess {get; set;} = default;
    public string Message {get; set;} = string.Empty;
    public T? Data {get; set; } = default(T);

}

public class TestController : ControllerBase
{
    [HttpGet]
    public Task<ActionResult<ResultDTO<string>>> TestCI()
    {

        var res = new ResultDTO<string>()
        {
            IsSuccess = true,
            Message = "Test CI OK",
            Data = "Ok!"
        };
        return Task.FromResult<ActionResult<ResultDTO<string>>>(Ok(res));
    }
}