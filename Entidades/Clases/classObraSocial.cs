using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Clases
{
    public class classObraSocial
    {
        #region Atributos y Metodos

        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Descripcion { set; get; }
        public int IdCiudad { set; get; }
        public int IdBarrio { set; get; }
        public string Direccion { set; get; }
        public string Telefono1 { set; get; }
        public string Telefono2 { set; get; }
        public int Visible { set; get; }

        #endregion

        #region Constructores

        public classObraSocial()
        {
            this.Id = 0;
            this.Nombre = "";
            this.Descripcion = "";
            this.IdCiudad = 0;
            this.IdBarrio = 0;
            this.Direccion = "";
            this.Telefono1= "";
            this.Telefono2= "";
            this.Visible = 1;
        }

        public classObraSocial(int Id, string Nombre, string Descripcion, int IdCiudad, int IdBarrio, 
            string Direccion, string Telefono1, string Telefono2, int Visible)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.IdCiudad = IdCiudad;
            this.IdBarrio = IdBarrio;
            this.Direccion = Direccion;
            this.Telefono1 = Telefono1;
            this.Telefono2 = Telefono2;
            this.Visible = Visible;
        }

        #endregion


    }
}
