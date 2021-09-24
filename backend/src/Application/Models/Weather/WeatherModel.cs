using Application.Models.Base;
using Application.Models.User;

namespace Application.Models.Weather
{
    public class WeatherModel : BaseModel
    {
        public long CityId { get; set; }
        public CityModel City { get; set; }
        public double Temperture { get; set; }
        public double Sensation { get; set; }
    }
}
