using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//
using Entidades.Clases;

namespace Entidades.ParametersReaders
{
    public class PrProfessional
    {
        // OK - 17/10/21
        public List<SqlParameter> CreateParameter(ClassProfessional oP, int Abm)
        {
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", Abm));
            lParam.Add(new SqlParameter("@IdProfessional", oP.IdProfessional));
            lParam.Add(new SqlParameter("@Name", oP.Name));
            lParam.Add(new SqlParameter("@LastName", oP.LastName));
            lParam.Add(new SqlParameter("@ProfessionalRegistration", oP.ProfessionalRegistration));
            lParam.Add(new SqlParameter("@IdLocationCountry", oP.IdLocationCountry));
            lParam.Add(new SqlParameter("@IdLocationProvince", oP.IdLocationProvince));
            lParam.Add(new SqlParameter("@IdLocationCity", oP.IdLocationCity));
            lParam.Add(new SqlParameter("@Address", oP.Address));
            lParam.Add(new SqlParameter("@Phone", oP.Phone));
            lParam.Add(new SqlParameter("@Mail", oP.Mail));
            lParam.Add(new SqlParameter("@User", oP.User));
            lParam.Add(new SqlParameter("@Password", oP.Password));
            lParam.Add(new SqlParameter("@idPermission", oP.IdPermission));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));
            return lParam;
        }

        // OK - 17/10/21
        public ClassProfessional ReadReader(SqlDataReader oReader)
        {
            ClassProfessional oProfessional = new ClassProfessional(
                Convert.ToInt32(oReader["IdProfessional"]),
                Convert.ToString(oReader["Name"]),
                Convert.ToString(oReader["LastName"]),
                Convert.ToString(oReader["ProfessionalRegistration"]),
                Convert.ToInt32(oReader["IdLocationCountry"]),
                Convert.ToInt32(oReader["IdLocationProvince"]),
                Convert.ToInt32(oReader["IdLocationCity"]),
                Convert.ToString(oReader["Address"]),
                Convert.ToString(oReader["Phone"]),
                Convert.ToString(oReader["Mail"]),
                Convert.ToString(oReader["User"]),
                Convert.ToString(oReader["Password"]),
                Convert.ToInt32(oReader["idPermission"]),
                Convert.ToBoolean(oReader["Visible"]));
            return oProfessional;
        }
    }
}
