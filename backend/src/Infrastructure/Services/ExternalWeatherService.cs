
using Core.Configuration;
using Core.Interfaces;
using Core.Models;
using Core.Models.ExternalWheater;
using Infraestructure.WebClient;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Services
{
    public class ExternalWeatherService : WebClient, IExternalWheatherService
    {
        private const string MEASURE_UNIT = "metric";//metric, imperial, empty(kelvin)
        private readonly IOptions<Settings> _options;

        public ExternalWeatherService(IOptions<Settings> options)
        {
            _options = options;
        }

        public async Task<ExternalWheaterModel> FetchCurrentByCity(string cityName)
        {
            var cityNameEncoded = HttpUtility.UrlEncode(cityName);

            var jsonStr = await ExecuteGet(_options.Value.OpenWheater.APILink + $"?q={cityNameEncoded},ar&units={MEASURE_UNIT}&appid={_options.Value.OpenWheater.APIKey}");

            return JsonSerializer.Deserialize<OpenWeatherModel>(jsonStr);
        }
    }
}
