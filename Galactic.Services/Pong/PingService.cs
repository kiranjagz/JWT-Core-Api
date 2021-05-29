using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Galactic.Services.Pong
{
    public class PingService : IPongService
    {
        public Task<string> Ping()
        {
            return Task.Run(() =>
            {
                return "Pong!";
            });
        }
    }
}
