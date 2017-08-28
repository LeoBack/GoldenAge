using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Clases
{
    public class classBarrio
    {
        #region Atributos y Metodos

        public int IdCiudad { set; get; }
        public int IdBarrio { set; get; }
        public string Nombre { set; get; }

        #endregion

        #region Constructores

        public classBarrio()
        {
            this.IdCiudad = 0;
            this.IdBarrio = 0;
            this.Nombre = "";
        }

        public classBarrio(int IdCiudad, int IdBarrio, string Nombre)
        {
            this.IdCiudad = IdCiudad;
            this.IdBarrio = IdBarrio;
            this.Nombre = Nombre;
        }

        #endregion
    }
}
