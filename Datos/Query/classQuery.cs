using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.IO;
using Entidades;
using Entidades.Clases;
using Entidades.Grillas;
using System.Data.SqlClient;
using libData.SqlServer;

namespace Datos.Query
{
    public class classQuery
    {
        //----------------------------------------------------------

        #region Atributos y Metodos

        public enum eAbm { SelectAll = 0, Select = 1, Insert = 2, Update = 3, Delete = 4, LoadCmb = 5 }

        public string ConexionString { set; get; }
        public bool ActivarLog { set; get; }
        public string Menssage { set; get; }
        public bool Error { set; get; }
        public DataTable Table { set; get; }
        public DataSet oDataSet { set; get; }

        private classSql oSql;
        private List<SqlParameter> lParam;
        private classNameProcedures sp = new classNameProcedures();

        #endregion

        #region Constructores

        public classQuery()
        {
            ActivarLog = true;
            oSql = new classSql();
            ConexionString = oSql.ConnectionString;
            Menssage = oSql.Mensage;
            lParam = new List<SqlParameter>();
        }

        public classQuery(string vConnectionString)
        {
            ActivarLog = false;
            oSql = new classSql(vConnectionString);
            ConexionString = oSql.ConnectionString;
            Menssage = oSql.Mensage;
            lParam = new List<SqlParameter>();
        }

        public classQuery(string vPath, string vDBname, bool vLog)
        {
            ActivarLog = vLog;
            oSql = new classSql(classSql.BuildConecctionString(vPath, vDBname), vPath, ActivarLog);
            ConexionString = oSql.ConnectionString;
            Menssage = oSql.Mensage;
            lParam = new List<SqlParameter>();
        }

        /// <summary>
        /// Consulta la edicion con la base de datos
        /// OK 17/09/16
        /// </summary>
        /// <returns></returns>
        public string ServerVersion()
        {
            string A = string.Empty;
            if (oSql.SelectRaeder("SELECT SERVERPROPERTY('edition')"))
            {
                if (oSql.Reader.Read())
                    A = Convert.ToString(oSql.Reader[0]);
            }
            return A;
        }

        #endregion

        //----------------------------------------------------------
        // CONSULTAS PARA CADA FUNCION
        //----------------------------------------------------------

        // OK - 24/09/17
        #region ABM

        public object AbmDiagnostic(classDiagnostic oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmDiagnostic;

            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@IdDiagnostic", oP.IdDiagnostic));
            lParam.Add(new SqlParameter("@IdSpeciality", oP.IdSpeciality));
            lParam.Add(new SqlParameter("@Detail", oP.Detail));
            lParam.Add(new SqlParameter("@DiagnosticDate", oP.DiagnosticDate));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));

