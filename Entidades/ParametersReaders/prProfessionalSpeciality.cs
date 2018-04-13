using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//
using Entidades.Clases;

namespace Entidades.ParametersReaders
{
    public class PrProfessionalSpeciality
    {
        // OK - 18/02/07
        public List<SqlParameter> CreateParameter(ClassProfessionalSpeciality oP, int Abm)
        {
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@idProfessionalSpeciality", oP.IdProfessionalSpeciality));
            lParam.Add(new SqlParameter("@IdProfessional", oP.IdProfessional));
            lParam.Add(new SqlParameter("@IdSpeciality", oP.IdSpeciality));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));
            return lParam;
        }

        // OK - 18/02/07
        public ClassProfessionalSpeciality ReadReader(SqlDataReader oReader)
        {
            ClassProfessionalSpeciality oProfessionalSpeciality = new ClassProfessionalSpeciality(
            Convert.ToInt32(oReader["idProfessionalSpeciality"]),
            Convert.ToInt32(oReader["IdProfessional"]),
            Convert.ToInt32(oReader["IdSpeciality"]),
            Convert.ToBoolean(oReader["Visible"]));
            return oProfessionalSpeciality;
        }
    }
}
