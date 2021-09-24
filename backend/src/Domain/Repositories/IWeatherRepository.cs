using Core.Models;
using Core.Repositories.Base;
using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IWeatherRepository : IRepository<Weather>
    {
        Task<PageableList<Weather>> GetPageableListAsync(long cityId, int pageNumber, int pageSize, string orderBy);
    }
}
