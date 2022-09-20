using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace trilha_net_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("ObtainCurrentDateHour")]
        public IActionResult GetDateHour() 
        {
            var obj = new 
            {
                Date = DateTime.Now.ToLongDateString(),
                Hour = DateTime.Now.ToShortTimeString()
            };

            return Ok(obj);
        }

        [HttpGet("Introduce/{name}")]
        public IActionResult Introduce(string name)
        {
            var message = $"Hello {name} and welcome!";
            return Ok(new { message });
        }
    }
}