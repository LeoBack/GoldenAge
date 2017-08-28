using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Clases.ComboBox
{
    class cmbCiudad
    {
        #region Atributos y Propiedades

        public int Id { set; get; }
        public string Nombre { set; get; }

        #endregion

        #region Constructres

        public cmbCiudad()
        {
            this.Id = 0;
            this.Nombre = "";
        }

        public cmbCiudad(int Id, string Nombre)
        {
            this.Id = Id;
            this.Nombre = Nombre;
        }

        #endregion
    }
}
