using DryFi_ProjectBasedLearning_MVC.DAO;
using DryFi_ProjectBasedLearning_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DryFi_ProjectBasedLearning_MVC.Controllers
{
    public class ClienteController : PadraoController<ClienteViewModel>
    {
        public ClienteController()
        {
            DAO = new ClienteDAO();
            GeraProximoId = true;
            //List<ClienteViewModel> clienteViewModels = new List<ClienteViewModel>();
            //clienteViewModels.Add();
        }
        public IActionResult ListarCliente()
        {
            List<ClienteViewModel> cliente = new List<ClienteViewModel>();
            return View("Index", cliente);
        }
        public IActionResult ClienteRegistro()
        {
            ViewBag.Operacao = "I";
            ClienteViewModel cliente = new ClienteViewModel();
            ClienteDAO dao = new ClienteDAO();
            cliente.Id = dao.ProximoId();
            return View("Form", cliente);
        }
        protected override void ValidaDados(ClienteViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.NomeCliente))
                ModelState.AddModelError("Nome", "Preencha o nome.");
            if (string.IsNullOrEmpty(model.Cnpj))
                ModelState.AddModelError("CNPJ", "Preencha o CNPJ.");
            if (string.IsNullOrEmpty(model.Email))
                ModelState.AddModelError("Email", "Preencha o Email.");
            if (string.IsNullOrEmpty(model.Telefone))
                ModelState.AddModelError("Telefone", "Preencha o Telefone.");
        }
    }
}
