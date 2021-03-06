﻿using Galactic.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galactic.Core.Services.AccountService
{
    public interface IAccountService
    {
        AccountResponseModel GetAccounts();

        AccountResponseModel GetAccounts(string id);
    }
}
