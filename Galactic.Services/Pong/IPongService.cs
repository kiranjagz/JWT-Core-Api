using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Galactic.Services.Pong
{
    public interface IPongService
    {
        Task<string> Ping();
    }
}
