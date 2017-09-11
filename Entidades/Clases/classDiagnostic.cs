using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class classDiagnostic
    {
        #region Atributos y Metodos
        public int IdDiagnostic { set; get; }
        public int IdSpeciality { set; get; } 
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

        public classDiagnostic(int vIdDiagnostic)
        {
            this.IdDiagnostic = vIdDiagnostic;
            this.IdSpeciality = 0;
            this.Detail = "";
            this.DiagnosticDate = DateTime.Now.Date;
            this.Visible = true;
        }

        public classDiagnostic(int vIdDiagnostic, int vIdSpeciality, string vDetail, DateTime vDiagnosticDate, bool vVisible)
        {
            this.IdDiagnostic = vIdDiagnostic;
            this.IdSpeciality = vIdSpeciality;
            this.Detail = vDetail;
            this.DiagnosticDate = vDiagnosticDate;
            this.Visible = vVisible;
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