using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Server.Repository.Interfaces.DAL
{
    public interface IWeatherDataAccessLayer
    {
        /// <summary>
        /// Retrieve a Collection of Weather
        /// </summary>
        /// <returns></returns>
        List<Model.Weather> GetAllWeathers();

        /// <summary>
        /// Add Weather
        /// </summary>
        /// <param name="weather"></param>
        void AddWeather(Model.Weather weather);

        /// <summary>
        /// Get Weather
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Model.Weather GetWeather(DateTime id);

        /// <summary>
        /// Update Weather
        /// </summary>
        /// <param name="weather"></param>
        void UpdateWeather(Model.Weather weather);

        /// <summary>
        /// Delete Weather
        /// </summary>
        /// <param name="id"></param>
        void DeleteWeather(DateTime id);


    }
}
