using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class classGrandfatherParent
    {
        #region Atributos y Metodos
        public int IdGrandfatherParent { set; get; }
        public int IdGrandfather { set; get; }
        public int IdParent { set; get; }
        public bool Visible { set; get; }

        #endregion

        #region Constructores
        
        public classGrandfatherParent()
        {
            this.IdGrandfatherParent = 0;
            this.IdGrandfather = 0;
            this.IdParent = 0;
            this.Visible = true;
        }

        public classGrandfatherParent(int vIdGrandfatherParent)
        {
            this.IdGrandfatherParent = vIdGrandfatherParent;
            this.IdGrandfather = 0;
            this.IdParent = 0;
            this.Visible = true;
        }

        public classGrandfatherParent(int vIdIdGrandfatherParent, int vIdGrandfather, int vIdParent, bool vVisible)
        {
            this.IdGrandfatherParent = IdGrandfatherParent;
            this.IdGrandfather = vIdGrandfather;
            this.IdParent = vIdParent;
            this.Visible = vVisible;
        }
        #endregion

        #region Methods

        public override string ToString()
        {
            return "Id: " + this.IdGrandfatherParent.ToString() +
            "\nGrandfather: " + this.IdGrandfather.ToString() +
                "\nParentezco: " + this.IdParent.ToString() +
             "\nVisible: " + this.Visible.ToString();
        }

        #endregion
    }
}
