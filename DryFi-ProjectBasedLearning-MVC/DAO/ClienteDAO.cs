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
            parametros[1] = new SqlParameter("NomeCliente", model.NomeCliente);
            parametros[2] = new SqlParameter("CNPJ", model.Cnpj);
            parametros[3] = new SqlParameter("Email", model.Email);
            parametros[4] = new SqlParameter("Telefone", model.Telefone);
            
            return parametros;
        }
        protected override ClienteViewModel MontaModel(DataRow registro)
        {
            ClienteViewModel c = new ClienteViewModel();
            c.Id = Convert.ToInt32(registro["Id"]);
            c.NomeCliente = registro["NomeCliente"].ToString();
            c.Cnpj = registro["CNPJ"].ToString();
            c.Email = registro["Email"].ToString();
            c.Telefone = registro["Telefone"].ToString();
            
            return c;
        }
        protected override void SetTabela()
        {
            Tabela = "Cliente";
        }
    }
}
