using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace Datos
{
    public class classBackUp
    {
        #region Atributos y Propiedades

        private classConsultas oConsulta;
        public string Filter { set;  get; }
        public string Error { set; get; }

        #endregion

        #region Constructores

        public classBackUp(classConsultas oConsulta)
        {
            this.oConsulta = oConsulta;
            this.Filter = ".bck";
            this.Error = "";
        }

        #endregion

        #region Metodos

        #region Crear BackUp

        /// <summary>
        /// Copia el archivo BD y lo guarda donde se indica,
        /// cambiando el nombre y extencion.
        /// OK 100412
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public bool MakeCopy(string Path)
        {
            //Realizar una copia de la Base de datos
            string Origin = oConsulta.Path + oConsulta.DBname;
            string Destination = Path + @"\" + AssembleName();

            try
            {
                //COPIAR el archivo ya con el nombre modificado adonde endique
                File.Copy(Origin, Destination);
                return false;
            }
            catch (IOException e)
            {
                //almaecnar en la base de datos el directorio donde se guardo para recuperarlo.
                //chekear si se guardo.
                this.Error =
                    "Origen: " + Origin +
                    "\nDestino " + Destination +
                    "\n\r" + e.ToString();
                return true;
            }
        }

        /// <summary>
        /// Arma el nombre del archivo con la fecha actualmas extencion.
        /// OK 100412
        /// </summary>
        /// <returns></returns>
        private string AssembleName()
        {
            //Cambiarle el nombre por la fecha y hora del momento
            string ano = DateTime.Now.Year.ToString();
            if (ano.Length <= 3)
                ano = this.addCaracter(ano, 4);

            string mes = DateTime.Now.Month.ToString();
            if (mes.Length <= 1)
                mes = this.addCaracter(mes, 2);

            string dia = DateTime.Now.Day.ToString();
            if (dia.Length <= 1)
                dia = this.addCaracter(dia, 2);

            string hr = DateTime.Now.Hour.ToString();
            if (hr.Length <= 1)
                hr = this.addCaracter(hr, 2);

            string min = DateTime.Now.Minute.ToString();
            if (min.Length <= 1)
                min = this.addCaracter(min, 2);

            string sec = DateTime.Now.Second.ToString();
            if (sec.Length <= 1)
                sec = this.addCaracter(sec, 2);

            return ano + mes + dia + "-" + hr + min + sec + this.Filter;
        }

        /// <summary>
        /// Agrega 0 al principio de la cadena
        /// OK 100412
        /// </summary>
        /// <param name="Str"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        private string addCaracter(string Str, int T)
        {
            for (int B = 0; B <= T - 2; B++)
                Str = Str.Insert(0, "0");
            return Str;
        }

        #endregion

        #region Restaurar

        /// <summary>
        /// Restaura un archivo desde el directorio indicado y la extencion indicada.
        /// OK 110412
        /// </summary>
        /// <param name="pathDestination"></param>
        /// <returns></returns>
        public bool RestoreFile(string Extension, string pathDestination)
        {
            // Filtro los archivos 
            string[] aFiles = this.FilterFiles(Extension, pathDestination);

            // Trae el ultimo archivo creado para restaurar
            string Origin = this.LastFile(aFiles);
            string Destination = oConsulta.Path + oConsulta.DBname;

            try
            {
                if (File.Exists(Destination))
                    File.Delete(Destination);

                //MUEVE el archivo ya con el nombre modificado adonde endique
                File.Copy(Origin, Destination);
                return false;
            }
            catch (IOException e)
            {
                this.Error = "Origin: " + Origin + 
                    "\nDstination: " + Destination + 
                    "\n\r" + e.ToString();
                return true;
            }
        }

        /// <summary>
        /// Devuelve la ruta completa del archivo que tiene la fecha mas reciente.
        /// OK 110412
        /// </summary>
        /// <param name="nFiles"></param>
        /// <returns></returns>
        private string LastFile(string[] nFiles)
        {
            // 
            DateTime Date;
            string Result = "";
            DateTime Temp = new DateTime();

            for (int A = 0; A <= nFiles.Length - 1; A++)
            {
                string Name = this.CropName(nFiles[A]);
                
                // 20120410-213604
                // Obtener año
                string Ano = Name.Substring(0, 4);
                // Obtener mes
                string mes = Name.Substring(4, 2);
                // Obtener dia
                string dia = Name.Substring(6, 2);
                // Obtener hr
                string hr = Name.Substring(9, 2);
                // Obtener min
                string min = Name.Substring(11, 2);
                // Obtener seg
                string seg = Name.Substring(13, 2);
                // Creo el objeto de la fecha
                Date = new DateTime(
                    Convert.ToInt32(Ano),
                    Convert.ToInt32(mes),
                    Convert.ToInt32(dia),
                    Convert.ToInt32(hr),
                    Convert.ToInt32(min),
                    Convert.ToInt32(seg)
                    );

                // Comparo buscando el mas cercano de los ultimos
                if (Temp <= Date)
                {
                    Temp = Date;
                    Result = nFiles[A];
                }
            }

            return Result;
        }

        /// <summary>
        /// Devuleve un array con los archivos filtrados. 
        /// OK 100412
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public string[] FilterFiles(string Extension, string Path)
        {
            // Obtengo todos los archivos desde el path
            string[] aFiles = Directory.GetFiles(Path);
            List<string> lFilter = new List<string>();

            // Filtro los archivos y obtengo los que me interesan
            for (int A = 0; A <= aFiles.Length - 1; A++)
            {
                // Obtengo la Extencion
                int LastPoint = aFiles[A].LastIndexOf('.');
                string nExtension = aFiles[A].Substring(LastPoint, aFiles[A].Length - LastPoint);
                
                // Filtro segun extencion
                if (nExtension == Extension)
                    lFilter.Add(aFiles[A]);
            }
            return lFilter.ToArray();
        }

        /// <summary>
        /// Devuelve solo el nombre con extencion del achivo,
        /// desde un ruta completa.
        /// OK 100412
        /// </summary>
        /// <param name="File"></param>
        /// <returns></returns>
        public string CropName(string File)
        {
            // Obtiene el nombre del archivo desde la ruta completa
            int LastBar = File.LastIndexOf('\\') + 1;
            return File.Substring(LastBar, File.Length - LastBar);
        }

        #endregion

        #endregion
    }
}


/*
 * Clase
 * 
 * 
 * 
 */
