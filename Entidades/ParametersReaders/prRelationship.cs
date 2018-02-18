using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//
using Entidades.Clases;

namespace Entidades.ParametersReaders
{
    public class prRelationship
    {
        // OK - 18/02/07
        public List<SqlParameter> CreateParameter(classRelationship oP, int Abm)
        {
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@idRelationship", oP.IdRelationship));
            lParam.Add(new SqlParameter("@Description", oP.Description));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));
            return lParam;
        }

        // OK - 18/02/07
        public classRelationship ReadReader(SqlDataReader oReader)
        {
            classRelationship oRelationship = new classRelationship(
                Convert.ToInt32(oReader["idRelationship"]),
                Convert.ToString(oReader["Description"]),
                Convert.ToBoolean(oReader["Visible"]));
            return oRelationship;
        }
    }
}
