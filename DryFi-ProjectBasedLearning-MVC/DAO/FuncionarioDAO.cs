using DryFi_ProjectBasedLearning_MVC.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace DryFi_ProjectBasedLearning_MVC.DAO
{
    public class FuncionarioDAO : PadraoDAO<FuncionarioViewModel>
    {
        protected override SqlParameter[] CriaParametros(FuncionarioViewModel model)
        {
            object imgByte = model.ImagemEmByte;
            if (imgByte == null)
                imgByte = DBNull.Value;

            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("id", model.Id);
            parametros[1] = new SqlParameter("nome", model.Nome);
            parametros[2] = new SqlParameter("cargoId", model.CargoId);
            parametros[3] = new SqlParameter("email", model.Email);
            parametros[4] = new SqlParameter("imagem", imgByte);
            return parametros;
        }

        protected override FuncionarioViewModel MontaModel(DataRow registro)
        {
            FuncionarioViewModel a = new FuncionarioViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.Nome = registro["nome"].ToString();
            a.CargoId = Convert.ToInt32(registro["cargoId"]);
            a.Email = registro["email"].ToString();
            if (registro["imagem"] != DBNull.Value)
                a.ImagemEmByte = registro["imagem"] as byte[];
            
                                       
            if (registro.Table.Columns.Contains("DescricaoCategoria"))
                a.DescricaoCategoria = registro["DescricaoCategoria"].ToString();
            return a;
        }

        public List<FuncionarioViewModel> ConsultaAvancadaFuncionario(string nome,
                                                         int cargo)
        {
            SqlParameter[] p = {
             new SqlParameter("nome", nome),
             new SqlParameter("cargo", cargo),
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsultaAvancadaFuncionarios", p);
            var lista = new List<FuncionarioViewModel>();
            foreach (DataRow dr in tabela.Rows)
                lista.Add(MontaModel(dr));
            return lista;
        }


        protected override void SetTabela()
        {
            Tabela = "Funcionario";
        }
    }


}
