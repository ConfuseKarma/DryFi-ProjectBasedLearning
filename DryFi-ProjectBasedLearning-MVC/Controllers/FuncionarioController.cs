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
            if (model.Imagem == null && operacao == "I")
                ModelState.AddModelError("Imagem", "Escolha uma imagem.");
            if (model.Imagem != null && model.Imagem.Length / 1024 / 1024 >= 2)
                ModelState.AddModelError("Imagem", "Imagem limitada a 2 mb.");
            if (ModelState.IsValid)
            {
                //na alteração, se não foi informada a imagem, iremos manter a que já estava salva.
                if (operacao == "A" && model.Imagem == null)
                {
                    FuncionarioViewModel func = DAO.Consulta(model.Id);
                    model.ImagemEmByte = func.ImagemEmByte;
                }
                else
                {
                    model.ImagemEmByte = ConvertImageToByte(model.Imagem);
                }
            }
        }

        public byte[] ConvertImageToByte(IFormFile file)
        {
            if (file != null)
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    return ms.ToArray();
                }
            else
                return null;
        }


    }
}
