using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//
using Entidades.Clases;

namespace Entidades.ParametersReaders
{
    public class prParent
    {
        // OK - 17/11/14
        public List<SqlParameter> CreateParameter(classParent oP, int Abm)
        {
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@IdParent", oP.IdParent));
            lParam.Add(new SqlParameter("@Name", oP.Name));
            lParam.Add(new SqlParameter("@LastName", oP.LastName));
            lParam.Add(new SqlParameter("@IdTypeDocument", oP.IdTypeDocument));
            lParam.Add(new SqlParameter("@NumberDocument", oP.NumberDocument));
            lParam.Add(new SqlParameter("@Phone", oP.Phone));
            lParam.Add(new SqlParameter("@AlternativePhone", oP.AlternativePhone));
            lParam.Add(new SqlParameter("@Email", oP.Email));
            lParam.Add(new SqlParameter("@IdLocationCountry", oP.IdLocationCountry));
            lParam.Add(new SqlParameter("@IdLocationProvince", oP.IdLocationProvince));
            lParam.Add(new SqlParameter("@IdLocationCity", oP.IdLocationCity));
            lParam.Add(new SqlParameter("@Address", oP.Address));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));
            return lParam;
        }

        // OK - 17/11/14
        public classParent ReadReader(SqlDataReader oReader)
        {
            classParent oP = new classParent(
            Convert.ToInt32(oReader["IdParent"]),
            Convert.ToString(oReader["Name"]),
            Convert.ToString(oReader["LastName"]),
            Convert.ToInt32(oReader["IdTypeDocument"]),
            Convert.ToInt32(oReader["NumberDocument"]),
            Convert.ToString(oReader["Phone"]),
            Convert.ToString(oReader["AlternativePhone"]),
            Convert.ToString(oReader["Email"]),
            Convert.ToInt32(oReader["IdLocationCountry"]),
            Convert.ToInt32(oReader["IdLocationProvince"]),
            Convert.ToInt32(oReader["IdLocationCity"]),
            Convert.ToString(oReader["Address"]),
            Convert.ToBoolean(oReader["Visible"]));
            return oP;
        }
    }
}
