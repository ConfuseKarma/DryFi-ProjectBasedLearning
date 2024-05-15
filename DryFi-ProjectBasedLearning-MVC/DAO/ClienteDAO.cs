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
            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter("Id", model.Id);
            parametros[1] = new SqlParameter("NomeCliente", model.NomeCliente);
            parametros[2] = new SqlParameter("CNPJ", model.Cnpj);
            parametros[3] = new SqlParameter("Email", model.Email);
            parametros[4] = new SqlParameter("Telefone", model.Telefone);
            parametros[5] = new SqlParameter("TipoClienteId", model.TipoClienteId);

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
            c.TipoClienteId = Convert.ToInt32(registro["TipoClienteId"]);

            if (registro.Table.Columns.Contains("DescricaoTipoCliente"))
                c.DescricaoTipoCliente = registro["DescricaoTipoCliente"].ToString();

            return c;
        }
        public List<ClienteViewModel> ConsultaAvancadaCliente(string nomeCliente,
                                                              string cnpj,
                                                              int tipo)
        {
            SqlParameter[] p = {
             new SqlParameter("nomeCliente", nomeCliente),
             new SqlParameter("cnpj", cnpj),
             new SqlParameter("tipo", tipo),
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsultaAvancadaClientes", p);
            var lista = new List<ClienteViewModel>();
            foreach (DataRow dr in tabela.Rows)
                lista.Add(MontaModel(dr));
            return lista;
        }
        protected override void SetTabela()
        {
            Tabela = "Cliente";
        }
    }
}
