using Core.Specifications.Base;
using Domain.Entities;

namespace Domain.Specifications
{
    public class HistoricalWeatherSpec : BaseSpecification<Weather>
    {
        public HistoricalWeatherSpec(long? cityId, int pageNumber, int pageSize, string orderBy)
            : base(w => cityId.HasValue && w.CityId == cityId)
        {
            AddInclude("City.Country");
            ApplyPaging((pageNumber - 1) * pageSize, pageSize);
            if (orderBy == "City")
            {
                ApplyOrderBy(x => x.City.Name);
            }else if (orderBy == "Country")
            {
                ApplyOrderBy(x => x.City.Country.Name);
            }
        }
    }
}
