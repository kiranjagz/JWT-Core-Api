using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Galactic.Core.Services.RandomService;
using Galactic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Galactic.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private readonly Random rand = new Random();
        private readonly IRandomApi _randomApi;

        public RandomController(IRandomApi randomApi)
        {
            _randomApi = randomApi;
        }

        [HttpGet]
        [Route("getrandomfact/{type}/{number}")]
        [Authorize]
        public async Task<IActionResult> GetRandomFact(string type, int number)
        {
            var response = await _randomApi.FactGet(number, type);

            if (response == null || response.text.Contains("ERROR"))
                return BadRequest("Oops ze daisy :(");

            return Ok(response);
        }

        [HttpGet()]
        [Route("getlistrandomfact/{type}")]
        [Authorize]
        public async Task<ActionResult<IList<ResponseModel>>> GetListRandomFact(string type)
        {
            var list = new List<ResponseModel>();

            for (int i = 0; i <= 5; i++)
            {
                var response = await _randomApi.FactGet(rand.Next(1, 100), type);

                if (response != null && !response.text.Contains("ERROR"))
                    list.Add(response);
            }

            if (list.Count == 0)
                return BadRequest("This list is empty yoh, check it out please.)");

            return Ok(list);
        }
    }
}
