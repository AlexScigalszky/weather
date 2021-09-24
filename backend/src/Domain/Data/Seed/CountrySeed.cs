using Domain.Constants;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Data.Seed
{
    public class CountrySeed
    {
        public static IEnumerable<Country> GetData()
        {
            return new Country[]
            {
                Country.Create(CountryConstants.ARGENTINA_ID, "Argentina"),
            };
        }
    }
}
