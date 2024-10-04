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
        private readonly WebSocketPriceService _webSocketService;
        private readonly HistoricalPriceService _historicalPriceService;


        public PriceController(PriceService priceService, HistoricalPriceService historicalPriceService)
        {
            _priceService = priceService;
            var webSocketUri = "wss://platform.fintacharts.com";
            _webSocketService = new WebSocketPriceService(webSocketUri);
            _historicalPriceService = historicalPriceService;
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


        [HttpGet("api/assets/historical")]
        public async Task<IActionResult> GetHistoricalPrices([FromQuery] string asset, [FromQuery] string startDate, [FromQuery] string endDate)
        {
            var prices = await _historicalPriceService.GetHistoricalPrices(asset, startDate, endDate);
            return Ok(prices);
        }

        [HttpGet("start-websocket")]
        public async Task<IActionResult> StartWebSocket()
        {
            await _webSocketService.ConnectAsync();
            return Ok("WebSocket connection started.");
        }

        [HttpGet("close-websocket")]
        public async Task<IActionResult> CloseWebSocket()
        {
            await _webSocketService.CloseAsync();
            return Ok("WebSocket connection closed.");
        }
    }
}