            switch (Abm)
            {
                case eAbm.SelectAll:
                    {
                        List<classDiagnostic> lDiagnostic = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            lDiagnostic = new List<classDiagnostic>();
                            while (oSql.Reader.Read())
                            {
                                try
                                {
                                    classDiagnostic oDiagnostic = new classDiagnostic(
                                    Convert.ToInt32(oSql.Reader["IdDiagnostic"]),
                                    Convert.ToInt32(oSql.Reader["IdSpeciality"]),
                                    Convert.ToString(oSql.Reader["Detail"]),
                                    Convert.ToDateTime(oSql.Reader["DiagnosticDate"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                    lDiagnostic.Add(oDiagnostic);
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    lDiagnostic = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    lDiagnostic = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    lDiagnostic = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = lDiagnostic;
                        break;
                    }
                case eAbm.Select:
                    {
                        classDiagnostic oDiagnostic = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            if (oSql.Reader.Read())
                            {
                                try
                                {
                                    oDiagnostic = new classDiagnostic(
                                    Convert.ToInt32(oSql.Reader["IdDiagnostic"]),
                                    Convert.ToInt32(oSql.Reader["IdSpeciality"]),
                                    Convert.ToString(oSql.Reader["Detail"]),
                                    Convert.ToDateTime(oSql.Reader["DiagnosticDate"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    oDiagnostic = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    oDiagnostic = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    oDiagnostic = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = oDiagnostic;
                        break;
                    }
                case eAbm.Insert:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Update:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Delete:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.LoadCmb:
                    {
                        Result = oSql.ExecCombo(SPname, lParam.ToArray());
                        if (oSql.Table.Rows.Count != 0)
                            Table = oSql.Table;
                        else
                            Table = null;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return Result;
        }

        public object AbmParent(classParent oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmParent;

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
            lParam.Add(new SqlParameter("@IdRelationship", oP.IdRelationship));
            lParam.Add(new SqlParameter("@IdLocationCountry", oP.IdLocationCountry));
            lParam.Add(new SqlParameter("@IdLocationProvince", oP.IdLocationProvince));
            lParam.Add(new SqlParameter("@IdLocationCity", oP.IdLocationCity));
            lParam.Add(new SqlParameter("@Address", oP.Address));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));

            switch (Abm)
            {
                case eAbm.SelectAll:
                    {
                        List<classParent> lParent = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            lParent = new List<classParent>();
                            while (oSql.Reader.Read())
                            {
                                try
                                {
                                    classParent oParent = new classParent(
                                    Convert.ToInt32(oSql.Reader["IdParent"]),
                                    Convert.ToString(oSql.Reader["Name"]),
                                    Convert.ToString(oSql.Reader["LastName"]),
                                    Convert.ToInt32(oSql.Reader["IdTypeDocument"]),
                                    Convert.ToInt32(oSql.Reader["NumberDocument"]),
                                    Convert.ToString(oSql.Reader["Phone"]),
                                    Convert.ToString(oSql.Reader["AlternativePhone"]),
                                    Convert.ToString(oSql.Reader["Email"]),
                                    Convert.ToInt32(oSql.Reader["IdRelationship"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationCountry"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationProvince"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationCity"]),
                                    Convert.ToString(oSql.Reader["Address"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                    lParent.Add(oParent);
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    lParent = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    lParent = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    lParent = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = lParent;
                        break;
                    }
                case eAbm.Select:
                    {
                        classParent oParent = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            if (oSql.Reader.Read())
                            {
                                try
                                {
                                    oParent = new classParent(
                                    Convert.ToInt32(oSql.Reader["IdParent"]),
                                    Convert.ToString(oSql.Reader["Name"]),
                                    Convert.ToString(oSql.Reader["LastName"]),
                                    Convert.ToInt32(oSql.Reader["IdTypeDocument"]),
                                    Convert.ToInt32(oSql.Reader["NumberDocument"]),
                                    Convert.ToString(oSql.Reader["Phone"]),
                                    Convert.ToString(oSql.Reader["AlternativePhone"]),
                                    Convert.ToString(oSql.Reader["Email"]),
                                    Convert.ToInt32(oSql.Reader["IdRelationship"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationCountry"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationProvince"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationCity"]),
                                    Convert.ToString(oSql.Reader["Address"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    oParent = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    oParent = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    oParent = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = oParent;
                        break;
                    }
                case eAbm.Insert:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Update:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Delete:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.LoadCmb:
                    {
                        Result = oSql.ExecCombo(SPname, lParam.ToArray());
                        if (oSql.Table.Rows.Count != 0)
                            Table = oSql.Table;
                        else
                            Table = null;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return Result;
        }

        public object AbmPatient(classPatient oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmPatient;

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
            lParam.Add(new SqlParameter("@IdSocialWork", oP.IdSocialWork));
            lParam.Add(new SqlParameter("@AffiliateNumber", oP.AffiliateNumber));
            lParam.Add(new SqlParameter("@DateAdmission", oP.DateAdmission));
            lParam.Add(new SqlParameter("@EgressDate", oP.EgressDate));
            lParam.Add(new SqlParameter("@ReasonExit", oP.ReasonExit));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));

            switch (Abm)
            {
                case eAbm.SelectAll:
                    {
                        List<classPatient> lGrandfather = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            lGrandfather = new List<classPatient>();
                            while (oSql.Reader.Read())
                            {
                                try
                                {
                                    classPatient oGrandfather = new classPatient(
                                    Convert.ToInt32(oSql.Reader["IdPatient"]),
                                    Convert.ToString(oSql.Reader["Name"]),
                                    Convert.ToString(oSql.Reader["LastName"]),
                                    Convert.ToDateTime(oSql.Reader["Birthdate"]),
                                    Convert.ToInt32(oSql.Reader["IdTypeDocument"]),
                                    Convert.ToInt32(oSql.Reader["NumberDocument"]),
                                    Convert.ToInt32(oSql.Reader["Sex"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationCountry"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationProvince"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationCity"]),
                                    Convert.ToString(oSql.Reader["Address"]),
                                    Convert.ToString(oSql.Reader["Phone"]),
                                    Convert.ToInt32(oSql.Reader["IdSocialWork"]),
                                    Convert.ToInt32(oSql.Reader["AffiliateNumber"]),
                                    Convert.ToDateTime(oSql.Reader["DateAdmission"]),
                                    Convert.ToDateTime(oSql.Reader["EgressDate"]),
                                    Convert.ToString(oSql.Reader["ReasonExit"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                    lGrandfather.Add(oGrandfather);
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    lGrandfather = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    lGrandfather = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    lGrandfather = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = lGrandfather;
                        break;
                    }
                case eAbm.Select:
                    {
                        classPatient oGrandfather = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            if (oSql.Reader.Read())
                            {
                                try
                                {
                                    oGrandfather = new classPatient(
                                    Convert.ToInt32(oSql.Reader["IdPatient"]),
                                    Convert.ToString(oSql.Reader["Name"]),
                                    Convert.ToString(oSql.Reader["LastName"]),
                                    Convert.ToDateTime(oSql.Reader["Birthdate"]),
                                    Convert.ToInt32(oSql.Reader["IdTypeDocument"]),
                                    Convert.ToInt32(oSql.Reader["NumberDocument"]),
                                    Convert.ToInt32(oSql.Reader["Sex"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationCountry"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationProvince"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationCity"]),
                                    Convert.ToString(oSql.Reader["Address"]),
                                    Convert.ToString(oSql.Reader["Phone"]),
                                    Convert.ToInt32(oSql.Reader["IdSocialWork"]),
                                    Convert.ToInt32(oSql.Reader["AffiliateNumber"]),
                                    Convert.ToDateTime(oSql.Reader["DateAdmission"]),
                                    Convert.ToDateTime(oSql.Reader["EgressDate"]),
                                    Convert.ToString(oSql.Reader["ReasonExit"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    oGrandfather = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    oGrandfather = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    oGrandfather = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = oGrandfather;
                        break;
                    }
                case eAbm.Insert:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Update:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Delete:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.LoadCmb:
                    {
                        Result = oSql.ExecCombo(SPname, lParam.ToArray());
                        if (oSql.Table.Rows.Count != 0)
                            Table = oSql.Table;
                        else
                            Table = null;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return Result;
        }

        public object AbmPatientParent(classPatientParent oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmPatientParent;

            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@idPatientParent", oP.IdPatientParent));
            lParam.Add(new SqlParameter("@IdPatient", oP.IdPatient));
            lParam.Add(new SqlParameter("@IdParent", oP.IdParent));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));

            switch (Abm)
            {
                case eAbm.SelectAll:
                    {
                        List<classPatientParent> lPatientParent = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            lPatientParent = new List<classPatientParent>();
                            while (oSql.Reader.Read())
                            {
                                try
                                {
                                    classPatientParent oPatientParent = new classPatientParent(
                                    Convert.ToInt32(oSql.Reader["idPatientParent"]),
                                    Convert.ToInt32(oSql.Reader["IdPatient"]),
                                    Convert.ToInt32(oSql.Reader["IdParent"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                    lPatientParent.Add(oPatientParent);
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    lPatientParent = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    lPatientParent = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    lPatientParent = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = lPatientParent;
                        break;
                    }
                case eAbm.Select:
                    {
                        classPatientParent oPatientParent = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            if (oSql.Reader.Read())
                            {
                                try
                                {
                                    oPatientParent = new classPatientParent(
                                    Convert.ToInt32(oSql.Reader["idPatientParent"]),
                                    Convert.ToInt32(oSql.Reader["IdPatient"]),
                                    Convert.ToInt32(oSql.Reader["IdParent"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    oPatientParent = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    oPatientParent = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    oPatientParent = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = oPatientParent;
                        break;
                    }
                case eAbm.Insert:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Update:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Delete:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.LoadCmb:
                    {
                        Result = oSql.ExecCombo(SPname, lParam.ToArray());
                        if (oSql.Table.Rows.Count != 0)
                            Table = oSql.Table;
                        else
                            Table = null;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return Result;
        }

        public object AbmPermission(classPermission oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmPermission;

            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@idPermission", oP.IdPermission));
            lParam.Add(new SqlParameter("@Description", oP.Description));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));

            switch (Abm)
            {
                case eAbm.SelectAll:
                    {
                        List<classPermission> lPermission = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            lPermission = new List<classPermission>();
                            while (oSql.Reader.Read())
                            {
                                try
                                {
                                    classPermission oPermission = new classPermission(
                                    Convert.ToInt32(oSql.Reader["idPermission"]),
                                    Convert.ToString(oSql.Reader["Description"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                    lPermission.Add(oPermission);
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    lPermission = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    lPermission = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    lPermission = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = lPermission;
                        break;
                    }
                case eAbm.Select:
                    {
                        classPermission oPermission = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            if (oSql.Reader.Read())
                            {
                                try
                                {
                                    oPermission = new classPermission(
                                    Convert.ToInt32(oSql.Reader["idPermission"]),
                                    Convert.ToString(oSql.Reader["Description"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    oPermission = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    oPermission = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    oPermission = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = oPermission;
                        break;
                    }
                case eAbm.Insert:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Update:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Delete:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.LoadCmb:
                    {
                        //Result = oSql.ExecCombo(SPname, lParam.ToArray());
                        //if (oSql.Table.Rows.Count != 0)
                        //    Table = oSql.Table;
                        //else
                        //    Table = null;
                        DataTable dT = new DataTable(SPname);
                        dT.Columns.Add("Id", typeof(Int32));
                        dT.Columns.Add("Value", typeof(string));
                        dT.Rows.Add(new object[] { 1, "Usuario" });
                        dT.Rows.Add(new object[] { 2, "Administrador" });
                        Table = dT;
                        Result = true;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return Result;
        }

        public object AbmProfessional(classProfessional oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmProfessional;

            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
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
            lParam.Add(new SqlParameter("Admin", oP.Admin));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));

            switch (Abm)
            {
                case eAbm.SelectAll:
                    {
                        List<classProfessional> lProfessional = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            lProfessional = new List<classProfessional>();
                            while (oSql.Reader.Read())
                            {
                                try
                                {
                                    classProfessional oProfessional = new classProfessional(
                                    Convert.ToInt32(oSql.Reader["IdProfessional"]),
                                    Convert.ToString(oSql.Reader["Name"]),
                                    Convert.ToString(oSql.Reader["LastName"]),
                                    Convert.ToInt32(oSql.Reader["ProfessionalRegistration"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationCountry"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationProvince"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationCity"]),
                                    Convert.ToString(oSql.Reader["Address"]),
                                    Convert.ToString(oSql.Reader["Phone"]),
                                    Convert.ToString(oSql.Reader["Mail"]),
                                    Convert.ToString(oSql.Reader["User"]),
                                    Convert.ToString(oSql.Reader["Password"]),
                                    Convert.ToInt32(oSql.Reader["Admin"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                    lProfessional.Add(oProfessional);
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    lProfessional = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    lProfessional = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    lProfessional = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = lProfessional;
                        break;
                    }
                case eAbm.Select:
                    {
                        classProfessional oProfessional = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            if (oSql.Reader.Read())
                            {
                                try
                                {
                                    oProfessional = new classProfessional(
                                    Convert.ToInt32(oSql.Reader["IdProfessional"]),
                                    Convert.ToString(oSql.Reader["Name"]),
                                    Convert.ToString(oSql.Reader["LastName"]),
                                    Convert.ToInt32(oSql.Reader["ProfessionalRegistration"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationCountry"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationProvince"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationCity"]),
                                    Convert.ToString(oSql.Reader["Address"]),
                                    Convert.ToString(oSql.Reader["Phone"]),
                                    Convert.ToString(oSql.Reader["Mail"]),
                                    Convert.ToString(oSql.Reader["User"]),
                                    Convert.ToString(oSql.Reader["Password"]),
                                    Convert.ToInt32(oSql.Reader["Admin"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    oProfessional = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    oProfessional = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    oProfessional = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = oProfessional;
                        break;
                    }
                case eAbm.Insert:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Update:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Delete:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.LoadCmb:
                    {
                        Result = oSql.ExecCombo(SPname, lParam.ToArray());
                        if (oSql.Table.Rows.Count != 0)
                            Table = oSql.Table;
                        else
                            Table = null;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return Result;
        }

        public object AbmProfessionalSpeciality(classProfessionalSpeciality oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmProfessionalSpeciality;

            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@idProfessionalSpeciality", oP.IdProfessionalSpeciality));
            lParam.Add(new SqlParameter("@IdProfessional", oP.IdProfessional));
            lParam.Add(new SqlParameter("@IdSpeciality", oP.IdSpeciality));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));

            switch (Abm)
            {
                case eAbm.SelectAll:
                    {
                        List<classProfessionalSpeciality> lProfessionalSpeciality = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            lProfessionalSpeciality = new List<classProfessionalSpeciality>();
                            while (oSql.Reader.Read())
                            {
                                try
                                {
                                    classProfessionalSpeciality oProfessionalSpeciality = new classProfessionalSpeciality(
                                    Convert.ToInt32(oSql.Reader["idProfessionalSpeciality"]),
                                    Convert.ToInt32(oSql.Reader["IdProfessional"]),
                                    Convert.ToInt32(oSql.Reader["IdSpeciality"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                    lProfessionalSpeciality.Add(oProfessionalSpeciality);
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    lProfessionalSpeciality = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    lProfessionalSpeciality = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    lProfessionalSpeciality = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = lProfessionalSpeciality;
                        break;
                    }
                case eAbm.Select:
                    {
                        classProfessionalSpeciality oProfessionalSpeciality = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            if (oSql.Reader.Read())
                            {
                                try
                                {
                                    oProfessionalSpeciality = new classProfessionalSpeciality(
                                    Convert.ToInt32(oSql.Reader["idProfessionalSpeciality"]),
                                    Convert.ToInt32(oSql.Reader["IdProfessional"]),
                                    Convert.ToInt32(oSql.Reader["IdSpeciality"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    oProfessionalSpeciality = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    oProfessionalSpeciality = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    oProfessionalSpeciality = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = oProfessionalSpeciality;
                        break;
                    }
                case eAbm.Insert:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Update:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Delete:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.LoadCmb:
                    {
                        Result = oSql.ExecCombo(SPname, lParam.ToArray());
                        if (oSql.Table.Rows.Count != 0)
                            Table = oSql.Table;
                        else
                            Table = null;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return Result;
        }

        public object AbmRelationship(classRelationship oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmRelationship;

            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@idRelationship", oP.IdRelationship));
            lParam.Add(new SqlParameter("@Description", oP.Description));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));

            switch (Abm)
            {
                case eAbm.SelectAll:
                    {
                        List<classRelationship> lRelationship = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            lRelationship = new List<classRelationship>();
                            while (oSql.Reader.Read())
                            {
                                try
                                {
                                    classRelationship oRelationship = new classRelationship(
                                    Convert.ToInt32(oSql.Reader["idRelationship"]),
                                    Convert.ToString(oSql.Reader["Description"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                    lRelationship.Add(oRelationship);
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    lRelationship = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    lRelationship = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    lRelationship = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = lRelationship;
                        break;
                    }
                case eAbm.Select:
                    {
                        classRelationship oRelationship = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            if (oSql.Reader.Read())
                            {
                                try
                                {
                                    oRelationship = new classRelationship(
                                    Convert.ToInt32(oSql.Reader["idRelationship"]),
                                    Convert.ToString(oSql.Reader["Description"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    oRelationship = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    oRelationship = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    oRelationship = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = oRelationship;
                        break;
                    }
                case eAbm.Insert:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Update:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Delete:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.LoadCmb:
                    {
                        Result = oSql.ExecCombo(SPname, lParam.ToArray());
                        if (oSql.Table.Rows.Count != 0)
                            Table = oSql.Table;
                        else
                            Table = null;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return Result;
        }

        public object AbmSocialWork(classSocialWork oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmSocialWork;

            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@IdSocialWork", oP.IdSocialWork));
            lParam.Add(new SqlParameter("@Name", oP.Name));
            lParam.Add(new SqlParameter("@Description", oP.Description));
            lParam.Add(new SqlParameter("@IdLocationCountry", oP.IdLocationCountry));
            lParam.Add(new SqlParameter("@IdLocationProvince", oP.IdLocationProvince));
            lParam.Add(new SqlParameter("@IdLocationCity", oP.IdLocationCity));
            lParam.Add(new SqlParameter("@Address", oP.Address));
            lParam.Add(new SqlParameter("@Phone", oP.Phone));
            lParam.Add(new SqlParameter("@Contact", oP.Contact));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));

            switch (Abm)
            {
                case eAbm.SelectAll:
                    {
                        List<classSocialWork> lSocialWork = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            lSocialWork = new List<classSocialWork>();
                            while (oSql.Reader.Read())
                            {
                                try
                                {
                                    classSocialWork oSocialWork = new classSocialWork(
                                    Convert.ToInt32(oSql.Reader["IdSocialWork"]),
                                    Convert.ToString(oSql.Reader["Name"]),
                                    Convert.ToString(oSql.Reader["Description"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationCountry"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationProvince"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationCity"]),
                                    Convert.ToString(oSql.Reader["Address"]),
                                    Convert.ToString(oSql.Reader["Phone"]),
                                    Convert.ToString(oSql.Reader["Contact"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                    lSocialWork.Add(oSocialWork);
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    lSocialWork = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    lSocialWork = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    lSocialWork = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = lSocialWork;
                        break;
                    }
                case eAbm.Select:
                    {
                        classSocialWork oSocialWork = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            if (oSql.Reader.Read())
                            {
                                try
                                {
                                    oSocialWork = new classSocialWork(
                                    Convert.ToInt32(oSql.Reader["IdSocialWork"]),
                                    Convert.ToString(oSql.Reader["Name"]),
                                    Convert.ToString(oSql.Reader["Description"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationCountry"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationProvince"]),
                                    Convert.ToInt32(oSql.Reader["IdLocationCity"]),
                                    Convert.ToString(oSql.Reader["Address"]),
                                    Convert.ToString(oSql.Reader["Phone"]),
                                    Convert.ToString(oSql.Reader["Contact"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    oSocialWork = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    oSocialWork = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    oSocialWork = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = oSocialWork;
                        break;
                    }
                case eAbm.Insert:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Update:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Delete:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.LoadCmb:
                    {
                        Result = oSql.ExecCombo(SPname, lParam.ToArray());
                        if (oSql.Table.Rows.Count != 0)
                            Table = oSql.Table;
                        else
                            Table = null;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return Result;
        }

        public object AbmSpeciality(classSpecialty oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmSpeciality;

            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@idSpecialty", oP.IdSpecialty));
            lParam.Add(new SqlParameter("@Description", oP.Description));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));

            switch (Abm)
            {
                case eAbm.SelectAll:
                    {
                        List<classSpecialty> lSpecialty = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            lSpecialty = new List<classSpecialty>();
                            while (oSql.Reader.Read())
                            {
                                try
                                {
                                    classSpecialty oSpecialty = new classSpecialty(
                                    Convert.ToInt32(oSql.Reader["idSpecialty"]),
                                    Convert.ToString(oSql.Reader["Description"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                    lSpecialty.Add(oSpecialty);
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    lSpecialty = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    lSpecialty = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    lSpecialty = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = lSpecialty;
                        break;
                    }
                case eAbm.Select:
                    {
                        classSpecialty oSpecialty = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            if (oSql.Reader.Read())
                            {
                                try
                                {
                                    oSpecialty = new classSpecialty(
                                    Convert.ToInt32(oSql.Reader["idSpecialty"]),
                                    Convert.ToString(oSql.Reader["Description"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    oSpecialty = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    oSpecialty = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    oSpecialty = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = oSpecialty;
                        break;
                    }
                case eAbm.Insert:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Update:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Delete:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.LoadCmb:
                    {
                        Result = oSql.ExecCombo(SPname, lParam.ToArray());
                        if (oSql.Table.Rows.Count != 0)
                            Table = oSql.Table;
                        else
                            Table = null;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return Result;
        }

        public object AbmTypeDocument(classTypeDocument oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmTypeDocument;

            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Abm", (int)Abm));
            lParam.Add(new SqlParameter("@idTypeDocument", oP.IdTypeDocument));
            lParam.Add(new SqlParameter("@Description", oP.Description));
            lParam.Add(new SqlParameter("@Visible", oP.Visible));

            switch (Abm)
            {
                case eAbm.SelectAll:
                    {
                        List<classTypeDocument> lTypeDocument = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            lTypeDocument = new List<classTypeDocument>();
                            while (oSql.Reader.Read())
                            {
                                try
                                {
                                    classTypeDocument oTypeDocument = new classTypeDocument(
                                    Convert.ToInt32(oSql.Reader["idTypeDocument"]),
                                    Convert.ToString(oSql.Reader["Description"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                    lTypeDocument.Add(oTypeDocument);
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    lTypeDocument = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    lTypeDocument = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    lTypeDocument = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = lTypeDocument;
                        break;
                    }
                case eAbm.Select:
                    {
                        classTypeDocument oTypeDocument = null;
                        if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                        {
                            if (oSql.Reader.Read())
                            {
                                try
                                {
                                    oTypeDocument = new classTypeDocument(
                                    Convert.ToInt32(oSql.Reader["idTypeDocument"]),
                                    Convert.ToString(oSql.Reader["Description"]),
                                    Convert.ToBoolean(oSql.Reader["Visible"]));
                                }
                                catch (FormatException ex)
                                {
                                    Menssage = ex.ToString();
                                    oTypeDocument = null;
                                }
                                catch (InvalidCastException ex)
                                {
                                    Menssage = ex.ToString();
                                    oTypeDocument = null;
                                }
                                catch (OverflowException ex)
                                {
                                    Menssage = ex.ToString();
                                    oTypeDocument = null;
                                }
                            }
                        }
                        else
                            Menssage = oSql.Mensage;

                        oSql.Close();
                        Result = oTypeDocument;
                        break;
                    }
                case eAbm.Insert:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Update:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.Delete:
                    {
                        int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                        if (UltimoId == 0)
                            Menssage = oSql.Mensage;

                        Result = UltimoId;
                        break;
                    }
                case eAbm.LoadCmb:
                    {
                        Result = oSql.ExecCombo(SPname, lParam.ToArray());
                        if (oSql.Table.Rows.Count != 0)
                            Table = oSql.Table;
                        else
                            Table = null;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return Result;
        }

        #endregion

        // OK - 24/09/17
        # region Filtros

        /// <summary>
        /// Filtra por coincidencia.
        /// OK - 24/09/17
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Bloqueado"></param>
        /// <param name="Desde"></param>
        /// <param name="Hasta"></param>
        /// <returns></returns>
        public bool FiltroProfesionalesLimite(string Name, string LastName, int Desde, int Hasta)
        {
            string SPname = sp.FiltroProfesionalesLimite;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Name", Name));
            lParam.Add(new SqlParameter("@LastName", LastName));
            lParam.Add(new SqlParameter("@Desde", Desde));
            lParam.Add(new SqlParameter("@Hasta", Hasta));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                DataSet set = new DataSet();
                Table = new DataTable();
                set.Reset();
                oSql.Adapter.Fill(set);
                Table = set.Tables[0];
                oSql.Close();
                return true;
            }
            else
            {
                oSql.Close();
                return false;
            }
        }

        /// <summary>
        /// Filtra por coincidencia.
        /// OK - 24/09/17
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Desde"></param>
        /// <param name="Hasta"></param>
        /// <returns></returns>
        public bool FiltroSocialWorkLimite(string Name, int Desde, int Hasta)
        {
            string SPname = sp.FiltroSocialWorkLimite;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Name", Name));
            lParam.Add(new SqlParameter("@Desde", Desde));
            lParam.Add(new SqlParameter("@Hasta", Hasta));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                DataSet set = new DataSet();
                Table = new DataTable();
                set.Reset();
                oSql.Adapter.Fill(set);
                Table = set.Tables[0];
                oSql.Close();
                return true;
            }
            else
            {
                oSql.Close();
                return false;
            }
        }

        /// <summary>
        /// Filtra por coincidencia.
        /// OK - 24/09/17
        /// </summary>
        /// <param name="oPersona"></param>
        /// <param name="Desde"></param>
        /// <param name="Hasta"></param>
        /// <returns></returns>
        public bool FiltroPatientLimite(string Name, string LastName, int AffiliateNumber, int IdSocialWork, int Desde, int Hasta)
        {
            string SPname = sp.FiltroPatientLimite;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Name", Name));
            lParam.Add(new SqlParameter("@LastName", LastName));
            lParam.Add(new SqlParameter("@AffiliateNumber", AffiliateNumber));
            lParam.Add(new SqlParameter("@IdSocialWork", IdSocialWork));
            lParam.Add(new SqlParameter("@Desde", Desde));
            lParam.Add(new SqlParameter("@Hasta", Hasta));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                DataSet set = new DataSet();
                Table = new DataTable();
                set.Reset();
                oSql.Adapter.Fill(set);
                Table = set.Tables[0];
                oSql.Close();
                return true;
            }
            else
            {
                oSql.Close();
                return false;
            }
        }

        #endregion



        #region Contadores

        public decimal CountProfesionales(string p1, bool p2)
        {
            throw new NotImplementedException();
        }

        public decimal CountSocialWork(string p)
        {
            throw new NotImplementedException();
        }

        public decimal CountGrandfather(classPatient oPersona)
        {
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// OK 24/06/12
        ///// Cuenta Obras Sociales.
        ///// </summary>
        ///// <returns></returns>
        //public int CountPersona(classPersona oP)
        //{
        //    int C = 0;
        //    #region Consulta

        //    string Consulta = "SELECT COUNT(IdPersona)[C] FROM persona WHERE Visible = 1";

        //    if (oP.nAfiliado != "" && oP.Apellido != "")
        //    {
        //        Consulta += " AND Apellido LIKE '" + oP.Apellido 
        //            + "%' AND nAfiliado LIKE '" + oP.nAfiliado + "%' ";
        //    }
        //    else if (oP.Apellido != "")
        //    {   // OK 21/03/12
        //        Consulta += " AND Apellido LIKE '" + oP.Apellido + "%' ";
        //    }
        //    else if (oP.nAfiliado != "")
        //    {   // OK 21/03/12
        //        Consulta += " AND nAfiliado LIKE '" + oP.nAfiliado + "%'";  
        //    }
        //    else
        //    {   // OK 21/03/12
        //        //Consulta += " AND IdObraSocial = " + oP.ObraSocial ;
        //    }

        //    if (oP.ObraSocial != 1)
        //    {
        //        Consulta += " AND IdObraSocial = " + oP.ObraSocial + " ORDER BY Apellido;";
        //    }
        //    else
        //    {
        //        Consulta += " ORDER BY Apellido;";
        //    }
        //    #endregion

        //    if (Sql.SelectReader(Consulta, null, "CountPersona"))
        //    {
        //        Sql.Reader.Read();
        //        C = Convert.ToInt32(Sql.Reader["C"]);
        //        Sql.Reader.Close();
        //        Sql.Close();
        //    }
        //    return C;
        //}

        ///// <summary>
        ///// OK 24/06/12
        ///// Cuenta Obras Sociales.
        ///// </summary>
        ///// <returns></returns>
        //public int CountObraSocial(string Nombre)
        //{
        //    int C = 0;
        //    string Consulta = "SELECT COUNT(IdObraSocial)-1[C] FROM ObraSocial WHERE Visible = 1";

        //    if (Nombre != "")
        //        Consulta += " AND Nombre LIKE '" + Nombre + "%';";
        //    else
        //        Consulta += " ;";

        //    if (Sql.SelectReader(Consulta, null, "CountObraSocial"))
        //    {
        //        Sql.Reader.Read();
        //        C = Convert.ToInt32(Sql.Reader["C"]);
        //        Sql.Reader.Close();
        //        Sql.Close();
        //    }
        //    return C;
        //}

        ///// <summary>
        ///// OK 24/06/12
        ///// Cuenta Obras Sociales.
        ///// </summary>
        ///// <returns></returns>
        //public int CountUsuarios(string Nombre, bool Bloqueado)
        //{
        //    int C = 0;

        //    #region Consulta

        //    string Consulta = "SELECT COUNT(IdUsuario)[C] FROM Usuario ";

        //    if (Nombre != "") // OK 21/03/12
        //        Consulta = Consulta + "WHERE Bloqueado = " + Convert.ToInt32(Bloqueado) + " AND Nombre LIKE '" + Nombre + "%' ;";
        //    else// OK 21/03/12  
        //        Consulta = Consulta + " WHERE Bloqueado = " + Convert.ToInt32(Bloqueado) + " ;";

        //    #endregion

        //    if (Sql.SelectReader(Consulta, null, "CountUsuarios"))
        //    {
        //        Sql.Reader.Read();
        //        C = Convert.ToInt32(Sql.Reader["C"]);
        //        Sql.Reader.Close();
        //        Sql.Close();
        //    }
        //    return C;
        //}

        #endregion

        #region Ultimos

        ///// <summary>
        ///// Trae el ultimo usuario insertado
        ///// OK 07/06/12
        ///// </summary>
        ///// <returns></returns>
        //public int UltimoIdUsuario()
        //{
        //    int A = 0;

        //    if (Sql.SelectReader("SELECT MAX(IdUsuario) AS Id FROM Usuario", null, "UltimoIdUsuario"))
        //    {
        //        Sql.Reader.Read();
        //        A = Convert.ToInt32(Sql.Reader["Id"]);
        //        Sql.Reader.Close();
        //        Sql.Close();
        //    }

        //    return A;
        //}

        //// OK 25/05/12
        //public int UltimoIdPersona()
        //{
        //    int A = 0;

        //    if (Sql.SelectReader("SELECT MAX(IdPersona) AS Id FROM Persona", null, "UltimoIdPaciente"))
        //    {
        //        Sql.Reader.Read();
        //        A = Convert.ToInt32(Sql.Reader["Id"]);
        //        Sql.Reader.Close();
        //        Sql.Close();
        //    }

        //    return A;
        //}

        /// <summary>
        /// Trae el ultimo usuario insertado
        /// OK 07/06/12
        /// </summary>
        /// <returns></returns>
        public int UltimoIdProfessional()
        {
            int A = 0;

            if (oSql.SelectRaeder("SELECT MAX(IdProfessional) AS Id FROM Professional", null))
            {
                oSql.Reader.Read();
                A = Convert.ToInt32(oSql.Reader["Id"]);
                oSql.Reader.Close();
                oSql.Close();
            }

            return A;
        }

        #endregion

        #region Consultas Especiales

        /// <summary>
        /// Consulta por Usuaui y contraseña y devuelve el id.
        /// OK - 17/09/16
        /// </summary>
        /// <param name="oP"></param>
        /// <returns></returns>
        public int ValidarPassword(classProfessional oP)
        {
            string SPname = sp.Login;
            int A = 0;

            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@User", oP.User));
            lParam.Add(new SqlParameter("@Password", oP.Password));

            if (oSql.SelectRaeder(SPname, lParam.ToArray()))
            {
                if (oSql.Reader.Read())
                {
                    A = Convert.ToInt32(oSql.Reader[0]);
                    oSql.Reader.Close();
                }
            }
            oSql.Close();
            return A;
        }

        #endregion

        #region CONSULTAS COMETADAS

        //// OK 21/06/12
        #region Estadisticas

        ///// <summary>
        ///// Carga un objeto DataTable
        ///// OK 20/06/12
        ///// </summary>
        ///// <returns></returns>
        //public bool ePacientes(string nameDataTable, DateTime Desde, DateTime Hasta)
        //{
        //    DataTable TablaAuxiliar = new DataTable(nameDataTable);
        //    TablaAuxiliar.Columns.Add(new DataColumn("nPacientes", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("FechaNac", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("FechaAlta", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Ciudad", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Sexo", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Edad", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("FiltroEdad", typeof(string)));


        //    string Consulta = "SELECT (P.Apellido||', '||P.Nombre) [nPacientes], P.FechaNacimiento[FechaNac],"
        //       + " P.FechaAlta[FechaAlta],C.Nombre[Ciudad],P.Sexo[Sexo]"
        //       + " FROM Persona AS P INNER JOIN Ciudad AS C"
        //       + " ON P.IdCiudad = C.IdCiudad"
        //       + " INNER JOIN TipoPersona AS T"
        //       + " ON P.IdTipoPersona = T.IdTipoPersona"
        //       + " WHERE P.Visible = 1"
        //       + " AND P.FechaAlta BETWEEN ('" + String.Format("{0:yyyy'-'MM'-'dd}", Desde) + "')"
        //       + " AND ('" + String.Format("{0:yyyy'-'MM'-'dd}", Hasta) + "') ORDER BY P.FechaAlta;";

        //    if (Sql.SelectReader(Consulta, null, "ePacientes"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            DataRow Row = TablaAuxiliar.NewRow();
        //            classPersona oP = new classPersona();

        //            Row[0] = Sql.Reader["nPacientes"].ToString();
        //            Row[1] = String.Format("{0:d}", Convert.ToDateTime(Sql.Reader["FechaNac"]));
        //            Row[2] = String.Format("{0:y}", Convert.ToDateTime(Sql.Reader["FechaAlta"]));
        //            Row[3] = Sql.Reader["Ciudad"].ToString();
        //            Row[4] = oP.toSexo(Convert.ToInt32(Sql.Reader["Sexo"]));
        //            Row[5] = oP.Edad(Convert.ToDateTime(Sql.Reader["FechaNac"])).ToString();
        //            Row[6] = oP.toMayorEdad(oP.Edad(Convert.ToDateTime(Sql.Reader["FechaNac"])));

        //            TablaAuxiliar.Rows.Add(Row);
        //        }
        //        Sql.Reader.Close();
        //        Sql.Close();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Close();
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// Carga un objeto DataTable
        ///// OK 20/06/12
        ///// Tuto: http://msdn.microsoft.com/es-es/library/ch2aw0w6.aspx
        ///// </summary>
        ///// <returns></returns>
        //public bool eDiagnosticos(string nameDataTable, DateTime Desde, DateTime Hasta)
        //{
        //    DataTable TablaAuxiliar = new DataTable(nameDataTable);
        //    TablaAuxiliar.Columns.Add(new DataColumn("nPaciente", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Fecha", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Detalle", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Diagnostico", typeof(string)));

        //    string Consulta = "SELECT (P.Apellido||', '||P.Nombre) [nPaciente]"
        //        + ", D.Fecha, E.Nombre[Detalle], D.Diagnostico"
        //       + " FROM Persona AS P INNER JOIN Diagnostico AS D"
        //       + " ON P.IdPersona = D.IdPersona "
        //       + " INNER JOIN Detalle AS E"
        //       + " ON E.IdDetalle = D.IdDetalle"
        //       + " INNER JOIN Barrio AS B"
        //       + " ON P.IdBarrio = B.iIdBarrio"
        //       + " WHERE P.Visible = 1"
        //       + " AND P.FechaAlta BETWEEN ('" + String.Format("{0:yyyy'-'MM'-'dd}", Desde) + "')"
        //       + " AND ('" + String.Format("{0:yyyy'-'MM'-'dd}", Hasta) + "');";

        //    if (Sql.SelectReader(Consulta, null, "eDiagnoticos"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            DataRow Row = TablaAuxiliar.NewRow();

        //            Row[0] = Sql.Reader["nPaciente"].ToString();
        //            Row[1] = String.Format("{0:d}", Convert.ToDateTime(Sql.Reader["Fecha"]));
        //            Row[2] = Sql.Reader["Detalle"].ToString();
        //            Row[3] = Sql.Reader["Diagnostico"].ToString();

        //            TablaAuxiliar.Rows.Add(Row);
        //        }
        //        Sql.Reader.Close();
        //        Sql.Close();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Close();
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// Carga un objeto DataTable
        ///// OK 20/06/12
        ///// </summary>
        ///// <returns></returns>
        //public bool eObraSocial(string nameDataTable, DateTime Desde, DateTime Hasta)
        //{
        //    DataTable TablaAuxiliar = new DataTable(nameDataTable);
        //    TablaAuxiliar.Columns.Add(new DataColumn("IdPersona", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("nNombre", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("nObraSocial", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("FechaAlta", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Direccion", typeof(string)));

        //    string Consulta = "SELECT P.IdPersona, (P.Apellido||', '||P.Nombre) [nNombre], O.Nombre [nObraSocial]"
        //       + ", P.FechaAlta, C.Nombre||' - '||B.Nombre||' -' ||P.Direccion [Direccion]"
        //       + " FROM Persona AS P INNER JOIN ObraSocial AS O"
        //       + " ON P.IdObraSocial = O.IdObraSocial "
        //       + " INNER JOIN Ciudad AS C"
        //       + " ON P.IdCiudad = C.IdCiudad"
        //       + " INNER JOIN Barrio AS B"
        //       + " ON P.IdBarrio = B.iIdBarrio"
        //       + " WHERE P.Visible = 1 AND O.Visible = 1"
        //       + " AND P.FechaAlta BETWEEN ('" + String.Format("{0:yyyy'-'MM'-'dd}", Desde) + "')"
        //       + " AND ('" + String.Format("{0:yyyy'-'MM'-'dd}", Hasta) + "');";

        //    if (Sql.SelectReader(Consulta, null, "eObraSocial"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            DataRow Row = TablaAuxiliar.NewRow();

        //            Row[0] = Sql.Reader["IdPersona"].ToString();
        //            Row[1] = Sql.Reader["nNombre"].ToString();
        //            Row[2] = Sql.Reader["nObraSocial"].ToString();
        //            Row[3] = String.Format("{0:d}", Convert.ToDateTime(Sql.Reader["FechaAlta"]));
        //            Row[4] = Sql.Reader["Direccion"].ToString();

        //            TablaAuxiliar.Rows.Add(Row);
        //        }
        //        Sql.Reader.Close();
        //        Sql.Close();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Close();
        //        return false;
        //    }
        //}

        #endregion

        //// OK 21/06/12
        #region Consulta Reportes

        ///// <summary>
        ///// Trae todos los turnos del personas seleccionado.
        ///// OK 21/06/12 
        ///// </summary>
        ///// <param name="oT"></param>
        ///// <returns></returns>
        //public bool rTurnos(string nameDataTable, classTurnos oT)
        //{
        //    #region Tabla

        //    DataTable TablaAuxiliar = new DataTable(nameDataTable);
        //    TablaAuxiliar.Columns.Add(new DataColumn("Edad", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Expediente", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Paciente", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Medico", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Dia", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Hora", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Estado", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("ObraSocial", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Tipo", typeof(string)));

        //    #endregion

        //    #region Consulta

        //    string Consulta = "SELECT P.FechaNacimiento [Edad], P.nAfiliado[Expediente],"
        //        + " (P.Apellido||', '||P.Nombre)[Paciente], I.Nombre[Tipo],"
        //        + " U.Nombre[Medico], T.Fecha[Turno], E.Nombre[Estado], O.Nombre[ObraSocial]"
        //        + " FROM Turno AS T INNER JOIN Persona AS P "
        //        + " ON T.IdPersona = P.IdPersona "
        //        + " INNER JOIN Usuario AS U"
        //        + " ON T.IdUsuario = U.IdUsuario"
        //        + " INNER JOIN EstadoTurno AS E"
        //        + " ON T.IdEstadoTurno = E.IdEstadoTurno"
        //        + " INNER JOIN ObraSocial AS O"
        //        + " ON P.IdObraSocial = O.IdObraSocial"
        //        + " INNER JOIN TipoPersona AS I"
        //        + " ON P.IdTipoPersona = I.IdTipoPersona"
        //        + " WHERE T.IdPersona = " + oT.IdPersona
        //        + " AND U.IdUsuario = " + oT.IdUsuario + " ORDER BY T.Fecha;";

        //    #endregion

        //    if (Sql.SelectReader(Consulta, null, "rTurnos"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            classPersona oP = new classPersona();
        //            DataRow Row = TablaAuxiliar.NewRow();

        //            Row[0] = oP.Edad(Convert.ToDateTime(Sql.Reader["Edad"]));
        //            Row[1] = Sql.Reader["Expediente"].ToString();
        //            Row[2] = Sql.Reader["Paciente"].ToString();
        //            Row[3] = Sql.Reader["Medico"].ToString();
        //            Row[4] = String.Format("{0:m}", Convert.ToDateTime(Sql.Reader["Turno"]));
        //            Row[5] = String.Format("{0:T}", Convert.ToDateTime(Sql.Reader["Turno"]));
        //            Row[6] = Sql.Reader["Estado"].ToString();
        //            Row[7] = Sql.Reader["ObraSocial"].ToString();
        //            Row[8] = Sql.Reader["Tipo"].ToString();

        //            TablaAuxiliar.Rows.Add(Row);
        //        }
        //        Sql.Reader.Close();
        //        Sql.Close();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Close();
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// Trae todos los turnos del personas seleccionado.
        ///// OK 21/06/12 
        ///// </summary>
        ///// <param name="oT"></param>
        ///// <returns></returns>
        //public bool rTurnosLimite(string nameDataTable, classTurnos oT, int Desde, int Hasta)
        //{
        //    #region Tabla

        //    DataTable TablaAuxiliar = new DataTable(nameDataTable);
        //    TablaAuxiliar.Columns.Add(new DataColumn("Edad", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Expediente", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Paciente", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Medico", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Dia", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Hora", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Estado", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("ObraSocial", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Tipo", typeof(string)));

        //    #endregion

        //    #region Consulta

        //    string Consulta = "SELECT P.FechaNacimiento [Edad], P.nAfiliado[Expediente],"
        //        + " (P.Apellido||', '||P.Nombre)[Paciente], I.Nombre[Tipo],"
        //        + " U.Nombre[Medico], T.Fecha[Turno], E.Nombre[Estado], O.Nombre[ObraSocial]"
        //        + " FROM Turno AS T INNER JOIN Persona AS P "
        //        + " ON T.IdPersona = P.IdPersona "
        //        + " INNER JOIN Usuario AS U"
        //        + " ON T.IdUsuario = U.IdUsuario"
        //        + " INNER JOIN EstadoTurno AS E"
        //        + " ON T.IdEstadoTurno = E.IdEstadoTurno"
        //        + " INNER JOIN ObraSocial AS O"
        //        + " ON P.IdObraSocial = O.IdObraSocial"
        //        + " INNER JOIN TipoPersona AS I"
        //        + " ON P.IdTipoPersona = I.IdTipoPersona"
        //        + " WHERE T.IdPersona = " + oT.IdPersona
        //        + " AND U.IdUsuario = " + oT.IdUsuario + " ORDER BY T.Fecha" 
        //        + " LIMIT " + Desde + ", " + Hasta +" ;";

        //    #endregion

        //    if (Sql.SelectReader(Consulta, null, "rTurnosLimite"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            classPersona oP = new classPersona();
        //            DataRow Row = TablaAuxiliar.NewRow();

        //            Row[0] = oP.Edad(Convert.ToDateTime(Sql.Reader["Edad"]));
        //            Row[1] = Sql.Reader["Expediente"].ToString();
        //            Row[2] = Sql.Reader["Paciente"].ToString();
        //            Row[3] = Sql.Reader["Medico"].ToString();
        //            Row[4] = String.Format("{0:m}", Convert.ToDateTime(Sql.Reader["Turno"]));
        //            Row[5] = String.Format("{0:T}", Convert.ToDateTime(Sql.Reader["Turno"]));
        //            Row[6] = Sql.Reader["Estado"].ToString();
        //            Row[7] = Sql.Reader["ObraSocial"].ToString();
        //            Row[8] = Sql.Reader["Tipo"].ToString();

        //            TablaAuxiliar.Rows.Add(Row);
        //        }
        //        Sql.Reader.Close();
        //        Sql.Close();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Close();
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// Trae todos los turnos del personas seleccionado.
        ///// OK 21/06/12
        ///// </summary>
        ///// <param name="oT"></param>
        ///// <returns></returns>
        //public bool rTurnosDelDia(string nameDataTable, DateTime Desde, DateTime Hasta, int IdUsuario)
        //{
        //    #region Tabla

        //    DataTable TablaAuxiliar = new DataTable(nameDataTable);
        //    TablaAuxiliar.Columns.Add(new DataColumn("Edad", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Expediente", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Paciente", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Medico", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Dia", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Hora", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Estado", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("ObraSocial", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Tipo", typeof(string)));

        //    #endregion

        //    #region Consulta

        //    string Consulta = "SELECT P.FechaNacimiento [Edad], P.nAfiliado[Expediente]," 
        //        + " (P.Apellido||', '||P.Nombre)[Paciente], I.Nombre[Tipo],"
        //        + " U.Nombre[Medico], T.Fecha[Turno], E.Nombre[Estado], O.Nombre[ObraSocial]"
        //        + " FROM Turno AS T INNER JOIN Persona AS P "
        //        + " ON T.IdPersona = P.IdPersona "
        //        + " INNER JOIN Usuario AS U"
        //        + " ON T.IdUsuario = U.IdUsuario"
        //        + " INNER JOIN EstadoTurno AS E"
        //        + " ON T.IdEstadoTurno = E.IdEstadoTurno"
        //        + " INNER JOIN ObraSocial AS O"
        //        + " ON P.IdObraSocial = O.IdObraSocial"
        //        + " INNER JOIN TipoPersona AS I"
        //        + " ON P.IdTipoPersona = I.IdTipoPersona"
        //        + " WHERE T.Fecha BETWEEN '" + String.Format("{0:yyyy'-'MM'-'dd}", Desde)
        //        + "' AND '" + String.Format("{0:yyyy'-'MM'-'dd}", Hasta) + "' AND U.IdUsuario = " + IdUsuario + " ;";

        //    #endregion

        //    if (Sql.SelectReader(Consulta, null, "rTurnosDelDia"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            classPersona oP = new classPersona();
        //            DataRow Row = TablaAuxiliar.NewRow();

        //            Row[0] = oP.Edad(Convert.ToDateTime(Sql.Reader["Edad"]));
        //            Row[1] = Sql.Reader["Expediente"].ToString();
        //            Row[2] = Sql.Reader["Paciente"].ToString();
        //            Row[3] = Sql.Reader["Medico"].ToString();
        //            Row[4] = String.Format("{0:m}", Convert.ToDateTime(Sql.Reader["Turno"]));
        //            Row[5] = String.Format("{0:T}", Convert.ToDateTime(Sql.Reader["Turno"]));
        //            Row[6] = Sql.Reader["Estado"].ToString();
        //            Row[7] = Sql.Reader["ObraSocial"].ToString();
        //            Row[8] = Sql.Reader["Tipo"].ToString();

        //            TablaAuxiliar.Rows.Add(Row);
        //        }
        //        Sql.Reader.Close();
        //        Sql.Close();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Close();
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// Trae todos los turnos del personas seleccionado.
        ///// OK 21/06/12
        ///// </summary>
        ///// <param name="oT"></param>
        ///// <returns></returns>
        //public bool rTurnosDelDiaLimite(string nameDataTable, DateTime FechaDesde, DateTime FechaHasta, int IdUsuario, int Desde, int Hasta)
        //{
        //    #region Tabla

        //    DataTable TablaAuxiliar = new DataTable(nameDataTable);
        //    TablaAuxiliar.Columns.Add(new DataColumn("Edad", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Expediente", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Paciente", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Medico", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Dia", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Hora", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Estado", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("ObraSocial", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Tipo", typeof(string)));

        //    #endregion

        //    #region Consulta

        //    string Consulta = "SELECT P.FechaNacimiento [Edad], P.nAfiliado[Expediente],"
        //        + " (P.Apellido||', '||P.Nombre)[Paciente], I.Nombre[Tipo],"
        //        + " U.Nombre[Medico], T.Fecha[Turno], E.Nombre[Estado], O.Nombre[ObraSocial]"
        //        + " FROM Turno AS T INNER JOIN Persona AS P "
        //        + " ON T.IdPersona = P.IdPersona "
        //        + " INNER JOIN Usuario AS U"
        //        + " ON T.IdUsuario = U.IdUsuario"
        //        + " INNER JOIN EstadoTurno AS E"
        //        + " ON T.IdEstadoTurno = E.IdEstadoTurno"
        //        + " INNER JOIN ObraSocial AS O"
        //        + " ON P.IdObraSocial = O.IdObraSocial"
        //        + " INNER JOIN TipoPersona AS I"
        //        + " ON P.IdTipoPersona = I.IdTipoPersona"
        //        + " WHERE T.Fecha BETWEEN '" + String.Format("{0:yyyy'-'MM'-'dd}", FechaDesde)
        //        + "' AND '" + String.Format("{0:yyyy'-'MM'-'dd}", FechaHasta) + "' AND U.IdUsuario = " + IdUsuario
        //        + " LIMIT " + Desde + ", " + Hasta +" ;";

        //    #endregion

        //    if (Sql.SelectReader(Consulta, null, "rTurnosDelDiaLimite"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            classPersona oP = new classPersona();
        //            DataRow Row = TablaAuxiliar.NewRow();

        //            Row[0] = oP.Edad(Convert.ToDateTime(Sql.Reader["Edad"]));
        //            Row[1] = Sql.Reader["Expediente"].ToString();
        //            Row[2] = Sql.Reader["Paciente"].ToString();
        //            Row[3] = Sql.Reader["Medico"].ToString();
        //            Row[4] = String.Format("{0:m}", Convert.ToDateTime(Sql.Reader["Turno"]));
        //            Row[5] = String.Format("{0:T}", Convert.ToDateTime(Sql.Reader["Turno"]));
        //            Row[6] = Sql.Reader["Estado"].ToString();
        //            Row[7] = Sql.Reader["ObraSocial"].ToString();
        //            Row[8] = Sql.Reader["Tipo"].ToString();

        //            TablaAuxiliar.Rows.Add(Row);
        //        }
        //        Sql.Reader.Close();
        //        Sql.Close();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Close();
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// Carga un objeto adapter de tipo HistoriaClinica
        ///// OK 21/06/12
        ///// </summary>
        ///// <returns></returns>
        //public bool rHistoriaClinica(string nameDataTable, int IdPersona)
        //{
        //    #region Tabla

        //    DataTable TablaAuxiliar = new DataTable(nameDataTable);
        //    TablaAuxiliar.Columns.Add(new DataColumn("Paciente", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Edad", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Sexo", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Telefono", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("ObraSocial", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Diagnostico", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Fecha", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Domicilio", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Tipo", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Medico", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("nAfiliado", typeof(string)));

        //    #endregion

        //    #region Consulta

        //    string Consulta = "SELECT (P.Apellido||', '||P.Nombre) [Paciente], P.FechaNacimiento[Edad], P.Sexo," +
        //        "P.Telefono, O.Nombre[ObraSocial], D.Diagnostico, D.Fecha, U.Nombre[Medico]," +
        //        "(C.Nombre||', '||B.Nombre)[Domicilio], T.Nombre[Tipo], P.nAfiliado " +
        //        "FROM Persona AS P INNER JOIN ObraSocial AS O " +
        //        "ON O.IdObraSocial = P.IdObraSocial " +
        //        "INNER JOIN Diagnostico AS D " +
        //        "ON P.IdPersona = D.IdPersona " +
        //        "INNER JOIN Ciudad AS C " +
        //        "ON P.IdCiudad = C.IdCiudad " +
        //        "INNER JOIN Barrio AS B " +
        //        "ON P.IdBarrio = B.iIdBarrio " +
        //        "INNER JOIN TipoPersona AS T " +
        //        "ON T.IdTipoPersona = P.IdTipoPersona " +
        //        "INNER JOIN Usuario AS U " +
        //        "ON U.IdUsuario =  P.IdUsuario " +
        //        "WHERE P.Visible = 1 AND   D.Visible = 1 " +
        //        "AND   P.IdPersona = '" + IdPersona.ToString() + "';";

        //    #endregion

        //    if (Sql.SelectReader(Consulta, null, "rHistoriaClinica"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            classPersona oP = new classPersona();
        //            DataRow Row = TablaAuxiliar.NewRow();

        //            Row[0] = Sql.Reader["Paciente"].ToString();
        //            Row[1] = oP.Edad(Convert.ToDateTime(Sql.Reader["Edad"]));
        //            Row[2] = oP.toSexo(Convert.ToInt32(Sql.Reader["Sexo"]));
        //            Row[3] = Sql.Reader["Telefono"].ToString();
        //            Row[4] = Sql.Reader["ObraSocial"].ToString();
        //            Row[5] = Sql.Reader["Diagnostico"].ToString();
        //            Row[6] = String.Format("{0:d}", Convert.ToDateTime(Sql.Reader["Fecha"]));
        //            Row[7] = Sql.Reader["Domicilio"].ToString();
        //            Row[8] = Sql.Reader["Tipo"].ToString();
        //            Row[9] = Sql.Reader["Medico"].ToString();
        //            Row[10] = Sql.Reader["nAfiliado"].ToString();

        //            TablaAuxiliar.Rows.Add(Row);
        //        }
        //        Sql.Reader.Close();
        //        Sql.Close();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Close();
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// Carga un objeto adapter con lista de pacientes
        ///// OK 21/06/12
        ///// </summary>
        ///// <returns></returns>
        //public bool rListaPacientes(string nameDataTable, classPersona oP)
        //{
        //    #region Tabla

        //    DataTable TablaAuxiliar = new DataTable(nameDataTable);
        //    TablaAuxiliar.Columns.Add(new DataColumn("Edad", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("nPaciente", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Telefono", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("TipoPaciente", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Expediente", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("ObraSocial", typeof(string)));

        //    #endregion

        //    #region Consulta

        //    string Consulta = "SELECT P.FechaNacimiento [Edad], (P.Apellido||', '||P.Nombre) [nPaciente]," +
        //            " T.Nombre[TipoPaciente],P.nAfiliado[Expediente], S.Nombre[ObraSocial], P.Telefono" +
        //            " FROM Persona AS P INNER JOIN ObraSocial AS S" +
        //            " ON P.IdObraSocial = S.IdObraSocial" +
        //            " INNER JOIN TipoPersona AS T" +
        //            " ON P.IdTipoPersona = T.IdTipoPersona";

        //    if (oP.nAfiliado != "" && oP.Apellido != "")
        //    {   // OK 12/06/12
        //        Consulta = Consulta +
        //            " WHERE P.Apellido LIKE '" + oP.Apellido +
        //            "%' AND P.nAfiliado LIKE '" + oP.nAfiliado + "%' ";
        //    }
        //    else if (oP.Apellido != "")
        //    {   // OK 12/06/12
        //        Consulta = Consulta +
        //            " WHERE P.Apellido LIKE '" + oP.Apellido + "%' ";
        //    }
        //    else if (oP.nAfiliado != "")
        //    {   // OK 12/06/12
        //        Consulta = Consulta +
        //            " WHERE P.nAfiliado LIKE '" + oP.nAfiliado + "%' ";
        //    }
        //    else { }


        //    if (oP.ObraSocial != 1)
        //    {   // OK 12/06/12
        //        Consulta = Consulta +
        //            " AND P.IdObraSocial = " + oP.ObraSocial.ToString();
        //    }

        //    #endregion

        //    if (Sql.SelectReader(Consulta, null, "rListaPacientes"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            DataRow Row = TablaAuxiliar.NewRow();

        //            Row[0] = oP.Edad(Convert.ToDateTime(Sql.Reader["Edad"]));
        //            Row[1] = Sql.Reader["nPaciente"].ToString();
        //            Row[2] = Sql.Reader["Telefono"].ToString();
        //            Row[3] = Sql.Reader["TipoPaciente"].ToString();
        //            Row[4] = Sql.Reader["Expediente"].ToString();
        //            Row[5] = Sql.Reader["ObraSocial"].ToString();

        //            TablaAuxiliar.Rows.Add(Row);
        //        }
        //        Sql.Reader.Close();
        //        Sql.Close();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Close();
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// Carga un objeto adapter con lista de pacientes
        ///// OK 21/06/12
        ///// </summary>
        ///// <returns></returns>
        //public bool rListaPacientesLimite(string nameDataTable, classPersona oP, int Desde, int Hasta)
        //{
        //    #region Tabla

        //    DataTable TablaAuxiliar = new DataTable(nameDataTable);
        //    TablaAuxiliar.Columns.Add(new DataColumn("Edad", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("nPaciente", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Telefono", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("TipoPaciente", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Expediente", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("ObraSocial", typeof(string)));

        //    #endregion

        //    #region Consulta

        //    string Consulta = "SELECT P.FechaNacimiento [Edad], (P.Apellido||', '||P.Nombre) [nPaciente]," +
        //            " T.Nombre[TipoPaciente],P.nAfiliado[Expediente], S.Nombre[ObraSocial], P.Telefono" +
        //            " FROM Persona AS P INNER JOIN ObraSocial AS S" +
        //            " ON P.IdObraSocial = S.IdObraSocial" +
        //            " INNER JOIN TipoPersona AS T" +
        //            " ON P.IdTipoPersona = T.IdTipoPersona";

        //    if (oP.nAfiliado != "" && oP.Apellido != "")
        //    {   // OK 12/06/12
        //        Consulta = Consulta +
        //            " WHERE P.Apellido LIKE '" + oP.Apellido +
        //            "%' AND P.nAfiliado LIKE '" + oP.nAfiliado + "%' ";
        //    }
        //    else if (oP.Apellido != "")
        //    {   // OK 12/06/12
        //        Consulta = Consulta +
        //            " WHERE P.Apellido LIKE '" + oP.Apellido + "%' ";
        //    }
        //    else if (oP.nAfiliado != "")
        //    {   // OK 12/06/12
        //        Consulta = Consulta +
        //            " WHERE P.nAfiliado LIKE '" + oP.nAfiliado + "%' ";
        //    }
        //    else { }


        //    if (oP.ObraSocial != 1)
        //    {   // OK 12/06/12
        //        Consulta = Consulta +
        //            " AND P.IdObraSocial = " + oP.ObraSocial.ToString();
        //    }

        //    Consulta += " LIMIT " + Desde + ", " + Hasta +" ;";

        //    #endregion

        //    if (Sql.SelectReader(Consulta, null, "rListaPacientes"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            DataRow Row = TablaAuxiliar.NewRow();

        //            Row[0] = oP.Edad(Convert.ToDateTime(Sql.Reader["Edad"]));
        //            Row[1] = Sql.Reader["nPaciente"].ToString();
        //            Row[2] = Sql.Reader["Telefono"].ToString();
        //            Row[3] = Sql.Reader["TipoPaciente"].ToString();
        //            Row[4] = Sql.Reader["Expediente"].ToString();
        //            Row[5] = Sql.Reader["ObraSocial"].ToString();

        //            TablaAuxiliar.Rows.Add(Row);
        //        }
        //        Sql.Reader.Close();
        //        Sql.Close();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Close();
        //        return false;
        //    }
        //}

        #endregion

        #endregion
    }
}

/*
 * Formatos DateTime
 * http://www.csharp-examples.net/string-format-datetime/
 * 
 * 
 * 
 */
