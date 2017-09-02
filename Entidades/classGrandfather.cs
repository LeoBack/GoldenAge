using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class classGrandfather
    {
        #region Atributos y Metodos
        public int IdGrandfather { set; get; }
        public string Names { set; get; }
        public string LastName { set; get; }
        public DateTime Birthdate { set; get; }
        public int IdTypeDocument { set; get; }
        public int NumberDocument { set; get; }
        public int Sex { set; get; }
        public string Phone { set; get; }
        public int IdSocialWork { set; get; }
        public int AffiliateNumber { set; get; }
        public DateTime DateAdmission { set; get; }
        public DateTime EgressDate { set; get; }
        public int IdPersonCharge { set; get; }
        public string ReasonExit { set; get; }
        public bool Visible { set; get; }
        #endregion

        #region Constructores

        public classGrandfather()
        {
            this.IdGrandfather = 0;
            this.Names = "";
            this.LastName = "";
            this.Birthdate = DateTime.Now.AddYears(-65);
            this.IdTypeDocument = 0;
            this.NumberDocument = 0;
            this.Sex = 0;
            this.Phone = "";
            this.IdSocialWork = 0;
            this.AffiliateNumber = 0;
            this.DateAdmission=DateTime.Now;
            this.EgressDate = DateTime.Now.AddDays(90);
            this.IdPersonCharge = 0;
            this.ReasonExit = "";
            this.Visible=true;
        }

        
        public classGrandfather( int IdGrandfather, string Names, string LastName, DateTime Birthdate,           
            int IdTypeDocument, int NumberDocument,int Sex, string Phone, int IdSocialWork, int AffiliateNumber, 
            DateTime DateAdmission, DateTime EgressDate, int IdPersonCharge, string ReasonExit, bool Visible )
        {
            this.IdGrandfather = IdGrandfather;
            this.Names = Names;
            this.LastName = LastName;
            this.Birthdate = DateTime.Now.AddYears(-65);
            this.IdTypeDocument = IdTypeDocument;
            this.NumberDocument = NumberDocument;
            this.Sex = Sex;
            this.Phone =Phone;
            this.IdSocialWork = IdSocialWork;
            this.AffiliateNumber = AffiliateNumber;
            this.DateAdmission = DateAdmission;
            this.EgressDate = EgressDate;
            this.IdPersonCharge = IdPersonCharge;
            this.ReasonExit = ReasonExit;
            this.Visible=Visible;
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return
                "Id: " + this.IdGrandfather +
                "\nApellido y Nombre: " + this.LastName + ", " + this.Names +
                "\nFecha de Nacimiento: " +this.Birthdate +
                "\nTipo y Nro Doc: " + this.IdTypeDocument + "-" + this.NumberDocument +
                "\nSexo: " +this.Sex +
                "\nTelefono: " +this.Phone +
                "\nObra Social: " + this.IdSocialWork +
                "\nNumero de Afiliado: " + this.AffiliateNumber +
                "\nPersona a Cargo: " + this.IdPersonCharge +
                "\nFecha de Ingreso: " +this.DateAdmission +
                "\nFecha de Egreso: " +this.EgressDate +
                "\nMotivo de Egreso: " +this.ReasonExit +
                "\nVisible: " +this.Visible;
        }

        #endregion
    }
}