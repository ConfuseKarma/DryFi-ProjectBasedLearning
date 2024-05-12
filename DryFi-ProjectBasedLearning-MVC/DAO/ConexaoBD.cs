using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryFi_ProjectBasedLearning_MVC.DAO
{
    public static class ConexaoBD
    {
        /// <summary>
        /// Método Estático que retorna um conexao aberta com o BD
        /// </summary>
        /// <returns>Conexão aberta</returns>
        public static SqlConnection GetConexao()
        {
            //string strCon = "Data Source=LOCALHOST; Database=AULADB; user id=sa; password=123456";
            //String EDUARDO TOLEDO
            string strCon = "Data Source=DESKTOP-R99OVQ8\\SQLEXPRESS; Database=linguagemProgramacao; integrated security=true";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
