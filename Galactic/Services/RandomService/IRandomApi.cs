using System.Threading.Tasks;
using Galactic.Models;

namespace Galactic.Services.RestApi
{
    public interface IRandomApi
    {
        Task<ResponseModel> FactGet(int number, string type);
    }
}
