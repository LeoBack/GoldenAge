using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Clases
{
    public class classCiudad
    {
        #region Atributos y Metodos

        public int IdCiudad { set; get; }
        public string Nombre { set; get; }

        #endregion

        #region Constructores

        public classCiudad()
        {
            this.IdCiudad = 0;
            this.Nombre = "";
        }

        public classCiudad(int IdCiudad, string Nombre)
        {
            this.IdCiudad = IdCiudad;
            this.Nombre = Nombre;
        }

        #endregion
    }
}
