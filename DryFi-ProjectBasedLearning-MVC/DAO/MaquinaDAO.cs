﻿using DryFi_ProjectBasedLearning_MVC.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace DryFi_ProjectBasedLearning_MVC.DAO
{
    public class MaquinaDAO : PadraoDAO<MaquinaViewModel>
    {
        protected override SqlParameter[] CriaParametros(MaquinaViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@Id", model.Id);
            parametros[1] = new SqlParameter("@maqStatus", model.MaqStatus);
            parametros[2] = new SqlParameter("@endereco", model.Endereco);
            parametros[3] = new SqlParameter("@idCliente", model.IdCliente);

            return parametros;
        }

        protected override MaquinaViewModel MontaModel(DataRow registro)
        {
            MaquinaViewModel m = new MaquinaViewModel();
            m.Id = Convert.ToInt32(registro["Id"]);
            m.MaqStatus = Convert.ToInt32(registro["maqStatus"]);
            m.Endereco = registro["endereco"].ToString();
            m.IdCliente = Convert.ToInt32(registro["idCliente"]);
            m.DescricaoStatus = registro["DescricaoStatus"].ToString();  // Adiciona a descrição do status
            m.NomeCliente = registro["NomeCliente"].ToString();  // Adiciona o nome do cliente

            return m;
        }

        public List<MaquinaViewModel> ConsultaAvancadaMaquina(int maqStatus, int idCliente, string nomeCliente)
        {
            SqlParameter[] p = {
                new SqlParameter("@maqStatus", maqStatus),
                new SqlParameter("@idCliente", idCliente),
                new SqlParameter("@nomeCliente", nomeCliente)
            };

            var tabela = HelperDAO.ExecutaProcSelect("spConsultaAvancadaMaquinas", p);
            var lista = new List<MaquinaViewModel>();

            foreach (DataRow dr in tabela.Rows)
            {
                lista.Add(MontaModel(dr));
            }

            return lista;
        }

        protected override void SetTabela()
        {
            Tabela = "Maquina";
        }
    }
}
