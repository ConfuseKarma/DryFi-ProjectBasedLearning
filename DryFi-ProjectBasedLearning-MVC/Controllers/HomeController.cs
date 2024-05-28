using DryFi_ProjectBasedLearning_MVC.DAO;
using DryFi_ProjectBasedLearning_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using DryFi_ProjectBasedLearning_MVC.Services;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace DryFi_ProjectBasedLearning_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PostmanRequests _postman;
        public HomeController(ILogger<HomeController> logger, PostmanRequests postman)
        {
            _logger = logger;
            _postman = postman;
        }
        [HttpGet]
        public async Task<IActionResult> GetTemperatura()
        {
            try
            {
                List<JObject> temperatura = await _postman.GetTemperatura1000();
                return Ok(temperatura);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        //TESTE POSTMAN


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}