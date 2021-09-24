using Application.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICityService
    {
        Task<ICollection<CityModel>> GetAll();
    }
}
