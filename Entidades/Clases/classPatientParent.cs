using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class classPatientParent
    {
        #region Atributos y Metodos
        public int IdPatientParent { set; get; }
        public int IdPatient { set; get; }
        public int IdParent { set; get; }
        public int IdRelationship { set; get; }
        public bool Visible { set; get; }

        #endregion

        #region Constructores
        
        public classPatientParent()
        {
            this.IdPatientParent = 0;
            this.IdPatient = 0;
            this.IdParent = 0;
            this.IdRelationship = 0;
            this.Visible = true;
        }

        public classPatientParent(int vIdPatientParent)
        {
            this.IdPatientParent = vIdPatientParent;
            this.IdPatient = 0;
            this.IdParent = 0;
            this.IdRelationship = 0;
            this.Visible = true;
        }

        public classPatientParent(int vIdPatientParent, int vIdPatient, int vIdParent, int vIdRelationship, bool vVisible)
        {
            this.IdPatientParent = vIdPatientParent;
            this.IdPatient = vIdPatient;
            this.IdParent = vIdParent;
            this.IdRelationship = vIdRelationship;
            this.Visible = vVisible;
        }
        
        #endregion

        #region Methods

        public override string ToString()
        {
            return "Id: " + this.IdPatientParent.ToString() +
                "\nPatient: " + this.IdPatient.ToString() +
                "\nParentezco: " + this.IdParent.ToString() +
                "\nRelación: " + this.IdRelationship.ToString() +
                "\nVisible: " + this.Visible.ToString();
        }

        #endregion
    }
}
