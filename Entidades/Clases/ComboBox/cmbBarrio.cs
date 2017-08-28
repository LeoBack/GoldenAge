using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Clases.ComboBox
{
    class cmbBarrio
    {
        #region Atributos y Propiedades

        public int Id { set; get; }
        public string Nombre { set; get; }
        public int IdCiudad { set; get; }

        #endregion

        #region Constructres

        public cmbBarrio()
        {
            this.Id = 0;
            this.Nombre = "";
            this.IdCiudad = 1;
        }

        public cmbBarrio(int Id, string Nombre, int IdCiudad)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.IdCiudad = IdCiudad;
        }

        #endregion
    }
}
