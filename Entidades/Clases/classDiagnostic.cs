using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.newClases
{
    public class classDiagnostic
    {
        #region Atributos y Metodos
        public int IdDiagnostic { set; get; }
        public int IdSpeciality { set; get; } //Speciality
        public string Detail { set; get; }
        public DateTime DiagnosticDate { set; get; }
        public bool Visible { set; get; }
        #endregion

        #region Constructores
        public classDiagnostic()
        {
            this.IdDiagnostic = 0;
            this.IdSpeciality = 0;
            this.Detail = "";
            this.DiagnosticDate = DateTime.Now.Date;
            this.Visible = true;
        }

        public classDiagnostic(int IdDiagnostic, int IdSpeciality, string Detail, DateTime DiagnosticDate, bool Visible)
        {
            this.IdDiagnostic = IdDiagnostic;
            this.IdSpeciality = IdSpeciality;
            this.Detail = Detail;
            this.DiagnosticDate = DiagnosticDate;
            this.Visible = Visible;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return "Id: " + this.IdDiagnostic.ToString()+
            "\nEspecialidad: " + this.IdSpeciality.ToString()+
            "\nDetalle: " + this.Detail +
            "\nFecha: " + this.DiagnosticDate.ToString()+
            "\nVisible: " + this.Visible.ToString();
        
        }

        #endregion
    }
}