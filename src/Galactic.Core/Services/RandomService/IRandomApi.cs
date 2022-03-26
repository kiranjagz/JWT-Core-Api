using System.Threading.Tasks;
using Galactic.Models;

namespace Galactic.Core.Services.RandomService
{
    public interface IRandomApi
    {
        Task<ResponseModel> FactGet(int number, string type);
    }
}
