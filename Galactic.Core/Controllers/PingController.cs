using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Galactic.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        public PingController()
        {

        }

        [HttpGet()]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult Ping()
        {
            string message = "Pong!";

            return Ok(message);
        }
    }
}
