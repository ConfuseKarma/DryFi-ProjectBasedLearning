using DryFi_ProjectBasedLearning_MVC.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace DryFi_ProjectBasedLearning_MVC.DAO
{
    public class ClienteDAO : PadraoDAO<ClienteViewModel>
    {
        protected override SqlParameter[] CriaParametros(ClienteViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("Id", model.Id);
            parametros[1] = new SqlParameter("Nome", model.nomeCliente);
            parametros[2] = new SqlParameter("CNPJ", model.CNPJ);
            parametros[3] = new SqlParameter("Email", model.email);
            parametros[4] = new SqlParameter("Telefone", model.telefone);
            
            return parametros;
        }
        protected override ClienteViewModel MontaModel(DataRow registro)
        {
            ClienteViewModel c = new ClienteViewModel();
            c.Id = Convert.ToInt32(registro["Id"]);
            c.nomeCliente = registro["Nome"].ToString();
            c.CNPJ = registro["CNPJ"].ToString();
            c.email = registro["Email"].ToString();
            c.telefone = registro["Telefone"].ToString();
            
            return c;
        }
        protected override void SetTabela()
        {
            Tabela = "Cliente";
        }
    }
}
