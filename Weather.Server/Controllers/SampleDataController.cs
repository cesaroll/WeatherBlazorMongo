using Weather.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Server.Repository.Interfaces.DAL;
using Weather.Server.Repository.Model;
using Weather.Server.Repository.Mongo.DAL;

namespace Weather.Server.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        #region Private Properties

        private IWeatherDataAccessLayer WeatherDAL { get; }

        #endregion

        #region Constructor

        public SampleDataController()
        {
            WeatherDAL = WeatherDataAccessLayer.GetInstance();
        }


        #endregion

        #region Actions

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            return WeatherDAL.GetAllWeathers();
        }

        //private static string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //[HttpGet("[action]")]
        //public IEnumerable<WeatherForecast> WeatherForecasts()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    });
        //}

        #endregion

    }
}
