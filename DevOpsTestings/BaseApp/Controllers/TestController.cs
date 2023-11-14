using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BaseApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        private readonly IConfiguration Configuration;
        public TestController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        

        [HttpGet(Name = "GetTest")]
        public List<string> Get()
        {
            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];


            var name = Shared.Common.GetName();
            
            return new List<string>() { "Hello", "World", "Test" , connectionString };
        }
    }
}