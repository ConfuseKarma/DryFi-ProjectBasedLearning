using DryFi_ProjectBasedLearning_MVC.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Reflection.Emit;

namespace DryFi_ProjectBasedLearning_MVC.DAO
{
    public class MonitoramentoDAO : PadraoDAO<MonitoramentoViewModel>
    {
        protected override SqlParameter[] CriaParametros(MonitoramentoViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("Id", model.Id);
            parametros[1] = new SqlParameter("idMaquina", model.idMaquina);
            parametros[2] = new SqlParameter("Temperatura", model.temperatura);

            return parametros;
        }
        protected override MonitoramentoViewModel MontaModel(DataRow registro)
        {
            MonitoramentoViewModel m = new MonitoramentoViewModel();
            m.Id = Convert.ToInt32(registro["Id"]);
            m.idMaquina = Convert.ToInt32(registro["idMaquina"]);
            m.temperatura = Convert.ToDouble(registro["Temperatura"]);

            return m;
        }
        protected override void SetTabela()
        {
            Tabela = "Monitoramento";
        }
    }
}
