using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//
using Entidades.Clases;

namespace Entidades.ParametersReaders
{
    public class PrSocialWorks
    {
        // OK - 17/10/21
        public List<SqlParameter> CreateParameter(ClassSocialWork oP, int Abm)
        {
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", Abm));
            lParam.Add(new SqlParameter("@IdSocialWork", oP.IdSocialWork));
            lParam.Add(new SqlParameter("@Name", oP.Name));
            lParam.Add(new SqlParameter("@Description", oP.Description));
            lParam.Add(new SqlParameter("@IdIvaType", oP.IdIvaType));
            lParam.Add(new SqlParameter("@IdLocationCountry", oP.IdLocationCountry));
            lParam.Add(new SqlParameter("@IdLocationProvince", oP.IdLocationProvince));
            lParam.Add(new SqlParameter("@IdLocationCity", oP.IdLocationCity));
            lParam.Add(new SqlParameter("@Address", oP.Address));
            lParam.Add(new SqlParameter("@Phone", oP.Phone));
            lParam.Add(new SqlParameter("@Contact", oP.Contact));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));
            return lParam;
        }

        // OK - 17/10/21
        public ClassSocialWork ReadReader(SqlDataReader oReader)
        {
            ClassSocialWork oSocialWork = new ClassSocialWork(
                Convert.ToInt32(oReader["IdSocialWork"]),
                Convert.ToString(oReader["Name"]),
                Convert.ToString(oReader["Description"]),
                Convert.ToInt32(oReader["IdIvaType"]),
                Convert.ToInt32(oReader["IdLocationCountry"]),
                Convert.ToInt32(oReader["IdLocationProvince"]),
                Convert.ToInt32(oReader["IdLocationCity"]),
                Convert.ToString(oReader["Address"]),
                Convert.ToString(oReader["Phone"]),
                Convert.ToString(oReader["Contact"]),
                Convert.ToBoolean(oReader["Visible"]));
            return oSocialWork;
        }
    }
}
