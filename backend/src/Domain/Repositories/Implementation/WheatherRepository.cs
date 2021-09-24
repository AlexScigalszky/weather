using Core.Models;
using Domain.Data;
using Domain.Entities;
using Domain.Specifications;
using Infrastructure.Repository.Base;
using System.Threading.Tasks;

namespace Domain.Repositories.Implementation
{
    public class WheatherRepository : Repository<Weather>, IWeatherRepository
    {

        public WheatherRepository(ExampleContext dbContext) : base(dbContext)
        {
        }

        public async Task<PageableList<Weather>> GetPageableListAsync(long cityId, int pageNumber, int pageSize, string orderBy)
        {
            var spec = new HistoricalWeatherSpec(cityId, pageNumber, pageSize, orderBy);
            return await GetPageableListAsync(spec);
        }
    }
}
