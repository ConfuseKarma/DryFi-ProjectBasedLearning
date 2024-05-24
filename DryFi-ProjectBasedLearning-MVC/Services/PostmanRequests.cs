using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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

        public async Task<List<JObject>> GetTemperatura1000()
        {
            var allData = new List<JObject>();
            int offset = 0;
            const int batchSize = 100;

            while (true)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"http://20.185.230.186:8666/STH/v2/entities/urn:ngsi-ld:Temp:001/attrs/temperature?type=Temp&hOffset={offset}&lastN={batchSize}");
                request.Headers.Add("fiware-service", "smart");
                request.Headers.Add("fiware-servicepath", "/");

                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var dataBatch = JArray.Parse(content); // Assumindo que o conteúdo seja um array JSON
                
                allData.AddRange((IEnumerable<JObject>)dataBatch);

                if (offset >= 1000)
                {
                    break; // Termina o loop se não houver mais dados
                }

                offset += batchSize;
            }
            return allData;
        }

        public async Task<string> GetTemperatura1()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("http://20.185.230.186:8666/STH/v2/entities/urn:ngsi-ld:Temp:001/attrs/temperature?type=Temp&lastN=100");
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

        public async Task<string> GetLuminosidadeDaLampada()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("http://10.5.10.34:8666/STH/v1/contextEntities/type/Lamp/id/urn:ngsi-ld:Lamp:001/attributes/luminosity?lastN=30");
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
        //CONSULTAR TEMPERATURA COM DADOS DA AULA
        //var client = new HttpClient();
        //var request = new HttpRequestMessage(HttpMethod.Get, "http://20.185.230.186:8666/STH/v2/entities/urn:ngsi-ld:Temp:001/attrs/temperature?type=Temp&lastN=30");
        //request.Headers.Add("fiware-service", "smart");
        //request.Headers.Add("fiware-servicepath", "/");
        //var response = await client.SendAsync(request);
        //response.EnsureSuccessStatusCode();
        //Console.WriteLine(await response.Content.ReadAsStringAsync());

        //CRIAR MÁQUINA
        //var client = new HttpClient();
        //var request = new HttpRequestMessage(HttpMethod.Post, "http://20.185.230.186:4041/iot/devices");
        //request.Headers.Add("fiware-service", "smart");
        //request.Headers.Add("fiware-servicepath", "/");
        //var content = new StringContent("{\n  \"devices\": [\n    {\n      \"device_id\":   \"temp001\",         \n      \"entity_name\": \"urn:ngsi-ld:Temp:001\",   \n      \"entity_type\": \"Temp\",          \n      \"protocol\":    \"PDI-IoTA-UltraLight\",  \n      \"transport\":   \"MQTT\",            \n\n      \n      \"attributes\": [\n        { \"object_id\": \"t\", \"name\": \"temperature\", \"type\": \"Float\" }  \n      ]\n    }\n  ]\n}\n", null, "application/json");
        //request.Content = content;
        //var response = await client.SendAsync(request);
        //response.EnsureSuccessStatusCode();
        //Console.WriteLine(await response.Content.ReadAsStringAsync());

        //BUSCAR MEDIDAS
        //var client = new HttpClient();
        //var request = new HttpRequestMessage(HttpMethod.Get, "http://20.185.230.186:8666/STH/v2/entities/urn:ngsi-ld:Temp:001/attrs/temperature?type=Temp&lastN=100");
        //request.Headers.Add("fiware-service", "smart");
        //request.Headers.Add("fiware-servicepath", "/");
        //var response = await client.SendAsync(request);
        //response.EnsureSuccessStatusCode();
        //Console.WriteLine(await response.Content.ReadAsStringAsync());

        /*var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "http://20.185.230.186:4041/iot/devices");
        request.Headers.Add("fiware-service", "smart");
        request.Headers.Add("fiware-servicepath", "/");
        var content = new StringContent("{\r\n  \"devices\": [\r\n    {\r\n      \"device_id\": \"heatG001\",         \n      \"entity_name\": \"urn:ngsi-ld:heatG:001\",   \n      \"entity_type\": \"heatG\",          \n      \"protocol\": \"PDI-IoTA-UltraLight\",  \n      \"transport\": \"MQTT\",            \n\r\n      \n      \"commands\": [\r\n        { \"name\": \"on\", \"type\": \"command\" },  \n        { \"name\": \"off\", \"type\": \"command\" }  \n      ],\r\n\r\n      \n      \"attributes\": [\r\n        { \"object_id\": \"s\", \"name\": \"state\", \"type\": \"Text\" }, \n        { \"object_id\": \"t\", \"name\": \"temperature\", \"type\": \"Float\" }  \n      ]\r\n    }\r\n  ]\r\n}", null, "application/json");
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());*/
        // Adicione métodos para outras requisições do Postman conforme necessário
    }
}
