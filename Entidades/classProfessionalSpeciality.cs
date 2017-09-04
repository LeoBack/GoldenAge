using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class classProfessionalSpeciality
    {
        #region Atributos y Metodos
        private int IdProfessionalSpeciality { set; get; }
        private int IdProfessional { set; get; }
        private int IdSpeciality { set; get; }
        private bool Visible { set; get; }
        #endregion

        #region Constructores
        
        public classProfessionalSpeciality()
        {
            this.IdProfessionalSpeciality = 0;
            this.IdProfessional = 0;
            this.IdSpeciality = 0;
            this.Visible = true;
        }

        public classProfessionalSpeciality(int IdProfessionalSpeciality, int IdProfessional, int IdSpeciality, bool Visible)
        {
            this.IdProfessionalSpeciality = IdProfessionalSpeciality;
            this.IdProfessional = IdProfessional;
            this.IdSpeciality = IdSpeciality;
            this.Visible = Visible;
        }
        #endregion

        #region Methods

        public string ToString()
        {
            return "Id: " + this.IdProfessionalSpeciality.ToString() +
            "\nProfesional: " + this.IdProfessional.ToString() +
            "\nEspecialidad: " + this.IdSpeciality.ToString()  +
            "\nVisible: " + this.Visible.ToString();
        }

        #endregion
    }
}
