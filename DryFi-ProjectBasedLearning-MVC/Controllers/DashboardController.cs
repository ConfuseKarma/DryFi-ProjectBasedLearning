using DryFi_ProjectBasedLearning_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace DryFi_ProjectBasedLearning_MVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PostmanRequests _postman;
        public DashboardController(ILogger<HomeController> logger, PostmanRequests postman)
        {
            _logger = logger;
            _postman = postman;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetTemperatura1000()
        {
            try
            {
                List<JObject> temperatura = await _postman.GetTemperatura1000();

                // Adicionando logs para verificar o conteúdo da lista
                foreach (var item in temperatura)
                {
                    Console.WriteLine(item.ToString());
                }

                // Se desejar, pode transformar os dados em um formato mais amigável
                var formattedTemperatura = temperatura.Select(t => new
                {
                    Id = t["_id"]?.ToString(),
                    RecvTime = t["recvTime"]?.ToString(),
                    AttrName = t["attrName"]?.ToString(),
                    AttrType = t["attrType"]?.ToString(),
                    AttrValue = t["attrValue"]?.ToString()
                }).ToList();

                return Ok(formattedTemperatura);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
