using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Clases.Grillas
{
    public class grvPersona
    {
        #region Atributos y Metodos

        public int IdPersona { set; get;}
        public string ObraSocial { set; get; }
        public int TipoPaciente { set; get; }
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string Direccion { set; get; }
        public DateTime FechaNac { set; get; }
        public string Sexo { set; get; }
        public string nAfiliado { set; get; }

        #endregion

        #region Constructores

        public grvPersona()
        {
            this.IdPersona = 0;
            this.ObraSocial = "";
            this.TipoPaciente = 1;
            this.Nombre = "";
            this.Apellido = "";
            this.Direccion = "";
            this.FechaNac = DateTime.Now;
            this.Sexo = "";
            this.nAfiliado = "";
        }

        public grvPersona(int IdPersona, string ObraSocial,int TipoPaciente, string Nombre, string Apellido, string Direccion, 
            DateTime FechaNac, string Sexo, string nAfiliado)
        {
            this.IdPersona = IdPersona;
            this.ObraSocial = ObraSocial;
            this.TipoPaciente = TipoPaciente;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Direccion = Direccion;
            this.FechaNac = FechaNac;
            this.Sexo = Sexo;
            this.nAfiliado = nAfiliado;
        }

        #endregion
    }
}
