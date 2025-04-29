using StockPriceMicroservice.Models;

namespace StockPriceMicroservice.Repository
{
    public interface IPriceRepository
    {
        Task AddPriceAsync(Price price);
        Task<List<Price>> GetPricesBySymbolAsync(string symbol);
        Task<List<Price>> GetPricesBySymbolAndDateAsync(string symbol, DateTime startDate, DateTime endDate);
    }
}
