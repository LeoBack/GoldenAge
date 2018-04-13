using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class ClassPatientSocialWork
    {
        // OK - 18/02/07
        #region Atributos y Metodos

        public int IdPatientSocialWork { set; get; }
        public int IdSocialWork { set; get; }
        public int IdPatient { set; get; }
        public string AffiliateNumber { set; get; }
        public bool Visible { set; get; }
        
        #endregion

        #region Constructores

        public ClassPatientSocialWork()
        {
            this.IdPatientSocialWork = 0;
            this.IdSocialWork = 0;
            this.IdPatient = 0;
            this.AffiliateNumber = string.Empty;
            this.Visible = true;
        }

        public ClassPatientSocialWork(int vIdPatientSocialWork)
        {
            this.IdPatientSocialWork = vIdPatientSocialWork;
            this.IdSocialWork = 0;
            this.IdPatient = 0;
            this.AffiliateNumber = string.Empty;
            this.Visible = true;
        }

        public ClassPatientSocialWork(int vIdPatientSocialWork, int vIdSocialWork, int vIdPatient,
            string vAffiliateNumber, bool vVisible)
        {
            this.IdPatientSocialWork = vIdPatientSocialWork;
            this.IdSocialWork = vIdSocialWork;
            this.IdPatient = vIdPatient;
            this.AffiliateNumber = vAffiliateNumber;
            this.Visible = vVisible;
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            return
            "IdPatientSocialWork: " + this.IdPatientSocialWork.ToString() +
            "\nIdSocialWork: " + this.IdSocialWork.ToString() +
            "\nIdPatient: " + this.IdPatient +
            "\nAffiliateNumber: " + this.AffiliateNumber +
            "\nVisible: " + this.Visible.ToString();
        }

        #endregion
    }
}
