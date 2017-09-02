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
        public int Age { set; get; }
        public string Phone { set; get; }
        public int IdobraSocial { set; get; }
        public int AffiliateNumber { set; get; }
        public DateTime DateAdmission { set; get; }
        public DateTime EgressDate { set; get; }
        
        #endregion

         #region Constructores

        public classGrandfather()
        {
            this.IdGrandfather = 0;
            this.Names = "";
            this.LastName = "";
        }

        public classGrandfather(int IdGrandfather, string Names, string LastName)
        {
            this.IdGrandfather = IdGrandfather;
            this.Names = Names;
            this.LastName = LastName;
        }

        #endregion

         #region Metodos
        public string toString()
        {
            return
                "Id: " + this.IdGrandfather +
                "\nDescripcion: " + this.SpecialtyDescription;
        }

        #endregion
    }
}
