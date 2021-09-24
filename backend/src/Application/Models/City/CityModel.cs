using Application.Models.Base;

namespace Application.Models.User
{
    public class CityModel : BaseModel
    {
        public string Name { get; set; }
        public CountryModel Country { get; set; }
    }
}
