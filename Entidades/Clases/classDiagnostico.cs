using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Clases
{
    public class classDiagnostico
    {
        #region Atributos y Metodos

        public int IdDiagnostico { set; get; }
        public int IdPersona { set; get; } //Obsoleto
        public int IdDetalle { set; get; } //Speciality
        public string Diagnostico { set; get; }
        public DateTime Fecha { set; get; }

        #endregion

        #region Constructores

        public classDiagnostico()
        {
            this.IdDiagnostico = 0;
            this.IdPersona = 0;
            this.IdDetalle = 0;
            this.Diagnostico = "";
            this.Fecha = DateTime.Now.Date;
        }

        public classDiagnostico(int Id, int IdPersona, int IdDetalle, string Diagnostico, DateTime Fecha)
        {
            this.IdDiagnostico = Id;
            this.IdPersona = IdPersona;
            this.IdDetalle = IdDetalle;
            this.Diagnostico = Diagnostico;
            this.Fecha = Fecha;
        }

        #endregion
    }
}
