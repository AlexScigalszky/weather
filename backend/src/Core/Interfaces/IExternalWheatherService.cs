using Core.Models;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IExternalWheatherService
    {
        Task<ExternalWheaterModel> FetchCurrentByCity(string cityName);
    }
}
