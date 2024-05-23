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
            //String LAB
            // string strCon = "Data Source=LOCALHOST; Database=AULADB; user id=sa; password=123456";

            //String EDUARDO TOLEDO
            //string strCon = "Data Source=DESKTOP-R99OVQ8\\SQLEXPRESS; Database=linguagemProgramacao; integrated security=true";

            //String GUILHERME SANTOS
            //string strCon = "Data Source=GUILHERME\\SQLSERVER2022; Database=AulaDB; integrated security=true";

            //String KAUÊ DE SOUZA
            string strCon = "Data Source=CONFUSEDKARMA\\SQLEXPRESS01; Database=LinguagemProgramacao; Integrated Security=True;";
            SqlConnection conexao = new SqlConnection(strCon);


            conexao.Open();
            return conexao;
        }
    }
}
