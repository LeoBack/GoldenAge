﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//
using Entidades.Clases;

namespace Entidades.ParametersReaders
{
    public class PrIvaType
    {
        // OK - 18/02/07
        public List<SqlParameter> CreateParameter(ClassIvaType oP, int Abm)
        {
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@IdIvaType", oP.IdIvaType));
            lParam.Add(new SqlParameter("@Description", oP.Description));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));
            return lParam;
        }

        // OK - 18/02/07
        public ClassIvaType ReadReader(SqlDataReader oReader)
        {
            ClassIvaType oIvaType = new ClassIvaType(
            Convert.ToInt32(oReader["IdIvaType"]),
            Convert.ToString(oReader["Description"]),
            Convert.ToBoolean(oReader["Visible"]));
            return oIvaType;
        }
    }
}
