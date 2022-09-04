using Microsoft.AspNetCore.Mvc;

namespace ModularMonolith.Modules.Conferences.Api.Controllers;

[Route(BasePath)]
public class HomeController:BaseController
{
    [HttpGet]
    public ActionResult<string> Get() => " Hello Conferences";
}