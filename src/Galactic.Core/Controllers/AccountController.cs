using Galactic.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using Galactic.Core.Services.AccountService;
using Newtonsoft.Json;
using Galactic.Core.Models.Account;

namespace Galactic.Core.Controllers
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

            Console.WriteLine(JsonConvert.SerializeObject(accounts));

            return Ok(accounts);
        }

        [HttpGet()]
        [Route("getnotifications/{id}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult GetNotifications(string id)
        {
            string notification = string.Empty;

            var account = _accountService.GetAccounts(id)
                .Accounts
                .Where(account => account.AccountType == AccountType.Cheque.ToString())
                .FirstOrDefault();

            if (account.AvailableBalance > 7300.00m)
            {
                notification = "Sir, you qualify for a overdraft!";
            }
            else
            {
                notification = "Oh no, you do not qualify for a overdraft!";
            }

            var notificationModel = new NotificationModel()
            {
                Id = id,
                AvailableBalance = account.AvailableBalance,
                Message = notification
            };

            return Ok(notificationModel);
        }
    }
}
