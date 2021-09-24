using API.Controllers.Base;
using Application.Interfaces;
using Application.Models.Base;
using Application.Models.Weather;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ExampleController
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService) : base()
        {
            _weatherService = weatherService;
        }

        [Route("[action]/{cityId}")]
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(WeatherModel))]
        public async Task<ActionResult<WeatherModel>> GetCurrent(long cityId)
        {
            var cities = await _weatherService.Current(cityId);

            return Ok(cities);
        }

        [Route("[action]")]
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(BaseListModel<WeatherModel>))]
        public async Task<ActionResult<BaseListModel<WeatherModel>>> Historical([FromQuery] QueryWeatherDto queryWeatherDto)
        {
            var consultation = await _weatherService.Historical(
                queryWeatherDto.CityId,
                queryWeatherDto.PageNumber,
                queryWeatherDto.PageSize,
                queryWeatherDto.OrderBy
            );

            return Ok(consultation);
        }
    }
}
