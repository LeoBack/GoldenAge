using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//
using Entidades.Clases;

namespace Entidades.ParametersReaders
{
    public class PrPermission
    {
        // OK - 17/11/14
        public List<SqlParameter> CreateParameter(ClassPermission oP, int Abm)
        {
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@idPermission", oP.IdPermission));
            lParam.Add(new SqlParameter("@Description", oP.Description));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));
            return lParam;
        }

        // OK - 17/11/14
        public ClassPermission ReadReader(SqlDataReader oReader)
        {
            ClassPermission oP = new ClassPermission(
            Convert.ToInt32(oReader["idPermission"]),
            Convert.ToString(oReader["Description"]),
            Convert.ToBoolean(oReader["Visible"]));
            return oP;
        }
    }
}
