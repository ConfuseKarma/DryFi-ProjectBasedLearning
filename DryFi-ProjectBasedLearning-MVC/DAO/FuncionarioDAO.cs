using CadAlunoMVC.DAO;
using DryFi_ProjectBasedLearning_MVC.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace DryFi_ProjectBasedLearning_MVC.DAO
{
    public class FuncionarioDAO
    {

            //     CREATE TABLE Funcionarios(
            //  Id INT PRIMARY KEY, 
            //  Nome NVARCHAR(100),
            //  Cargo NVARCHAR(100),
            //  Foto NVARCHAR(255), -- Caminho da foto
            //  DepartamentoId INT,
            //  NomeDepartamento NVARCHAR(100),
            //  FOREIGN KEY(DepartamentoId) REFERENCES Departamentos(Id)
            //

        public void Inserir(FuncionarioViewModel funcionario)
        {
            SqlParameter[] parametros = CriaParametros(funcionario);
            HelperDAO.ExecutaProc("spIncluiFuncionario", parametros);
        }

        public void Alterar(FuncionarioViewModel funcionario)
        {
            SqlParameter[] parametros = CriaParametros(funcionario);
            HelperDAO.ExecutaProc("spAlteraFuncionario", parametros);
        }

        private SqlParameter[] CriaParametros(FuncionarioViewModel funcionario)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("id", funcionario.Id);
            parametros[1] = new SqlParameter("nome", funcionario.Nome);
            parametros[2] = new SqlParameter("cargo", funcionario.Cargo);
            parametros[3] = new SqlParameter("foto", funcionario.Foto);
            parametros[4] = new SqlParameter("departamentoId", funcionario.DepartamentoId);
            return parametros;
        }

        public void Excluir(int id)
        {
            SqlParameter[] parametros = { new SqlParameter("id", id) };
            HelperDAO.ExecutaProc("spExcluiFuncionario", parametros);
        }

        private FuncionarioViewModel MontaFuncionario(DataRow registro)
        {
            FuncionarioViewModel funcionario = new FuncionarioViewModel();
            funcionario.Id = Convert.ToInt32(registro["id"]);
            funcionario.Nome = registro["nome"].ToString();
            funcionario.Cargo = registro["cargo"].ToString();
            funcionario.Foto = registro["foto"].ToString();
            funcionario.DepartamentoId = Convert.ToInt32(registro["departamentoId"]);
            return funcionario;
        }

        public FuncionarioViewModel Consulta(int id)
        {
            SqlParameter[] parametros = { new SqlParameter("id", id) };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaFuncionario", parametros);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaFuncionario(tabela.Rows[0]);
        }

        public List<FuncionarioViewModel> Listagem()
        {
            List<FuncionarioViewModel> lista = new List<FuncionarioViewModel>();
            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemFuncionarios", null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaFuncionario(registro));
            return lista;
        }

        public int ProximoId()
        {
            SqlParameter[] parametros = { new SqlParameter("tabela", "funcionarios") };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spProximoId", parametros);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }
    }

}
