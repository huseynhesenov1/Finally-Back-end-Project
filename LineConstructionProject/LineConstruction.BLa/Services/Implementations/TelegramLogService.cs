using System.Text;
using System.Text.Json;

namespace LineConstruction.BLa.Services.Implementations
{
    public class TelegramLogService
    {
        private readonly HttpClient _httpClient;
        private readonly string _botToken;
        private readonly string _chatId;

        public TelegramLogService(string chatId, string botToken, HttpClient httpClient)
        {
            _chatId = chatId;
            _botToken = botToken;
            _httpClient = httpClient;
        }
        public async Task LogAsync(string message)
        {
            string url = $"https://api.telegram.org/bot{_botToken}/sendMessage";
            var payload = new
            {
                chat_id = _chatId,
                text = message
            };
            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Telegram log service failed");
            }
        }
    }
}
