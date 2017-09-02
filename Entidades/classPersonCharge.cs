using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class classPersonCharge
    {
        #region Atributos y Metodos
        public int IdPersonCharge { set; get; }
        public string Names { set; get; }
        public string LastName { set; get; }
        public int IdTypeDocument { set; get; }
        public int NumberDocument { set; get; }
        public string Phone { set; get; }
        public string AlternativePhone { set; get; }
        public string Email { set; get; }
        public int IdRelationship { set; get; }
        public string DescriptionRelationship { set; get; }
        public string Address { set; get; }
        public bool Visible { set; get; }
        #endregion

         #region Constructores

        public classPersonCharge()
        {
            this.IdPersonCharge = 0;
            this.Names = "";
            this.LastName = "";
            this.IdTypeDocument = 0;
            this.NumberDocument = 0;
            this.Phone = "";
            this.AlternativePhone = "";
            this.Email = "";
            this.IdRelationship = 0;
            this.DescriptionRelationship = "";
            this.Address = "";
            this.Visible = true;
        }

        public classPersonCharge(int IdPersonCharge, string Names, string LastName, int IdTypeDocument, int NumberDocument,
            string Phone, string AlternativePhone, string Email, int IdRelationship, string DescriptionRelationship, string Address, bool Visible)
        {
            this.IdPersonCharge = IdPersonCharge;
            this.Names = Names;
            this.LastName = LastName;
            this.IdTypeDocument = IdTypeDocument;
            this.NumberDocument = NumberDocument;
            this.Phone =Phone;
            this.AlternativePhone = AlternativePhone;
            this.Email = Email;
            this.IdRelationship = IdRelationship;
            this.DescriptionRelationship = DescriptionRelationship;
            this.Address = Address;
            this.Visible = Visible;
        }

        #endregion

         #region Metodos
        public string toString()
        {
            return
                "Id: " + this.IdPersonCharge +
                "\nApellido y Nombre: " + this.LastName + ", " + this.Names +
                "\nTipo y Nro Doc: " + this.IdTypeDocument + "-" + this.NumberDocument +
                "\nTelefono: " +this.Phone +
                "\nTelefono Alternativo: " + this.AlternativePhone +
                "\nEmail: " + this.Email +
                "\nRelación: " + this.IdRelationship + "-" + this.DescriptionRelationship +
                "\nDomicilio: " +this.Address +
                "\nVisible: " + this.Visible 
                ;
        }

        #endregion
    }
}
