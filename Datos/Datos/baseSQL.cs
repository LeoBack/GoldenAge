using System;
using System.Collections.Generic;
using System.Text;
//
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class baseSQL
    {
        #region Atributos y Propiedades

        public string Path { set; get; }
        public string DBname { set; get; }
        public bool ActivarLog { set; get; }
        private string ConexionString { set; get; }

        public string Mensaje { set; get; }

        public SqlParameter[] Parametros { set; get; }
        public SqlDataReader Reader { set; get; }
        public SqlDataAdapter Adapter { set; get; }

        public SqlConnection Cx { set; get; }
        public SqlCommand Cmd { set; get; }
        public SqlTransaction Transaction { set; get; }

        private classInspector Log;

        private DataTable Table { set; get; }
        private SqlParameter Param { set; get; }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor Sin Parametros.
        /// </summary>
        public baseSQL(bool aActivarLog)
        {
            Path = AppDomain.CurrentDomain.BaseDirectory;
            DBname = "Test.db";
            ActivarLog = aActivarLog;
            ConexionString = Path + DBname;
            Log = new classInspector(ActivarLog, Path);
            Mensaje = "";
            Reader = null;
            Adapter = null;

            Cx = new SqlConnection(dataConexionString());
            Cmd = new SqlCommand();
        }

        /// <summary>
        /// Constructor Con Parametros (Cadena de Conexion).
        /// </summary>
        public baseSQL(string vPath, string vDBname, bool vActivarLog)
        {
            Path = vPath;
            DBname = vDBname;
            ActivarLog = vActivarLog;
            ConexionString = Path + DBname;
            Log = new classInspector(ActivarLog, Path);
            Mensaje = "";
            Reader = null;
            Adapter = null;

            Cx = new SqlConnection(dataConexionString());
            Cmd = new SqlCommand();
        }

        /// <summary>
        /// Aram la cadena de conexion con todos los parametros.
        /// </summary>
        /// <returns></returns>
        private string dataConexionString()
        {   //Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Project-GitHub\GraphicsCSV\testDB\testDB\Database1.mdf;Integrated Security=True;Connect Timeout=30";
            return String.Format("Data Source=(LocalDB)\v11.0;AttachDbFilename=" + ConexionString + " ;Integrated Security=True;Connect Timeout=30");
            //return String.Format("Data Source=" + ConexionString);
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
                Log.Write("*-> Conexion Abierta");
            }
            catch (SqlException ex)
            {
                Log.Write("*error Al abrir conexion ->" +  ex.ToString());
                Mensaje = ex.ToString();
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
                Log.Write("*<- Conexion Cerrada");
            }
            catch (SqlException ex)
            {
                Log.Write("*error Al cerrar conexion ->" + ex.ToString());
                Mensaje = ex.ToString();
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
                Adapter = new SqlDataAdapter(SQL, Cx.ConnectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(Adapter);

                // Populate a new data table and bind it to the BindingSource.
                Table = new DataTable();
                Table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                Adapter.Fill(Table);
                Desconectar();
                return true;
            }
            catch (SqlException er)
            {
                Mensaje = er.ToString();
                Desconectar();
                return false;
            }
        }

        /// <summary>
        /// Metodo Comunes para Insertar, Actualizar y Eliminar
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        private bool Execute(string SQL, SqlParameter[] param, string nameConsulta)
        {
            bool error = true;

            if (Conectar())
            {
                SqlTransaction trans = Cx.BeginTransaction();

                try
                {
                    Cmd.CommandText = SQL;

                    if (param != null)
                        Cmd.Parameters.AddRange(param);

                    if (Cmd.ExecuteNonQuery() == -1)
                    {
                        Log.Write("* " + nameConsulta + " 0 rows afected");
                        Mensaje = "No hay Columnas Afectadas";
                        error = false;
                    }
                    trans.Commit();
                    Log.Write("* " + nameConsulta + " Ok");
                }
                catch (SqlException ex)
                {
                    trans.Rollback();
                    Log.Write("* " + nameConsulta + "\n" + ex.ToString());
                    Mensaje = ex.ToString();
                    error = false;
                }
                catch (NullReferenceException ex)
                {
                    trans.Rollback();
                    Log.Write("* " + nameConsulta + "\n" + ex.ToString());
                    Mensaje = ex.ToString();
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
        public bool SelectReaderDB(string sql, SqlParameter[] param, string nameConsulta)
        {
            if (Conectar())
            {
                if (param != null)
                    Cmd.Parameters.AddRange(param);
                Cmd.CommandText = sql;
                Reader = Cmd.ExecuteReader();
                Log.Write("* " + nameConsulta + " Ok");
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
            if (Conectar())
            {
                Cmd.CommandText = sql;
                Adapter = new SqlDataAdapter(Cmd);
                Log.Write("* " + nameConsulta + " 0 rows afected Adapter");
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
        public bool InsertDB(string sql, SqlParameter[] param, string nameConsulta)
        {
            return Execute(sql, param, nameConsulta);
        }

        /// <summary>
        /// Realiza un Delete en la base de datos.
        /// Recibe un String SQL
        /// Devuelve un Boleano y un mensaje en caso de error.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>bool</returns>
        public bool DeleteDB(string sql, SqlParameter[] param, string nameConsulta)
        {
            return Execute(sql, param, nameConsulta);
        }

        /// <summary>
        /// Realiza un Update en la base de datos.
        /// Recibe un String SQL
        /// Devuelve un Boleano y un mensaje en caso de error.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>bool</returns>
        public bool UpdateDB(string sql, SqlParameter[] param, string nameConsulta)
        {
            return Execute(sql, param, nameConsulta);
        }

        #endregion
    }
}
