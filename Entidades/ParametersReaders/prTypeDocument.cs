using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//
using Entidades.Clases;

namespace Entidades.ParametersReaders
{
    public class PrTypeDocument
    {
        // OK - 18/02/07
        public List<SqlParameter> CreateParameter(ClassTypeDocument oP, int Abm)
        {
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@idTypeDocument", oP.IdTypeDocument));
            lParam.Add(new SqlParameter("@Description", oP.Description));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));
            return lParam;
        }

        // OK - 18/02/07
        public ClassTypeDocument ReadReader(SqlDataReader oReader)
        {
            ClassTypeDocument oTypeDocument = new ClassTypeDocument(
            Convert.ToInt32(oReader["idTypeDocument"]),
            Convert.ToString(oReader["Description"]),
            Convert.ToBoolean(oReader["Visible"]));
            return oTypeDocument;
        }
    }
}
