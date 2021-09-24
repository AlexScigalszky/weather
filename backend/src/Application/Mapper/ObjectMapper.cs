using Application.Models.Base;
using Application.Models.User;
using Application.Models.Weather;
using AutoMapper;
using Core.Models;
using Core.Models.ExternalWheater;
using Domain.Entities;
using System;

namespace Application.Mapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<SeapolDtoMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }

    public class SeapolDtoMapper : Profile
    {
        public SeapolDtoMapper()
        {
            /**
             * Trim all strings
             * */
            CreateMap<string, string>()
                .ConvertUsing(str => (str ?? "").Trim());

            /**
             * Models
             * */
            CreateMap(typeof(PageableList<>), typeof(BaseListModel<>))
                .ReverseMap();
            CreateMap<Country, CountryModel>()
                .ReverseMap();
            CreateMap<City, CityModel>()
                .ReverseMap();
            CreateMap<Domain.Entities.Weather, WeatherModel>()
                .ReverseMap();
            CreateMap<ExternalWheaterModel, WeatherModel>();
            CreateMap<ExternalWheaterModel, Domain.Entities.Weather>()
                .ForMember(dest => dest.Temperture, opt => opt.MapFrom(src => src.Temperature()))
                .ForMember(dest => dest.Sensation, opt => opt.MapFrom(src => src.Sensation()));
            CreateMap<OpenWeatherModel, WeatherModel>()
                .ForMember(dest => dest.Temperture, opt => opt.MapFrom(src => src.Main.Temp))
                .ForMember(dest => dest.Sensation, opt => opt.MapFrom(src => src.Main.FeelsLike));
            /**
             * DTOs
             * */
            CreateMap<Country, CountryDto>()
                .ReverseMap();
            CreateMap<Domain.Entities.Weather, WeatherDto>()
                .ReverseMap();
            CreateMap<City, CityDto>()
                .ReverseMap();
        }
    }
}
