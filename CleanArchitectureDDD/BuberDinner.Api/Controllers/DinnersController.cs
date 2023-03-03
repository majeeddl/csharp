using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("api/[controller]")]
    
    public class DinnersController : ApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
