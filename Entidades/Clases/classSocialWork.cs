using System;
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
        public int IdLocationCountry { set; get; }
        public int IdLocationProvince { set; get; }
        public int IdLocationCity { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string AlternativePhone { set; get; }
        public bool Visible { set; get; }
        
        #endregion

        #region Constructores

        public classSocialWork()
        {
            this.IdSocialWork = 0;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.IdLocationCountry = 0;
            this.IdLocationProvince = 0;
            this.IdLocationCity = 0;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.AlternativePhone = string.Empty;
            this.Visible = true;
        }

        public classSocialWork(int IdSocialWork, string Name, string Description,
            int IdLocationCountry, int IdLocationProvince, int IdLocationCity, string Address, string Phone, string AlternativePhone, bool Visible)
        {
            this.IdSocialWork = IdSocialWork;
            this.Name = Name;
            this.Description = Description;
            this.IdLocationCountry = IdLocationCountry;
            this.IdLocationProvince = IdLocationProvince;
            this.IdLocationCity = IdLocationCity;
            this.Address = Address;
            this.Phone = Phone;
            this.AlternativePhone = AlternativePhone;
            this.Visible = Visible;
        }

        #endregion

        #region Metodos
        public string toString()
        {
            return
            "Id: " + this.IdSocialWork.ToString() +
            "\nNombre: " + this.Name +
            "\nDescripcion: " + this.Description +
            "\nPais: " + this.IdLocationCountry +
            "\nProvincia: " + this.IdLocationProvince +
            "\nCiudad: " + this.IdLocationCity +
            "\nDomicilio: " + this.Address +
            "\nTelefono: " + this.Phone +
            "\nTelefono Alternativo: " + this.AlternativePhone +
            "\nVisible: " + this.Visible.ToString();
        }

        #endregion
    }
}
