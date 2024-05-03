using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DryFi_ProjectBasedLearning_MVC.Services
{
    public class PostmanRequests
    {
        private readonly HttpClient _client;

        public PostmanRequests()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("fiware-service", "smart");
            _client.DefaultRequestHeaders.Add("fiware-servicepath", "/");
        }

        public async Task<string> GetLuminosidadeDaLampada()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("http://:8666/STH/v1/contextEntities/type/Lamp/id/urn:ngsi-ld:Lamp:001/attributes/luminosity?lastN=30");
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
                throw;
            }
        }

        // Adicione métodos para outras requisições do Postman conforme necessário
    }
}
