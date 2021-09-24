using Application.Interfaces;
using Application.Mapper;
using Application.Models.Base;
using Application.Models.Weather;
using Core.Interfaces;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IExternalWheatherService _externalWheatherService;

        public WeatherService(IWeatherRepository weatherRepository,
            ICityRepository cityRepository,
            IExternalWheatherService externalWheatherService
            )
        {
            _weatherRepository = weatherRepository ?? throw new ArgumentNullException(nameof(weatherRepository));
            _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
            _externalWheatherService = externalWheatherService ?? throw new ArgumentNullException(nameof(externalWheatherService));
        }

        public async Task<WeatherModel> Current(long cityId)
        {
            var city = await _cityRepository.GetByIdAsync(cityId);
            if (city == null)
            {
                throw new ApplicationException("City not avaliable");
            }

            var current = await _externalWheatherService.FetchCurrentByCity(city.Name);
            if (current == null || !current.Valid())
            {
                throw new ApplicationException("External wheater is not avaliable");
            }

            var newEntity = ObjectMapper.Mapper.Map<Weather>(current);

            newEntity.CityId = cityId;
            await _weatherRepository.AddAsync(newEntity);

            var mapped = ObjectMapper.Mapper.Map<WeatherModel>(newEntity);

            return mapped;
        }


        public async Task<BaseListModel<WeatherModel>> Historical(long cityId, int pageNumber, int pageSize, string orderBy)
        {
            var pageableList = await _weatherRepository.GetPageableListAsync(cityId, pageNumber, pageSize, orderBy);

            var mapped = ObjectMapper.Mapper.Map<BaseListModel<WeatherModel>>(pageableList);
            return mapped;
        }

    }
}
