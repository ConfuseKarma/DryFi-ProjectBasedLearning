using DryFi_ProjectBasedLearning_MVC.DAO;
using DryFi_ProjectBasedLearning_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using DryFi_ProjectBasedLearning_MVC.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DryFi_ProjectBasedLearning_MVC.Controllers
{
    public class MaquinaController : PadraoController<MaquinaViewModel>
    {
        public MaquinaController()
        {
            DAO = new MaquinaDAO();
            GeraProximoId = true;
        }

        public IActionResult ListarMaquina()
        {
            List<MaquinaViewModel> maquina = new List<MaquinaViewModel>();
            return View("Index", maquina);
        }

        public IActionResult MaquinaRegistro()
        {
            ViewBag.Operacao = "I";
            MaquinaViewModel maquina = new MaquinaViewModel();
            MaquinaDAO dao = new MaquinaDAO();
            maquina.Id = dao.ProximoId();
            return View("Form", maquina);
        }

        protected override void ValidaDados(MaquinaViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (operacao == "A" && DAO.Consulta(model.IdCliente) == null)
                ModelState.AddModelError("idCliente", "Este registro de cliente não existe!");
            if (model.IdCliente <= 0)
                ModelState.AddModelError("idCliente", "Id de cliente inválido!");
        }

        public IActionResult ObtemDadosConsultaAvancada(int maqStatus, int idCliente, string nomeCliente)
        {
            try
            {
                MaquinaDAO dao = new MaquinaDAO();
                if (nomeCliente == null)
                    nomeCliente = "";

                List<MaquinaViewModel> lista = dao.ConsultaAvancadaMaquina(maqStatus, idCliente, nomeCliente);
                return PartialView("_ListMaquina", lista);
            }
            catch (Exception erro)
            {
                return Json(new { erro = true, msg = erro.Message });
            }
        }

        public List<SelectListItem> GetMachineStatusList()
        {
            return Enum.GetValues(typeof(MachineStatusEnum))
                       .Cast<MachineStatusEnum>()
                       .Select(e => new SelectListItem
                       {
                           Value = ((int)e).ToString(),
                           Text = e.ToString()
                       }).ToList();
        }
    }
}
