using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using MongoDB.Driver;

namespace Weather.Server.Repository.Mongo.DB
{
    public class WeatherDBContext
    {
        private IMongoDatabase MongoDatabase { get; }

        public WeatherDBContext(IMongoClient client)
        {
            MongoDatabase = client.GetDatabase("Weather");
        }

        public IMongoCollection<Model.Weather> WeatherCollection => MongoDatabase.GetCollection<Model.Weather>("WeatherRecord");


        public static WeatherDBContext GetInstance()
        {
            return new WeatherDBContext(new MongoClient("mongodb+srv://cesarl:STart123@clusterces-s5jn4.mongodb.net/test?retryWrites=true"));
        }

    }
}
