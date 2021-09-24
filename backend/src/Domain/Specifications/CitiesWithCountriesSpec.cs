using Core.Specifications.Base;
using Domain.Entities;

namespace Domain.Specifications
{
    public class CitiesWithCountriesSpec : BaseSpecification<City>
    {
        public CitiesWithCountriesSpec() : base(c => true)
        {
            AddInclude(c => c.Country);
        }
    }
}
