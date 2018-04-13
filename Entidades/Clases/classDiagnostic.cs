using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class ClassDiagnostic
    {
        #region Atributos y Metodos
        public int IdDiagnostic { set; get; }
        public int IdSpeciality { set; get; }
        public int IdPatient { set; get; }
        public int IdProfessional { set; get; }
        public string Detail { set; get; }
        public DateTime Date { set; get; }
        public int IdDestinationSpeciality { set; get; }
        public int IdDestinationProfessional { set; get; }
        public bool DestinationRead { set; get; }
        public bool Visible { set; get; }
        #endregion

        #region Constructores

        public ClassDiagnostic()
        {
            this.IdDiagnostic = 0;
            this.IdSpeciality = 0;
            this.IdPatient = 0;
            this.IdProfessional = 0;
            this.Detail = string.Empty;
            this.Date = DateTime.Now.Date;
            this.IdDestinationSpeciality = 0;
            this.IdDestinationProfessional = 0;
            this.DestinationRead = false;
            this.Visible = true;
        }

        public ClassDiagnostic(int vIdDiagnostic)
        {
            this.IdDiagnostic = vIdDiagnostic;
            this.IdSpeciality = 0;
            this.IdPatient = 0;
            this.IdProfessional = 0;
            this.Detail = string.Empty;
            this.Date = DateTime.Now.Date;
            this.IdDestinationSpeciality = 0;
            this.IdDestinationProfessional = 0;
            this.DestinationRead = false;
            this.Visible = true;
        }

        public ClassDiagnostic(int vIdDiagnostic, int vIdSpeciality, int vIdPatient, int vProfessional,
            string vDetail, DateTime vDate, int vIdDestinationSpeciality,  int vIdDestinationProfessional, 
            bool vDestinationRead, bool vVisible)
        {
            this.IdDiagnostic = vIdDiagnostic;
            this.IdSpeciality = vIdSpeciality;
            this.IdPatient = vIdPatient;
            this.IdProfessional = vProfessional;
            this.Detail = vDetail;
            this.Date = vDate;
            this.IdDestinationSpeciality = vIdDestinationSpeciality;
            this.IdDestinationProfessional = vIdDestinationProfessional;
            this.DestinationRead = vDestinationRead;
            this.Visible = vVisible;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return "Id: " + IdDiagnostic.ToString()+
            "\nEspecialidad: " + IdSpeciality.ToString()+
            "\nPaciente: " + IdPatient.ToString() +
            "\nProfessional: " + IdProfessional.ToString() +
            "\nDetalle: " + Detail +
            "\nFecha: " + Date.ToString() +
            "\nIdDestinationProfessional: " + IdDestinationProfessional.ToString() +
            "\nIdDestinationProfessional: " + IdDestinationProfessional.ToString() +
            "\nDestinationRead: " + DestinationRead.ToString() +
            "\nVisible: " + Visible.ToString();
        }

        #endregion
    }
}