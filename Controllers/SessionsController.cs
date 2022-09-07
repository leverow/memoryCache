namespace Name.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SessionsController : Controller
{
    public string SessionKey = ".request.count";
    [HttpPost]
    public IActionResult SetSession()
    {
        int.TryParse(HttpContext.Session.GetString(SessionKey), out var Counter);
        HttpContext.Session.SetString(SessionKey, $"{++Counter}");

        HttpContext.Session.SetString(SessionKey, (Counter++).ToString());

        return Accepted();
    }
}