using DryFi_ProjectBasedLearning_MVC.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace DryFi_ProjectBasedLearning_MVC.DAO
{
    public class DashboardDAO : PadraoDAO<MaquinaViewModel>
    {
        protected override SqlParameter[] CriaParametros(MaquinaViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override MaquinaViewModel MontaModel(DataRow registro)
        {
            throw new NotImplementedException();
        }

        protected override void SetTabela()
        {
            throw new NotImplementedException();
        }
    }
}
