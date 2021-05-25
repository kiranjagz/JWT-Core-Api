using Galactic.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galactic.Core.Models.Account
{
    public class RedbucksAccountModel : IAccountModel
    {
        public string IdNumber { get; set; }
        public decimal AvailableBalance { get; set; }
        public decimal TotalBalance { get; set; }
        public string AccountType { get; set; }
    }
}
