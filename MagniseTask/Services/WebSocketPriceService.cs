using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace MagniseTask.Services
{
    public class WebSocketPriceService
    {
        private readonly Uri _webSocketUri;
        private ClientWebSocket _client;

        public WebSocketPriceService(string uri)
        {
            _webSocketUri = new Uri(uri);
            _client = new ClientWebSocket();
        }

        public async Task ConnectAsync()
        {
            try
            {
                await _client.ConnectAsync(_webSocketUri, CancellationToken.None);
                Console.WriteLine("WebSocket connection established.");
                await ReceiveMessagesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during connection: {ex.Message}");
            }
        }

        private async Task ReceiveMessagesAsync()
        {
            var buffer = new byte[1024 * 4];
            while (_client.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await _client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine($"Message received: {message}");
            }
        }

        public async Task CloseAsync()
        {
            if (_client.State == WebSocketState.Open)
            {
                await _client.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                Console.WriteLine("WebSocket connection closed.");
            }
        }
    }
}
