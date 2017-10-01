using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class classTypeParent
    {
        #region Atributos y Metodos

        public int IdTypeParent { set; get; }
        public string Description { set; get; }
        public bool Visible { set; get; }

        #endregion

        #region Constructores

        public classTypeParent()
        {
            IdTypeParent = 0;
            Description = string.Empty;
            Visible = true;
        }

        public classTypeParent(int vIdTypeParent)
        {
            IdTypeParent = vIdTypeParent;
            Description = string.Empty;
            Visible = true;
        }

        public classTypeParent(int vIdTypeParent, string vDescription, bool vVisible)
        {
            IdTypeParent = vIdTypeParent;
            Description = vDescription;
            Visible = vVisible;
        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            return
            "IdTypeParent: " + IdTypeParent.ToString() +
            "\nDescription: " + Description +
            "\nVisible: " + Visible.ToString();
        }

        #endregion
    }
}
