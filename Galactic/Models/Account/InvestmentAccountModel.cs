using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galactic.Models.Account
{
    public class InvestmentAccountModel : IAccountModel
    {
        public string IdNumber { get; set; }
        public decimal AvailableBalance { get; set; }
        public decimal TotalBalance { get; set; }
        public decimal InterestEarned { get; set; }
        public decimal InterestRate { get; set; }
        public string AccountType { get; set; }
    }
}
