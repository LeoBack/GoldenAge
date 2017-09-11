using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class classProfessionalSpeciality
    {
        #region Atributos y Metodos
        public int IdProfessionalSpeciality { set; get; }
        public int IdProfessional { set; get; }
        public int IdSpeciality { set; get; }
        public bool Visible { set; get; }
        #endregion

        #region Constructores
        
        public classProfessionalSpeciality()
        {
            this.IdProfessionalSpeciality = 0;
            this.IdProfessional = 0;
            this.IdSpeciality = 0;
            this.Visible = true;
        }

        public classProfessionalSpeciality(int vIdProfessionalSpeciality)
        {
            this.IdProfessionalSpeciality = vIdProfessionalSpeciality;
            this.IdProfessional = 0;
            this.IdSpeciality = 0;
            this.Visible = true;
        }

        public classProfessionalSpeciality(int vIdProfessionalSpeciality, int vIdProfessional, int vIdSpeciality, bool vVisible)
        {
            this.IdProfessionalSpeciality = vIdProfessionalSpeciality;
            this.IdProfessional = vIdProfessional;
            this.IdSpeciality = vIdSpeciality;
            this.Visible = vVisible;
        }
        #endregion

        #region Methods

        public override string ToString()
        {
            return "Id: " + this.IdProfessionalSpeciality.ToString() +
            "\nProfesional: " + this.IdProfessional.ToString() +
            "\nEspecialidad: " + this.IdSpeciality.ToString()  +
            "\nVisible: " + this.Visible.ToString();
        }

        #endregion
    }
}
