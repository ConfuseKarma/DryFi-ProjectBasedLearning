using DryFi_ProjectBasedLearning_MVC.DAO;
using DryFi_ProjectBasedLearning_MVC.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult ObtemDadosConsultaAvancada(string maqStatus, int idCliente)
        {
            try
            {
                MaquinaDAO dao = new MaquinaDAO();
                if (string.IsNullOrEmpty(maqStatus))
                    maqStatus = "";

                List<MaquinaViewModel> lista = dao.ConsultaAvancadaMaquina(maqStatus, idCliente);
                return PartialView("_ListMaquina", lista);
            }
            catch (Exception erro)
            {
                return Json(new { erro = true, msg = erro.Message });
            }
        }


    }
}
