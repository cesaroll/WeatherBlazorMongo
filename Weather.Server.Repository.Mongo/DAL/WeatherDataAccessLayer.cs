using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using AutoMapper;
using Weather.Server.Repository.Interfaces.DAL;
using Weather.Server.Repository.Mongo.DB;
using MongoDB.Driver;
using Weather.Shared;

namespace Weather.Server.Repository.Mongo.DAL
{
    public class WeatherDataAccessLayer : IWeatherDataAccessLayer
    {
        private WeatherDBContext DBCtx { get; }
        private readonly IMapper mapper;

        public WeatherDataAccessLayer(WeatherDBContext context, IMapper mapper)
        {
            DBCtx = context;
            this.mapper = mapper;
        }

        #region Public Properties

        public List<WeatherForecast> GetAllWeathers()
        {
            try
            {
                var cursorTask = DBCtx.WeatherCollection.FindAsync(_ => true);
                cursorTask.Wait();

                var listTask = cursorTask.Result.ToListAsync();
                listTask.Wait();

                var weathers = listTask.Result;

                var list = mapper.Map<List<Model.Weather>, List<WeatherForecast>>(weathers);

                return list;

            }
            catch
            {
                //TODO: Use a logger
                throw;
            }
        }

        public void AddWeather(WeatherForecast weatherForecast)
        {
            try
            {
                var weather = mapper.Map<WeatherForecast, Model.Weather>(weatherForecast);

                DBCtx.WeatherCollection.InsertOneAsync(weather).Wait();

            }
            catch 
            {
                throw;
            }
        }

        public WeatherForecast GetWeather(DateTime date)
        {
            try
            {
                var cursorTask = DBCtx.WeatherCollection.FindAsync(x => x.Date == date);
                cursorTask.Wait();

                var weather = cursorTask.Result.FirstOrDefault();

                return mapper.Map<Model.Weather, WeatherForecast>(weather);
            }
            catch
            {
                
                throw;
            }
        }

        public void UpdateWeather(WeatherForecast weatherForecast)
        {
            try
            {
                var weather = mapper.Map<WeatherForecast, Model.Weather>(weatherForecast);
                //DBCtx.WeatherCollection.ReplaceOne(x => x.Date == weather.Date, weather);
                DBCtx.WeatherCollection.ReplaceOneAsync(x => x.Date == weather.Date, weather).Wait();
            }
            catch 
            {
                
                throw;
            }
        }

        public void DeleteWeather(DateTime date)
        {
            try
            {
                //DBCtx.WeatherCollection.DeleteOne(x => x.Date == date);
                DBCtx.WeatherCollection.DeleteOneAsync(x => x.Date == date).Wait();
            }
            catch 
            {
                
                throw;
            }
        }
        #endregion

        #region Get Instance

        public static IWeatherDataAccessLayer GetInstance()
        {
            return new WeatherDataAccessLayer(WeatherDBContext.GetInstance(), AutomapperConfiguration.Configure().CreateMapper());
        }

        #endregion

    }
}
