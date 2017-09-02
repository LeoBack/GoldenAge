using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.newClases
{
    public class classSpecialty
    {
        #region Atributos y Metodos

        public int IdSpecialty { set; get; }
        public string Description { set; get; }
        public bool Visible { set; get; }
        
        #endregion

        #region Constructores

        public classSpecialty()
        {
            IdSpecialty = 0;
            Description = string.Empty;
            Visible = true;
        }

        public classSpecialty(int vIdSpecialty, string vDescription, bool vVisible)
        {
            IdSpecialty = vIdSpecialty;
            Description = vDescription;
            Visible = vVisible;
        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            return
            "IdSpecialty: " + IdSpecialty.ToString() +
            "\nDescription: " + Description +
            "\nVisible: " + Visible.ToString();
        }

        #endregion
    }
}
