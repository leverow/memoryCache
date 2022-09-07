namespace Name.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SessionsController : Controller
{
    public string SessionKey = ".request.count";
    public static int Counter = 1;
    [HttpGet]
    public IActionResult GetSession()
    {
        var session = HttpContext.Session.GetString(SessionKey);

        if(string.IsNullOrWhiteSpace(session))
            return NotFound();

        return Ok(session);
    }
    [HttpPost]
    public IActionResult SetSession()
    {
        if(HttpContext.Session.GetString(SessionKey) is null)
            Counter = 1;

        HttpContext.Session.SetString(".request.count", (Counter++).ToString());

        return Accepted();
    }
}