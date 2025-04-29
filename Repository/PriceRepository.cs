using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StockPriceMicroservice.Config;
using StockPriceMicroservice.Models;

namespace StockPriceMicroservice.Repository
{
    public class PriceRepository : IPriceRepository
    {
        private readonly IMongoCollection<Price> _collection;

        public PriceRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<Price>("Prices");
        }

        public async Task AddPriceAsync(Price price)
        {
            await _collection.InsertOneAsync(price);
        }

        public async Task<List<Price>> GetPricesBySymbolAsync(string symbol)
        {
            return await _collection.Find(P => P.Symbol == symbol).ToListAsync();
        }

        public async Task<List<Price>> GetPricesBySymbolAndDateAsync(string symbol, DateTime startDate, DateTime endDate)
        {
            var filter = Builders<Price>.Filter.And(
                Builders<Price>.Filter.Eq(p => p.Symbol, symbol),
                Builders<Price>.Filter.Gte(p => p.Timestamp, startDate),
                Builders<Price>.Filter.Lte(p => p.Timestamp, endDate)
            );

            return await _collection.Find(filter).ToListAsync();
        }
    }
}
