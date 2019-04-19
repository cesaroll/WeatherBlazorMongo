using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MongoDB.Driver;
using Weather.Shared;

namespace Weather.Server.Repository.Mongo.DAL
{
    public static class AutomapperConfiguration
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Model.Weather, WeatherForecast>()
                    .ForMember(weatherForecast => weatherForecast.TemperatureF, opt => opt.Ignore());
                cfg.CreateMap<WeatherForecast, Model.Weather>()
                    .ForMember(weather => weather.Id, opt => opt.Ignore());
            });

            return config;
        }
    }
}
