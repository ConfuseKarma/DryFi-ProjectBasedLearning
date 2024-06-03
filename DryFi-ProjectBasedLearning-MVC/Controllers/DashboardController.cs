using DryFi_ProjectBasedLearning_MVC.Models;
using DryFi_ProjectBasedLearning_MVC.DAO;
using DryFi_ProjectBasedLearning_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

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
            var dataTable = HelperDAO.ExecutaProcSelect("GetMaquinaIds", null);
            var maquinaIds = new List<int>();

            foreach (DataRow row in dataTable.Rows)
            {
                maquinaIds.Add(Convert.ToInt32(row["Id"]));
            }

            ViewBag.MaquinaIds = maquinaIds;

            DashboardViewModel d = new DashboardViewModel();
            d.Offset = 8000;

            return View(d);
        }
        [HttpGet]
        public async Task<IActionResult> GetTemperatura1000([FromQuery] string machine, [FromQuery] string offset)
        {
            try
            {
                if (!string.IsNullOrEmpty(machine))
                {
                    machine = machine.PadLeft(3, '0');
                }
                List<JObject> temperatura = await _postman.GetTemperatura1000(machine, offset);

                // Adicionando logs para verificar o conteúdo da lista
                //foreach (var item in temperatura)
                //{
                //    Console.WriteLine(item.ToString());
                //}

                // Se desejar, pode transformar os dados em um formato mais amigável
                //var formattedTemperatura = temperatura.Select(t => new
                //{
                //    Id = t["_id"]?.ToString(),
                //    RecvTime = t["recvTime"]?.ToString(),
                //    AttrName = t["attrName"]?.ToString(),
                //    AttrType = t["attrType"]?.ToString(),
                //    AttrValue = t["attrValue"]?.ToString()
                //}).ToList();

                var formattedTemperatura = temperatura.Select(t => new
                {
                    RecvTime = t["recvTime"]?.ToString(),
                    AttrValue = float.Parse(t["attrValue"]?.ToString() ?? "0")
                }).ToList();
                ViewBag.dados = JsonConvert.SerializeObject(formattedTemperatura);
                return PartialView("_GraficoHistorico", formattedTemperatura);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        public IActionResult GetGraficoAoVivo()
        {
            return PartialView("_GraficoAoVivo");
        }

        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> GetLatestTemperatura()
        {
            try
            {
                Console.WriteLine("Método GetLatestTemperatura chamado.");

                List<JObject> temperatura = await _postman.GetTemperatura1();

                if (temperatura == null || !temperatura.Any())
                {
                    Console.WriteLine("Nenhum dado de temperatura recebido da API.");
                    return Json(new List<object>());
                }

                foreach (var item in temperatura)
                {
                    Console.WriteLine($"Item recebido: {item}");
                }

                var latestData = temperatura.Select(t => new
                {
                    RecvTime = t["recvTime"]?.ToString(),
                    AttrValue = t["attrValue"] != null ? float.Parse(t["attrValue"].ToString()) : 0
                }).ToList();

                foreach (var item in latestData)
                {
                    Console.WriteLine($"Dados formatados: RecvTime={item.RecvTime}, AttrValue={item.AttrValue}");
                }

                return Json(latestData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro no método GetLatestTemperatura: {ex.Message}");
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

    }
}
