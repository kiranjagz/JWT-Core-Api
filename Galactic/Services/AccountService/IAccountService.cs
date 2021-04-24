using Galactic.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galactic.Services.AccountService
{
    public interface IAccountService
    {
        IList<IAccountModel> GetAccounts();
    }
}
