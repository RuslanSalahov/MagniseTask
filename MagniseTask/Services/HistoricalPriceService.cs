using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MagniseTask.Services
{
    public class HistoricalPriceService
    {
        private readonly HttpClient _httpClient;

        public HistoricalPriceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetHistoricalPrices(string assetSymbol, string startDate, string endDate)
        {
            // Construct the URL with parameters for the historical data
            string url = $"https://platform.fintacharts.com/api/historical?symbol={assetSymbol}&startDate={startDate}&endDate={endDate}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;  // You can parse and return structured data as needed
            }
            else
            {
                throw new Exception("Error fetching historical prices");
            }
        }
    }
}
