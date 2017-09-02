using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.IO;
using Entidades;
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

        #region CONSULTAS COMETADAS

        //// OK 07/06/12
        //#region Consultas Comboboxes

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

        ///// <summary>
        ///// Carga una Combo con Patologias (Tabla detalle)
        ///// OK 26/05/12
        ///// </summary>
        ///// <returns></returns>
        //public bool ListaPatologias()
        //{
        //    if (Sql.SelectAdapterDB("SELECT IdDetalle[Id], Nombre[Valor] FROM Detalle WHERE Visible = 1 ORDER BY Nombre",
        //        "ListaPatologias"))
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
        ///// Carga una Combo con Barrios
        ///// OK 25/05/12
        ///// </summary>
        ///// <returns></returns>
        //public bool ListaBarrios(int IdCiudad)
        //{
        //    if (Sql.SelectAdapterDB("SELECT iIdBarrio[Id], Nombre[Valor] FROM Barrio WHERE Visible = 1 AND IdCiudad = " + IdCiudad + " ORDER BY Nombre; "
        //        , "ListaBarrios"))
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
        ///// Carga una Combo con Ciudades
        ///// OK 25/05/12
        ///// </summary>
        ///// <returns></returns>
        //public bool ListaCiudades()
        //{
        //    if (Sql.SelectAdapterDB("SELECT IdCiudad[Id], Nombre[Valor] FROM Ciudad WHERE Visible = 1 ORDER BY Nombre", "ListaCiudades"))
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
        //public bool ListaObraSociales(bool Filtro)
        //{
        //    #region Consulta

        //    string Consulta = "SELECT IdObraSocial[Id], Nombre[Valor] FROM ObraSocial WHERE Visible = 1 ";

        //    if (Filtro)
        //        Consulta += " ORDER BY Nombre";
        //    else
        //        Consulta += " AND IdObraSocial BETWEEN 2 AND (SELECT MAX(I.IdObraSocial) FROM ObraSocial AS I) " +
        //            " ORDER BY Nombre";

        //    #endregion

        //    if (Sql.SelectAdapterDB(Consulta, "ListaObraSociales"))
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
        ///// Carga una Combo con Personas
        ///// OK 21/03/12
        ///// </summary>
        ///// <returns></returns>
        //public bool ListaTipoDePersonas()
        //{
        //    if (Sql.SelectAdapterDB("SELECT IdTipoPersona[Id], Nombre[Valor] FROM TipoPersona ORDER BY Nombre",
        //        "ListaTipoDePersonas"))
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

        //#endregion

        //// OK 26/05/12
        //#region Consulta Diagnostico

        //// Revisado OK 25/05/12
        //public DateTime UltimaVisita(classPersona oP)
        //{
        //    DateTime oD = DateTime.Now;

        //    if (Sql.SelectReaderDB("SELECT max(Fecha)[UltimaVisita]" +
        //                       " FROM Diagnostico WHERE IdPersona = " + oP.IdPersona + " ;",
        //                       null,
        //                       "UltimaVisita"))
        //    {

        //        Sql.Reader.Read();
        //        string re = Sql.Reader["UltimaVisita"].ToString();

        //        if (re != "")
        //            oD = Convert.ToDateTime(re);
        //        else
        //            oD = DateTime.Now;

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }

        //    return oD;
        //}

        //// Revisado OK 25/05/12
        //public DateTime PrimeraVisita(classPersona oP)
        //{
        //    DateTime oD = DateTime.Now;

        //    if (Sql.SelectReaderDB("SELECT min(Fecha)[PrimeraVisita]" +
        //                       " FROM Diagnostico WHERE IdPersona = " + oP.IdPersona + " ;",
        //                       null,
        //                       "PrimeraVisita"))
        //    {

        //        Sql.Reader.Read();
        //        string re = Sql.Reader["PrimeraVisita"].ToString();
        //        if (re != "")
        //            oD = Convert.ToDateTime(re);
        //        else
        //            oD = DateTime.Now;
        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }

        //    return oD;
        //}

        //// Revisado OK 25/05/12
        //public int CantidadVisitas(classPersona oP)
        //{
        //    int oD = 0;

        //    if (Sql.SelectReaderDB("SELECT count(Fecha)[CantVisita]" +
        //                       " FROM Diagnostico WHERE IdPersona = " + oP.IdPersona + " ;",
        //                       null,
        //                       "CantidadVisitas"))
        //    {
        //        Sql.Reader.Read();
        //        oD = Convert.ToInt32(Sql.Reader["CantVisita"]);
        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }

        //    return oD;
        //}

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

        //#endregion 

        //// OK 26/05/12
        //#region Consulta Persona

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

        //// OK 26/05/12
        //public bool AgregarPersona(classPersona oP, int IdUsuario)
        //{
        //    bool error;

        //    error = Sql.InsertDB(" INSERT INTO Persona (Nombre, Apellido, Direccion, FechaNacimiento,FechaAlta, Sexo, "
        //        + " IdObraSocial, nAfiliado, Visible, IdTipoPersona, IdCiudad, IdBarrio, Telefono, TelefonoParticular, IdUsuario)"
        //        + " VALUES ('" + oP.Nombre + "', '" + oP.Apellido + "', '" + oP.Direccion + "', '"
        //        + String.Format("{0:yyyy'-'MM'-'dd}", oP.FechaNac) + "' , '"
        //        + String.Format("{0:yyyy'-'MM'-'dd}", oP.FechaAlta) + "' , "
        //        + oP.Sexo + ", "
        //        + oP.ObraSocial + ", '" + oP.nAfiliado + "', " + 1 + ", " + oP.TipoPaciente
        //        + ", " + oP.IdCiudad + ", " + oP.IdBarrio + ", '" + oP.Telefono + "', '" + oP.TelefonoParticular
        //        + "', " + IdUsuario + " ); ",
        //        null,
        //        "AgregarPaciente");

        //    Menssage = Sql.Mensaje;

        //    return error;
        //}

        //// Revisado OK 26/05/12
        //public bool ModificarPersona(classPersona oP)
        //{
        //    bool error;

        //    error = Sql.UpdateDB("UPDATE Persona SET Nombre = '" + oP.Nombre + "', Apellido = '" + oP.Apellido
        //        + "', IdTipoPersona = " + oP.TipoPaciente + ", Direccion = '" + oP.Direccion
        //        + "', FechaNacimiento = '" + String.Format("{0:yyyy'-'MM'-'dd}", oP.FechaNac)
        //        + "', FechaAlta = '" + String.Format("{0:yyyy'-'MM'-'dd}", oP.FechaAlta)
        //        + "', Sexo = " + oP.Sexo + ", IdObraSocial = " + oP.ObraSocial + ", nAfiliado = '" + oP.nAfiliado
        //        + "', IdCiudad = " + oP.IdCiudad + ", IdBarrio = " + oP.IdBarrio
        //        + " , Telefono = '" + oP.Telefono + "', TelefonoParticular = '" + oP.TelefonoParticular
        //        + "' WHERE IdPersona = " + oP.IdPersona + ";", null, "ModificarPaciente");

        //    Menssage = Sql.Mensaje;

        //    return error;
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

        //#endregion

        //// OK 03/06/12
        //#region Consulta obraSocial

        ///// <summary>
        ///// OK 03/06/12
        ///// Inserta una Obra Social.
        ///// </summary>
        ///// <param name="oS"></param>
        ///// <returns></returns>
        //public bool AgregarObraSocial(classObraSocial oS)
        //{
        //    bool error;

        //    error = Sql.InsertDB("INSERT INTO ObraSocial (Nombre, Descripcion, IdCiudad, IdBarrio, Direccion, Telefono1, Telefono2, Visible) VALUES ('" 
        //        + oS.Nombre + "', '" + oS.Descripcion + "', " + oS.IdCiudad + ", " +oS.IdBarrio + ", '" + oS.Direccion 
        //        + "', '" + oS.Telefono1 + "', '" + oS.Telefono2 + "', " + oS.Visible + ");",
        //        Sql.Parametros,
        //        "AgregarObraSocial");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        ///// <summary>
        ///// OK 22/03/12
        ///// Actualiza una Obra Social.
        ///// </summary>
        ///// <param name="oS"></param>
        ///// <returns></returns>
        //public bool ModificarObraSocial(classObraSocial oS)
        //{
        //    bool error;

        //    error = Sql.InsertDB("UPDATE ObraSocial SET Nombre = '" + oS.Nombre + "', Descripcion = '" + oS.Descripcion
        //        + "', IdCiudad = " + oS.IdCiudad + ", Direccion = '" + oS.Direccion + "', IdBarrio = " + oS.IdBarrio
        //        + ", Telefono1 = '" +oS.Telefono1 + "',  Telefono2 = '" + oS.Telefono2 
        //        + "' WHERE IdObraSocial = " + oS.Id + ";",
        //        null,
        //        "ModificarObraSocial");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        ///// <summary>
        ///// OK 03/06/12
        ///// Elimina de forma definitiva o Actualiza el campo visible de una Obra Social. 
        ///// </summary>
        ///// <param name="oS"></param>
        ///// <param name="Eliminar"></param>
        ///// <returns></returns>
        //public bool EliminarObraSocial(classObraSocial oS, bool Eliminar)
        //{
        //    bool error;

        //    if (Eliminar)
        //        error = Sql.DeleteDB("DELETE ObraSocial WHERE IdObraSocial = " + oS.Id + " ;", null, "EliminarObraSocial");
        //    else
        //        error = Sql.InsertDB("UPDATE ObraSocial SET Visible = 0 WHERE IdObraSocial = " + oS.Id + " ;", null, "EliminarObraSocial");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

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
        //        + "FROM ObraSocial WHERE IdObraSocial = " + oS.Id + " AND Visible = " + oS.Visible  +
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

        //#endregion

        //// OK 31/05/12
        //#region Consulta Turnos

        ///// <summary>
        ///// OK 24/06/12
        ///// Cuenta Obras Sociales.
        ///// </summary>
        ///// <returns></returns>
        //public int CountTurnosDelDia(DateTime FechaDesde, DateTime FechaHasta, int IdUsuario)
        //{
        //    int C = 0;

        //    #region Consulta

        //    string Consulta = "SELECT COUNT(oT.IdTurno)[C] FROM Turno AS oT "
        //        + " INNER JOIN Usuario AS oU ON oU.Idusuario = oT.IdUsuario "
        //        + " WHERE oT.Fecha BETWEEN '" + String.Format("{0:yyyy'-'MM'-'dd}", FechaDesde)
        //        + "' AND '" + String.Format("{0:yyyy'-'MM'-'dd}", FechaHasta) + "' AND oU.IdUsuario= " + IdUsuario + " ;";

        //    #endregion

        //    if (Sql.SelectReaderDB(Consulta, null, "CountTurnosDelDia"))
        //    {
        //        Sql.Reader.Read();
        //        C = Convert.ToInt32(Sql.Reader["C"]);
        //        Sql.Reader.Close();
        //        Error = true;
        //        Sql.Desconectar();
        //    }
        //    return C;
        //}

        ///// <summary>
        ///// OK 24/06/12
        ///// Cuenta Obras Sociales.
        ///// </summary>
        ///// <returns></returns>
        //public int CountTurnos(classTurnos oT)
        //{
        //    int C = 0;

        //    #region Consulta

        //    string Consulta = "SELECT COUNT(oT.IdTurno)[C] FROM Turno AS oT "
        //        + " INNER JOIN Usuario AS oU ON oU.Idusuario = oT.IdUsuario "
        //        + " WHERE oT.IdPersona = " + oT.IdPersona + " AND oU.IdUsuario= " + oT.IdUsuario;

        //    #endregion

        //    if (Sql.SelectReaderDB(Consulta, null, "CountTurnos"))
        //    {
        //        Sql.Reader.Read();
        //        C = Convert.ToInt32(Sql.Reader["C"]);
        //        Sql.Reader.Close();
        //        Error = true;
        //        Sql.Desconectar();
        //    }
        //    return C;
        //}

        ///// <summary>
        ///// OK 23/04/12
        ///// Inserta un Turno.
        ///// </summary>
        ///// <param name="oS"></param>
        ///// <returns></returns>
        //public bool AgregarTurno(classTurnos oT)
        //{
        //    bool error;
        //    string Consulta = "INSERT INTO Turno (IdPersona, Fecha, IdEstadoTurno, IdUsuario)"
        //        + "VALUES (" + oT.IdPersona + ", '" + String.Format("{0:yyyy'-'MM'-'dd' 'HH':'mm}", oT.Turno) + "', '"
        //        + oT.Estado + "', " + oT.IdUsuario + " );";


        //    error = Sql.InsertDB(Consulta, null, "AgregarTurno");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}


        ///// <summary>
        ///// Trae todos los turnos del paciente seleccionado.
        ///// OK 230412
        ///// </summary>
        ///// <param name="oT"></param>
        ///// <returns></returns>
        //public List<classTurnos> SelectTurnos(classTurnos oT)
        //{
        //    List<classTurnos> oTa = new List<classTurnos>();

        //    if (Sql.SelectReaderDB("SELECT IdTurno, IdPersona, Fecha, IdEstadoTurno, IdUsuario "
        //        + " FROM Turno WHERE IdPersona = " + oT.IdPersona + ";",
        //        null,
        //        "selectTurnos"))
        //    {
        //        while (Sql.Reader.Read())
        //        {
        //            classTurnos oTr = new classTurnos(
        //                Convert.ToInt32(Sql.Reader["IdTurno"])
        //                , Convert.ToDateTime(Sql.Reader["Fecha"])
        //                , Convert.ToInt32(Sql.Reader["IdEstadoTurno"])
        //                , Convert.ToInt32(Sql.Reader["IdPersona"])
        //                , Convert.ToInt32(Sql.Reader["IdUsuario"])
        //                );
        //            oTa.Add(oTr);
        //        }

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return oTa;
        //}

        ///// <summary>
        ///// Trae los datos de un turnos seleccionado.
        ///// OK 230412
        ///// </summary>
        ///// <param name="oT"></param>
        ///// <returns></returns>
        //public classTurnos SelectTurno(classTurnos oT)
        //{
        //    classTurnos oTr = new classTurnos();

        //    if (Sql.SelectReaderDB("SELECT IdTurno, IdPersona, Fecha, IdEstadoTurno, IdUsuario "
        //        + " FROM Turno WHERE IdTurno = " + oT.Id + ";",
        //        null,
        //        "selectTurno"))
        //    {
        //        Sql.Reader.Read();
        //        oTr = new classTurnos(
        //            Convert.ToInt32(Sql.Reader["IdTurno"])
        //            , Convert.ToDateTime(Sql.Reader["Fecha"])
        //            , Convert.ToInt32(Sql.Reader["IdEstadoTurno"])
        //            , Convert.ToInt32(Sql.Reader["IdPersona"])
        //            , Convert.ToInt32(Sql.Reader["IdUsuario"])
        //            );

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return oTr;
        //}

        ///// <summary>
        ///// Modifica el turno.
        ///// </summary>
        ///// <param name="oT"></param>
        ///// <returns></returns>
        //public bool ModificarTurno(classTurnos oT)
        //{
        //    bool error;

        //    error = Sql.UpdateDB("UPDATE Turno SET Fecha = '" + String.Format("{0:yyyy'-'MM'-'dd' 'HH':'mm}", oT.Turno)
        //        + "', IdEstadoTurno = " + oT.Estado + ", IdUsuario = " + oT.IdUsuario + " WHERE IdTurno = " + oT.Id + " ;",
        //        null, "ModificarTurno");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        ///// <summary>
        ///// CHEKEAR SI FUNCIONA 22/03/12
        ///// Elimina de forma definitiva o Actualiza el campo visible de una Obra Social. 
        ///// </summary>
        ///// <param name="oS"></param>
        ///// <param name="Eliminar"></param>
        ///// <returns></returns>
        //public bool EliminarTurno(classTurnos oT, bool Eliminar)
        //{
        //    bool error;

        //    if (Eliminar)
        //        error = Sql.DeleteDB("DELETE FROM Turno WHERE IdTurno = " + oT.Id + " ;", null, "EliminarTurno");
        //    else
        //        error = Sql.InsertDB("UPDATE FROM Turno SET Estado = 0 WHERE IdTurno = " + oT.Id + " ;", null, "EliminarTurno");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        //#endregion

        //// OK 03/06/12
        //#region Consulta Patologias

        ///// <summary>
        ///// Elimina de forma definitiva o Actualiza el campo visible de Patologias
        ///// Eliminar: True-> Elimina
        /////           False-> Modifica Estado "No Elimina"
        ///// OK 03/06/12
        ///// </summary>
        ///// <param name="oP"></param>
        ///// <param name="Eliminar"></param>
        ///// <returns></returns>
        //public bool EliminarPatologia(classPatologia oP, bool Eliminar)
        //{
        //    bool error;

        //    if (Eliminar)
        //        error = Sql.DeleteDB("DELETE FROM Detalle WHERE IdDetalle = " + oP.IdDetalle + " ;", null, "EliminarDetalle");
        //    else
        //        error = Sql.UpdateDB("UPDATE Detalle SET Visible = 0 WHERE IdDetalle = " + oP.IdDetalle + " ;", null, "EliminarDetalle");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        ///// <summary>
        ///// Trae los datos de una Patologia seleccionado.
        ///// OK 03/06/12
        ///// </summary>
        ///// <param name="oC"></param>
        ///// <returns></returns>
        //public classPatologia SelectPatologia(classPatologia oC)
        //{
        //    classPatologia oTr = null;

        //    if (Sql.SelectReaderDB("SELECT IdDetalle, Nombre "
        //        + " FROM Detalle WHERE IdDetalle = " + oC.IdDetalle + " AND Visible = 1 ORDER BY Nombre;",
        //        null,
        //        "selectPatologia"))
        //    {
        //        Sql.Reader.Read();
        //        oTr = new classPatologia(
        //            Convert.ToInt32(Sql.Reader["IdDetalle"])
        //            , Sql.Reader["Nombre"].ToString()
        //            );

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return oTr;
        //}

        ///// <summary>
        ///// Inserta una Patologia.
        ///// OK 03/06/12
        ///// </summary>
        ///// <param name="oS"></param>
        ///// <returns></returns>
        //public bool AgregarPatologia(classPatologia oP)
        //{
        //    bool error;

        //    error = Sql.InsertDB("INSERT INTO Detalle (Nombre) VALUES ('"+ oP.Detalle +"');",
        //        null,
        //        "AgregarPatologia");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        ///// <summary>
        ///// Modifica una Patologia.
        ///// Restore: True-> Vuelve a mostrar
        /////          False-> Oculta
        ///// OK 03/06/12
        ///// </summary>
        ///// <param name="oP"></param>
        ///// <returns></returns>
        //public bool ModificarPatologia(classPatologia oP, bool Restore)
        //{
        //    bool error;

        //    error = Sql.UpdateDB("UPDATE Detalle SET Nombre = '" + oP.Detalle
        //        + "', Visible = " + Convert.ToInt32(Restore) 
        //        + " WHERE IdDetalle = " + oP.IdDetalle + " ;",
        //        null,
        //        "ModificarPatologia");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        //#endregion

        //// OK 03/06/12
        //#region Consulta Barrio

        ///// <summary>
        ///// Elimina de forma definitiva o Actualiza el campo visible de Barrios
        ///// Eliminar: True-> Elimina
        /////           False-> Modifica Estado "No Elimina"
        ///// OK 03/06/12
        ///// </summary>
        ///// <param name="oB"></param>
        ///// <param name="Eliminar"></param>
        ///// <returns></returns>
        //public bool EliminarBarrio(classBarrio oB, bool Eliminar)
        //{
        //    bool error;

        //    if (Eliminar)
        //        error = Sql.DeleteDB("DELETE FROM Barrio WHERE iIdBarrio = " + oB.IdBarrio + " ;", null, "EliminarBarrio");
        //    else
        //        error = Sql.UpdateDB("UPDATE Barrio SET Visible = 0 WHERE iIdBarrio = " + oB.IdBarrio + " ;", null, "EliminaBarrio");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        ///// <summary>
        ///// Trae los datos de una Barrio seleccionado.
        ///// OK 03/06/12
        ///// </summary>
        ///// <param name="oB"></param>
        ///// <returns></returns>
        //public classBarrio SelectBarrio(classBarrio oB)
        //{
        //    classBarrio oTr = null;

        //    if (Sql.SelectReaderDB("SELECT iIdBarrio, IdCiudad, Nombre "
        //        + " FROM Barrio WHERE iIdBarrio = " + oB.IdBarrio + " AND Visible = 1 ORDER BY Nombre;",
        //        null,
        //        "selectBarrio"))
        //    {
        //        Sql.Reader.Read();
        //        oTr = new classBarrio(
        //            Convert.ToInt32(Sql.Reader["IdCiudad"])
        //            , Convert.ToInt32(Sql.Reader["iIdBarrio"])
        //            , Sql.Reader["Nombre"].ToString()
        //            );

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return oTr;
        //}

        ///// <summary>
        ///// Inserta una Barrio.
        ///// OK 03/06/12
        ///// </summary>
        ///// <param name="oS"></param>
        ///// <returns></returns>
        //public bool AgregarBarrio(classBarrio oB)
        //{
        //    bool error;

        //    error = Sql.InsertDB("INSERT INTO Barrio (Nombre, IdCiudad) VALUES ( '"
        //        + oB.Nombre + "', " + oB.IdCiudad +");",
        //        null,
        //        "AgregarBarrio");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        ///// <summary>
        ///// Modifica un Barrio.
        ///// Restore: True-> Vuelve a mostrar
        /////          False-> Oculta
        ///// OK 03/06/12
        ///// </summary>
        ///// <param name="oB"></param>
        ///// <returns></returns>
        //public bool ModificarBarrio(classBarrio oB, bool Restore)
        //{
        //    bool error;

        //    error = Sql.UpdateDB("UPDATE Barrio SET Nombre = '" + oB.Nombre
        //        + "', IdCiudad = " + oB.IdCiudad 
        //        + " Visible = " + Convert.ToInt32(Restore) 
        //        + " WHERE iIdBarrio = " + oB.IdBarrio + " ;",
        //        null,
        //        "ModificarBarrio");


        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        //#endregion

        //// OK 03/06/12
        //#region Consulta Ciudad

        ///// <summary>
        ///// Elimina de forma definitiva o Actualiza el campo visible de Ciudades
        ///// Eliminar: True-> Elimina
        /////           False-> Modifica Estado "No Elimina"
        ///// OK 03/06/12
        ///// </summary>
        ///// <param name="oC"></param>
        ///// <param name="Eliminar"></param>
        ///// <returns></returns>
        //public bool EliminarCiudad(classCiudad oC, bool Eliminar)
        //{
        //    bool error;
        //    if (Eliminar)
        //        error = Sql.DeleteDB("DELETE FROM Ciudad WHERE IdCiudad = " + oC.IdCiudad + " ;", null, "EliminarCiudad");
        //    else
        //        error = Sql.UpdateDB("UPDATE Ciudad SET Visible = 0 WHERE IdCiudad = " + oC.IdCiudad + " ;", null, "EliminarCiudad");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        ///// <summary>
        ///// Trae los datos de una Ciudad seleccionado.
        ///// OK 03/06/12
        ///// </summary>
        ///// <param name="oC"></param>
        ///// <returns></returns>
        //public classCiudad SelectCiudad(classCiudad oC)
        //{
        //    classCiudad oTr = new classCiudad();

        //    if (Sql.SelectReaderDB("SELECT IdCiudad, Nombre "
        //        + " FROM Ciudad WHERE IdCiudad = " + oC.IdCiudad + " ORDER BY Nombre;",
        //        null,
        //        "selectCiudad"))
        //    {
        //        Sql.Reader.Read();
        //        oTr = new classCiudad(
        //            Convert.ToInt32(Sql.Reader["IdCiudad"])
        //            , Sql.Reader["Nombre"].ToString()
        //            );

        //        Sql.Reader.Close();
        //        Sql.Desconectar();
        //    }
        //    return oTr;
        //}

        ///// <summary>
        ///// Inserta una Ciudad.
        ///// OK 03/06/12
        ///// </summary>
        ///// <param name="oS"></param>
        ///// <returns></returns>
        //public bool AgregarCiudad(classCiudad oT)
        //{
        //    bool error;

        //    error = Sql.InsertDB("INSERT INTO Ciudad (Nombre) VALUES ( '"
        //        + oT.Nombre + "');",
        //        null,
        //        "AgregarCiudad");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        ///// <summary>
        ///// Modifica una Ciudad.
        ///// Restore: True-> Vuelve a mostrar
        /////          False-> Oculta
        ///// OK 03/06/12
        ///// </summary>
        ///// <param name="oC"></param>
        ///// <returns></returns>
        //public bool ModificarCiudad(classCiudad oC, bool Restore)
        //{
        //    bool error;

        //    error = Sql.UpdateDB("UPDATE Ciudad SET Nombre = '" + oC.Nombre
        //        + "', Visible = " + Convert.ToInt32(Restore) 
        //        + " WHERE IdCiudad = " + oC.IdCiudad + " ;",
        //        null,
        //        "ModificarCiudad");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        //#endregion

        //// OK 11/16/12
        //#region Consulta Usuario

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
        ///// Elimina de forma definitiva o Actualiza el campo visible de Password
        ///// Eliminar: True-> Elimina
        /////           False-> Modifica Estado "No Elimina"
        ///// OK /06/12
        ///// </summary>
        ///// <param name="oU"></param>
        ///// <param name="Eliminar"></param>
        ///// <returns></returns>
        //public bool EliminarUsuario(classUsuarios oU, bool Eliminar)
        //{
        //    bool error;
        //    if (Eliminar)
        //        error = Sql.DeleteDB("DELETE FROM Usuario WHERE IdUsuario = " + oU.IdUsuario + " ;", null, "EliminarUsuario");
        //    else
        //        error = Sql.UpdateDB("UPDATE Usuario SET Bloqueado = 0 WHERE IdUsuario = " + oU.IdUsuario + " ;", null, "EliminarUsuario");

        //    Menssage = Sql.Mensaje;
        //    return error;
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

        ///// <summary>
        ///// Inserta una Usuario.
        ///// 07/06/12
        ///// </summary>
        ///// <param name="oS"></param>
        ///// <returns></returns>
        //public bool AgregarUsuario(classUsuarios oU)
        //{
        //    bool error;

        //    error = Sql.InsertDB("INSERT INTO Usuario (Nombre, Apellido, Email, Contrasenia) VALUES ( '"
        //        + oU.Nombre + "', '" + oU.Apellido + "', '" + oU.Email + "', '" + oU.Contrasenia + "');",
        //        null,
        //        "AgregarUsuario");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        ///// <summary>
        ///// Modifica una Usuario.
        ///// Restore: True-> Vuelve a mostrar
        /////          False-> Oculta
        ///// 07/06/12
        ///// </summary>
        ///// <param name="oU"></param>
        ///// <returns></returns>
        //public bool ModificarUsuario(classUsuarios oU)
        //{
        //    bool error;

        //    error = Sql.UpdateDB("UPDATE Usuario SET Nombre = '" + oU.Nombre
        //        + "', Bloqueado = " + Convert.ToInt32(oU.Bloqueado)
        //        + " , Contrasenia = '" + oU.Contrasenia 
        //        + "', Apellido = '" + oU.Apellido
        //        + "', Email = '" + oU.Email 
        //        + "' WHERE IdUsuario = " + oU.IdUsuario + " ;",
        //        null,
        //        "ModificarUsuario");

        //    Menssage = Sql.Mensaje;
        //    return error;
        //}

        //#endregion

        //// OK 11/06/12
        //#region Consulta Filtros

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

        //#endregion

        //// OK 21/06/12
        //#region Estadisticas

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

        //#endregion

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
