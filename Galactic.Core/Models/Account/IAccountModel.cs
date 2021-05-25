using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galactic.Models.Account
{
    public interface IAccountModel
    {
        string IdNumber { get; set; }
        decimal AvailableBalance { get; set; }
        decimal TotalBalance { get; set; }
        string AccountType { get; set; }
    }

    public enum AccountType
    {
        Cheque,
        Investment,
        Redbucks
    }
}
