using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Weather.Server.Repository.Interfaces.DAL;
using Weather.Server.Repository.Mongo.DB;
using MongoDB.Driver;

namespace Weather.Server.Repository.Mongo.DAL
{
    class WeatherDataAccessLayer : IWeatherDataAccessLayer
    {
        private WeatherDBContext DBCtx { get; }

        public WeatherDataAccessLayer(WeatherDBContext context)
        {
            DBCtx = context;
        }

        #region Public Properties

        public List<Model.Weather> GetAllWeathers()
        {
            try
            {
                var cursorTask = DBCtx.WeatherCollection.FindAsync(_ => true);
                cursorTask.Wait();

                var listTask = cursorTask.Result.ToListAsync();
                listTask.Wait();

                return listTask.Result;

            }
            catch
            {
                //TODO: Use a logger
                throw;
            }
        }

        public void AddWeather(Model.Weather weather)
        {
            try
            {
                DBCtx.WeatherCollection.InsertOne(weather);
            }
            catch 
            {
                throw;
            }
        }

        public Model.Weather GetWeather(DateTime id)
        {
            try
            {
                var cursorTask = DBCtx.WeatherCollection.FindAsync(x => x.DateTime == id);
                cursorTask.Wait();

                return cursorTask.Result.FirstOrDefault();
            }
            catch
            {
                
                throw;
            }
        }

        public void UpdateWeather(Model.Weather weather)
        {
            try
            {
                DBCtx.WeatherCollection.ReplaceOne(x => x.DateTime == weather.DateTime, weather);
            }
            catch 
            {
                
                throw;
            }
        }

        public void DeleteWeather(DateTime id)
        {
            try
            {
                DBCtx.WeatherCollection.DeleteOne(x => x.DateTime == id);
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
            return new WeatherDataAccessLayer(WeatherDBContext.GetInstance());
        }

        #endregion

    }
}
