using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//
using Entidades.Clases;

namespace Entidades.ParametersReaders
{
    public class prPatient
    {
        // OK - 17/11/14
        public List<SqlParameter> CreateParameter(classPatient oP, int Abm)
        {
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@IdPatient", oP.IdPatient));
            lParam.Add(new SqlParameter("@Name", oP.Name));
            lParam.Add(new SqlParameter("@LastName", oP.LastName));
            lParam.Add(new SqlParameter("@Birthdate", oP.Birthdate));
            lParam.Add(new SqlParameter("@IdTypeDocument", oP.IdTypeDocument));
            lParam.Add(new SqlParameter("@NumberDocument", oP.NumberDocument));
            lParam.Add(new SqlParameter("@Sex", oP.Sex));
            lParam.Add(new SqlParameter("@IdLocationCountry", oP.IdLocationCountry));
            lParam.Add(new SqlParameter("@IdLocationProvince", oP.IdLocationProvince));
            lParam.Add(new SqlParameter("@IdLocationCity", oP.IdLocationCity));
            lParam.Add(new SqlParameter("@Address", oP.Address));
            lParam.Add(new SqlParameter("@Phone", oP.Phone));
            lParam.Add(new SqlParameter("@DateAdmission", oP.DateAdmission));
            lParam.Add(new SqlParameter("@EgressDate", oP.EgressDate));
            lParam.Add(new SqlParameter("@ReasonExit", oP.ReasonExit));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));
            return lParam;
        }

        // OK - 17/11/14
        public classPatient ReadReader(SqlDataReader oReader)
        {
            classPatient oP = new classPatient(
            Convert.ToInt32(oReader["IdPatient"]),
            Convert.ToString(oReader["Name"]),
            Convert.ToString(oReader["LastName"]),
            oReader["Birthdate"].ToString().Length > 0 ? DateTime.Parse(oReader["Birthdate"].ToString()) : DateTime.MinValue,
            Convert.ToInt32(oReader["IdTypeDocument"]),
            Convert.ToInt32(oReader["NumberDocument"]),
            Convert.ToBoolean(oReader["Sex"]),
            Convert.ToInt32(oReader["IdLocationCountry"]),
            Convert.ToInt32(oReader["IdLocationProvince"]),
            Convert.ToInt32(oReader["IdLocationCity"]),
            Convert.ToString(oReader["Address"]),
            Convert.ToString(oReader["Phone"]),
            oReader["DateAdmission"].ToString().Length > 0 ? DateTime.Parse(oReader["DateAdmission"].ToString()) : DateTime.MinValue,
            oReader["EgressDate"].ToString().Length > 0 ? DateTime.Parse(oReader["EgressDate"].ToString()) : DateTime.MinValue,
            Convert.ToString(oReader["ReasonExit"]),
            Convert.ToBoolean(oReader["Visible"]));
            return oP;
        }
    }
}
