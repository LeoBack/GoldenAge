using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class ClassSpecialty
    {
        #region Atributos y Metodos

        public int IdSpecialty { set; get; }
        public string Description { set; get; }
        public bool Visible { set; get; }
        
        #endregion

        #region Constructores

        public ClassSpecialty()
        {
            IdSpecialty = 0;
            Description = string.Empty;
            Visible = true;
        }

        public ClassSpecialty(int vIdSpecialty)
        {
            IdSpecialty = vIdSpecialty;
            Description = string.Empty;
            Visible = true;
        }

        public ClassSpecialty(int vIdSpecialty, string vDescription, bool vVisible)
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
