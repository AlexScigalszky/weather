using Domain.Constants;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Data.Seed
{
    public class CitySeed
    {
        public static IEnumerable<City> GetData()
        {
            return new City[]
            {
                City.Create(CityConstants.TRES_ARROYOS_ID, "Tres Arroyos", CountryConstants.ARGENTINA_ID),
                City.Create(CityConstants.CABA_ID, "Ciudad Autónoma de Buenos Aires", CountryConstants.ARGENTINA_ID),
            };
        }
    }
}
