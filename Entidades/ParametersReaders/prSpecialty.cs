using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//
using Entidades.Clases;

namespace Entidades.ParametersReaders
{
    public class PrSpecialty
    {
        // OK - 18/02/07
        public List<SqlParameter> CreateParameter(ClassSpecialty oP, int Abm)
        {
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@idSpecialty", oP.IdSpecialty));
            lParam.Add(new SqlParameter("@Description", oP.Description));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));
            return lParam;
        }

        // OK - 18/02/07
        public ClassSpecialty ReadReader(SqlDataReader oReader)
        {
            ClassSpecialty oSpecialty = new ClassSpecialty(
            Convert.ToInt32(oReader["idSpecialty"]),
            Convert.ToString(oReader["Description"]),
            Convert.ToBoolean(oReader["Visible"]));
            return oSpecialty;
        }
    }
}
