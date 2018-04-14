using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//
using Entidades.Clases;

namespace Entidades.ParametersReaders
{
    public class PrPatientState
    {
        // OK - 18/04/13
        public List<SqlParameter> CreateParameter(ClassPatientState oP, int Abm)
        {
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@IdPatientState", oP.IdPatientState));
            lParam.Add(new SqlParameter("@IdPatient", oP.IdPatient));
            lParam.Add(new SqlParameter("@Description", oP.Description));
            lParam.Add(new SqlParameter("@Date", oP.Date));
            lParam.Add(new SqlParameter("@State", oP.State));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));
            return lParam;
        }

        // OK - 18/04/13
        public ClassPatientState ReadReader(SqlDataReader oReader)
        {
            ClassPatientState oPatientState = new ClassPatientState(
            Convert.ToInt32(oReader["IdPatientState"]),
            Convert.ToInt32(oReader["IdPatient"]),
            Convert.ToString(oReader["Description"]),
            oReader["Date"].ToString().Length > 0 ? DateTime.Parse(oReader["Date"].ToString()) : DateTime.Now.AddDays(1),
            Convert.ToBoolean(oReader["State"]),
            Convert.ToBoolean(oReader["Visible"]));
            return oPatientState;
        }
    }
}