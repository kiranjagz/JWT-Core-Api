using Galactic.Models.Account;
using Galactic.Services.AccountService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Authorization;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;

namespace Galactic.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private const string _errorMessage = "No accounts found. Contact Bob.";
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet()]
        [Route("getallaccounts")]
        [ProducesResponseType(typeof(AccountResponseModel), (int)HttpStatusCode.OK)]
        public IActionResult GetAccounts()
        {
            var accounts = _accountService.GetAccounts();

            if (accounts.Accounts.Count <= 0)
            {
                return BadRequest(_errorMessage);
            }

            return Ok(accounts);
        }

        [HttpGet()]
        [Route("getaccountsbyid/{id}")]
        [ProducesResponseType(typeof(AccountResponseModel), (int)HttpStatusCode.OK)]
        public IActionResult GetAccounts(string id)
        {
            var accounts = _accountService.GetAccounts(id);

            if (accounts.Accounts.Count <= 0)
            {
                return BadRequest(_errorMessage);
            }

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(accounts));

            return Ok(accounts);
        }
    }
}
