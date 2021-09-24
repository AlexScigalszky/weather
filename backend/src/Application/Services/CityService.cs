using Application.Interfaces;
using Application.Mapper;
using Application.Models.User;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
        }

        public async Task<ICollection<CityModel>> GetAll()
        {
            var cityList = await _cityRepository.GetWithCountryAllAsync();
            var mapped = ObjectMapper.Mapper.Map<ICollection<CityModel>>(cityList);
            return mapped;
        }
    }
}
