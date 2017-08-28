using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SQLite;
using System.Data;

namespace Datos
{
    public class SQLite
    {
        #region Atributos y Propiedades

        public string Path { set; get; }
        public string DBname { set; get; }
        public bool ActivarLog { set; get; }
        private string ConexionString { set; get; }

        public string Mensaje { set; get; }
        
        public SQLiteParameter[] Parametros { set; get; }
        public SQLiteDataReader Reader { set; get; }
        public SQLiteDataAdapter Adapter { set; get; }

        public SQLiteConnection Cx { set; get; }
        public SQLiteCommand Cmd { set; get; }
        public SQLiteTransaction Transaction { set; get; }

        private classInspector Log;

        private DataTable Table { set; get; }
        private SQLiteParameter Param { set; get; }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor Sin Parametros
        /// </summary>
        public SQLite(bool ActivarLog)
        {
            this.Path = AppDomain.CurrentDomain.BaseDirectory;
            this.DBname = "Test.db";
            this.ActivarLog = ActivarLog;
            this.ConexionString = this.Path + this.DBname;
            this.Log = new classInspector(this.ActivarLog, this.Path);
            this.Mensaje = "";
            this.Reader = null;
            this.Adapter = null;

            this.Cx = new SQLiteConnection(this.dataConexionString());
            this.Cmd = new SQLiteCommand();
        }

        /// <summary>
        /// Constructor Con Parametros (Cadena de Conexion)
        /// </summary>
        public SQLite(string Path, string DBname, bool ActivarLog)
        {
            this.Path = Path;
            this.DBname = DBname;
            this.ActivarLog = ActivarLog;
            this.ConexionString = this.Path + this.DBname;
            this.Log = new classInspector(this.ActivarLog, this.Path);
            this.Mensaje = "";
            this.Reader = null;
            this.Adapter = null;

            this.Cx = new SQLiteConnection(this.dataConexionString());
            this.Cmd = new SQLiteCommand();
        }

        private string dataConexionString()
        {
            return String.Format("Data Source=" + ConexionString);
        }

        #endregion

        #region Metodos Comunes

        /// <summary>
        /// Realiza la conexion con la Base de Datos
        /// Recibe un String ConexionString
        /// Devuelve un Boleano y un mensaje en caso de error.
        /// </summary>
        /// <returns>bool</returns>
        public bool Conectar()
        {
            try
            {
                Cx.Open();
                Cmd.Connection = Cx;
                Cmd.CommandType = System.Data.CommandType.Text;
                this.Log.Write("*-> Conexion Abierta");
            }
            catch (SQLiteException ex)
            {
                this.Log.Write("*error Al abrir conexion ->" +  ex.ToString());
                this.Mensaje = ex.ToString();
                return false;
            }
            return true;
        }


        /// <summary>
        /// Realiza la desconexion con la Base de Datos
        /// Devuelve un Boleano y un mensaje en caso de error.
        /// </summary>
        /// <returns>bool</returns>
        public bool Desconectar()
        {
            try
            {
                Cx.Close();
                this.Log.Write("*<- Conexion Cerrada");
            }
            catch (SQLiteException ex)
            {
                this.Log.Write("*error Al cerrar conexion ->" + ex.ToString());
                this.Mensaje = ex.ToString();
                return false;
            }
            return true;
        }

        #endregion

        #region Metodos preparados para: Consultar en forma directa

        /// <summary>
        /// Metodo para traer datos a una Grilla.
        /// Devuebe un DataTable
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public bool GetDataGridView(string SQL)
        {
            try
            {
                Adapter = new SQLiteDataAdapter(SQL, Cx.ConnectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(Adapter);

                // Populate a new data table and bind it to the BindingSource.
                Table = new DataTable();
                Table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                Adapter.Fill(Table);
                this.Desconectar();
                return true;
            }
            catch (SQLiteException er)
            {
                this.Mensaje = er.ToString();
                this.Desconectar();
                return false;
            }
        }


        /// <summary>
        /// Metodo Comunes para Insertar, Actualizar y Eliminar
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        private bool Execute(string SQL, SQLiteParameter[] param, string nameConsulta)
        {
            bool error = true;

            if (this.Conectar())
            {
                SQLiteTransaction trans = Cx.BeginTransaction();

                try
                {
                    Cmd.CommandText = SQL;

                    if (param != null)
                        Cmd.Parameters.AddRange(param);

                    if (Cmd.ExecuteNonQuery() == -1)
                    {
                        this.Log.Write("* " + nameConsulta + " 0 rows afected");
                        this.Mensaje = "No hay Columnas Afectadas";
                        error = false;
                    }
                    trans.Commit();
                    this.Log.Write("* " + nameConsulta + " Ok");
                }
                catch (SQLiteException ex)
                {
                    trans.Rollback();
                    this.Log.Write("* " + nameConsulta + "\n" + ex.ToString());
                    this.Mensaje = ex.ToString();
                    error = false;
                }
                catch (NullReferenceException ex)
                {
                    trans.Rollback();
                    this.Log.Write("* " + nameConsulta + "\n" + ex.ToString());
                    this.Mensaje = ex.ToString();
                    error = false;
                }
                finally
                {
                    Desconectar();
                }
            }
            return error;
        }

        /// <summary>
        /// Carga el un Reader desde una consulta Select
        /// Devuelve un Boleano y un mensaje en caso de error.
        /// </summary>
        /// <param name="sql"></param>
        public bool SelectReaderDB(string sql, SQLiteParameter[] param, string nameConsulta)
        {
            if (this.Conectar())
            {
                if (param != null)
                    Cmd.Parameters.AddRange(param);
                Cmd.CommandText = sql;
                Reader = Cmd.ExecuteReader();
                this.Log.Write("* " + nameConsulta + " Ok");
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Carga el un Adapter desde una consulta Select
        /// Devuelve un Boleano y un mensaje en caso de error.
        /// </summary>
        /// <param name="sql"></param>
        public bool SelectAdapterDB(string sql, string nameConsulta)
        {
            if (this.Conectar())
            {
                Cmd.CommandText = sql;
                Adapter = new SQLiteDataAdapter(Cmd);
                this.Log.Write("* " + nameConsulta + " 0 rows afected Adapter");
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Realiza un Inserta en la base de datos.
        /// Recibe un String SQL
        /// Devuelve un Boleano y un mensaje en caso de error.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>bool</returns>
        public bool InsertDB(string sql, SQLiteParameter[] param, string nameConsulta)
        {
            return this.Execute(sql, param, nameConsulta);
        }

        /// <summary>
        /// Realiza un Delete en la base de datos.
        /// Recibe un String SQL
        /// Devuelve un Boleano y un mensaje en caso de error.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>bool</returns>
        public bool DeleteDB(string sql, SQLiteParameter[] param, string nameConsulta)
        {
            return this.Execute(sql, param, nameConsulta);
        }

        /// <summary>
        /// Realiza un Update en la base de datos.
        /// Recibe un String SQL
        /// Devuelve un Boleano y un mensaje en caso de error.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>bool</returns>
        public bool UpdateDB(string sql, SQLiteParameter[] param, string nameConsulta)
        {
            return this.Execute(sql, param, nameConsulta);
        }

        #endregion
    }
}
