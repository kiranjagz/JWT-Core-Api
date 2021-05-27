using Galactic.Core.Models.Account;
using Galactic.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galactic.Core.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IList<IAccountModel> _accountModels;
        public AccountService()
        {
            _accountModels = new List<IAccountModel>
            {
                new ChequeAccountModel
                {
                    IdNumber = "1000",
                    AvailableBalance = 5000.00m,
                    TotalBalance = 7000.00m,
                    OverDraftBalance = 3000.00m,
                    AccountType = AccountType.Cheque.ToString()
                },
                new ChequeAccountModel
                {
                    IdNumber = "2000",
                    AvailableBalance = 12000.00m,
                    TotalBalance = 14000.00m,
                    OverDraftBalance = 2000.00m,
                    AccountType = AccountType.Cheque.ToString()
                },
                new InvestmentAccountModel
                {
                    IdNumber = "1000",
                    AvailableBalance = 40000.00m,
                    TotalBalance = 60000.00m,
                    InterestEarned = 1450.55m,
                    InterestRate = 3.45m,
                    AccountType = AccountType.Investment.ToString()
                },
                new RedbucksAccountModel
                {
                    IdNumber = "1000",
                    AccountType  = AccountType.Redbucks.ToString(),
                    AvailableBalance = 35000.00m,
                    TotalBalance = 45000.00m
                },
                 new RedbucksAccountModel
                {
                    IdNumber = "2000",
                    AccountType  = AccountType.Redbucks.ToString(),
                    AvailableBalance = 15000.00m,
                    TotalBalance = 18000.00m
                }
            };
        }
        public AccountResponseModel GetAccounts()
        {
            return new AccountResponseModel
            {
                Accounts = _accountModels,
                Message = $"Successfully returnd accounts with id: {Guid.NewGuid()}"
            };
        }

        public AccountResponseModel GetAccounts(string id)
        {
            return new AccountResponseModel
            {
                Accounts = _accountModels.Where(x => x.IdNumber == id).ToList(),
                Message = $"Successfully returnd accounts with id: {Guid.NewGuid()}"
            };
        }
    }
}
