using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class classParentRelationship
    {
        #region Atributos y Metodos
        private int IdParentRelationship { set; get; }
        private int IdParent { set; get; }
        private int IdRelationship { set; get; }
        private bool Visible { set; get; }
        #endregion

        #region Constructores
        
        public classParentRelationship()
        {
            this.IdParentRelationship = 0;
            this.IdParent = 0;
            this.IdRelationship = 0;
            this.Visible = true;
        }

        public classParentRelationship(int IdParentRelationship, int IdParent, int IdRelationship, bool Visible)
        {
            this.IdParentRelationship = IdParentRelationship;
            this.IdParent = IdParent;
            this.IdRelationship = IdRelationship;
            this.Visible = Visible;
        }
        #endregion

        #region Methods

        public string ToString()
        {
            return "Id: " + this.IdParentRelationship.ToString() +
            "\nParentezco: " + this.IdParent.ToString() +
            "\nRelacion: " + this.IdRelationship.ToString()  +
            "\nVisible: " + this.Visible.ToString();
        }

        #endregion
    }
}
