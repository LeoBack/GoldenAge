﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class classSocialWork
    {
        #region Atributos y Metodos

        public int IdSocialWork { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public int IdIvaType { set; get; }
        public int IdLocationCountry { set; get; }
        public int IdLocationProvince { set; get; }
        public int IdLocationCity { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Contact { set; get; }
        public bool Visible { set; get; }
        
        #endregion

        #region Constructores

        public classSocialWork()
        {
            this.IdSocialWork = 0;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.IdIvaType = 0;
            this.IdLocationCountry = 0;
            this.IdLocationProvince = 0;
            this.IdLocationCity = 0;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Contact = string.Empty;
            this.Visible = true;
        }

        public classSocialWork(int vIdSocialWork)
        {
            this.IdSocialWork = vIdSocialWork;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.IdIvaType = 0;
            this.IdLocationCountry = 0;
            this.IdLocationProvince = 0;
            this.IdLocationCity = 0;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Contact = string.Empty;
            this.Visible = true;
        }

        public classSocialWork(int vIdSocialWork, string vName, string vDescription, int vIdIvaType,
            int vIdLocationCountry, int vIdLocationProvince, int vIdLocationCity, string vAddress, string vPhone, string vContact, bool vVisible)
        {
            this.IdSocialWork = vIdSocialWork;
            this.Name = vName;
            this.Description = vDescription;
            this.IdIvaType = vIdIvaType;
            this.IdLocationCountry = vIdLocationCountry;
            this.IdLocationProvince = vIdLocationProvince;
            this.IdLocationCity = vIdLocationCity;
            this.Address = vAddress;
            this.Phone = vPhone;
            this.Contact = vContact;
            this.Visible = vVisible;
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            return
            "Id: " + this.IdSocialWork.ToString() +
            "\nNombre: " + this.Name +
            "\nDescripcion: " + this.Description +
            "\nTipo Iva: " + this.IdIvaType +
            "\nPais: " + this.IdLocationCountry +
            "\nProvincia: " + this.IdLocationProvince +
            "\nCiudad: " + this.IdLocationCity +
            "\nDomicilio: " + this.Address +
            "\nTelefono: " + this.Phone +
            "\nContacto: " + this.Contact +
            "\nVisible: " + this.Visible.ToString();
        }

        #endregion
    }
}
