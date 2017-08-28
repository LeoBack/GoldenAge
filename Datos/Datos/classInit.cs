using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace Datos
{
    public class classSchemaBD
    {
        #region Atributos y Propiedades

        public string path {get; set; }
        public string BDname { get; set; }
        public bool ActivarLog { set; get; }
        public string Menssage {set; get;}
        private SQLite oSql;

        public classSchemaBD(bool ActivarLog)
        {
            this.ActivarLog = ActivarLog;
            oSql = new SQLite(this.ActivarLog);
        }

        public classSchemaBD(string path, string BDname, bool Log)
        {
            this.path = path;
            this.BDname = BDname;
            this.ActivarLog = Log;
            oSql = new SQLite(this.path, this.BDname, this.ActivarLog);
        }

        #endregion

        // Llamar a esta funcion.
        #region MetodosAplicar

        /// <summary>
        /// Si no existe la Base de Datos la crea.
        /// TERMINAR
        /// </summary>
        public bool ExistCreateBD()
        {
            bool st = false;

            if (!File.Exists(this.path + "\\" + this.BDname))
            {
                if (CrearTablas())
                {
                    CargarTablas();
                    st = true;
                }
                else
                    st = false;
            }
            return st;
        }

        /// <summary>
        /// Cadena de tablas para armar.
        /// </summary>
        /// <returns></returns>
        private bool CrearTablas()
        {
            int C = 0;
            bool Status = true;

            foreach (string Insert in this.Tablas())
            {
                if ( false == oSql.InsertDB(Insert, null, "Tabla ->" + C))
                    Status = false;
                C++;
            }
            return Status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CargarTablas()
        {
            int C = 0;
            bool Status = true;

            foreach (string Insert in this.cargarPredeterminados())
            {
                if (false == oSql.InsertDB(Insert, null, "CargaTablas ->" + C))
                    Status = false;
                C++;
            }
            return Status;
        }

        #endregion

        #region Estructura de Tablas

        /// <summary>
        /// Contiene las tablas a executar para armar la Base de Datos.
        /// </summary>
        /// <returns></returns>
        private string[] Tablas()
        {
            List<string> lV = new List<string>();

            lV.Add("CREATE TABLE TipoTelefono ("
            + "IdTipoTelefono INTEGER   PRIMARY KEY AUTOINCREMENT UNIQUE,  "
            + "Nombre         VARCHAR( 20 ));");

            lV.Add("CREATE TABLE Telefono ( "
            + "IdTelefono INTEGER   PRIMARY KEY AUTOINCREMENT UNIQUE, "
            + "Numero         NUMERIC, "
            + "IdTipoTelefono INTEGER REFERENCES TipoTelefono ( IdTipoTelefono ) );");

            lV.Add("CREATE TABLE Ciudad ("
            + "IdCiudad INTEGER   PRIMARY KEY AUTOINCREMENT UNIQUE, "
            + "Visible      INT( 1 )       DEFAULT ( 1 ), "
            + "Nombre   VARCHAR( 50 ) );");

            lV.Add("CREATE TABLE Barrio ( "
            + "iIdBarrio INTEGER   PRIMARY KEY AUTOINCREMENT UNIQUE, "
            + "Nombre   VARCHAR( 50 ), "
            + "Visible      INT( 1 )       DEFAULT ( 1 ), "
            + "IdCiudad INTEGER        REFERENCES Ciudad ( IdCiudad ) );");

            lV.Add("CREATE TABLE TipoPersona ( "
            + "IdTipoPersona INTEGER PRIMARY KEY AUTOINCREMENT, "
            + "Nombre        VARCHAR( 50 ) );");

            lV.Add("CREATE TABLE ObraSocial ( "
            + "IdObraSocial INTEGER   PRIMARY KEY AUTOINCREMENT, "
            + "Nombre       VARCHAR( 20 ), "
            + "Descripcion  TEXT, "
            + "IdCiudad     INTEGER        REFERENCES Ciudad ( IdCiudad ), "
            + "IdBarrio     INTEGER        REFERENCES Barrio ( IdBarrio ), "
            + "Direccion    TEXT, "
            + "Visible      INT( 1 )       DEFAULT ( 1 ), "
            + "Telefono1    VARCHAR( 20 ), "
            + "Telefono2    VARCHAR( 20 ) ); ");

            lV.Add("CREATE TABLE TelefonoObraSocial ( "
            + "IdTelefonoObraSocial INTEGER PRIMARY KEY AUTOINCREMENT, "
            + "IdTelefono           INTEGER REFERENCES TipoTelefono ( IdTelefono ), "
            + "IdObraSocial         INTEGER REFERENCES ObraSocial ( IdObraSocial ) );");

            lV.Add("CREATE TABLE Persona ( "
            + "IdPersona       INTEGER        PRIMARY KEY AUTOINCREMENT, "
            + "Nombre          VARCHAR( 50 ), "
            + "Apellido        VARCHAR( 50 ),  "
            + "Direccion       VARCHAR( 50 ),  "
            + "FechaNacimiento DATETIME, "
            + "FechaAlta       DATETIME, "
            + "Sexo            INTEGER, "
            + "nAfiliado       VARCHAR( 30 ), "
            + "IdObraSocial    INTEGER        REFERENCES ObraSocial ( IdObraSocial ), "
            + "IdTipoPersona   INTEGER        REFERENCES TipoPersona ( IdTipoPersona ), "
            + "IdCiudad        INTEGER        REFERENCES Ciudad ( IdCiudad ), "
            + "IdBarrio        INTEGER        REFERENCES Barrio ( IdBarrio ), "
            + "IdUsuario       INTEGER        REFERENCES Usuario ( IdUsuario ), "
            + "Visible         INT( 1 )       DEFAULT ( 1 ), "
            + "Telefono        VARCHAR( 20 ), "
            + "TelefonoParticular VARCHAR( 20 ) );");

            lV.Add("CREATE TABLE TelefonoPersona ( "
            + "IdTelefonoPersona INTEGER PRIMARY KEY AUTOINCREMENT, "
            + "IdTelefono        INTEGER REFERENCES TipoTelefono ( IdTelefono ), "
            + "IdPersona         INTEGER REFERENCES Persona ( IdPersona ) );");

            lV.Add("CREATE TABLE Detalle ( "
            + "IdDetalle     INTEGER        PRIMARY KEY AUTOINCREMENT, "
            + "Visible      INT( 1 )       DEFAULT ( 1 ), "
            + "Nombre        VARCHAR( 50 ));");

            lV.Add("CREATE TABLE Diagnostico ( "
            + "IdDiagnostico INTEGER   PRIMARY KEY AUTOINCREMENT, "
            + "IdPersona     INTEGER   REFERENCES Persona ( IdPersona ), "
            + "IdDetalle     INTEGER   REFERENCES Detalle ( IdDetalle),"
            + "Diagnostico   TEXT, "
            + "Fecha         DATE      NOT NULL, "
            + "Visible       INT( 1 )  DEFAULT ( 1 ));");

            lV.Add("CREATE TABLE Usuario ( "
            + "IdUsuario   INTEGER        PRIMARY KEY AUTOINCREMENT, "
            + "Nombre      VARCHAR( 20 )  NOT NULL, "
            + "Apellido      VARCHAR( 20 )  NOT NULL, "
            + "Email      VARCHAR( 20 )  NOT NULL, "
            + "Bloqueado      INT( 1 )      DEFAULT ( 0 ), "
            + "Contrasenia VARCHAR( 20 )  NOT NULL );");

            lV.Add("CREATE TABLE EstadoTurno ( "
            + "IdEstadoTurno INTEGER        PRIMARY KEY AUTOINCREMENT, "
            + "Nombre        VARCHAR( 20 )  NOT NULL );");

            lV.Add("CREATE TABLE Turno (  "
            + "IdTurno       INTEGER  PRIMARY KEY AUTOINCREMENT, "
            + "IdPersona     INTEGER  REFERENCES Persona ( IdPersona ), "
            + "IdUsuario     INTEGER  REFERENCES Usuario ( IdUsuario ), "
            + "IdEstadoTurno INTEGER  REFERENCES EstadoTurno ( IdEstadoTurno ), "
            + "Fecha         DATETIME  );");

            return lV.ToArray();
        }

        /// <summary>
        /// Aqui se insertan los datos ensenciales para el funcionamineto de la Base de Datos.
        /// </summary>
        /// <returns></returns>
        private string[] cargarPredeterminados()
        {
            List<string> lV = new List<string>();

            // Ciudades
            lV.Add("INSERT INTO Ciudad (nombre) VALUES ('Cordoba');");
            lV.Add("INSERT INTO Ciudad (nombre) VALUES ('Cosquin');");
            lV.Add("INSERT INTO Ciudad (nombre) VALUES ('Tanti');");
            lV.Add("INSERT INTO Ciudad (nombre) VALUES ('La Falda');");
            lV.Add("INSERT INTO Ciudad (nombre) VALUES ('Alta Gracia');");
            lV.Add("INSERT INTO Ciudad (nombre) VALUES ('Carlos Paz');");
            lV.Add("INSERT INTO Ciudad (nombre) VALUES ('Santa Maria de Punilla');");
            lV.Add("INSERT INTO Ciudad (nombre) VALUES ('Villa Giardino');");
            lV.Add("INSERT INTO Ciudad (nombre) VALUES ('La Cumbre');");
            lV.Add("INSERT INTO Ciudad (nombre) VALUES ('Valle Hermoso');");
            lV.Add("INSERT INTO Ciudad (nombre) VALUES ('Casa Grande');");
            lV.Add("INSERT INTO Ciudad (nombre) VALUES ('Bialet Masse');");
            lV.Add("INSERT INTO Ciudad (nombre) VALUES ('Saldan');");
            lV.Add("INSERT INTO Ciudad (nombre) VALUES ('La Calera');");
            lV.Add("INSERT INTO Ciudad (nombre) VALUES ('Agua de Oro');");
            // Barrios
            // http://www.cordoba.gov.ar/cordobaciudad/principal2/default.asp?ir=42_3_2
            lV.Add("INSERT INTO Barrio (nombre, IdCiudad) VALUES ('Villa Pan de Azucar', 2);");
            lV.Add("INSERT INTO Barrio (nombre, IdCiudad) VALUES ('Alto Mieres', 2);");
            lV.Add("INSERT INTO Barrio (nombre, IdCiudad) VALUES ('Alberdi', 1);");
            lV.Add("INSERT INTO Barrio (nombre, IdCiudad) VALUES ('Alta Cordoba', 1);");
            lV.Add("INSERT INTO Barrio (nombre, IdCiudad) VALUES ('Villa Bustos', 7);");
            lV.Add("INSERT INTO Barrio (nombre, IdCiudad) VALUES ('El Mirador del Lago', 6);");
            lV.Add("INSERT INTO Barrio (nombre, IdCiudad) VALUES ('Itiuzango', 1);");
            lV.Add("INSERT INTO Barrio (nombre, IdCiudad) VALUES ('Alberto ', 1);");
            lV.Add("INSERT INTO Barrio (nombre, IdCiudad) VALUES ('Alaborada Sur ', 1);");
            // TipoTelefono
            lV.Add("INSERT INTO TipoTelefono (nombre) VALUES ('Movil');");
            lV.Add("INSERT INTO TipoTelefono (nombre) VALUES ('Fijo');");
            lV.Add("INSERT INTO TipoTelefono (nombre) VALUES ('Personal');");
            lV.Add("INSERT INTO TipoTelefono (nombre) VALUES ('Trabajo');");
            lV.Add("INSERT INTO TipoTelefono (nombre) VALUES ('De un pariente cercano');");
            // TipoPersona
            lV.Add("INSERT INTO TipoPersona (nombre) VALUES ('No Ambulatorio'); ");
            lV.Add("INSERT INTO TipoPersona (nombre) VALUES ('Ambulatorio');");
            // EstadoTurno
            lV.Add("INSERT INTO EstadoTurno (nombre) VALUES ('Pendiente'); ");
            lV.Add("INSERT INTO EstadoTurno (nombre) VALUES ('Asistio'); ");
            lV.Add("INSERT INTO EstadoTurno (nombre) VALUES ('No asistio'); ");
            lV.Add("INSERT INTO EstadoTurno (nombre) VALUES ('Cancelado'); ");
            // ObraSocial
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio, Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('Indefinido', 1, 1, 1, 'Indefindo', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio, Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('PAMI', 1, 1, 1, 'Instituto Nacional de Servicios Sociales para Jubilados y Pensionados', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio,  Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('APROS', 1, 1, 1, 'Administración Provincial de Seguro de Salud es una entidad autárquica', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio,  Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('OSPIGPC', 1, 1, 1, 'Obra Social del Personal de la Industria Grafica de la Provincia de Cordoba', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio,  Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('OSLYF', 1, 1, 1, 'Obra Social del Personal Luz y Fuerza de Cordoba', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio,  Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('OSITAC', 1, 1, 1, 'Obra Social de la Industria del Transporte Automotor de Cordoba', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio,  Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('OSEPC', 1, 1, 1, 'Obra Social de Empleados de Prensa de Cordoba', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio,  Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('MEDIFÉ', 1, 1, 1, 'Cobertura Médica Nacional', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio,  Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('OSPE', 1, 1, 1, 'Obra Social Petroleros', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio,  Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('OSPOCE', 1, 1, 1, 'Nuestra convicción es actuar solidariamente ya que cada persona es única y sus problemas exigen una solución diferenciada.', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio,  Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('OSCCPTAC', 1, 1, 1, 'Asociación Mutual De Trabajadores Del Transporte Automotor De Cargas.', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio,  Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('OSADRA', 1, 1, 1, 'Obra Social Árbitros Deportivos De La Republica Argentina', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio,  Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('STEL', 1, 1, 1, 'Obra Social Del Personal De Telecomunicaciones De La Republica Argentina.', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio,  Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('O.S.P.T.V', 1, 1, 1, 'Obra Social Del Personal De Televisión.', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio,  Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('OMINT', 1, 1, 1, 'Calidad de servicios médicos, eficacia y ética profesional.', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio,  Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('OSDE BINARIO', 1, 1, 1, '', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio,  Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('OSIM', 1, 1, 1, 'Obra Soc. de Actividades Empresarias.', '', '', ''); ");
            lV.Add("INSERT INTO ObraSocial (Nombre, IdCiudad, IdBarrio,  Visible, Descripcion, Telefono1, Telefono2, Direccion)" +
                " VALUES ('GALENO', 1, 1, 1, '', '', '', ''); ");
            // Detalle
            lV.Add("INSERT INTO Detalle (Nombre) VALUES ('Trauma'); ");
            lV.Add("INSERT INTO Detalle (Nombre) VALUES ('Lecion'); ");
            // USUARIO POR DEFECTO
            lV.Add("INSERT INTO Usuario (Nombre, Apellido, Email, Contrasenia) VALUES ('admin', 'admin', 'admin@admin.com', 'admin')");

            return lV.ToArray();
        }

        #endregion
    }
}
