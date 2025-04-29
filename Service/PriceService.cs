using StockPriceMicroservice.Models;
using StockPriceMicroservice.Repository;

namespace StockPriceMicroservice.Service
{
    public class PriceService
    {
        private readonly IPriceRepository _PriceRepository;

        public PriceService(IPriceRepository repository)
        {
            _PriceRepository = repository;
        }

        public async Task AddPriceAsync(Price price)
        {
            await _PriceRepository.AddPriceAsync(price);
        }

        public async Task<List<Price>> GetPricesBySymbolAsync(string symbol)
        {
            return await _PriceRepository.GetPricesBySymbolAsync(symbol);
        }

        public async Task<List<Price>> GetPricesBySymbolAndDateAsync(string symbol, DateTime startDate, DateTime endDate)
        {
            return await _PriceRepository.GetPricesBySymbolAndDateAsync(symbol, startDate, endDate);
        }
    }
}
