using Application.Models.Base;

namespace Application.Models.Weather
{
    public class QueryWeatherDto : PageableDTO
    {
        public long CityId { get; set; }
    }
}
