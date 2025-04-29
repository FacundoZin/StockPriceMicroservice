using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPriceMicroservice.Models;
using StockPriceMicroservice.Service;

namespace StockPriceMicroservice.Controllers
{
    [Route("api/[controller]/Price")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly PriceService _PriceService;

        public PriceController (PriceService priceService)
        {
            _PriceService = priceService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPrice([FromBody] Price price)
        {
            await _PriceService.AddPriceAsync(price);
            return Ok();
        }

        [HttpGet("{symbol}")]
        public async Task<IActionResult> GetPrices(string symbol)
        {
            var prices = await _PriceService.GetPricesBySymbolAsync(symbol);
            return Ok(prices);
        }

        [HttpGet("{symbol}/between/{startDate}/{endDate}")]
        public async Task<IActionResult> GetPricesBetweenDates(string symbol, DateTime startDate, DateTime endDate)
        {
            var prices = await _PriceService.GetPricesBySymbolAndDateAsync(symbol, startDate, endDate);
            return Ok(prices);
        }
    }
}
