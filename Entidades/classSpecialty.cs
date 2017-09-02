using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class classSpecialty
    {
        
         #region Atributos y Metodos

        public int IdSpecialty { set; get; }
        public string SpecialtyDescription { set; get; }
        
        #endregion

         #region Constructores

        public classSpecialty()
        {
            this.IdSpecialty = 0;
            this.SpecialtyDescription = "";
        }

        public classSpecialty(int IdSpecialty, string SpecialtyDescription)
        {
            this.IdSpecialty = IdSpecialty;
            this.SpecialtyDescription = SpecialtyDescription;
        }

        #endregion

         #region Metodos
        public string toString()
        {
            return
                "Id: " + this.IdSpecialty +
                "\nDescripcion: " + this.SpecialtyDescription;
        }

        #endregion
    }
}
