using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace StockPriceMicroservice.Models.MongoDB
{
    public class Price
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Symbol { get; set; }

        public DateTime Timestamp { get; set; }

        public decimal Value { get; set; }
    }
}
