using DryFi_ProjectBasedLearning_MVC.DAO;
using DryFi_ProjectBasedLearning_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlTypes;

namespace DryFi_ProjectBasedLearning_MVC.Controllers
{
    public class FuncionarioController : PadraoController<FuncionarioViewModel>
    {
        public FuncionarioController()
        {
            DAO = new FuncionarioDAO();
            GeraProximoId = true;
        }
        public IActionResult ListarFunc()
        {
            List<FuncionarioViewModel> func = new List<FuncionarioViewModel>();
            return View("Index", func);
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

        public IActionResult ConsultaAvancadaFuncionario()
        {
            try
            {
                // PreparaComboCategorias();
                ViewBag.Categorias.Insert(0, new SelectListItem("TODAS", "0"));
                return View("Listagem");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }

        public IActionResult ObtemDadosConsultaAvancada(string nome,
                                                         int cargo)
        {
            try
            {
                FuncionarioDAO dao = new FuncionarioDAO();
                if (string.IsNullOrEmpty(nome))
                    nome = "";
                var lista = dao.ConsultaAvancadaFuncionario(nome, cargo);
                return PartialView("pvGridJogos", lista);
            }
            catch (Exception erro)
            {
                return Json(new { erro = true, msg = erro.Message });
            }
        }
        //private void PreparaComboCategorias()
        //{
        //    CategoriaDAO dao = new CategoriaDAO();
        //    var lista = dao.Listagem();
        //    List<SelectListItem> listaRetorno = new List<SelectListItem>();
        //    foreach (var categ in lista)
        //        listaRetorno.Add(new SelectListItem(categ.Descricao, categ.Id.ToString()));

        //    ViewBag.Categorias = listaRetorno;
        //}


    }
}
