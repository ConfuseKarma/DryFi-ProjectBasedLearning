using System;
using System.Net.Http;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using DryFi_ProjectBasedLearning_MVC.Models;
using Newtonsoft.Json;
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
                var request = new HttpRequestMessage(HttpMethod.Get, $"http://20.185.230.186:8666/STH/v2/entities/urn:ngsi-ld:Temp:001/attrs/temperature?type=Temp&hOffset={offset}&lastN=100");

                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(content);

                // Acessar a propriedade 'value' que é um array
                var dataBatch = (JArray)jsonObject["value"];

                foreach (var item in dataBatch)
                {
                    var obj = item as JObject;
                    if (obj != null &&
                        obj.TryGetValue("_id", out JToken idToken) && !string.IsNullOrWhiteSpace(idToken.ToString()) &&
                        obj.TryGetValue("recvTime", out JToken recvTimeToken) && !string.IsNullOrWhiteSpace(recvTimeToken.ToString()) &&
                        obj.TryGetValue("attrName", out JToken attrNameToken) && !string.IsNullOrWhiteSpace(attrNameToken.ToString()) &&
                        obj.TryGetValue("attrType", out JToken attrTypeToken) && !string.IsNullOrWhiteSpace(attrTypeToken.ToString()) &&
                        obj.TryGetValue("attrValue", out JToken attrValueToken) && !string.IsNullOrWhiteSpace(attrValueToken.ToString()))
                    {
                        allData.Add(obj);
                    }
                }

                if (offset >= 100)
                {
                    break; // Termina o loop se não houver mais dados ou se o limite de 1000 for atingido
                }

                offset += batchSize;
            }
            return allData;
        }

        public async Task<List<JObject>> GetTemperatura1()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("http://20.185.230.186:8666/STH/v2/entities/urn:ngsi-ld:Temp:001/attrs/temperature?type=Temp&lastN=100");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var jsonArray = JArray.Parse(content);

                // Converte o JArray para List<JObject>
                List<JObject> jsonObjectList = jsonArray.Select(item => (JObject)item).ToList();

                return jsonObjectList;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
                throw;
            }
        }


        public async Task CreateMachine(MaquinaViewModel maquina)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://20.185.230.186:4041/iot/devices");

            // Adicionar cabeçalhos
            request.Headers.Add("fiware-service", "smart");
            request.Headers.Add("fiware-servicepath", "/");

            // Converter objeto MaquinaViewModel para JSON
            var jsonContent = JsonConvert.SerializeObject(new
            {
                devices = new[]
                {
                new
                {
                    device_id = $"maq{maquina.IdCliente}",
                    entity_name = $"urn:ngsi-ld:Maq:{maquina.IdCliente}",
                    entity_type = "Maq",
                    protocol = "PDI-IoTA-UltraLight",
                    transport = "MQTT",
                    attributes = new[]
                    {
                        new { object_id = "s", name = "status", type = "Integer" },
                        new { object_id = "d", name = "descricaoStatus", type = "String" },
                        new { object_id = "e", name = "endereco", type = "String" }
                    }
                }
            }
            });

            // Adicionar conteúdo JSON à requisição
            request.Content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

            // Enviar requisição
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // Ler a resposta
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
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
