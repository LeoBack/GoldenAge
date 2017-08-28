using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace Datos
{
    public class classInspector
    {
        #region Atributos y Propiedades

        public string pathLog { set; get; }
        private string fileLog = "Log.bck";
        public bool Activar { set; get; }

        #endregion

        #region Constructores

        public classInspector()
        {
            this.pathLog = AppDomain.CurrentDomain.BaseDirectory + this.fileLog;
            this.Activar = true;
        }

        public classInspector(bool Activar, string path)
        {
            this.pathLog = path + this.fileLog;
            this.Activar = Activar;
        }

        #endregion

        #region Metodos

        private void ExistFile()
        {
            if (File.Exists(pathLog))
            {
                
            }
        }

        public void Write(string Mensaje)
        {
            if (this.Activar)
            {
                try
                {
                    StreamWriter st = new StreamWriter(pathLog, File.Exists(pathLog));
                    st.WriteLine(DateTime.Now.ToString() + " -> " + Mensaje);
                    st.Flush();
                    st.Close();
                }
                catch (IOException) { }
            }
        }

        #endregion
    }
}
