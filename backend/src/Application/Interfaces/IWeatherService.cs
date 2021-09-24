using Application.Models.Base;
using Application.Models.Weather;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherModel> Current(long cityId);
        Task<BaseListModel<WeatherModel>> Historical(long cityId, int pageNumber, int pageSize, string orderBy);
    }
}
