using System;

namespace Weather.Server.Repository.Model
{
    public class Weather
    {
        public DateTime DateTime { get; set; }

        public int TemperatureC { get; set; }

        public string Sumary { get; set; }
    }
}
