using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Galactic.Models;

namespace Galactic.Core.Services.RandomService
{
    public class RandomApi : IRandomApi
    {
        private const string BaseUrl = "http://numbersapi.com/";
        private readonly HttpClient _httpClient;

        public RandomApi()
        {
            _httpClient = new HttpClient();
        }
        public async Task<ResponseModel> FactGet(int number, string type)
        {
            var url = $"{BaseUrl}" + number + "/" + type + "?json";

            var response = await _httpClient.GetByteArrayAsync(url);

            if (!string.IsNullOrWhiteSpace(Encoding.UTF8.GetString(response)))
            {
                return JsonConvert.DeserializeObject<ResponseModel>(Encoding.UTF8.GetString(response));
            }

            return null;
        }
    }
}
