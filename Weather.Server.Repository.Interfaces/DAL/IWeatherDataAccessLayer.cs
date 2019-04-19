using System;
using System.Collections.Generic;
using System.Text;
using Weather.Shared;

namespace Weather.Server.Repository.Interfaces.DAL
{
    public interface IWeatherDataAccessLayer
    {
        /// <summary>
        /// Retrieve a Collection of WeatherForeCast
        /// </summary>
        /// <returns></returns>
        List<WeatherForecast> GetAllWeathers();

        /// <summary>
        /// Add WeatherForecast
        /// </summary>
        /// <param name="weather"></param>
        void AddWeather(WeatherForecast weatherForecast);

        /// <summary>
        /// Get WeatherForecast
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        WeatherForecast GetWeather(DateTime date);

        /// <summary>
        /// Update WeatherForecast
        /// </summary>
        /// <param name="weather"></param>
        void UpdateWeather(WeatherForecast weatherForecast);

        /// <summary>
        /// Delete WeatherForecast
        /// </summary>
        /// <param name="id"></param>
        void DeleteWeather(DateTime date);


    }
}
