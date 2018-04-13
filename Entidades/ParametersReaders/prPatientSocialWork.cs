﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//
using Entidades.Clases;

namespace Entidades.ParametersReaders
{
    public class PrPatientSocialWork
    {
        // OK - 18/02/07
        public List<SqlParameter> CreateParameter(ClassPatientSocialWork oP, int Abm)
        {
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", Abm));
            lParam.Add(new SqlParameter("@IdPatientSocialWork", oP.IdPatientSocialWork));
            lParam.Add(new SqlParameter("@IdSocialWork", oP.IdSocialWork));
            lParam.Add(new SqlParameter("@IdPatient", oP.IdPatient));
            lParam.Add(new SqlParameter("@AffiliateNumber", oP.AffiliateNumber));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));
            return lParam;
        }

        // OK - 18/02/07
        public ClassPatientSocialWork ReadReader(SqlDataReader oReader)
        {
            ClassPatientSocialWork oPatientSocialWork = new ClassPatientSocialWork(
                Convert.ToInt32(oReader["IdPatientSocialWork"]),
                Convert.ToInt32(oReader["IdSocialWork"]),
                Convert.ToInt32(oReader["IdPatient"]),
                Convert.ToString(oReader["AffiliateNumber"]),
                Convert.ToBoolean(oReader["Visible"]));
            return oPatientSocialWork;
        }
    }
}
