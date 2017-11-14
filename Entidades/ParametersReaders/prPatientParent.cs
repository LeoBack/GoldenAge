using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//
using Entidades.Clases;

namespace Entidades.ParametersReaders
{
    public class prPatientParent
    {
        // OK - 17/11/14
        public List<SqlParameter> CreateParameter(classPatientParent oP, int Abm)
        {
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@idPatientParent", oP.IdPatientParent));
            lParam.Add(new SqlParameter("@IdPatient", oP.IdPatient));
            lParam.Add(new SqlParameter("@IdParent", oP.IdParent));
            lParam.Add(new SqlParameter("@IdRelationship", oP.IdRelationship));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));
            return lParam;
        }

        // OK - 17/11/14
        public classPatientParent ReadReader(SqlDataReader oReader)
        {
            classPatientParent oP = new classPatientParent(
              Convert.ToInt32(oReader["idPatientParent"]),
              Convert.ToInt32(oReader["IdPatient"]),
              Convert.ToInt32(oReader["IdParent"]),
              Convert.ToInt32(oReader["IdRelationship"]),
              Convert.ToBoolean(oReader["Visible"]));
            return oP;
        }
    }
}
