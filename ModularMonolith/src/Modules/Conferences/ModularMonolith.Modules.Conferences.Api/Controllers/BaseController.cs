
using Microsoft.AspNetCore.Mvc;

namespace ModularMonolith.Modules.Conferences.Api.Controllers;

[ApiController]
[Route(BasePath+"/[controller]")]
public class BaseController:ControllerBase
{
    protected const string BasePath = "conferences-module";
}