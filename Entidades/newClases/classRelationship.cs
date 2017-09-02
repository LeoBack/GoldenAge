using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.newClases
{
    public class classRelationship
    {
        #region Atributos y Metodos

        public int IdRelationship { set; get; }
        public string Description { set; get; }
        public bool Visible { set; get; }
        
        #endregion

        #region Constructores

        public classRelationship()
        {
            this.IdRelationship = 0;
            this.Description = string.Empty;
            this.Visible = true;
        }

        public classRelationship(int vIdRelationship, string vDescription, bool Visible)
        {
            this.IdRelationship = vIdRelationship;
            this.Description = vDescription;
            this.Visible = Visible;
        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            return
            "Id: " + this.IdRelationship.ToString() +
            "\nRelación: " + this.Description +
            "\nVisible: " + this.Visible.ToString();
        }

        #endregion
    }
}
