﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.newClases
{
    public class classParent
    {
        #region Atributos y Metodos
        public int IdParent { set; get; }
        public string Name { set; get; }
        public string LastName { set; get; }
        public int IdTypeDocument { set; get; }
        public int NumberDocument { set; get; }
        public string Phone { set; get; }
        public string AlternativePhone { set; get; }
        public string Email { set; get; }
        public int IdRelationship { set; get; }
        public string Address { set; get; }
        public bool Visible { set; get; }
        #endregion

         #region Constructores

        public classParent()
        {
            this.IdParent = 0;
            this.Name = string.Empty;
            this.LastName = string.Empty;
            this.IdTypeDocument = 0;
            this.NumberDocument = 0;
            this.Phone = string.Empty;
            this.AlternativePhone = string.Empty;
            this.Email = string.Empty;
            this.IdRelationship = 0;
            this.Address = string.Empty;
            this.Visible = true;
        }

        public classParent(int vIdParent, string vName, string vLastName, int vIdTypeDocument, int vNumberDocument,
            string vPhone, string vAlternativePhone, string vEmail, int vIdRelationship, string vAddress, bool vVisible)
        {
            this.IdParent = vIdParent;
            this.Name = vName;
            this.LastName = vLastName;
            this.IdTypeDocument = vIdTypeDocument;
            this.NumberDocument = vNumberDocument;
            this.Phone = vPhone;
            this.AlternativePhone = vAlternativePhone;
            this.Email = vEmail;
            this.IdRelationship = vIdRelationship;
            this.Address = vAddress;
            this.Visible = vVisible;
        }

        #endregion

         #region Metodos
        public override string ToString()
        {
            return
                "Id: " + this.IdParent.ToString() +
                "\nApellido y Nombre: " + this.LastName + ", " + this.Name +
                "\nTipo y Nro Doc: " + this.IdTypeDocument.ToString() + "-" + this.NumberDocument.ToString() +
                "\nTelefono: " +this.Phone +
                "\nTelefono Alternativo: " + this.AlternativePhone +
                "\nEmail: " + this.Email +
                "\nRelación: " + this.IdRelationship.ToString() +
                "\nDomicilio: " +this.Address +
                "\nVisible: " + this.Visible.ToString();
        }

        #endregion
    }
}