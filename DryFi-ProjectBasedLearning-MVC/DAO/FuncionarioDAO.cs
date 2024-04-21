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
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("id", model.Id);
            parametros[1] = new SqlParameter("nome", model.Nome);
            parametros[2] = new SqlParameter("cargo", model.Cargo);
            parametros[3] = new SqlParameter("foto", model.Foto);
            parametros[4] = new SqlParameter("idDepartamento", model.IdDepartamento);
            parametros[5] = new SqlParameter("email", model.Email);
            return parametros;
        }

        protected override FuncionarioViewModel MontaModel(DataRow registro)
        {
            FuncionarioViewModel a = new FuncionarioViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.Nome = registro["nome"].ToString();
            a.Cargo = registro["cargo"].ToString();
            a.Foto = registro["foto"].ToString();
            a.IdDepartamento = Convert.ToInt32(registro["idDepartamento"]);
            a.Email = registro["email"].ToString();
            return a;
        }
        protected override void SetTabela()
        {
            Tabela = "funcionarios";
        }
    }


}
