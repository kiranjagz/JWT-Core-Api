using Galactic.Core.Services.AccountService;
using NUnit.Framework;

namespace Galactic.Tests
{
    public class Tests
    {
        private IAccountService _accountService;
        [SetUp]
        public void Setup()
        {
            _accountService = new AccountService();
        }

        [Test]
        public void Test_Atleast_One_Account_Is_Returned()
        {
            var result = _accountService.GetAccounts("1000");

            Assert.That(result.Accounts.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Test_No_Accounts_Returned()
        {
            var result = _accountService.GetAccounts("9999");

            Assert.That(result.Accounts.Count, Is.EqualTo(0));
        }
    }
}