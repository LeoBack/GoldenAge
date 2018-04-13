using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class ClassTypeDocument
    {
        #region Atributos y Metodos

        public int IdTypeDocument { set; get; }
        public string Description { set; get; }
        public bool Visible { set; get; }
        
        #endregion

        #region Constructores

        public ClassTypeDocument()
        {
            this.IdTypeDocument = 0;
            this.Description = "";
            this.Visible = true;
        }

        public ClassTypeDocument(int vIdTypeDocument)
        {
            this.IdTypeDocument = vIdTypeDocument;
            this.Description = "";
            this.Visible = true;
        }

        public ClassTypeDocument(int vIdTypeDocument, string vDescription, bool vVisible)
        {
            this.IdTypeDocument = vIdTypeDocument;
            this.Description = vDescription;
            this.Visible = vVisible;
        }

        #endregion

        #region Metodos
        public string toString()
        {
            return
            "Id: " + this.IdTypeDocument +
            "\nTipo: " + this.Description +
            "\nVisible: " + this.Visible;
        }

        #endregion

    }
}
