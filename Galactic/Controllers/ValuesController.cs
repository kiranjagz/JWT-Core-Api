using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Galactic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Galactic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly Random rand = new Random();

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAsync()
        {     

            var url = $"http://numbersapi.com/" + rand.Next(5000) + "/" + "math" + "?json";
            using (var client = new HttpClient())
            {
                var response = await client.GetByteArrayAsync(url);
                var responseString = Encoding.UTF8.GetString(response);
                if (!string.IsNullOrWhiteSpace(responseString))
                {
                    var model = JsonConvert.DeserializeObject<ResponseModel>(responseString);
                    return Ok(model);
                }
            }

            return BadRequest("Oops ze daisy :(");
        }

        [HttpGet()]
        [Route("getlist")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ResponseModel>>> GetListAsync()
        {
            var list = new List<ResponseModel>();

            using (var client = new HttpClient())
            {
                for(int i = 0; i <= 5; i++)
                {
                    var url = $"http://numbersapi.com/" + i + "/" + "math" + "?json";
                    var response = await client.GetByteArrayAsync(url);
                    var responseString = Encoding.UTF8.GetString(response);
                    if (!string.IsNullOrWhiteSpace(responseString))
                    {
                        var model = JsonConvert.DeserializeObject<ResponseModel>(responseString);
                        list.Add(model);
                      
                    }
                }
                return new JsonResult(list);
            }
        }
    }
}
