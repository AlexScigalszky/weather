using Domain.Data;
using Domain.Entities;
using Domain.Specifications;
using Infrastructure.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories.Implementation
{
    public class CityRepository : Repository<City>, ICityRepository
    {

        public CityRepository(ExampleContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<City>> GetWithCountryAllAsync()
        {
            var spec = new CitiesWithCountriesSpec();
            var list = await GetAsync(spec);
            return list;
        }
    }
}
