using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.IO;
using Entidades.newClases;
using Entidades;
using Entidades.Clases;
//using Entidades.Clases;
//using Entidades.Clases.Grillas;

namespace Datos
{
    public class classConsultas
    {
        //----------------------------------------------------------

        #region Atributos y Metodos

        public string Path { set; get; }
        public string DBname { set; get; }
        public bool ActivarLog { set; get; }
        public string Menssage { set; get; }
        public bool Error { set; get; }
        public DataTable Table { set; get; }
        public DataSet oDataSet { set; get; }

        private baseSQL Sql;

        #endregion

        #region Constructores

        public classConsultas()
        {
            ActivarLog = true;
            Sql = new baseSQL(ActivarLog);
            Path = Sql.Path;
            DBname = Sql.DBname;
            Menssage = Menssage;
        }

        public classConsultas(string vPath, string vDBname, bool vLog)
        {
            ActivarLog = vLog;
            Path = vPath;
            DBname = vDBname;
            Sql = new baseSQL(Path, DBname, ActivarLog);
            Menssage = Menssage;
        }

        #endregion

        //----------------------------------------------------------
        // CONSULTAS PARA CADA FUNCION
        //----------------------------------------------------------

        // OK - 17/09/02
        #region Consultas Specialty

        /// <summary>
        /// OK - 17/09/02
        /// Inserta una Especialidad.
        /// </summary>
        /// <param name="oSp">Specialty</param>
        /// <returns>Error</returns>
        public bool AddSpecialty(classSpecialty oSp)
        {
            bool error;

            error = Sql.InsertDB("INSERT INTO Specialty (Description) VALUES ('" + oSp.Description + ");",
                Sql.Parametros, "AddSpecialty");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Modifica una Especialidad.
        /// </summary>
        /// <param name="oSp">Specialty</param>
        /// <returns>Error</returns>
        public bool UpdateSpecialty(classSpecialty oSp)
        {
            bool error;

            error = Sql.InsertDB("UPDATE Specialty SET Description = '" + oSp.Description
                + "', Visible = " + Convert.ToInt32(oSp.Visible) + " WHERE IdSpecialty = " + oSp.IdSpecialty + ";",
                null, "UpdateSpecialty");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Elimina de forma definitiva o Actualiza el campo visible de una Especialidad. 
        /// </summary>
        /// <param name="oSp"></param>
        /// <param name="Delete">Delete o Update state</param>
        /// <returns>Error</returns>
        public bool DeleteSpecialty(classSpecialty oSp, bool Delete)
        {
            bool error;

            if (Delete)
                error = Sql.DeleteDB("DELETE Specialty WHERE IdSpecialty = " + oSp.IdSpecialty + " ;", null, "DeleteSpecialty");
            else
                error = Sql.InsertDB("UPDATE Specialty SET Visible = 0 WHERE IdSpecialty = " + oSp.IdSpecialty + " ;", null, "DeleteSpecialty");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Carga una Combo con Especialidades
        /// </summary>
        /// <returns></returns>
        public bool ListSpecialty(bool Filtro)
        {
            #region Consulta

            string Consulta = "SELECT IdSpecialty[Id], Description[Valor] FROM Specialty WHERE Visible = 1 ";

            if (Filtro)
                Consulta += " ORDER BY Description";
            else
                Consulta += " AND IdSpecialty BETWEEN 2 AND (SELECT MAX(I.IdSpecialty) FROM Specialty AS I) " +
                    " ORDER BY Description";

            #endregion

            if (Sql.SelectAdapterDB(Consulta, "ListSpecialty"))
            {
                DataSet set = new DataSet();
                Table = new DataTable();
                set.Reset();
                Sql.Adapter.Fill(set);
                Table = set.Tables[0];
                Sql.Desconectar();
                return true;
            }
            else
            {
                Sql.Desconectar();
                return false;
            }
        }

        #endregion

        // OK - 17/09/02
        #region Consultas Relationship

        /// <summary>
        /// OK - 17/09/02
        /// Inserta una Relacion.
        /// </summary>
        /// <param name="oSp">Relationship</param>
        /// <returns>Error</returns>
        public bool AddRelationship(classRelationship oSp)
        {
            bool error;

            error = Sql.InsertDB("INSERT INTO Relationship (Description) VALUES ('" + oSp.Description + ");",
                Sql.Parametros, "AddRelationship");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Modifica una Relacion.
        /// </summary>
        /// <param name="oSp">Relationship</param>
        /// <returns>Error</returns>
        public bool UpdateRelationship(classRelationship oSp)
        {
            bool error;

            error = Sql.InsertDB("UPDATE Relationship SET Description = '" + oSp.Description
                + "', Visible = " + Convert.ToInt32(oSp.Visible) + " WHERE IdRelationship = " + oSp.IdRelationship + ";",
                null, "UpdateRelationship");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Elimina de forma definitiva o Actualiza el campo visible de una Relacion. 
        /// </summary>
        /// <param name="oSp"></param>
        /// <param name="Delete">Delete o Update state</param>
        /// <returns>Error</returns>
        public bool DeleteRelationship(classRelationship oSp, bool Delete)
        {
            bool error;

            if (Delete)
                error = Sql.DeleteDB("DELETE Relationship WHERE IdRelationship = " + oSp.IdRelationship + " ;", null, "DeleteRelationship");
            else
                error = Sql.InsertDB("UPDATE Relationship SET Visible = 0 WHERE IdRelationship = " + oSp.IdRelationship + " ;", null, "DeleteRelationship");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Carga una Combo con Relacion.
        /// </summary>
        /// <returns></returns>
        public bool ListRelationship(bool Filtro)
        {
            #region Consulta

            string Consulta = "SELECT IdRelationship[Id], Description[Valor] FROM Relationship WHERE Visible = 1 ";

            if (Filtro)
                Consulta += " ORDER BY Description";
            else
                Consulta += " AND IdRelationship BETWEEN 2 AND (SELECT MAX(I.IdRelationship) FROM Relationship AS I) " +
                    " ORDER BY Description";

            #endregion

            if (Sql.SelectAdapterDB(Consulta, "ListRelationship"))
            {
                DataSet set = new DataSet();
                Table = new DataTable();
                set.Reset();
                Sql.Adapter.Fill(set);
                Table = set.Tables[0];
                Sql.Desconectar();
                return true;
            }
            else
            {
                Sql.Desconectar();
                return false;
            }
        }

        #endregion

        // OK - 17/09/02
        #region Consultas TypeDocument

        /// <summary>
        /// OK - 17/09/02
        /// Inserta una TypeDocument.
        /// </summary>
        /// <param name="oTd">TypeDocument</param>
        /// <returns>Error</returns>
        public bool AddTypeDocument(classTypeDocument oTd)
        {
            bool error;

            error = Sql.InsertDB("INSERT INTO TypeDocument (Description) VALUES ('" + oTd.Description + ");",
                Sql.Parametros, "AddTypeDocument");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Modifica una TypeDocument.
        /// </summary>
        /// <param name="oTd">Specialty</param>
        /// <returns>Error</returns>
        public bool UpdateTypeDocument(classTypeDocument oTd)
        {
            bool error;

            error = Sql.InsertDB("UPDATE TypeDocument SET Description = '" + oTd.Description
                + "', Visible = " + Convert.ToInt32(oTd.Visible) + " WHERE IdTypeDocument = " + oTd.IdTypeDocument + ";",
                null, "UpdateSpecialty");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Elimina de forma definitiva o Actualiza el campo visible de una TypeDocument. 
        /// </summary>
        /// <param name="oTd"></param>
        /// <param name="Delete">Delete o Update state</param>
        /// <returns>Error</returns>
        public bool DeleteTypeDocument(classTypeDocument oTd, bool Delete)
        {
            bool error;

            if (Delete)
                error = Sql.DeleteDB("DELETE TypeDocument WHERE IdTypeDocument = " + oTd.IdTypeDocument + " ;", null, "DeleteTypeDocument");
            else
                error = Sql.InsertDB("UPDATE TypeDocument SET Visible = 0 WHERE IdTypeDocument = " + oTd.IdTypeDocument + " ;", null, "DeleteTypeDocument");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Carga una Combo con TypeDocument
        /// </summary>
        /// <returns></returns>
        public bool ListTypeDocument(bool Filtro)
        {
            #region Consulta

            string Consulta = "SELECT IdTypeDocument[Id], Description[Valor] FROM TypeDocument WHERE Visible = 1 ";

            if (Filtro)
                Consulta += " ORDER BY Description";
            else
                Consulta += " AND IdSpecialty BETWEEN 2 AND (SELECT MAX(I.IdTypeDocument) FROM Specialty AS I) " +
                    " ORDER BY Description";

            #endregion

            if (Sql.SelectAdapterDB(Consulta, "ListTypeDocument"))
            {
                DataSet set = new DataSet();
                Table = new DataTable();
                set.Reset();
                Sql.Adapter.Fill(set);
                Table = set.Tables[0];
                Sql.Desconectar();
                return true;
            }
            else
            {
                Sql.Desconectar();
                return false;
            }
        }

        #endregion

        // OK - 17/09/02
        #region Consultas Parent

        /// <summary>
        /// OK - 17/09/02
        /// Inserta una Pariente.
        /// </summary>
        /// <param name="oSp">Parent</param>
        /// <returns>Error</returns>
        public bool AddParent(classParent oSp)
        {
            bool error;

            error = Sql.InsertDB("INSERT INTO Parent (Name, LastName, IdTypeDocument, " 
                + " NumberDocument, Phone, AlternativePhone, Email, IdRelationship, "
                + " Address, Visible ) VALUES ('" + oSp.Name + "', '" + oSp.LastName + "', " + oSp.IdTypeDocument 
                + ", " + oSp.NumberDocument + ", '" + oSp.Phone + "', '" + oSp.AlternativePhone 
                + "', '" + oSp.Email + "', " + oSp.IdRelationship + ", '" + oSp.Address + "'"+ oSp.IdLocationCity+");",
                Sql.Parametros, "AddParent");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Modifica una Pariente.
        /// </summary>
        /// <param name="oSp">Parent</param>
        /// <returns>Error</returns>
        public bool UpdateParent(classParent oSp)
        {
            bool error;

            error = Sql.InsertDB("UPDATE Parent SET Name = '" + oSp.Name + "', LastName = '" + oSp.LastName
                + "', IdTypeDocument = " + oSp.IdTypeDocument + ", NumberDocument" + oSp.NumberDocument
                + ", Phone = '" + oSp.Phone + "', AlternativePhone ='" + oSp.AlternativePhone + "', Email= '" +oSp.Email 
                + "', IdRelationship = " +oSp.IdRelationship + ", Address = '"+ oSp.Address
                + "', Visible = " + Convert.ToInt32(oSp.Visible) + " WHERE IdParent = " + oSp.IdParent + ";",
                null, "UpdateParent");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Elimina de forma definitiva o Actualiza el campo visible de una Pariente. 
        /// </summary>
        /// <param name="oSp"></param>
        /// <param name="Delete">Delete o Update state</param>
        /// <returns>Error</returns>
        public bool DeleteParent(classParent oSp, bool Delete)
        {
            bool error;

            if (Delete)
                error = Sql.DeleteDB("DELETE Parent WHERE IdParent = " + oSp.IdParent + " ;", null, "DeleteParent");
            else
                error = Sql.InsertDB("UPDATE Parent SET Visible = 0 WHERE IdParent = " + oSp.IdParent + " ;", null, "DeleteParent");

            Menssage = Sql.Mensaje;
            return error;
        }

        #endregion

        // OK - 17/09/02
        #region Consultas Grandfather

        /// <summary>
        /// OK - 17/09/02
        /// Inserta una Abuelo.
        /// </summary>
        /// <param name="oSp">Grandfather</param>
        /// <returns>Error</returns>
        public bool AddGrandfather(classGrandfather oSp)
        {
            bool error;

            error = Sql.InsertDB("INSERT INTO Grandfather (Name, LastName, Birthdate, IdTypeDocument, "
                + " NumberDocument, Sex, Address, Phone, IdSocialWork, AffiliateNumber, DateAdmission, "
                + " EgressDate, ReasonExit,Visible) VALUES ('" + oSp.Name + "', '" + oSp.LastName 
                + "', '" + oSp.Birthdate.Date + "', " + oSp.IdTypeDocument + ", " + oSp.NumberDocument 
                + ", " + oSp.Sex + ", '" + oSp.Address + "', '" + oSp.Phone + "', " + oSp.IdSocialWork
                + ", " + oSp.AffiliateNumber + ", '" +oSp.DateAdmission.Date + "', '" + oSp.EgressDate.Date
                + "', '" + oSp.ReasonExit + "'," + oSp.Visible+");",
                Sql.Parametros, "AddGrandfather");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Modifica un Abuelo.
        /// </summary>
        /// <param name="oSp">Grandfather</param>
        /// <returns>Error</returns>
        public bool UpdateGrandfather(classGrandfather oSp)
        {
            bool error;

            error = Sql.InsertDB("UPDATE Grandfather SET Name = '" + oSp.Name + "', LastName = '" + oSp.LastName
                + "', Birthdate = '" + oSp.Birthdate.Date + "', IdTypeDocument" + oSp.IdTypeDocument
                + ", NumberDocument = " + oSp.NumberDocument + ", Sex =" + oSp.Sex + ", Address = '" + oSp.Address
                + "', Phone = '" + oSp.Phone + "', IdSocialWork = " + oSp.IdSocialWork + ", AffiliateNumber = " + oSp.AffiliateNumber
                + ", DateAdmission = '" + oSp.DateAdmission.Date + "', EgressDate = '" + oSp.EgressDate.Date 
                + "', ReasonExit = '" + oSp.ReasonExit + "', Visible = " + Convert.ToInt32(oSp.Visible) 
                + " WHERE IdGrandfather = " + oSp.IdGrandfather + ";",
                null, "UpdateGrandfather");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Elimina de forma definitiva o Actualiza el campo visible de un Abuelo. 
        /// </summary>
        /// <param name="oSp"></param>
        /// <param name="Delete">Delete o Update state</param>
        /// <returns>Error</returns>
        public bool DeleteGrandfather(classGrandfather oSp, bool Delete)
        {
            bool error;

            if (Delete)
                error = Sql.DeleteDB("DELETE Grandfather WHERE IdGrandfather = " + oSp.IdGrandfather + " ;", null, "DeleteGrandfather");
            else
                error = Sql.InsertDB("UPDATE Grandfather SET Visible = 0 WHERE IdGrandfather = " + oSp.IdGrandfather + " ;", null, "DeleteGrandfather");

            Menssage = Sql.Mensaje;
            return error;
        }

        #endregion

        // OK - 17/09/02
        #region Consultas Professional

        /// <summary>
        /// OK - 17/09/02
        /// Inserta una Professional.
        /// </summary>
        /// <param name="oPl">Professional</param>
        /// <returns>Error</returns>
        public bool AddProfessional(classProfessional oPl)
        {
            bool error;

            error = Sql.InsertDB("INSERT INTO Professional (ProfessionalRegistration, Names, LastName, "
                + "Address, Phone, Mail, User, Password, Visible ) VALUES (" + oPl.ProfessionalRegistration + ", '"
                + oPl.Name + "', '" + oPl.LastName + "', '" + oPl.Address + "', '" + oPl.Phone
                + "', '" + oPl.Mail + "', '" + oPl.User + "', '" + oPl.Password + "', " + oPl.Visible + "');",
                Sql.Parametros, "AddProfessional");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Modifica una Professional.
        /// </summary>
        /// <param name="oPl">Professional</param>
        /// <returns>Error</returns>
        public bool UpdateProfessional(classProfessional oPl)
        {
            bool error;

            error = Sql.InsertDB(
                "UPDATE Professional SET ProfessionalRegistration = " + oPl.ProfessionalRegistration + ", " +
                " Names = '" + oPl.Name + "', LastName = '" + oPl.LastName + "', Address = '" + oPl.Address
                + "', Phone = '" + oPl.Phone + "', Mail ='" + oPl.Mail + "', User= '" + oPl.User
                + "', Password= '" + oPl.Password + "', Visible = " + Convert.ToInt32(oPl.Visible) +
                " WHERE IdProfessional = " + oPl.IdProfessional + ";", null, "UpdateProfessional");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Elimina de forma definitiva o Actualiza el campo visible de una Professional. 
        /// </summary>
        /// <param name="oPl"></param>
        /// <param name="Delete">Delete o Update state</param>
        /// <returns>Error</returns>
        public bool DeleteProfessional(classProfessional oPl, bool Delete)
        {
            bool error;

            if (Delete)
                error = Sql.DeleteDB("DELETE Professional WHERE IdProfessional = " + oPl.IdProfessional + " ;", null, "DeleteProfessional");
            else
                error = Sql.InsertDB("UPDATE Professional SET Visible = 0 WHERE IdProfessional = " + oPl.IdProfessional + " ;", null, "DeleteProfessional");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// Trae los datos de una Professional seleccionado.
        /// OK 11/06/12
        /// </summary>
        /// <param name="oU"></param>
        /// <returns></returns>
        public classProfessional SelectProfessional(classProfessional oU)
        {
            classProfessional oTr = new classProfessional();

            //string Consulta = "SELECT IdProfessional, ProfessionalRegistration,Name, LastName, Address, Phone, Mail, User, Password, Visible FROM Professional ";

            //if (oU.IdProfessional != 0)
            //    Consulta = Consulta + "WHERE IdProfessional = " + oU.IdProfessional;
            //else
            //    Consulta = Consulta + "WHERE User LIKE '" + oU.User + "' AND Password LIKE '" + oU.Password + "'";

            //if (Sql.SelectReaderDB(Consulta + " ORDER BY Name;",
            //    null,
            //    "SelectProfessional"))
            //{
            //    Sql.Reader.Read();
            //    oTr = new classProfessional(
            //        Convert.ToInt32(Sql.Reader["IdProfessional"])
            //        , Convert.ToInt32(Sql.Reader["ProfessionalRegistration"])
            //        , Sql.Reader["Name"].ToString()
            //        , Sql.Reader["LastName"].ToString()
            //        , Sql.Reader["Address"].ToString()
            //        , Sql.Reader["Phone"].ToString()
            //        , Sql.Reader["Mail"].ToString()
            //        , Sql.Reader["User"].ToString()
            //        , Sql.Reader["Password"].ToString()
            //        , Convert.ToBoolean(Sql.Reader["Visible"])
            //        );

            //    Sql.Reader.Close();
            //    Sql.Desconectar();
            //}

            return oTr;
        }

        /// <summary>
        /// Trae el ultimo usuario insertado
        /// OK 07/06/12
        /// </summary>
        /// <returns></returns>
        public int UltimoIdProfessional()
        {
            int A = 0;

            if (Sql.SelectReaderDB("SELECT MAX(IdProfessional) AS Id FROM Professional", null, "UltimoIdUsuario"))
            {
                Sql.Reader.Read();
                A = Convert.ToInt32(Sql.Reader["Id"]);
                Sql.Reader.Close();
                Sql.Desconectar();
            }

            return A;
        }
        #endregion

        // OK - 17/09/02
        #region Consultas SocialWork

        /// <summary>
        /// OK - 17/09/02
        /// Inserta una Obra Social.
        /// </summary>
        /// <param name="oSp">SocialWork</param>
        /// <returns>Error</returns>
        public bool AddSocialWork(classSocialWork oSp)
        {
            bool error;

            error = Sql.InsertDB("INSERT INTO SocialWork (Name, Description, Address, Phone , AlternativePhone) "
                + "VALUES ('" + oSp.Name + "', '" + oSp.Description + "', '" + oSp.Address + "', '" + oSp.Phone 
                + "', '" + oSp.AlternativePhone + "');", Sql.Parametros, "AddSocialWork");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Modifica una Obra Social.
        /// </summary>
        /// <param name="oSp">SocialWork</param>
        /// <returns>Error</returns>
        public bool UpdateSocialWork(classSocialWork oSp)
        {
            bool error;

            error = Sql.InsertDB("UPDATE SocialWork SET Name = '" + oSp.Name + "', Description = '" + oSp.Description
                + "', Address = '" + oSp.Address + "' Phone = '" + oSp.Phone + "', AlternativePhone = '" + oSp.AlternativePhone 
                + "', Visible = " + Convert.ToInt32(oSp.Visible) + " WHERE IdSocialWork = " + oSp.IdSocialWork + ";",
                null, "UpdateSocialWork");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Elimina de forma definitiva o Actualiza el campo visible de una Obra Social. 
        /// </summary>
        /// <param name="oSp"></param>
        /// <param name="Delete">Delete o Update state</param>
        /// <returns>Error</returns>
        public bool DeleteSocialWork(classSocialWork oSp, bool Delete)
        {
            bool error;

            if (Delete)
                error = Sql.DeleteDB("DELETE SocialWork WHERE IdSocialWork = " + oSp.IdSocialWork + " ;", null, "DeleteSocialWork");
            else
                error = Sql.InsertDB("UPDATE SocialWork SET Visible = 0 WHERE IdSocialWork = " + oSp.IdSocialWork + " ;", null, "DeleteSocialWork");

            Menssage = Sql.Mensaje;
            return error;
        }


        /// <summary>
        /// OK 03/06/12
        /// Trae una SocialWork. 
        /// Campo ID obligatorio.
        /// </summary>
        /// <param name="oS"></param>
        /// <returns></returns>
        public classSocialWork SelectSocialWork(classSocialWork oS)
        {
            classSocialWork oSa = null;

            //string Consulta = "SELECT IdSocialWork, Name, Description, Address, Phone, AlternativePhone, Visible"
            //    + "FROM SocialWork WHERE IdSocialWork = " + oS.IdSocialWork + " AND Visible = " + oS.Visible +
            //    " AND IdSocialWork BETWEEN 2 AND (SELECT MAX(I.IdSocialWork) FROM SocialWork AS I);";

            //if (Sql.SelectReaderDB(Consulta, null, "SelectSocialWork"))
            //{
            //    while (Sql.Reader.Read())
            //    {
            //        classSocialWork oSr = new classSocialWork(
            //            Convert.ToInt32(Sql.Reader["IdSocialWork"])
            //            , Sql.Reader["Name"].ToString()
            //            , Sql.Reader["Description"].ToString()
            //            , Sql.Reader["Address"].ToString()
            //            , Sql.Reader["Phone"].ToString()
            //            , Sql.Reader["AlternativePhone"].ToString()
            //            , Convert.ToBoolean(Sql.Reader["Visible"])
            //            );
            //        oSa = oSr;
            //    }

            //    Sql.Reader.Close();
            //    Sql.Desconectar();
            //}
            return oSa;
        }


        ///// <summary>
        ///// OK - 17/09/02
        ///// Carga una Combo con Obra Social
        ///// </summary>
        ///// <returns></returns>
        //public bool ListSocialWork(bool Filtro)
        //{
        //    #region Consulta

        //    string Consulta = "SELECT IdSocialWork[Id], Description[Valor] FROM SocialWork WHERE Visible = 1 ";

        //    if (Filtro)
        //        Consulta += " ORDER BY Description";
        //    else
        //        Consulta += " AND IdSocialWork BETWEEN 2 AND (SELECT MAX(I.IdSocialWork) FROM SocialWork AS I) " +
        //            " ORDER BY Description";

        //    #endregion

        //    if (Sql.SelectAdapterDB(Consulta, "ListSocialWork"))
        //    {
        //        DataSet set = new DataSet();
        //        Table = new DataTable();
        //        set.Reset();
        //        Sql.Adapter.Fill(set);
        //        Table = set.Tables[0];
        //        Sql.Desconectar();
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Desconectar();
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// Carga una Combo con Obras Sociales
        ///// OK 25/05/12
        ///// </summary>
        ///// <returns></returns>
        //public bool ListaSocialWorkes(bool Filtro)
        //{
        //    #region Consulta

        //    string Consulta = "SELECT IdSocialWork[Id], Nombre[Valor] FROM SocialWork WHERE Visible = 1 ";

        //    if (Filtro)
        //        Consulta += " ORDER BY Nombre";
        //    else
        //        Consulta += " AND IdSocialWork BETWEEN 2 AND (SELECT MAX(I.IdSocialWork) FROM SocialWork AS I) " +
        //            " ORDER BY Nombre";

        //    #endregion

        //    if (Sql.SelectAdapterDB(Consulta, "ListaSocialWorkes"))
        //    {
        //        DataSet set = new DataSet();
        //        Table = new DataTable();
        //        set.Reset();
        //        Sql.Adapter.Fill(set);
        //        Table = set.Tables[0];
        //        Sql.Desconectar();
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Desconectar();
        //        return false;
        //    }
        //}

        #endregion

        #region CONSULTAS COMETADAS

        //// OK 07/06/12
        #region Consultas Comboboxes

        ///// <summary>
        ///// Carga una Combo con Usuarios
        ///// OK 07/06/12
        ///// </summary>
        ///// <returns></returns>
        //public bool ListaUsuarios()
        //{
        //    if (Sql.SelectAdapterDB("SELECT IdUsuario[Id], Nombre[Valor] FROM Usuario WHERE Visible = 1 ORDER BY Nombre",
        //        "ListaUsuarios"))
        //    {
        //        DataSet set = new DataSet();
        //        Table = new DataTable();
        //        set.Reset();
        //        Sql.Adapter.Fill(set);
        //        Table = set.Tables[0];
        //        Sql.Desconectar();
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Desconectar();
        //        return false;
        //    }
        //}

        #endregion

        //// OK 26/05/12
        #region Consulta Diagnostico

        //// Revisado OK 25/05/12
        //public bool AgregarDiagnostico(classDiagnostico oD)
        //{
        //    bool error;

        //    error = Sql.InsertDB("INSERT INTO Diagnostico (IdPersona, Diagnostico, IdDetalle, Fecha, Visible) VALUES ("
        //        + oD.IdPersona + ", '" + oD.Diagnostico + "', " +  oD.IdDetalle + ",'" + String.Format("{0:yyyy'-'MM'-'dd}", oD.Fecha)
        //        + "', " + 1 + " );", null, "AgregarDiagnostico");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        //// Revisado OK 25/05/12
        //public bool ModificarDiagnostico(classDiagnostico oD)
        //{
        //    bool error;

        //    error = Sql.UpdateDB("UPDATE Diagnostico SET IdPersona = " + oD.IdPersona + ", Diagnostico = '" + oD.Diagnostico
        //        + "', IdDetalle = " + oD.IdDetalle + ", Fecha = '" + String.Format("{0:yyyy'-'MM'-'dd}", oD.Fecha) 
        //        + "' WHERE IdDiagnostico = " + oD.IdDiagnostico + " ;",
        //        Sql.Parametros,
        //        "ModificarDiagnostico");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        //// Revisado OK 25/05/12
        //public classDiagnostico SelectDiagnostico(classDiagnostico oD)
        //{
        //    classDiagnostico oDa = new classDiagnostico();

        //    if (Sql.SelectReaderDB("SELECT IdDiagnostico, IdPersona, Diagnostico, IdDetalle, Fecha "
        //        + "FROM Diagnostico WHERE Visible = 1 AND IdDiagnostico = " + oD.IdDiagnostico + " ;",
        //        null,
        //        "selectDiagnostico"))
        //    {
        //        Sql.Reader.Read();

        //        classDiagnostico oDr = new classDiagnostico(
        //            Convert.ToInt32(Sql.Reader["IdDiagnostico"])
        //            , Convert.ToInt32(Sql.Reader["IdPersona"])
        //            , Convert.ToInt32(Sql.Reader["IdDetalle"])
        //            , Sql.Reader["Diagnostico"].ToString()
        //            , Convert.ToDateTime(Sql.Reader["Fecha"])
        //            );

        //        oDa = oDr;

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return oDa;
        //}

        //// Revisado OK 25/05/12
        //public List<classDiagnostico> SelectDiagnosticoPersona(classDiagnostico oD)
        //{
        //    List<classDiagnostico> oDa = new List<classDiagnostico>();

        //    if (Sql.SelectReaderDB("SELECT IdDiagnostico, IdPersona, Diagnostico, IdDetalle, Fecha "
        //        + " FROM Diagnostico WHERE Visible = 1 AND IdPersona = " + oD.IdPersona + "; ",
        //        null,
        //        "selectDiagnosticoPersona"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            classDiagnostico oDr = new classDiagnostico(
        //                Convert.ToInt32(Sql.Reader["IdDiagnostico"])
        //                , Convert.ToInt32(Sql.Reader["IdPersona"])
        //                , Convert.ToInt32(Sql.Reader["IdDetalle"])
        //                , Sql.Reader["Diagnostico"].ToString()
        //                , Convert.ToDateTime(Sql.Reader["Fecha"])
        //                );
        //            oDa.Add(oDr);
        //        }

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return oDa;
        //}

        //// Revisado OK 25/05/12 Chekear
        //public List<classDiagnostico> SelectAllDiagnostico()
        //{
        //    List<classDiagnostico> oDa = null;

        //    if (Sql.SelectReaderDB("SELECT IdDiagnostico, IdPersona, Diagnostico, IdDetalle, Fecha "
        //        + "FROM Diagnostico WHERE Visible = 1;",
        //        null,
        //        "SelectAllDiagnostico"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            classDiagnostico oDr = new classDiagnostico(
        //                Convert.ToInt32(Sql.Reader["IdDiagnostico"])
        //                , Convert.ToInt32(Sql.Reader["IdPersona"])
        //                , Convert.ToInt32(Sql.Reader["IdDetalle"])
        //                , Sql.Reader["Diagnostico"].ToString()
        //                , Convert.ToDateTime(Sql.Reader["Fecha"])
        //                );
        //            oDa.Add(oDr);
        //        }

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return oDa;
        //}

        //// Revisado OK 25/05/12
        //public bool EliminarDiagnostico(classDiagnostico oD, bool Eliminar)
        //{
        //    bool error;

        //    if (Eliminar)
        //    {
        //        error = Sql.DeleteDB("DELETE Diagnostico WHERE IdDiagnostico = " + oD.IdDiagnostico + ";",
        //            Sql.Parametros,
        //            "EliminarDiagnostico");
        //    }
        //    else
        //    {
        //        error = Sql.UpdateDB("UPDATE Diagnostico SET Visible = 0 WHERE IdDiagnostico = " + oD.IdDiagnostico + ";",
        //            Sql.Parametros,
        //            "EliminarDiagnostico");
        //    }

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        #endregion 

        //// OK 26/05/12
        #region Consulta Persona

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

        //    if (Sql.SelectReaderDB(Consulta, null, "CountPersona"))
        //    {
        //        Sql.Reader.Read();
        //        C = Convert.ToInt32(Sql.Reader["C"]);
        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return C;
        //}

        //// OK 25/05/12
        //public int UltimoIdPersona()
        //{
        //    int A = 0;

        //    if (Sql.SelectReaderDB("SELECT MAX(IdPersona) AS Id FROM Persona", null, "UltimoIdPaciente"))
        //    {
        //        Sql.Reader.Read();
        //        A = Convert.ToInt32(Sql.Reader["Id"]);
        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }

        //    return A;
        //}

        //// Revisado OK 25/05/12
        //public classPersona SelectPersona(classPersona oP)
        //{
        //    classPersona oPa = null;

        //    if (Sql.SelectReaderDB("SELECT IdPersona, Nombre, Apellido, Direccion, FechaNacimiento, Sexo, IdObraSocial, nAfiliado, IdTipoPersona, "
        //        + "IdCiudad, IdBarrio, Telefono, TelefonoParticular, FechaAlta "
        //        + " FROM Persona WHERE IdPersona = " + oP.IdPersona + " AND Visible = 1 ;", null, "SelectPaciente"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            classPersona oPr = new classPersona(
        //                Convert.ToInt32(Sql.Reader["IdPersona"])
        //                , Convert.ToInt32(Sql.Reader["IdObraSocial"])
        //                , Convert.ToInt32(Sql.Reader["IdTipoPersona"])
        //                , Convert.ToInt32(Sql.Reader["IdCiudad"])
        //                , Convert.ToInt32(Sql.Reader["IdBarrio"])
        //                , Sql.Reader["Nombre"].ToString()
        //                , Sql.Reader["Apellido"].ToString()
        //                , Sql.Reader["Direccion"].ToString()
        //                , Convert.ToDateTime(Sql.Reader["FechaNacimiento"])
        //                , Convert.ToDateTime(Sql.Reader["FechaAlta"])
        //                , Convert.ToInt32(Sql.Reader["Sexo"])
        //                , Sql.Reader["nAfiliado"].ToString()
        //                , Sql.Reader["Telefono"].ToString()
        //                , Sql.Reader["TelefonoParticular"].ToString()
        //                );
        //            oPa = oPr;
        //        }
        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }

        //    return oPa;
        //}

        //// Revisado OK 25/05/12 CHEKEAR
        //public List<classPersona> SelectAllPersona()
        //{
        //    List<classPersona> oPa = new List<classPersona>(); ;

        //    if (Sql.SelectReaderDB("SELECT IdPersona, Nombre, Apellido, Direccion, FechaNacimiento, Sexo, IdObraSocial, nAfiliado, IdTipoPersona, "
        //        + "IdCiudad, IdBarrio, Telefono, TelefonoParticular, FechaAlta "
        //        + " FROM Persona WHERE Visible = 1;", null, "SelectAllPaciente"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            classPersona oPr = new classPersona(
        //                Convert.ToInt32(Sql.Reader["IdPersona"])
        //                , Convert.ToInt32(Sql.Reader["IdObraSocial"])
        //                , Convert.ToInt32(Sql.Reader["IdTipoPaciente"])
        //                , Convert.ToInt32(Sql.Reader["IdCiudad"])
        //                , Convert.ToInt32(Sql.Reader["IdBarrio"])
        //                , Sql.Reader["Nombre"].ToString()
        //                , Sql.Reader["Apellido"].ToString()
        //                , Sql.Reader["Direccion"].ToString()
        //                , Convert.ToDateTime(Sql.Reader["FechaNacimiento"])
        //                , Convert.ToDateTime(Sql.Reader["FechaAlta"])
        //                , Convert.ToInt32(Sql.Reader["Sexo"])
        //                , Sql.Reader["nAfiliado"].ToString()
        //                , Sql.Reader["Telefono"].ToString()
        //                , Sql.Reader["TelefonoParticular"].ToString()
        //                );
        //            oPa.Add(oPr);
        //        }

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return oPa;
        //}

        #endregion

        //// OK 03/06/12
        #region Consulta obraSocial

        ///// <summary>
        ///// OK 03/06/12
        ///// Trae una Obra Social. 
        ///// Campo ID obligatorio.
        ///// </summary>
        ///// <param name="oS"></param>
        ///// <returns></returns>
        //public classObraSocial SelectObraSocial(classObraSocial oS)
        //{
        //    classObraSocial oSa = null;

        //    string Consulta = "SELECT IdObraSocial, Nombre, Descripcion, IdCiudad, IdBarrio, Visible, Telefono1, Telefono2, Direccion "
        //        + "FROM ObraSocial WHERE IdObraSocial = " + oS.Id + " AND Visible = " + oS.Visible +
        //        " AND IdObraSocial BETWEEN 2 AND (SELECT MAX(I.IdObraSocial) FROM ObraSocial AS I);";

        //    if (Sql.SelectReaderDB(Consulta, null, "SelectObraSocial"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            classObraSocial oSr = new classObraSocial(
        //                Convert.ToInt32(Sql.Reader["IdObraSocial"])
        //                , Sql.Reader["Nombre"].ToString()
        //                , Sql.Reader["Descripcion"].ToString()
        //                , Convert.ToInt32(Sql.Reader["IdCiudad"])
        //                , Convert.ToInt32(Sql.Reader["IdBarrio"])
        //                , Sql.Reader["Direccion"].ToString()
        //                , Sql.Reader["Telefono1"].ToString()
        //                , Sql.Reader["Telefono2"].ToString()
        //                , Convert.ToInt32(Sql.Reader["Visible"])
        //                );
        //            oSa = oSr;
        //        }

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return oSa;
        //}

        ///// <summary>
        ///// OK 03/06/12
        ///// Trae todas las Obras Sociales.
        ///// </summary>
        ///// <returns></returns>
        //public List<classObraSocial> SelectAllObraSocial()
        //{
        //    List<classObraSocial> oSa = null;

        //    if (Sql.SelectReaderDB("SELECT IdObraSocial, Nombre, Descripcion, IdCiudad, IdBarrio, Visible, Telefono1, Telefono2, Direccion FROM ObraSocial;",
        //        null,
        //        "selectAllObraSocial"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            classObraSocial oSr = new classObraSocial(
        //                Convert.ToInt32(Sql.Reader["IdObraSocial"])
        //                , Sql.Reader["Nombre"].ToString()
        //                , Sql.Reader["Descripcion"].ToString()
        //                , Convert.ToInt32(Sql.Reader["IdCiudad"])
        //                , Convert.ToInt32(Sql.Reader["IdBarrio"])
        //                , Sql.Reader["Direccion"].ToString()
        //                , Sql.Reader["Telefono1"].ToString()
        //                , Sql.Reader["Telefono2"].ToString()
        //                , Convert.ToInt32(Sql.Reader["Visible"])
        //                );
        //            oSa.Add(oSr);
        //        }

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return oSa;
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

        //    if (Sql.SelectReaderDB(Consulta, null, "CountObraSocial"))
        //    {
        //        Sql.Reader.Read();
        //        C = Convert.ToInt32(Sql.Reader["C"]);
        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return C;
        //}

        ///// <summary>
        ///// Carga un objeto DataTable
        ///// OK 20/06/12
        ///// </summary>
        ///// <returns></returns>
        //public bool listaPacientesObraSocial(string nameDataTable, DateTime Desde, DateTime Hasta, bool filtrar)
        //{
        //    #region Table

        //    DataTable TablaAuxiliar = new DataTable(nameDataTable);
        //    TablaAuxiliar.Columns.Add(new DataColumn("IdPersona", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("nNombre", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("nObraSocial", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Dia", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Hora", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Direccion", typeof(string)));
        //    TablaAuxiliar.Columns.Add(new DataColumn("Expediente", typeof(string)));

        //    #endregion

        //    string Consulta = "";

        //    if (filtrar)
        //    {
        //        Consulta = "SELECT P.IdPersona, (P.Apellido||', '||P.Nombre) [nNombre], O.Nombre [nObraSocial]"
        //       + ", T.Fecha [Fecha], C.Nombre||' - '||B.Nombre||' -' ||P.Direccion [Direccion], P.nAfiliado [Expediente]"
        //       + " FROM Persona AS P INNER JOIN ObraSocial AS O"
        //       + " ON P.IdObraSocial = O.IdObraSocial "
        //       + " INNER JOIN Ciudad AS C"
        //       + " ON P.IdCiudad = C.IdCiudad"
        //       + " INNER JOIN Barrio AS B"
        //       + " ON P.IdBarrio = B.iIdBarrio"
        //        + " INNER JOIN Turno AS T"
        //        + " ON P.IdPersona =  T.IdPersona"
        //        + " WHERE P.Visible = 1 AND O.Visible = 1"
        //        + " AND T.Fecha BETWEEN ('" + String.Format("{0:yyyy'-'MM'-'dd}", Desde) + "')"
        //        + " AND ('" + String.Format("{0:yyyy'-'MM'-'dd}", Hasta) + "');";
        //    }
        //    else
        //    {
        //        Consulta = "SELECT P.IdPersona, (P.Apellido||', '||P.Nombre) [nNombre], O.Nombre [nObraSocial]"
        //       + ", P.FechaAlta [Fecha], C.Nombre||' - '||B.Nombre||' -' ||P.Direccion [Direccion], P.nAfiliado [Expediente]"
        //       + " FROM Persona AS P INNER JOIN ObraSocial AS O"
        //       + " ON P.IdObraSocial = O.IdObraSocial "
        //       + " INNER JOIN Ciudad AS C"
        //       + " ON P.IdCiudad = C.IdCiudad"
        //       + " INNER JOIN Barrio AS B"
        //       + " ON P.IdBarrio = B.iIdBarrio";
        //    }

        //    if (Sql.SelectReaderDB(Consulta, null, "listaPacientesObraSocial"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            DataRow Row = TablaAuxiliar.NewRow();

        //            Row[0] = Sql.Reader["IdPersona"].ToString();
        //            Row[1] = Sql.Reader["nNombre"].ToString();
        //            Row[2] = Sql.Reader["nObraSocial"].ToString();
        //            Row[3] = String.Format("{0:m}", Convert.ToDateTime(Sql.Reader["Fecha"]));
        //            Row[4] = String.Format("{0:T}", Convert.ToDateTime(Sql.Reader["Fecha"]));
        //            Row[5] = Sql.Reader["Direccion"].ToString();
        //            Row[6] = Sql.Reader["Expediente"].ToString();

        //            TablaAuxiliar.Rows.Add(Row);
        //        }
        //        Sql.Reader.Close();
        //        Sql.Desconectar();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Desconectar();
        //        return false;
        //    }
        //}

        #endregion

        //// OK 11/16/12
        #region Consulta Usuario

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

        //    if (Sql.SelectReaderDB(Consulta, null, "CountUsuarios"))
        //    {
        //        Sql.Reader.Read();
        //        C = Convert.ToInt32(Sql.Reader["C"]);
        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return C;
        //}

        ///// <summary>
        ///// Trae los datos de una Usuario seleccionado.
        ///// OK 07/06/12
        ///// </summary>
        ///// <param name="oU"></param>
        ///// <returns></returns>
        //public bool ValidarPassword(classUsuarios oU)
        //{
        //    bool A = false;

        //    if (Sql.SelectReaderDB("SELECT Count(IdUsuario) FROM Usuario  "
        //        + " WHERE Bloqueado = 0  AND Nombre = '" + oU.Nombre
        //        + "' AND Contrasenia = '" + oU.Contrasenia + "';",
        //        null,
        //        "selectPassword"))
        //    {
        //        Sql.Reader.Read();
        //        A = Convert.ToBoolean(Sql.Reader[0]);
        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return A;
        //}

        ///// <summary>
        ///// Trae los datos de una Usuario seleccionado.
        ///// OK 11/06/12
        ///// </summary>
        ///// <param name="oU"></param>
        ///// <returns></returns>
        //public classUsuarios SelectUsuario(classUsuarios oU)
        //{
        //    classUsuarios oTr = new classUsuarios();

        //    string Consulta = "SELECT IdUsuario, Nombre, Apellido, Contrasenia, Email, Bloqueado FROM Usuario ";

        //    if (oU.IdUsuario != 0)
        //        Consulta = Consulta + "WHERE IdUsuario = " + oU.IdUsuario;
        //    else
        //        Consulta = Consulta + "WHERE Nombre LIKE '" + oU.Nombre + "' AND Contrasenia LIKE '" + oU.Contrasenia + "'";

        //    if (Sql.SelectReaderDB(Consulta + " ORDER BY Nombre;",
        //        null,
        //        "SelectUsuario"))
        //    {
        //        Sql.Reader.Read();
        //            oTr = new classUsuarios(
        //                Convert.ToInt32(Sql.Reader["IdUsuario"])
        //                , Sql.Reader["Nombre"].ToString()
        //                , Sql.Reader["Apellido"].ToString()
        //                , Sql.Reader["Contrasenia"].ToString()
        //                , Sql.Reader["Email"].ToString()
        //                , Convert.ToBoolean(Sql.Reader["Bloqueado"])
        //                );

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return oTr;
        //}

        ///// <summary>
        ///// Trae el ultimo usuario insertado
        ///// OK 07/06/12
        ///// </summary>
        ///// <returns></returns>
        //public int UltimoIdUsuario()
        //{
        //    int A = 0;

        //    if (Sql.SelectReaderDB("SELECT MAX(IdUsuario) AS Id FROM Usuario", null, "UltimoIdUsuario"))
        //    {
        //        Sql.Reader.Read();
        //        A = Convert.ToInt32(Sql.Reader["Id"]);
        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }

        //    return A;
        //}

        #endregion

        //// OK 11/06/12
        #region Consulta Filtros

        ///// <summary>
        ///// Filtra Obras Sociales por coincidencia de la primera letras.
        ///// OK 22/03/12
        ///// </summary>
        ///// <param name="Nombre"></param>
        ///// <returns></returns>
        //public List<classUsuarios> FiltroUsuario(string Nombre, bool Bloqueado)
        //{
        //    List<classUsuarios> oUa = new List<classUsuarios>();
        //    Error = false;

        //    #region Consulta

        //    string Consulta = "SELECT IdUsuario, Nombre, Apellido, Email, Bloqueado, Contrasenia FROM Usuario ";

        //    if (Nombre != "")// OK 21/03/12 
        //        Consulta = Consulta + "WHERE Bloqueado = " + Convert.ToInt32(Bloqueado) + " AND Nombre LIKE '" + Nombre + "%' ;";
        //    else// OK 21/03/12  
        //        Consulta = Consulta + " WHERE Bloqueado = " + Convert.ToInt32(Bloqueado) + " ;";

        //    #endregion

        //    if (Sql.SelectReaderDB(Consulta, null, "FiltroUsuario"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            classUsuarios oU = new classUsuarios(
        //                Convert.ToInt32(Sql.Reader["IdUsuario"])
        //                , Sql.Reader["Nombre"].ToString()
        //                , Sql.Reader["Apellido"].ToString()
        //                , Sql.Reader["Contrasenia"].ToString()
        //                , Sql.Reader["Email"].ToString()
        //                , Convert.ToBoolean(Sql.Reader["Bloqueado"])
        //                );
        //            oUa.Add(oU);
        //        }
        //        Error = true;

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }

        //    return oUa;
        //}

        ///// <summary>
        ///// Filtra Obras Sociales por coincidencia de la primera letras.
        ///// OK 22/03/12
        ///// </summary>
        ///// <param name="Nombre"></param>
        ///// <returns></returns>
        //public List<classUsuarios> FiltroUsuarioLimite(string Nombre, bool Bloqueado, int Desde, int Hasta)
        //{
        //    List<classUsuarios> oUa = new List<classUsuarios>();
        //    Error = false;

        //    #region Consulta

        //    string Consulta = "SELECT IdUsuario, Nombre, Apellido, Email, Bloqueado, Contrasenia FROM Usuario ";

        //    if (Nombre != "")// OK 21/03/12 
        //        Consulta = Consulta + "WHERE Bloqueado = " + Convert.ToInt32(Bloqueado) + " AND Nombre LIKE '" + Nombre + "%'";
        //    else// OK 21/03/12  
        //        Consulta = Consulta + " WHERE Bloqueado = " + Convert.ToInt32(Bloqueado) ;

        //    Consulta += " LIMIT " + Desde + " ," + Hasta + " ;";

        //    #endregion

        //    if (Sql.SelectReaderDB(Consulta, null, "FiltroUsuarioLimite"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            classUsuarios oU = new classUsuarios(
        //                Convert.ToInt32(Sql.Reader["IdUsuario"])
        //                , Sql.Reader["Nombre"].ToString()
        //                , Sql.Reader["Apellido"].ToString()
        //                , Sql.Reader["Contrasenia"].ToString()
        //                , Sql.Reader["Email"].ToString()
        //                , Convert.ToBoolean(Sql.Reader["Bloqueado"])
        //                );
        //            oUa.Add(oU);
        //        }
        //        Error = true;

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }

        //    return oUa;
        //}

        ///// <summary>
        ///// Filtra Obras Sociales por coincidencia de la primera letras.
        ///// OK 22/03/12
        ///// </summary>
        ///// <param name="Nombre"></param>
        ///// <returns></returns>
        //public List<classObraSocial> FiltroObraSocial(string Nombre)
        //{
        //    List<classObraSocial> oPa = new List<classObraSocial>();
        //    Error = false;

        //    #region Consulta

        //    string Consulta = "";

        //    if (Nombre != "")
        //    {   // OK 21/03/12
        //        Consulta = "SELECT IdObraSocial, Nombre, Descripcion, IdCiudad, IdBarrio, Visible, Telefono1, Telefono2, Direccion " +
        //            " FROM ObraSocial WHERE Visible = 1 AND Nombre LIKE '" + Nombre + "%'" +
        //            " AND IdObraSocial != 1;";
        //    }

        //    else
        //    {   // OK 21/03/12
        //        Consulta = "SELECT IdObraSocial, Nombre, Descripcion, IdCiudad, IdBarrio, Visible, Telefono1, Telefono2, Direccion " +
        //            " FROM ObraSocial WHERE Visible = 1 " +
        //            " AND IdObraSocial != 1;";
        //    }

        //    #endregion

        //    if (Sql.SelectReaderDB(Consulta, null, "FiltroObraSocial"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            classObraSocial oPr = new classObraSocial(
        //                Convert.ToInt32(Sql.Reader["IdObraSocial"])
        //                , Sql.Reader["Nombre"].ToString()
        //                , Sql.Reader["Descripcion"].ToString()
        //                , Convert.ToInt32(Sql.Reader["IdCiudad"])
        //                , Convert.ToInt32(Sql.Reader["IdBarrio"])
        //                , Sql.Reader["Direccion"].ToString()
        //                , Sql.Reader["Telefono1"].ToString()
        //                , Sql.Reader["Telefono2"].ToString()
        //                , Convert.ToInt32(Sql.Reader["Visible"])
        //                );
        //            oPa.Add(oPr);
        //        }
        //        Error = true;

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }

        //    return oPa;
        //}

        ///// <summary>
        ///// Filtra Obras Sociales por coincidencia de la primera letras.
        ///// OK 22/03/12
        ///// </summary>
        ///// <param name="Nombre"></param>
        ///// <returns></returns>
        //public List<classObraSocial> FiltroObraSocialLimite(string Nombre, int Desde, int Hasta)
        //{
        //    List<classObraSocial> oPa = new List<classObraSocial>();
        //    Error = false;

        //    #region Consulta

        //    string Consulta = "";

        //    if (Nombre != "")
        //    {   // OK 21/03/12
        //        Consulta = "SELECT IdObraSocial, Nombre, Descripcion, IdCiudad, IdBarrio, Visible, Telefono1, Telefono2, Direccion " +
        //            " FROM ObraSocial WHERE Visible = 1 AND Nombre LIKE '" + Nombre + "%'" +
        //            " AND IdObraSocial != 1 LIMIT " + Desde + ", " + Hasta + " ;";
        //    }

        //    else
        //    {   // OK 21/03/12
        //        Consulta = "SELECT IdObraSocial, Nombre, Descripcion, IdCiudad, IdBarrio, Visible, Telefono1, Telefono2, Direccion " +
        //            " FROM ObraSocial WHERE Visible = 1 " +
        //            " AND IdObraSocial != 1 LIMIT " + Desde + ", " + Hasta + " ;";
        //    }

        //    #endregion

        //    if (Sql.SelectReaderDB(Consulta, null, "FiltroObraSocial"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            classObraSocial oPr = new classObraSocial(
        //                Convert.ToInt32(Sql.Reader["IdObraSocial"])
        //                , Sql.Reader["Nombre"].ToString()
        //                , Sql.Reader["Descripcion"].ToString()
        //                , Convert.ToInt32(Sql.Reader["IdCiudad"])
        //                , Convert.ToInt32(Sql.Reader["IdBarrio"])
        //                , Sql.Reader["Direccion"].ToString()
        //                , Sql.Reader["Telefono1"].ToString()
        //                , Sql.Reader["Telefono2"].ToString()
        //                , Convert.ToInt32(Sql.Reader["Visible"])
        //                );
        //            oPa.Add(oPr);
        //        }
        //        Error = true;

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }

        //    return oPa;
        //}

        ///// <summary>
        ///// Filtra Personas por coincidencia de la primera letras.
        ///// OK 26/05/12
        ///// </summary>
        ///// <param name="Nombre"></param>
        ///// <returns></returns>
        //public List<grvPersona> FiltroPersona(classPersona oP)
        //{
        //    Error = false;
        //    List<grvPersona> oPa = new List<grvPersona>();

        //    #region Consulta

        //    string Consulta = "SELECT oP.IdPersona, oP.Nombre, oP.Apellido, oP.Direccion, oP.FechaNacimiento, " 
        //        + "oP.Sexo, oS.Nombre [ObraSocial], oP.nAfiliado, oP.IdTipoPersona"
        //        + " FROM Persona as oP INNER JOIN  ObraSocial as oS ON   oP.IdObraSocial = oS.IdObraSocial ";
            
        //    if (oP.nAfiliado != "" && oP.Apellido != "")
        //    {
        //        Consulta += " WHERE oP.Apellido LIKE '" + oP.Apellido 
        //            + "%' AND oP.nAfiliado LIKE '" + oP.nAfiliado + "%' ";
        //    }
        //    else if (oP.Apellido != "")
        //    {   // OK 21/03/12
        //        Consulta += " WHERE oP.Apellido LIKE '" + oP.Apellido + "%' ";
        //    }
        //    else if (oP.nAfiliado != "")
        //    {   // OK 21/03/12
        //        Consulta += " WHERE oP.nAfiliado LIKE '" + oP.nAfiliado + "%'";  
        //    }
        //    else
        //    {   // OK 21/03/12
        //        Consulta += " WHERE oP.IdObraSocial = " + oP.ObraSocial ;
        //    }

        //    if (oP.ObraSocial != 1)
        //    {
        //        Consulta += " AND oP.IdObraSocial = " + oP.ObraSocial + " ORDER BY oP.Apellido;";
        //    }
        //    else
        //    {
        //        Consulta += " ORDER BY oP.Apellido;";
        //    }
        //    #endregion

        //    if (Sql.SelectReaderDB(Consulta, null, "FiltroPaciente"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            grvPersona oPr = new grvPersona(
        //                  Convert.ToInt32(Sql.Reader["IdPersona"])
        //                , Sql.Reader["ObraSocial"].ToString()
        //                , Convert.ToInt32(Sql.Reader["IdTipoPersona"])
        //                , Sql.Reader["Nombre"].ToString()
        //                , Sql.Reader["Apellido"].ToString()
        //                , Sql.Reader["Direccion"].ToString()
        //                , Convert.ToDateTime(Sql.Reader["FechaNacimiento"])
        //                , oP.toSexo(Convert.ToInt32(Sql.Reader["Sexo"]))
        //                , Sql.Reader["nAfiliado"].ToString()
        //                );
        //            /*
        //            oPr.IdPersona = Convert.ToInt32(Sql.Reader["IdPersona"]);
        //            oPr.ObraSocial = Sql.Reader["ObraSocial"].ToString();
        //            oPr.TipoPaciente = Convert.ToInt32(Sql.Reader["IdTipoPersona"]);
        //            oPr.Nombre = Sql.Reader["Nombre"].ToString();
        //            oPr.Apellido = Sql.Reader["Apellido"].ToString();
        //            oPr.Direccion = Sql.Reader["Direccion"].ToString();
        //            oPr.FechaNac = Convert.ToDateTime(Sql.Reader["FechaNacimiento"]);
        //            oPr.Sexo = Convert.ToInt32(Sql.Reader["Sexo"]);
        //            oPr.nAfiliado = Sql.Reader["nAfiliado"].ToString();
        //            */
        //            oPa.Add(oPr);
        //        }
        //        Error = true;

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return oPa;
        //}

        ///// <summary>
        ///// Filtra Personas por coincidencia de la primera letras.
        ///// OK 26/05/12
        ///// </summary>
        ///// <param name="Nombre"></param>
        ///// <returns></returns>
        //public List<grvPersona> FiltroPersonaLimite(classPersona oP, int Desde, int Hasta)
        //{
        //    Error = false;
        //    List<grvPersona> oPa = new List<grvPersona>();

        //    #region Consulta

        //    string Consulta = "SELECT oP.IdPersona, oP.Nombre, oP.Apellido, oP.Direccion, oP.FechaNacimiento, "
        //        + "oP.Sexo, oS.Nombre [ObraSocial], oP.nAfiliado, oP.IdTipoPersona"
        //        + " FROM Persona as oP INNER JOIN  ObraSocial as oS ON   oP.IdObraSocial = oS.IdObraSocial ";

        //    if (oP.nAfiliado != "" && oP.Apellido != "")
        //    {
        //        Consulta += " WHERE oP.Apellido LIKE '" + oP.Apellido
        //            + "%' AND oP.nAfiliado LIKE '" + oP.nAfiliado + "%' ";
        //    }
        //    else if (oP.Apellido != "")
        //    {   // OK 21/03/12
        //        Consulta += " WHERE oP.Apellido LIKE '" + oP.Apellido + "%' ";
        //    }
        //    else if (oP.nAfiliado != "")
        //    {   // OK 21/03/12
        //        Consulta += " WHERE oP.nAfiliado LIKE '" + oP.nAfiliado + "%'";
        //    }
        //    else
        //    {   // OK 21/03/12
        //        //Consulta += " WHERE oP.IdObraSocial = " + oP.ObraSocial;
        //    }

        //    if (oP.ObraSocial != 1)
        //    {
        //        Consulta += " AND oP.IdObraSocial = " + oP.ObraSocial + " ORDER BY oP.Apellido";
        //    }
        //    else
        //    {
        //        Consulta += " ORDER BY oP.Apellido";
        //    }

        //    Consulta += " LIMIT " + Desde + ", " + Hasta + " ;";
        //    #endregion

        //    if (Sql.SelectReaderDB(Consulta, null, "FiltroPacienteLimite"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            grvPersona oPr = new grvPersona(
        //                  Convert.ToInt32(Sql.Reader["IdPersona"])
        //                , Sql.Reader["ObraSocial"].ToString()
        //                , Convert.ToInt32(Sql.Reader["IdTipoPersona"])
        //                , Sql.Reader["Nombre"].ToString()
        //                , Sql.Reader["Apellido"].ToString()
        //                , Sql.Reader["Direccion"].ToString()
        //                , Convert.ToDateTime(Sql.Reader["FechaNacimiento"])
        //                , oP.toSexo(Convert.ToInt32(Sql.Reader["Sexo"]))
        //                , Sql.Reader["nAfiliado"].ToString()
        //                );
        //            /*
        //            oPr.IdPersona = Convert.ToInt32(Sql.Reader["IdPersona"]);
        //            oPr.ObraSocial = Sql.Reader["ObraSocial"].ToString();
        //            oPr.TipoPaciente = Convert.ToInt32(Sql.Reader["IdTipoPersona"]);
        //            oPr.Nombre = Sql.Reader["Nombre"].ToString();
        //            oPr.Apellido = Sql.Reader["Apellido"].ToString();
        //            oPr.Direccion = Sql.Reader["Direccion"].ToString();
        //            oPr.FechaNac = Convert.ToDateTime(Sql.Reader["FechaNacimiento"]);
        //            oPr.Sexo = Convert.ToInt32(Sql.Reader["Sexo"]);
        //            oPr.nAfiliado = Sql.Reader["nAfiliado"].ToString();
        //            */
        //            oPa.Add(oPr);
        //        }
        //        Error = true;

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return oPa;
        //}

        ///// <summary>
        ///// Trae todos los turnos del personas seleccionado.
        ///// OK 24/05/12 MOdificar estado
        ///// </summary>
        ///// <param name="oT"></param>
        ///// <returns></returns>
        //public List<grvTurnos> FiltroTurnos(classTurnos oT)
        //{
        //    List<grvTurnos> oTa = new List<grvTurnos>();

        //    string Consulta = "SELECT oT.IdTurno, oT.IdPersona, oT.Fecha, oE.Nombre, oU.Nombre [Usuario], "
        //        + " (oP.Apellido||', '||oP.Nombre)[Paciente] "
        //        + " FROM Turno AS oT INNER JOIN Estadoturno AS oE ON oT.IdEstadoTurno = oE.IdEstadoTurno "
        //        + " INNER JOIN Usuario AS oU ON oU.Idusuario = oT.IdUsuario "
        //        + " INNER JOIN Persona AS oP ON oP.IdPersona = oT.IdPersona"
        //        + " WHERE oT.IdPersona = " + oT.IdPersona + " AND oU.IdUsuario= " + oT.IdUsuario + "  ORDER BY oT.Fecha;";

        //    if (Sql.SelectReaderDB(Consulta , null, "SelectGrillaTurnos"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            grvTurnos oTr = new grvTurnos();
        //            oTr.Id = Convert.ToInt32(Sql.Reader["IdTurno"]);
        //            oTr.EstadoNombre = Sql.Reader["Nombre"].ToString();
        //            oTr.IdPaciente = Convert.ToInt32(Sql.Reader["IdPersona"]);
        //            oTr.Usuario = Sql.Reader["Usuario"].ToString();
        //            oTr.Paciente = Sql.Reader["Paciente"].ToString();

        //            DateTime A = Convert.ToDateTime(Sql.Reader["Fecha"]);
        //            oTr.Dia = A.ToLongDateString();
        //            oTr.Hora = A.ToLongTimeString();

        //            oTa.Add(oTr);
        //        }

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }

        //    return oTa;
        //}

        ///// <summary>
        ///// Trae todos los turnos del personas seleccionado.
        ///// OK 24/05/12 MOdificar estado
        ///// </summary>
        ///// <param name="oT"></param>
        ///// <returns></returns>
        //public List<grvTurnos> FiltroTurnosLimite(classTurnos oT, int Desde, int Hasta)
        //{
        //    List<grvTurnos> oTa = new List<grvTurnos>();

        //    string Consulta = "SELECT oT.IdTurno, oT.IdPersona, oT.Fecha, oE.Nombre, oU.Nombre [Usuario], "
        //        + " (oP.Apellido||', '||oP.Nombre)[Paciente] "
        //        + " FROM Turno AS oT INNER JOIN Estadoturno AS oE ON oT.IdEstadoTurno = oE.IdEstadoTurno "
        //        + " INNER JOIN Usuario AS oU ON oU.Idusuario = oT.IdUsuario "
        //        + " INNER JOIN Persona AS oP ON oP.IdPersona = oT.IdPersona"
        //        + " WHERE oT.IdPersona = " + oT.IdPersona + " AND oU.IdUsuario= " + oT.IdUsuario 
        //        + "  ORDER BY oT.Fecha LIMIT " + Desde + ", " + Hasta +" ;";

        //    if (Sql.SelectReaderDB(Consulta, null, "SelectGrillaTurnos"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            grvTurnos oTr = new grvTurnos();
        //            oTr.Id = Convert.ToInt32(Sql.Reader["IdTurno"]);
        //            oTr.EstadoNombre = Sql.Reader["Nombre"].ToString();
        //            oTr.IdPaciente = Convert.ToInt32(Sql.Reader["IdPersona"]);
        //            oTr.Usuario = Sql.Reader["Usuario"].ToString();
        //            oTr.Paciente = Sql.Reader["Paciente"].ToString();

        //            DateTime A = Convert.ToDateTime(Sql.Reader["Fecha"]);
        //            oTr.Dia = A.ToLongDateString();
        //            oTr.Hora = A.ToLongTimeString();

        //            oTa.Add(oTr);
        //        }

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }

        //    return oTa;
        //}

        ///// <summary>
        ///// Trae todos los turnos del personas seleccionado.
        ///// OK 15/06/12
        ///// </summary>
        ///// <param name="oT"></param>
        ///// <returns></returns>
        //public List<grvTurnos> FiltroTurnosDelDia(DateTime Desde, DateTime Hasta, int IdUsuario)
        //{
        //    List<grvTurnos> oTa = new List<grvTurnos>();

        //    string Consulta = "SELECT oT.IdTurno, oT.IdPersona, oT.Fecha, oE.Nombre, oU.Nombre [Usuario], "
        //        + " (oP.Apellido||', '||oP.Nombre)[Paciente] "
        //        + " FROM Turno AS oT INNER JOIN Estadoturno AS oE ON oT.IdEstadoTurno = oE.IdEstadoTurno "
        //        + " INNER JOIN Usuario AS oU ON oU.Idusuario = oT.IdUsuario "
        //        + " INNER JOIN Persona AS oP ON oP.IdPersona = oT.IdPersona"
        //        + " WHERE Fecha BETWEEN '" + String.Format("{0:yyyy'-'MM'-'dd}", Desde)
        //        + "' AND '" + String.Format("{0:yyyy'-'MM'-'dd}", Hasta) + "' AND oU.IdUsuario= " + IdUsuario +  ";";

        //    if (Sql.SelectReaderDB(Consulta , null, "selectGrillaTurnos"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            grvTurnos oTr = new grvTurnos();
        //            oTr.Id = Convert.ToInt32(Sql.Reader["IdTurno"]);
        //            oTr.EstadoNombre = Sql.Reader["Nombre"].ToString();
        //            oTr.IdPaciente = Convert.ToInt32(Sql.Reader["IdPersona"]);
        //            oTr.Usuario = Sql.Reader["Usuario"].ToString();
        //            oTr.Paciente = Sql.Reader["Paciente"].ToString();

        //            string CV = Sql.Reader["Fecha"].ToString();
        //            DateTime A = Convert.ToDateTime(CV);
        //            oTr.Dia = A.ToLongDateString();
        //            oTr.Hora = A.ToLongTimeString();

        //            oTa.Add(oTr);
        //        }

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }

        //    return oTa;
        //}

        ///// <summary>
        ///// Trae todos los turnos del personas seleccionado.
        ///// OK 15/06/12
        ///// </summary>
        ///// <param name="oT"></param>
        ///// <returns></returns>
        //public List<grvTurnos> FiltroTurnosDelDiaLimite(DateTime FechaDesde, DateTime FechaHasta, int IdUsuario, 
        //    int Desde, int Hasta)
        //{
        //    List<grvTurnos> oTa = new List<grvTurnos>();

        //    string Consulta = "SELECT oT.IdTurno, oT.IdPersona, oT.Fecha, oE.Nombre, oU.Nombre [Usuario], "
        //        + " (oP.Apellido||', '||oP.Nombre)[Paciente] "
        //        + " FROM Turno AS oT INNER JOIN Estadoturno AS oE ON oT.IdEstadoTurno = oE.IdEstadoTurno "
        //        + " INNER JOIN Usuario AS oU ON oU.Idusuario = oT.IdUsuario "
        //        + " INNER JOIN Persona AS oP ON oP.IdPersona = oT.IdPersona"
        //        + " WHERE oT.Fecha BETWEEN '" + String.Format("{0:yyyy'-'MM'-'dd}", FechaDesde)
        //        + "' AND '" + String.Format("{0:yyyy'-'MM'-'dd}", FechaHasta) + "' AND oU.IdUsuario= " + IdUsuario 
        //        + " LIMIT " + Desde + ", " + Hasta +" ;";

        //    if (Sql.SelectReaderDB(Consulta, null, "selectGrillaTurnos"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            grvTurnos oTr = new grvTurnos();
        //            oTr.Id = Convert.ToInt32(Sql.Reader["IdTurno"]);
        //            oTr.EstadoNombre = Sql.Reader["Nombre"].ToString();
        //            oTr.IdPaciente = Convert.ToInt32(Sql.Reader["IdPersona"]);
        //            oTr.Usuario = Sql.Reader["Usuario"].ToString();
        //            oTr.Paciente = Sql.Reader["Paciente"].ToString();

        //            string CV = Sql.Reader["Fecha"].ToString();
        //            DateTime A = Convert.ToDateTime(CV);
        //            oTr.Dia = A.ToLongDateString();
        //            oTr.Hora = A.ToLongTimeString();

        //            oTa.Add(oTr);
        //        }

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }

        //    return oTa;
        //}

        #endregion

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

        //    if (Sql.SelectReaderDB(Consulta, null, "ePacientes"))
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
        //        Sql.Desconectar();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Desconectar();
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

        //    if (Sql.SelectReaderDB(Consulta, null, "eDiagnoticos"))
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
        //        Sql.Desconectar();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Desconectar();
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

        //    if (Sql.SelectReaderDB(Consulta, null, "eObraSocial"))
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
        //        Sql.Desconectar();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Desconectar();
        //        return false;
        //    }
        //}

        //#endregion

        //// OK 21/06/12
        //#region Consulta Reportes

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

        //    if (Sql.SelectReaderDB(Consulta, null, "rTurnos"))
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
        //        Sql.Desconectar();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Desconectar();
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

        //    if (Sql.SelectReaderDB(Consulta, null, "rTurnosLimite"))
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
        //        Sql.Desconectar();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Desconectar();
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

        //    if (Sql.SelectReaderDB(Consulta, null, "rTurnosDelDia"))
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
        //        Sql.Desconectar();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Desconectar();
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

        //    if (Sql.SelectReaderDB(Consulta, null, "rTurnosDelDiaLimite"))
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
        //        Sql.Desconectar();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Desconectar();
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

        //    if (Sql.SelectReaderDB(Consulta, null, "rHistoriaClinica"))
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
        //        Sql.Desconectar();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Desconectar();
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

        //    if (Sql.SelectReaderDB(Consulta, null, "rListaPacientes"))
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
        //        Sql.Desconectar();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Desconectar();
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

        //    if (Sql.SelectReaderDB(Consulta, null, "rListaPacientes"))
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
        //        Sql.Desconectar();

        //        Table = TablaAuxiliar;
        //        return true;
        //    }
        //    else
        //    {
        //        Sql.Desconectar();
        //        return false;
        //    }
        //}

        #endregion

        #endregion

        #region AGREGADOS MARCOS CARRERAS
        #region Consultas ProfessionalSpeciality

        /// <summary>
        /// OK - 17/09/02
        /// Inserta una ProfessionalSpeciality.
        /// </summary>
        /// <param name="oPsy">ProfessionalSpeciality</param>
        /// <returns>Error</returns>
        public bool AddProfessionalSpeciality(classProfessionalSpeciality oPsy)
        {
            bool error;

            error = Sql.InsertDB("INSERT INTO ProfessionalSpeciality (IdProfessional, IdSpeciality, Visible) VALUES (" + oPsy.IdProfessional + "," + oPsy.IdSpeciality + "," +oPsy.Visible +");",
                Sql.Parametros, "AddProfessionalSpeciality");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Modifica una ProfessionalSpeciality.
        /// </summary>
        /// <param name="oPs">Specialty</param>
        /// <returns>Error</returns>
        public bool UpdateProfessionalSpeciality(classProfessionalSpeciality oPs)
        {
            bool error;

            error = Sql.InsertDB("UPDATE ProfessionalSpeciality SET IdProfessional = " + oPs.IdProfessional + "," + "IdSpeciality = '" + oPs.IdSpeciality + ", Visible = " + Convert.ToInt32(oPs.Visible) + " WHERE IdProfessionalSpeciality = " + oPs.IdProfessionalSpeciality + ";",
                null, "UpdateSpecialty");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Elimina de forma definitiva o Actualiza el campo visible de una ProfessionalSpeciality. 
        /// </summary>
        /// <param name="oPs"></param>
        /// <param name="Delete">Delete o Update state</param>
        /// <returns>Error</returns>
        public bool DeleteProfessionalSpeciality(classProfessionalSpeciality oPs, bool Delete)
        {
            bool error;

            if (Delete)
                error = Sql.DeleteDB("DELETE ProfessionalSpeciality WHERE IdProfessionalSpeciality = " + oPs.IdProfessionalSpeciality + " ;", null, "DeleteProfessionalSpeciality");
            else
                error = Sql.InsertDB("UPDATE ProfessionalSpeciality SET Visible = 0 WHERE IdProfessionalSpeciality = " + oPs.IdProfessionalSpeciality + " ;", null, "DeleteProfessionalSpeciality");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Carga una Combo con ProfessionalSpeciality
        /// </summary>
        /// <returns></returns>
        public bool ListProfessionalSpeciality(bool Filtro)
        {
            #region Consulta

            string Consulta = "SELECT IdProfessionalSpeciality[Id], IdProfessional[Valor] FROM ProfessionalSpeciality WHERE Visible = 1 ";

            if (Filtro)
                Consulta += " ORDER BY IdProfessional";
            else
                Consulta += " AND IdSpecialty BETWEEN 2 AND (SELECT MAX(I.IdProfessionalSpeciality) FROM Specialty AS I) " +
                    " ORDER BY IdProfessional";

            #endregion

            if (Sql.SelectAdapterDB(Consulta, "ListProfessionalSpeciality"))
            {
                DataSet set = new DataSet();
                Table = new DataTable();
                set.Reset();
                Sql.Adapter.Fill(set);
                Table = set.Tables[0];
                Sql.Desconectar();
                return true;
            }
            else
            {
                Sql.Desconectar();
                return false;
            }
        }

        #endregion

        #region Consultas ParentRelationship

        /// <summary>
        /// OK - 17/09/02
        /// Inserta una ParentRelationship.
        /// </summary>
        /// <param name="oPr">ParentRelationship</param>
        /// <returns>Error</returns>
        public bool AddParentRelationship(classParentRelationship oPr)
        {
            bool error;

            error = Sql.InsertDB("INSERT INTO ParentRelationship (IdParent, IdRelationship,Visible) VALUES (" + oPr.IdParent + "," + oPr.IdRelationship + "," +oPr.Visible+");",
                Sql.Parametros, "AddParentRelationship");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Modifica una ParentRelationship.
        /// </summary>
        /// <param name="oPs">Specialty</param>
        /// <returns>Error</returns>
        public bool UpdateParentRelationship(classParentRelationship oPs)
        {
            bool error;

            error = Sql.InsertDB("UPDATE ParentRelationship SET IdParent = " + oPs.IdParent + "," + "IdRelationship = '" + oPs.IdRelationship + ", Visible = " + Convert.ToInt32(oPs.Visible) + " WHERE IdParentRelationship = " + oPs.IdParentRelationship + ";",
                null, "UpdateSpecialty");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Elimina de forma definitiva o Actualiza el campo visible de una ParentRelationship. 
        /// </summary>
        /// <param name="oPs"></param>
        /// <param name="Delete">Delete o Update state</param>
        /// <returns>Error</returns>
        public bool DeleteParentRelationship(classParentRelationship oPs, bool Delete)
        {
            bool error;

            if (Delete)
                error = Sql.DeleteDB("DELETE ParentRelationship WHERE IdParentRelationship = " + oPs.IdParentRelationship + " ;", null, "DeleteParentRelationship");
            else
                error = Sql.InsertDB("UPDATE ParentRelationship SET Visible = 0 WHERE IdParentRelationship = " + oPs.IdParentRelationship + " ;", null, "DeleteParentRelationship");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Carga una Combo con ParentRelationship
        /// </summary>
        /// <returns></returns>
        public bool ListParentRelationship(bool Filtro)
        {
            #region Consulta

            string Consulta = "SELECT IdParentRelationship[Id], IdParent[Valor] FROM ParentRelationship WHERE Visible = 1 ";

            if (Filtro)
                Consulta += " ORDER BY IdParent";
            else
                Consulta += " AND IdSpecialty BETWEEN 2 AND (SELECT MAX(I.IdParentRelationship) FROM Specialty AS I) " +
                    " ORDER BY IdParent";

            #endregion

            if (Sql.SelectAdapterDB(Consulta, "ListParentRelationship"))
            {
                DataSet set = new DataSet();
                Table = new DataTable();
                set.Reset();
                Sql.Adapter.Fill(set);
                Table = set.Tables[0];
                Sql.Desconectar();
                return true;
            }
            else
            {
                Sql.Desconectar();
                return false;
            }
        }

        #endregion

        #region Consultas Diagnostic

        /// <summary>
        /// OK - 17/09/02
        /// Inserta una Diagnostic.
        /// </summary>
        /// <param name="oDc">Diagnostic</param>
        /// <returns>Error</returns>
        public bool AddDiagnostic(classDiagnostic oDc)
        {
            bool error;

            error = Sql.InsertDB("INSERT INTO Diagnostic (IdDiagnostic, IdSpeciality, Detail, DiagnosticDate, Visible) VALUES (" + oDc.IdDiagnostic + ","+ oDc.IdSpeciality +",'"+ oDc.Detail+"','"+oDc.DiagnosticDate+"',"+oDc.Visible+");",
                Sql.Parametros, "AddDiagnostic");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Modifica una Diagnostic.
        /// </summary>
        /// <param name="oPs">Specialty</param>
        /// <returns>Error</returns>
        public bool UpdateDiagnostic(classDiagnostic oPs)
        {
            bool error;

            error = Sql.InsertDB("UPDATE Diagnostic SET IdDiagnostic = " + oPs.IdDiagnostic + "," +
                                                       "IdSpeciality = " + oPs.IdSpeciality + ","+
                                                       "Detail = '" + oPs.Detail + "'," +
                                                       "DiagnosticDate = '" + oPs.DiagnosticDate + "'," +
                                                       "Visible = " + Convert.ToInt32(oPs.Visible) +
                                                       " WHERE IdDiagnostic = " + oPs.IdDiagnostic + ";",
                null, "UpdateSpecialty");

            Menssage = Sql.Mensaje;
            return error;
        }

        /// <summary>
        /// OK - 17/09/02
        /// Elimina de forma definitiva o Actualiza el campo visible de una Diagnostic. 
        /// </summary>
        /// <param name="oPs"></param>
        /// <param name="Delete">Delete o Update state</param>
        /// <returns>Error</returns>
        public bool DeleteDiagnostic(classDiagnostic oPs, bool Delete)
        {
            bool error;

            if (Delete)
                error = Sql.DeleteDB("DELETE Diagnostic WHERE IdDiagnostic = " + oPs.IdDiagnostic + " ;", null, "DeleteDiagnostic");
            else
                error = Sql.InsertDB("UPDATE Diagnostic SET Visible = 0 WHERE IdDiagnostic = " + oPs.IdDiagnostic + " ;", null, "DeleteDiagnostic");

            Menssage = Sql.Mensaje;
            return error;
        }

        public classDiagnostic SelectDiagnostic(classDiagnostic oD)
        {
            classDiagnostic oDa = new classDiagnostic();

            if (Sql.SelectReaderDB("SELECT IdDiagnostic, IdSpeciality, Detail, DiagnosticDate, Visible "
                + "FROM Diagnostic WHERE Visible = 1 AND IdDiagnostic = " + oD.IdDiagnostic + " ;",
                null,
                "selectDiagnostic"))
            {
                Sql.Reader.Read();

                classDiagnostic oDr = new classDiagnostic(
                    Convert.ToInt32(Sql.Reader["IdDiagnostic"])
                    , Convert.ToInt32(Sql.Reader["IdSpeciality"])
                    , Sql.Reader["Detail"].ToString()
                    , Convert.ToDateTime(Sql.Reader["DiagnosticDate"])
                    , Convert.ToBoolean(Sql.Reader["Visible"])

                    );

                oDa = oDr;

                Sql.Reader.Close();
                Sql.Desconectar();
            }
            return oDa;
        }
        /// <summary>
        /// OK - 17/09/02
        /// Carga una Combo con Diagnostic
        /// </summary>
        /// <returns></returns>
        public bool ListDiagnostic(bool Filtro)
        {
            #region Consulta

            string Consulta = "SELECT IdDiagnostic[Id], IdDiagnostic[Valor] FROM Diagnostic WHERE Visible = 1 ";

            if (Filtro)
                Consulta += " ORDER BY IdDiagnostic";
            else
                Consulta += " AND IdSpecialty BETWEEN 2 AND (SELECT MAX(I.IdDiagnostic) FROM Specialty AS I) " +
                    " ORDER BY IdDiagnostic";

            #endregion

            if (Sql.SelectAdapterDB(Consulta, "ListDiagnostic"))
            {
                DataSet set = new DataSet();
                Table = new DataTable();
                set.Reset();
                Sql.Adapter.Fill(set);
                Table = set.Tables[0];
                Sql.Desconectar();
                return true;
            }
            else
            {
                Sql.Desconectar();
                return false;
            }
        }

        #endregion



        #endregion

        public List<classProfessional> FiltroUsuarioLimite(string p1, bool p2, int p3, int p4)
        {
            throw new NotImplementedException();
        }

        public decimal CountProfesionales(string p1, bool p2)
        {
            throw new NotImplementedException();
        }

        public decimal CountSocialWork(string p)
        {
            throw new NotImplementedException();
        }

        public List<classSocialWork> FiltroSocialWorkLimite(string p1, int p2, int p3)
        {
            throw new NotImplementedException();
        }

        public bool rListaGrandfatherLimite(string p1, classGrandfather oP, int p2, int p3)
        {
            throw new NotImplementedException();
        }

        public decimal CountGrandfather(classGrandfather oPersona)
        {
            throw new NotImplementedException();
        }

        public List<Entidades.Clases.Grillas.grvGrandfather> FiltroGrandfatherLimite(classGrandfather oPersona, int p1, int p2)
        {
            throw new NotImplementedException();
        }
    }
}

/*
 * Formatos DateTime
 * http://www.csharp-examples.net/string-format-datetime/
 * 
 * 
 * 
 */
