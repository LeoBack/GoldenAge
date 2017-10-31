using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//
using Entidades.Clases;

namespace Entidades.ParametersReaders
{
    public class prDiagnostic
    {
        // OK - 17/10/31
        public List<SqlParameter> CreateParameter(classDiagnostic oP, int Abm)
        {
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@IdDiagnostic", oP.IdDiagnostic));
            lParam.Add(new SqlParameter("@IdSpeciality", oP.IdSpeciality));
            lParam.Add(new SqlParameter("@IdPatient", oP.IdPatient));
            lParam.Add(new SqlParameter("@IdProfessional", oP.IdProfessional));
            lParam.Add(new SqlParameter("@Detail", oP.Detail));
            lParam.Add(new SqlParameter("@Date", oP.Date));
            lParam.Add(new SqlParameter("@IdDestinationSpeciality", oP.IdDestinationSpeciality));
            lParam.Add(new SqlParameter("@IdDestinationProfessional", oP.IdDestinationProfessional));
            lParam.Add(new SqlParameter("@DestinationRead", oP.DestinationRead));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));
            return lParam;
        }

        // OK - 17/10/31
        public classDiagnostic ReadReader(SqlDataReader oReader)
        {
            classDiagnostic oDiagnostic = new classDiagnostic(
            Convert.ToInt32(oReader["IdDiagnostic"]),
            Convert.ToInt32(oReader["IdSpeciality"]),
            Convert.ToInt32(oReader["IdPatient"]),
            Convert.ToInt32(oReader["IdProfessional"]),
            Convert.ToString(oReader["Detail"]),
            Convert.ToDateTime(oReader["Date"]),
            Convert.ToInt32(oReader["IdDestinationSpeciality"]),
            Convert.ToInt32(oReader["IdDestinationProfessional"]),
            Convert.ToBoolean(oReader["DestinationRead"]),
            Convert.ToBoolean(oReader["Visible"]));
            return oDiagnostic;
        }
    }
}
