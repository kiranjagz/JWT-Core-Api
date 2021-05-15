using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galactic.Models.Account
{
    public class AccountResponseModel
    {
        public IList<IAccountModel> Accounts { get; set; }
        public string Message { get; set; }
    }
}
