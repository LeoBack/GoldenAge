using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.newClases
{
    public class classParentRelationship
    {
        #region Atributos y Metodos
        public int IdParentRelationship { set; get; }
        public int IdParent { set; get; }
        public int IdRelationship { set; get; }
        public bool Visible { set; get; }
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
