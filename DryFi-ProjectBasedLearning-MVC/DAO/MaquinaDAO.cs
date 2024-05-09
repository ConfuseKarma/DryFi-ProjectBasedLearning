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
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("Id", model.Id);
            parametros[1] = new SqlParameter("maqStatus", model.maqStatus);
            parametros[2] = new SqlParameter("idCliente", model.idCliente);

            return parametros;
        }
        protected override MaquinaViewModel MontaModel(DataRow registro)
        {
            MaquinaViewModel m = new MaquinaViewModel();
            m.Id = Convert.ToInt32(registro["Id"]);
            m.maqStatus = registro["maqStatus"].ToString();
            m.idCliente = Convert.ToInt32(registro["idCliente"]);

            return m;
        }
        protected override void SetTabela()
        {
            Tabela = "Maquina";
        }
    }
}
