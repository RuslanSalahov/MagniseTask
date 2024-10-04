using MagniseTask.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MagniseTask.Controllers
{
    [ApiController]
    [Route("api/assets/{assetId}/price")]
    public class PriceController : ControllerBase
    {
        private readonly PriceService _priceService;

        public PriceController(PriceService priceService)
        {
            _priceService = priceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrice(string assetId)
        {
            var realTimePrice = await _priceService.GetRealTimePriceAsync(assetId);
            return Ok(realTimePrice);
        }

        [HttpGet("historical")]
        public async Task<IActionResult> GetHistoricalPrices(string assetId)
        {
            var historicalPrices = await _priceService.GetHistoricalPricesAsync(assetId);
            return Ok(historicalPrices);
        }
    }
}
