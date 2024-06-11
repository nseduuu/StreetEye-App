using Newtonsoft.Json;
using System.Text;

namespace StreetEye_App.Services.Whatsapp
{
    public class WhatsappService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "YOUR_GUPSHUP_API_KEY"; // Substituir pelo valor real
        private const string ApiUrl = "https://api.gupshup.io/sm/api/v1/msg"; // URL da API do Gupshup

        public WhatsappService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("apikey", ApiKey);
        }

        public async Task<bool> SendMessage(string phoneNumber, string message)
        {
            var payload = new
            {
                channel = "whatsapp", // Configuração do canal
                source = "YOUR_WHATSAPP_NUMBER", // Substituir pelo número do WhatsApp registrado no Gupshup
                destination = phoneNumber,
                message = new
                {
                    type = "text",
                    text = message
                }
            };

            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(ApiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    // Log ou ação adicional em caso de sucesso
                    return true;
                }
                else
                {
                    // Log ou ação adicional em caso de falha
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Erro ao enviar mensagem: {responseContent}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Tratamento de exceções
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }
    }
}
