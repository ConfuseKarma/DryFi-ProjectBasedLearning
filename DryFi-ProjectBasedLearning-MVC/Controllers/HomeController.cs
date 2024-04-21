using DryFi_ProjectBasedLearning_MVC.DAO;
using DryFi_ProjectBasedLearning_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DryFi_ProjectBasedLearning_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult FuncRegistro() 
        {
            ViewBag.Operacao = "I";
            FuncionarioViewModel funcionario = new FuncionarioViewModel();
            FuncionarioDAO dao = new FuncionarioDAO();
            funcionario.Id = dao.ProximoId();            
            return View("FuncRegistro", funcionario); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}