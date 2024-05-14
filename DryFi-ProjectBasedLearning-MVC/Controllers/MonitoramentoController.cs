using DryFi_ProjectBasedLearning_MVC.DAO;
using DryFi_ProjectBasedLearning_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DryFi_ProjectBasedLearning_MVC.Controllers
{
    public class MonitoramentoController : PadraoController<MonitoramentoViewModel>
    {
        public MonitoramentoController()
        {
            DAO = new MonitoramentoDAO();
            GeraProximoId = true;
        }
        public IActionResult MaquinaRegistro()
        {
            ViewBag.Operacao = "I";
            MonitoramentoViewModel maquina = new MonitoramentoViewModel();
            MonitoramentoDAO dao = new MonitoramentoDAO();
            maquina.Id = dao.ProximoId();
            return View("Form", maquina);
        }

        protected override void ValidaDados(MonitoramentoViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (operacao == "A" && DAO.Consulta(model.idMaquina) == null)
                ModelState.AddModelError("idCliente", "Este registro de cliente não existe!");
            if (model.temperatura == null)
                ModelState.AddModelError("Temperatura", "Temperatura não pode ser nula!");
        }
    }
}
