using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.IO;
using Entidades;
using Entidades.Clases;
using Entidades.ParametersReaders;
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

        // OK - 18/02/07
        #region ABM

        // OK - 17/10/31
        public object AbmDiagnostic(classDiagnostic oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmDiagnostic;
            prDiagnostic pr = new prDiagnostic();
            List<SqlParameter> lParam = pr.CreateParameter(oP, (int)Abm);

            switch (Abm)
            {
                case eAbm.SelectAll:
                    List<classDiagnostic> lDiagnostic = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        lDiagnostic = new List<classDiagnostic>();
                        while (oSql.Reader.Read())
                        {
                            try
                            {
                                lDiagnostic.Add(pr.ReadReader(oSql.Reader));
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
                case eAbm.Select:
                    classDiagnostic oDiagnosti = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        if (oSql.Reader.Read())
                        {
                            try
                            {
                                oDiagnosti = pr.ReadReader(oSql.Reader);
                            }
                            catch (FormatException ex)
                            {
                                Menssage = ex.ToString();
                                oDiagnosti = null;
                            }
                            catch (InvalidCastException ex)
                            {
                                Menssage = ex.ToString();
                                oDiagnosti = null;
                            }
                            catch (OverflowException ex)
                            {
                                Menssage = ex.ToString();
                                oDiagnosti = null;
                            }
                        }
                    }
                    else
                        Menssage = oSql.Mensage;
                    oSql.Close();
                    Result = oDiagnosti;
                    break;
                case eAbm.Insert:
                case eAbm.Update:
                case eAbm.Delete:
                    int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                    if (UltimoId == 0)
                        Menssage = oSql.Mensage;

                    Result = UltimoId;
                    break;
                case eAbm.LoadCmb:
                    Result = oSql.ExecCombo(SPname, lParam.ToArray());
                    if (oSql.Table.Rows.Count != 0)
                        Table = oSql.Table;
                    else
                        Table = null;
                    break;
                default:
                    break;
            }
            return Result;
        }

        // OK - 18/02/07
        public object AbmIvaType(classIvaType oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmIvaType;
            prIvaType pr = new prIvaType();
            List<SqlParameter> lParam = pr.CreateParameter(oP, (int)Abm);

            switch (Abm)
            {
                case eAbm.SelectAll:
                    List<classIvaType> lIvaType = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        lIvaType = new List<classIvaType>();
                        while (oSql.Reader.Read())
                        {
                            try
                            {
                                lIvaType.Add(pr.ReadReader(oSql.Reader));
                            }
                            catch (FormatException ex)
                            {
                                Menssage = ex.ToString();
                                lIvaType = null;
                            }
                            catch (InvalidCastException ex)
                            {
                                Menssage = ex.ToString();
                                lIvaType = null;
                            }
                            catch (OverflowException ex)
                            {
                                Menssage = ex.ToString();
                                lIvaType = null;
                            }
                        }
                    }
                    else
                        Menssage = oSql.Mensage;

                    oSql.Close();
                    Result = lIvaType;
                    break;
                case eAbm.Select:
                    classIvaType oIvaTyp = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        if (oSql.Reader.Read())
                        {
                            try
                            {
                                oIvaTyp = pr.ReadReader(oSql.Reader);
                            }
                            catch (FormatException ex)
                            {
                                Menssage = ex.ToString();
                                oIvaTyp = null;
                            }
                            catch (InvalidCastException ex)
                            {
                                Menssage = ex.ToString();
                                oIvaTyp = null;
                            }
                            catch (OverflowException ex)
                            {
                                Menssage = ex.ToString();
                                oIvaTyp = null;
                            }
                        }
                    }
                    else
                        Menssage = oSql.Mensage;

                    oSql.Close();
                    Result = oIvaTyp;
                    break;
                case eAbm.Insert:
                case eAbm.Update:
                case eAbm.Delete:
                    int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                    if (UltimoId == 0)
                        Menssage = oSql.Mensage;

                    Result = UltimoId;
                    break;
                case eAbm.LoadCmb:
                    Result = oSql.ExecCombo(SPname, lParam.ToArray());
                    if (oSql.Table.Rows.Count != 0)
                        Table = oSql.Table;
                    else
                        Table = null;
                    break;
                default:
                    break;
            }
            return Result;
        }

        // OK - 17/11/14
        public object AbmParent(classParent oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmParent;
            prParent pr = new prParent();
            List<SqlParameter> lParam = pr.CreateParameter(oP, (int)Abm);

            switch (Abm)
            {
                case eAbm.SelectAll:
                    List<classParent> lParent = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        lParent = new List<classParent>();
                        while (oSql.Reader.Read())
                        {
                            try
                            {
                                lParent.Add(pr.ReadReader(oSql.Reader));
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
                case eAbm.Select:
                    classParent oParen = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        if (oSql.Reader.Read())
                        {
                            try
                            {
                                oParen = pr.ReadReader(oSql.Reader);
                            }
                            catch (FormatException ex)
                            {
                                Menssage = ex.ToString();
                                oParen = null;
                            }
                            catch (InvalidCastException ex)
                            {
                                Menssage = ex.ToString();
                                oParen = null;
                            }
                            catch (OverflowException ex)
                            {
                                Menssage = ex.ToString();
                                oParen = null;
                            }
                        }
                    }
                    else
                        Menssage = oSql.Mensage;
                    oSql.Close();
                    Result = oParen;
                    break;
                case eAbm.Insert:
                case eAbm.Update:
                case eAbm.Delete:
                    int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                    if (UltimoId == 0)
                        Menssage = oSql.Mensage;

                    Result = UltimoId;
                    break;
                case eAbm.LoadCmb:
                    Result = oSql.ExecCombo(SPname, lParam.ToArray());
                    if (oSql.Table.Rows.Count != 0)
                        Table = oSql.Table;
                    else
                        Table = null;
                    break;
                default:
                    break;
            }
            return Result;
        }

        // OK - 17/11/14
        public object AbmPatient(classPatient oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmPatient;
            prPatient pr = new prPatient();
            List<SqlParameter> lParam = pr.CreateParameter(oP, (int)Abm);

            switch (Abm)
            {
                case eAbm.SelectAll:
                    List<classPatient> lPatient = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        lPatient = new List<classPatient>();
                        while (oSql.Reader.Read())
                        {
                            try
                            {
                                lPatient.Add(pr.ReadReader(oSql.Reader));
                            }
                            catch (FormatException ex)
                            {
                                Menssage = ex.ToString();
                                lPatient = null;
                            }
                            catch (InvalidCastException ex)
                            {
                                Menssage = ex.ToString();
                                lPatient = null;
                            }
                            catch (OverflowException ex)
                            {
                                Menssage = ex.ToString();
                                lPatient = null;
                            }
                        }
                    }
                    else
                        Menssage = oSql.Mensage;

                    oSql.Close();
                    Result = lPatient;
                    break;
                case eAbm.Select:
                    classPatient oPatien = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        if (oSql.Reader.Read())
                        {
                            try
                            {
                                oPatien = pr.ReadReader(oSql.Reader);
                            }
                            catch (FormatException ex)
                            {
                                Menssage = ex.ToString();
                                oPatien = null;
                            }
                            catch (InvalidCastException ex)
                            {
                                Menssage = ex.ToString();
                                oPatien = null;
                            }
                            catch (OverflowException ex)
                            {
                                Menssage = ex.ToString();
                                oPatien = null;
                            }
                        }
                    }
                    else
                        Menssage = oSql.Mensage;

                    oSql.Close();
                    Result = oPatien;
                    break;
                case eAbm.Insert:
                case eAbm.Update:
                case eAbm.Delete:
                    int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                    if (UltimoId == 0)
                        Menssage = oSql.Mensage;

                    Result = UltimoId;
                    break;
                case eAbm.LoadCmb:
                    Result = oSql.ExecCombo(SPname, lParam.ToArray());
                    if (oSql.Table.Rows.Count != 0)
                        Table = oSql.Table;
                    else
                        Table = null;
                    break;
                default:
                    break;
            }
            return Result;
        }

        // OK - 17/11/14
        public object AbmPatientParent(classPatientParent oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmPatientParent;
            prPatientParent pr = new prPatientParent();
            List<SqlParameter> lParam = pr.CreateParameter(oP, (int)Abm);

            switch (Abm)
            {
                case eAbm.SelectAll:
                    List<classPatientParent> lPatientParent = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        lPatientParent = new List<classPatientParent>();
                        while (oSql.Reader.Read())
                        {
                            try
                            {
                                lPatientParent.Add(pr.ReadReader(oSql.Reader));
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
                case eAbm.Select:
                    classPatientParent oPatientParen = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        if (oSql.Reader.Read())
                        {
                            try
                            {
                                oPatientParen =  pr.ReadReader(oSql.Reader);
                            }
                            catch (FormatException ex)
                            {
                                Menssage = ex.ToString();
                                oPatientParen = null;
                            }
                            catch (InvalidCastException ex)
                            {
                                Menssage = ex.ToString();
                                oPatientParen = null;
                            }
                            catch (OverflowException ex)
                            {
                                Menssage = ex.ToString();
                                oPatientParen = null;
                            }
                        }
                    }
                    else
                        Menssage = oSql.Mensage;

                    oSql.Close();
                    Result = oPatientParen;
                    break;
                case eAbm.Insert:
                case eAbm.Update:
                case eAbm.Delete:
                    int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                    if (UltimoId == 0)
                        Menssage = oSql.Mensage;

                    Result = UltimoId;
                    break;
                case eAbm.LoadCmb:
                    Result = oSql.ExecCombo(SPname, lParam.ToArray());
                    if (oSql.Table.Rows.Count != 0)
                        Table = oSql.Table;
                    else
                        Table = null;
                    break;
                default: 
                    break;
            }
            return Result;
        }

        // OK - 18/02/07
        public object AbmPatientSocialWork(classPatientSocialWork oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmPatientSocialWork;
            prPatientSocialWork pr = new prPatientSocialWork();
            List<SqlParameter> lParam = pr.CreateParameter(oP, (int)Abm);

            switch (Abm)
            {
                case eAbm.SelectAll:
                    List<classPatientSocialWork> lPatientSocialWork = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        lPatientSocialWork = new List<classPatientSocialWork>();
                        while (oSql.Reader.Read())
                        {
                            try
                            {
                                lPatientSocialWork.Add(pr.ReadReader(oSql.Reader));
                            }
                            catch (FormatException ex)
                            {
                                Menssage = ex.ToString();
                                lPatientSocialWork = null;
                            }
                            catch (InvalidCastException ex)
                            {
                                Menssage = ex.ToString();
                                lPatientSocialWork = null;
                            }
                            catch (OverflowException ex)
                            {
                                Menssage = ex.ToString();
                                lPatientSocialWork = null;
                            }
                        }
                    }
                    else
                        Menssage = oSql.Mensage;

                    oSql.Close();
                    Result = lPatientSocialWork;
                    break;
                case eAbm.Select:
                    classPatientSocialWork oPatientSocialWork = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        if (oSql.Reader.Read())
                        {
                            try
                            {
                                oPatientSocialWork = pr.ReadReader(oSql.Reader);
                            }
                            catch (FormatException ex)
                            {
                                Menssage = ex.ToString();
                                oPatientSocialWork = null;
                            }
                            catch (InvalidCastException ex)
                            {
                                Menssage = ex.ToString();
                                oPatientSocialWork = null;
                            }
                            catch (OverflowException ex)
                            {
                                Menssage = ex.ToString();
                                oPatientSocialWork = null;
                            }
                        }
                    }
                    else
                        Menssage = oSql.Mensage;

                    oSql.Close();
                    Result = oPatientSocialWork;
                    break;
                case eAbm.Insert:
                case eAbm.Update:
                case eAbm.Delete:
                    int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                    if (UltimoId == 0)
                        Menssage = oSql.Mensage;

                    Result = UltimoId;
                    break;
                case eAbm.LoadCmb:
                    Result = oSql.ExecCombo(SPname, lParam.ToArray());
                    if (oSql.Table.Rows.Count != 0)
                        Table = oSql.Table;
                    else
                        Table = null;
                    break;
                default:
                    break;
            }
            return Result;
        }

        // OK - 17/11/14
        public object AbmPermission(classPermission oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmPermission;
            prPermission pr = new prPermission();
            List<SqlParameter> lParam = pr.CreateParameter(oP, (int)Abm);

            switch (Abm)
            {
                case eAbm.SelectAll:
                    List<classPermission> lPermission = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        lPermission = new List<classPermission>();
                        while (oSql.Reader.Read())
                        {
                            try
                            {
                                lPermission.Add(pr.ReadReader(oSql.Reader));
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
                case eAbm.Select:
                    classPermission oPermissio = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        if (oSql.Reader.Read())
                        {
                            try
                            {
                                oPermissio = pr.ReadReader(oSql.Reader);
                            }
                            catch (FormatException ex)
                            {
                                Menssage = ex.ToString();
                                oPermissio = null;
                            }
                            catch (InvalidCastException ex)
                            {
                                Menssage = ex.ToString();
                                oPermissio = null;
                            }
                            catch (OverflowException ex)
                            {
                                Menssage = ex.ToString();
                                oPermissio = null;
                            }
                        }
                    }
                    else
                        Menssage = oSql.Mensage;

                    oSql.Close();
                    Result = oPermissio;
                    break;
                case eAbm.Insert:
                case eAbm.Update:
                case eAbm.Delete:
                    int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                    if (UltimoId == 0)
                        Menssage = oSql.Mensage;

                    Result = UltimoId;
                    break;
                case eAbm.LoadCmb:
                    Result = oSql.ExecCombo(SPname, lParam.ToArray());
                    if (oSql.Table.Rows.Count != 0)
                        Table = oSql.Table;
                    else
                        Table = null;
                    Result = true;
                    break;
                default:
                    break;
            }
            return Result;
        }

        // OK - 17/10/21
        public object AbmProfessional(classProfessional oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmProfessional;
            prProfessional pr = new prProfessional();
            List<SqlParameter> lParam = pr.CreateParameter(oP, (int)Abm);

            switch (Abm)
            {
                case eAbm.SelectAll:
                    List<classProfessional> lProfessional = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        lProfessional = new List<classProfessional>();
                        while (oSql.Reader.Read())
                        {
                            try
                            {
                                lProfessional.Add(pr.ReadReader(oSql.Reader));
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
                case eAbm.Select:
                    classProfessional oProfessiona = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        if (oSql.Reader.Read())
                        {
                            try
                            {
                                oProfessiona = pr.ReadReader(oSql.Reader);
                            }
                            catch (FormatException ex)
                            {
                                Menssage = ex.ToString();
                                oProfessiona = null;
                            }
                            catch (InvalidCastException ex)
                            {
                                Menssage = ex.ToString();
                                oProfessiona = null;
                            }
                            catch (OverflowException ex)
                            {
                                Menssage = ex.ToString();
                                oProfessiona = null;
                            }
                        }
                    }
                    else
                        Menssage = oSql.Mensage;

                    oSql.Close();
                    Result = oProfessiona;
                    break;
                case eAbm.Insert:
                case eAbm.Update:
                case eAbm.Delete:
                    int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                    if (UltimoId == 0)
                        Menssage = oSql.Mensage;

                    Result = UltimoId;
                    break;
                case eAbm.LoadCmb:
                    Result = oSql.ExecCombo(SPname, lParam.ToArray());
                    if (oSql.Table.Rows.Count != 0)
                        Table = oSql.Table;
                    else
                        Table = null;
                    break;
                default:
                    break;
            }
            return Result;
        }

        // OK - 18/02/07
        public object AbmProfessionalSpeciality(classProfessionalSpeciality oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmProfessionalSpeciality;
            prProfessionalSpeciality pr = new prProfessionalSpeciality();
            List<SqlParameter> lParam = pr.CreateParameter(oP, (int)Abm);

            switch (Abm)
            {
                case eAbm.SelectAll:
                    List<classProfessionalSpeciality> lProfessionalSpeciality = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        lProfessionalSpeciality = new List<classProfessionalSpeciality>();
                        while (oSql.Reader.Read())
                        {
                            try
                            {
                                lProfessionalSpeciality.Add(pr.ReadReader(oSql.Reader));
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
                case eAbm.Select:
                    classProfessionalSpeciality oProfessionalSpecialit = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        if (oSql.Reader.Read())
                        {
                            try
                            {
                                oProfessionalSpecialit = pr.ReadReader(oSql.Reader);
                            }
                            catch (FormatException ex)
                            {
                                Menssage = ex.ToString();
                                oProfessionalSpecialit = null;
                            }
                            catch (InvalidCastException ex)
                            {
                                Menssage = ex.ToString();
                                oProfessionalSpecialit = null;
                            }
                            catch (OverflowException ex)
                            {
                                Menssage = ex.ToString();
                                oProfessionalSpecialit = null;
                            }
                        }
                    }
                    else
                        Menssage = oSql.Mensage;

                    oSql.Close();
                    Result = oProfessionalSpecialit;
                    break;
                case eAbm.Insert:
                case eAbm.Update:
                case eAbm.Delete:
                    int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                    if (UltimoId == 0)
                        Menssage = oSql.Mensage;

                    Result = UltimoId;
                    break;
                case eAbm.LoadCmb:
                    Result = oSql.ExecCombo(SPname, lParam.ToArray());
                    if (oSql.Table.Rows.Count != 0)
                        Table = oSql.Table;
                    else
                        Table = null;
                    break;
                default:
                    break;
            }
            return Result;
        }
        
        // OK - 18/02/07
        public object AbmRelationship(classRelationship oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmRelationship;
            prRelationship pr = new prRelationship();
            List<SqlParameter> lParam = pr.CreateParameter(oP, (int)Abm);

            switch (Abm)
            {
                case eAbm.SelectAll:
                    List<classRelationship> lRelationship = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        lRelationship = new List<classRelationship>();
                        while (oSql.Reader.Read())
                        {
                            try
                            {
                                lRelationship.Add(pr.ReadReader(oSql.Reader));
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
                case eAbm.Select:
                    classRelationship oRelationshi = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        if (oSql.Reader.Read())
                        {
                            try
                            {
                                oRelationshi = pr.ReadReader(oSql.Reader);

                            }
                            catch (FormatException ex)
                            {
                                Menssage = ex.ToString();
                                oRelationshi = null;
                            }
                            catch (InvalidCastException ex)
                            {
                                Menssage = ex.ToString();
                                oRelationshi = null;
                            }
                            catch (OverflowException ex)
                            {
                                Menssage = ex.ToString();
                                oRelationshi = null;
                            }
                        }
                    }
                    else
                        Menssage = oSql.Mensage;

                    oSql.Close();
                    Result = oRelationshi;
                    break;
                case eAbm.Insert:
                case eAbm.Update:
                case eAbm.Delete:
                    int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                    if (UltimoId == 0)
                        Menssage = oSql.Mensage;

                    Result = UltimoId;
                    break;
                case eAbm.LoadCmb:
                    Result = oSql.ExecCombo(SPname, lParam.ToArray());
                    if (oSql.Table.Rows.Count != 0)
                        Table = oSql.Table;
                    else
                        Table = null;
                    break;
                default:
                    break;
            }
            return Result;
        }

        // OK - 17/10/21
        public object AbmSocialWork(classSocialWork oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmSocialWork;
            prSocialWorks pr = new prSocialWorks();
            List<SqlParameter> lParam = pr.CreateParameter(oP, (int)Abm);

            switch (Abm)
            {
                case eAbm.SelectAll:
                    List<classSocialWork> lSocialWork = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        lSocialWork = new List<classSocialWork>();
                        while (oSql.Reader.Read())
                        {
                            try
                            {
                                lSocialWork.Add(pr.ReadReader(oSql.Reader));
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
                case eAbm.Select:
                    classSocialWork oSocialWork = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        if (oSql.Reader.Read())
                        {
                            try
                            {
                                oSocialWork = pr.ReadReader(oSql.Reader);
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
                case eAbm.Insert:
                case eAbm.Update:
                case eAbm.Delete:
                    int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                    if (UltimoId == 0)
                        Menssage = oSql.Mensage;

                    Result = UltimoId;
                    break;
                case eAbm.LoadCmb:
                    Result = oSql.ExecCombo(SPname, lParam.ToArray());
                    if (oSql.Table.Rows.Count != 0)
                        Table = oSql.Table;
                    else
                        Table = null;
                    break;
                default:
                    break;
            }
            return Result;
        }

        // OK - 18/02/07
        public object AbmSpeciality(classSpecialty oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmSpeciality;
            prSpecialty pr = new prSpecialty();
            List<SqlParameter> lParam = pr.CreateParameter(oP, (int)Abm);

            switch (Abm)
            {
                case eAbm.SelectAll:
                    List<classSpecialty> lSpecialty = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        lSpecialty = new List<classSpecialty>();
                        while (oSql.Reader.Read())
                        {
                            try
                            {
                                lSpecialty.Add(pr.ReadReader(oSql.Reader));
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
                case eAbm.Select:
                    classSpecialty oSpecialt = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        if (oSql.Reader.Read())
                        {
                            try
                            {
                                oSpecialt = pr.ReadReader(oSql.Reader);
                            }
                            catch (FormatException ex)
                            {
                                Menssage = ex.ToString();
                                oSpecialt = null;
                            }
                            catch (InvalidCastException ex)
                            {
                                Menssage = ex.ToString();
                                oSpecialt = null;
                            }
                            catch (OverflowException ex)
                            {
                                Menssage = ex.ToString();
                                oSpecialt = null;
                            }
                        }
                    }
                    else
                        Menssage = oSql.Mensage;

                    oSql.Close();
                    Result = oSpecialt;
                    break;
                case eAbm.Insert:
                case eAbm.Update:
                case eAbm.Delete:
                    int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                    if (UltimoId == 0)
                        Menssage = oSql.Mensage;

                    Result = UltimoId;
                    break;
                case eAbm.LoadCmb:
                    Result = oSql.ExecCombo(SPname, lParam.ToArray());
                    if (oSql.Table.Rows.Count != 0)
                        Table = oSql.Table;
                    else
                        Table = null;
                    break;
                default:
                    break;
            }
            return Result;
        }

        // OK - 18/02/07
        public object AbmTypeDocument(classTypeDocument oP, eAbm Abm)
        {
            object Result = null;
            string SPname = sp.AbmTypeDocument;
            prTypeDocument pr = new prTypeDocument();
            List<SqlParameter> lParam = pr.CreateParameter(oP, (int)Abm);

            switch (Abm)
            {
                case eAbm.SelectAll:
                    List<classTypeDocument> lTypeDocument = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        lTypeDocument = new List<classTypeDocument>();
                        while (oSql.Reader.Read())
                        {
                            try
                            {
                                lTypeDocument.Add(pr.ReadReader(oSql.Reader));
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
                case eAbm.Select:
                    classTypeDocument oTypeDocumen = null;
                    if (oSql.SelectRaeder(SPname, lParam.ToArray()))
                    {
                        if (oSql.Reader.Read())
                        {
                            try
                            {
                                oTypeDocumen = pr.ReadReader(oSql.Reader);
                            }
                            catch (FormatException ex)
                            {
                                Menssage = ex.ToString();
                                oTypeDocumen = null;
                            }
                            catch (InvalidCastException ex)
                            {
                                Menssage = ex.ToString();
                                oTypeDocumen = null;
                            }
                            catch (OverflowException ex)
                            {
                                Menssage = ex.ToString();
                                oTypeDocumen = null;
                            }
                        }
                    }
                    else
                        Menssage = oSql.Mensage;

                    oSql.Close();
                    Result = oTypeDocumen;
                    break;
                case eAbm.Insert:
                case eAbm.Update:
                case eAbm.Delete:
                    int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

                    if (UltimoId == 0)
                        Menssage = oSql.Mensage;

                    Result = UltimoId;
                    break;
                case eAbm.LoadCmb:
                    Result = oSql.ExecCombo(SPname, lParam.ToArray());
                    if (oSql.Table.Rows.Count != 0)
                        Table = oSql.Table;
                    else
                        Table = null;
                    break;
                default:
                    break;
            }
            return Result;
        }

        #endregion

        // OK - 18/02/08
        # region Filtros

        /// <summary>
        /// Filtra por coincidencia.
        /// OK - 17/11/20
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Bloqueado"></param>
        /// <param name="Pag">Id Actual</param>
        /// <param name="RowsShow">Cantidad de filas a mostrar</param>
        /// <returns></returns>
        public bool FilterLimitProfession(string Name, string LastName, int Pag, int RowsShow)
        {
            string SPname = sp.FiltroProfesionalesLimite;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Name", Name));
            lParam.Add(new SqlParameter("@LastName", LastName));
            lParam.Add(new SqlParameter("@Pag", Pag));
            lParam.Add(new SqlParameter("@RowsShow", RowsShow));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                Table = new DataTable();
                oSql.Adapter.Fill(Table);
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
        /// OK - 17/11/20
        /// </summary>
        /// <param name="Nombre">Propiedades del filtro</param>
        /// <param name="Pag">Id Actual</param>
        /// <param name="RowsShow">Cantidad de filas a mostrar</param>
        /// <returns></returns>
        public bool FilterLimitSocialWork(string Name, int Pag, int RowsShow)
        {
            string SPname = sp.FilterSocialWorkLimite;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Name", Name));
            lParam.Add(new SqlParameter("@Pag", Pag));
            lParam.Add(new SqlParameter("@RowsShow", RowsShow));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                Table = new DataTable();
                oSql.Adapter.Fill(Table);
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
        /// OK - 18/02/08
        /// </summary>
        /// <param name="oPersona"></param>
        /// <param name="Pag">Id Actual</param>
        /// <param name="RowsShow">Cantidad de filas a mostrar</param>
        /// <returns></returns>
        public bool FilterLimitPatient(string Name, string LastName, int NumberDocument, int Pag, int RowsShow)
        {
            string SPname = sp.FiltroPatientLimite;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Name", Name));
            lParam.Add(new SqlParameter("@LastName", LastName));
            lParam.Add(new SqlParameter("@NumberDocument", NumberDocument));
            lParam.Add(new SqlParameter("@Pag", Pag));
            lParam.Add(new SqlParameter("@RowsShow", RowsShow));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                Table = new DataTable();
                oSql.Adapter.Fill(Table);
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
        /// OK - 17/11/20
        /// </summary>
        /// <param name="Read"></param>
        /// <param name="IdProfessional"></param>
        /// <param name="IdSpeciality"></param>
        /// <param name="Visible"></param>
        /// <param name="Pag">Id Actual</param>
        /// <param name="RowsShow">Cantidad de filas a mostrar</param>
        /// <returns></returns>
        public bool FilterLimitMessage(int Read, int IdProfessional, int IdSpeciality, int Visible, int Pag, int RowsShow)
        {
            string SPname = sp.FiltroMessageLimite;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@DestinationRead", Read));
            lParam.Add(new SqlParameter("@IdProfessional", IdProfessional));
            lParam.Add(new SqlParameter("@IdSpeciality", IdSpeciality));
            lParam.Add(new SqlParameter("@Visible", Visible));
            lParam.Add(new SqlParameter("@Pag", Pag));
            lParam.Add(new SqlParameter("@RowsShow", RowsShow));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                Table = new DataTable();
                oSql.Adapter.Fill(Table);
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

        // OK - 18/02/08
        #region Contadores Filtros

        /// <summary>
        /// Filtra por coincidencia.
        /// OK - 17/11/20
        /// </summary>
        /// <param name="Name">Propiedades del filtro</param>
        /// <param name="LastName">Propiedades del filtro</param>
        /// <returns></returns>
        public int FilterLimitCountProfession(string Name, string LastName)
        {
            string SPname = sp.CountProfesionalesLimite;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Name", Name));
            lParam.Add(new SqlParameter("@LastName", LastName));

            int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

            if (UltimoId == 0)
                Menssage = oSql.Mensage;

            return UltimoId;
        }

        /// <summary>
        /// Filtra por coincidencia.
        /// OK - 17/11/20
        /// </summary>
        /// <param name="Name">Propiedades del filtro</param>
        /// <returns></returns>
        public int FilterLimitCountSocialWork(string Name)
        {
            string SPname = sp.CountSocialWorkLimite;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Name", Name));

            int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

            if (UltimoId == 0)
                Menssage = oSql.Mensage;

            return UltimoId;
        }

        /// <summary>
        /// Filtra por coincidencia.
        /// OK - 18/02/08
        /// </summary>
        /// <param name="Name">Propiedades del filtro</param>
        /// <param name="LastName"></param>
        /// <param name="AffiliateNumber">Propiedades del filtro</param>
        /// <param name="IdSocialWork">Propiedades del filtro</param>
        /// <returns></returns>
        public int FilterLimitCountPatient(string Name, string LastName, int NumberDocument)
        {
            string SPname = sp.CountPatientLimite;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Name", Name));
            lParam.Add(new SqlParameter("@LastName", LastName));
            lParam.Add(new SqlParameter("@NumberDocument", NumberDocument));

            int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

            if (UltimoId == 0)
                Menssage = oSql.Mensage;

            return UltimoId;
        }

        /// <summary>
        /// Filtra por coincidencia.
        /// OK - 17/11/20
        /// </summary>
        /// <param name="Read"></param>
        /// <param name="IdProfessional">Propiedades del filtro</param>
        /// <param name="IdSpeciality">Propiedades del filtro</param>
        /// <param name="Visible">Propiedades del filtro</param>
        /// <returns></returns>
        public int FilterLimitCountMessage(int Read, int IdProfessional, int IdSpeciality, int Visible)
        {
            string SPname = sp.CountMessageLimite;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@DestinationRead", Read));
            lParam.Add(new SqlParameter("@IdProfessional", IdProfessional));
            lParam.Add(new SqlParameter("@IdSpeciality", IdSpeciality));
            lParam.Add(new SqlParameter("@Visible", Visible));

            int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

            if (UltimoId == 0)
                Menssage = oSql.Mensage;

            return UltimoId;
        }

        #endregion

        // OK - 18/02/08
        #region Reportes

        /// <summary>
        /// OK - 17/11/09
        /// diagnostico del paciente seleccionado.
        /// </summary>
        /// <param name="IdDiagnostic"></param>
        /// <returns>DataTable</returns>
        public bool RpDiagnostic(int IdDiagnostic)
        {
            string SPname = sp.RpClinicHistory;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Id", IdDiagnostic));
            lParam.Add(new SqlParameter("@Only", 1));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                Table = new DataTable("Diagnostic");
                oSql.Adapter.Fill(Table);
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
        /// OK - 17/11/09
        /// Historia Clinica del paciente seleccionado.
        /// </summary>
        /// <param name="IdPaciente"></param>
        /// <returns>DataTable</returns>
        public bool RpClinicHistory(int IdPatient)
        {
            string SPname = sp.RpClinicHistory;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Id", IdPatient));
            lParam.Add(new SqlParameter("@Only", 2));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                Table = new DataTable("Diagnostic");
                oSql.Adapter.Fill(Table);
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
        /// OK - 17/11/09
        /// Todos los datos del paciente seleccionado.
        /// </summary>
        /// <param name="IdPaciente"></param>
        /// <returns>DataTable</returns>
        public bool RpOnlyPatient(int IdPatient)
        {
            string SPname = sp.RpOnlyPatient;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@idPatient", IdPatient));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                Table = new DataTable("OnlyPatient");
                oSql.Adapter.Fill(Table);
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
        /// OK - 17/11/09
        /// Parientes del paciente seleccionado.
        /// </summary>
        /// <param name="IdPaciente"></param>
        /// <returns>DataTable</returns>
        public bool RpPatientParent(int IdPatient)
        {
            string SPname = sp.RpPatientParent;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@idPatient", IdPatient));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                Table = new DataTable("PatientParent");
                oSql.Adapter.Fill(Table);
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
        /// OK - 18/02/08
        /// Todos los paciente segun filtro.
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="N Afiliado"></param>
        /// <param name="IdObraSocial"></param>
        /// <returns>DataTable</returns>
        public bool rpListPatient(string Name, string LastName, int NumberDocument)
        {
            string SPname = sp.RpListPatient;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Name", Name));
            lParam.Add(new SqlParameter("@LastName", LastName));
            lParam.Add(new SqlParameter("@NumberDocument", NumberDocument));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                Table = new DataTable("ListPatient");
                oSql.Adapter.Fill(Table);
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
        /// OK - 17/11/09
        /// Todos los datos del Profesional seleccionado.
        /// </summary>
        /// <param name="IdProfessional"></param>
        /// <returns>DataTable</returns>
        public bool RpOnlyProfessional(int IdProfessional)
        {
            string SPname = sp.RpOnlyProfessional;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@idProfessional", IdProfessional));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                Table = new DataTable("OnlyProfessional");
                oSql.Adapter.Fill(Table);
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
        /// OK - 17/11/09
        /// Todos los Profesional segun filtro.
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <returns>DataTable</returns>
        public bool rpListProfessional(string Name, string LastName)
        {
            string SPname = sp.RpListProfessional;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Name", Name));
            lParam.Add(new SqlParameter("@LastName", LastName));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                Table = new DataTable("ListProfessional");
                oSql.Adapter.Fill(Table);
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
        /// OK - 17/11/09
        /// Todos los datos del Profesional seleccionado.
        /// </summary>
        /// <param name="IdProfessional"></param>
        /// <returns>DataTable</returns>
        public bool RpProfessionalSpeciality(int IdProfessional)
        {
            string SPname = sp.RpOnlyProfessionalSpeciality;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@idProfessional", IdProfessional));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                Table = new DataTable("ProfessionalSpeciality");
                oSql.Adapter.Fill(Table);
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
        /// OK - 18/02/08
        /// Obras Sociales del paciente seleccionado.
        /// </summary>
        /// <param name="IdPaciente"></param>
        /// <returns>DataTable</returns>
        public bool RpSocialWork(int IdPatient)
        {
            string SPname = sp.RpSocialWork;
            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Id", IdPatient));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                Table = new DataTable("SocialWork");
                oSql.Adapter.Fill(Table);
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

        // OK - 17/11/14
        #region Especiales

        // OK - 17/11/14
        public bool Contadores(int IdProfessional)
        {
            string SPname = sp.Contadores;

            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@IdProfessional", IdProfessional));

            if (oSql.SelectAdapterDB(SPname, lParam.ToArray()))
            {
                Table = new DataTable("Contadores");
                oSql.Adapter.Fill(Table);
                oSql.Close();
                return true;
            }
            else
            {
                oSql.Close();
                return false;
            }
        }

        // OK - 17/10/31
        public bool ProfessionalSpeciality(int IdSpeciality)
        {
            string SPname = sp.SpecialityProfessional;

            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@IdSpeciality", IdSpeciality));

            bool Result = oSql.ExecCombo(SPname, lParam.ToArray());
            if (oSql.Table.Rows.Count != 0)
                Table = oSql.Table;
            else
                Table = null;

            return Result;
        }

        // OK - 17/10/28
        public int OpenSession(string User, string Password)
        {
            string SPname = sp.Session;

            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Status", 1));
            lParam.Add(new SqlParameter("@User", User));
            lParam.Add(new SqlParameter("@Password", Password));
            lParam.Add(new SqlParameter("@IdSession", 0));

            int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

            if (UltimoId == 0)
                Menssage = oSql.Mensage;

            return UltimoId;
        }

        // OK - 17/10/28
        public int CloseSession(int IdSession)
        {
            string SPname = sp.Session;

            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Status", 3));
            lParam.Add(new SqlParameter("@User", string.Empty));
            lParam.Add(new SqlParameter("@Password", string.Empty));
            lParam.Add(new SqlParameter("@IdSession", IdSession));

            int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

            if (UltimoId == 0)
                Menssage = oSql.Mensage;

            return UltimoId;
        }

        // OK - 17/10/28
        public int SessionProfessional(int IdSession)
        {
            string SPname = sp.Session;

            List<SqlParameter> lParam = new List<SqlParameter>();
            lParam.Add(new SqlParameter("@Status", 2));
            lParam.Add(new SqlParameter("@User", string.Empty));
            lParam.Add(new SqlParameter("@Password", string.Empty));
            lParam.Add(new SqlParameter("@IdSession", IdSession));

            int UltimoId = oSql.ExecuteEscalar(SPname, lParam.ToArray());

            if (UltimoId == 0)
                Menssage = oSql.Mensage;

            return UltimoId;
        }

        #endregion

        // VER - 21/06/12
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
    }
}

/*
 * Formatos DateTime
 * http://www.csharp-examples.net/string-format-datetime/
 * 
 * 
 * 
 */
