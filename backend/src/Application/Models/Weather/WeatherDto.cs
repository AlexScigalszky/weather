using Application.Models.Base;

namespace Application.Models.Weather
{
    public class WeatherDto : BaseDto
    {
        public long CityId { get; set; }
        public string Temperture { get; set; }
        public string Sensation { get; set; }
    }
}
