using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Weather.Server.Repository.Model
{
    public class Weather
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}
