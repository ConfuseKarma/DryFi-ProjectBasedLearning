using DryFi_ProjectBasedLearning_MVC.DAO;
using DryFi_ProjectBasedLearning_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DryFi_ProjectBasedLearning_MVC.Controllers
{
    public class FuncionarioController : PadraoController<FuncionarioViewModel>
    {
        public FuncionarioController()
        {
            DAO = new FuncionarioDAO();
            GeraProximoId = true;
        }
        public IActionResult FuncRegistro()
        {
            ViewBag.Operacao = "I";
            FuncionarioViewModel funcionario = new FuncionarioViewModel();
            FuncionarioDAO dao = new FuncionarioDAO();
            funcionario.Id = dao.ProximoId();
            return View("Form", funcionario);
        }
        public IActionResult Login()
        {
            return View();
        }
        protected override void ValidaDados(FuncionarioViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Nome))
                ModelState.AddModelError("Nome", "Preencha o nome.");
        }

    }
}
