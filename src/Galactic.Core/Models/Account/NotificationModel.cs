using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galactic.Core.Models.Account
{
    public class NotificationModel
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public decimal AvailableBalance { get; set; }
    }
}
