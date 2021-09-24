using Application.Models.Base;

namespace Application.Models.User
{
    public class CityDto : BaseDto
    {
        public string Name { get; set; }
        public CountryDto Country { get; set; }
    }
}
