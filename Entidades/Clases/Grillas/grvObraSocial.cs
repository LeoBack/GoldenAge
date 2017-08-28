using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Clases.Grillas
{
    public class grvObraSocial
    {
         #region Atributos y Metodos

        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Descripcion { set; get; }
        public int Visible { set; get; }

        #endregion

        #region Constructores

        public grvObraSocial()
        {
            this.Id = 0;
            this.Nombre = "";
            this.Descripcion = "";
            this.Visible = 1;
        }

        public grvObraSocial(int Id, string Nombre, string Descripcion, int Visible)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Visible = Visible;
        }

        #endregion
    }
}
