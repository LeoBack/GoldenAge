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
        public string Names { set; get; }
        public string Description { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string AlternativePhone { set; get; }
        public bool Visible { set; get; }
        
        #endregion

        #region Constructores

        public classSocialWork()
        {
            this.IdSocialWork = 0;
            this.Names = "";
            this.Description = "";
            this.Address = "";
            this.Phone = "";
            this.AlternativePhone = "";
            this.Visible = true;
        }

        public classSocialWork(int IdSocialWork, string Names, string Description,
            string Address, string Phone, string AlternativePhone, bool Visible)
        {
            this.IdSocialWork = IdSocialWork;
            this.Names = Names;
            this.Description = Description;
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
            "Id: " + this.IdSocialWork +
            "\nNombre: " + this.Names +
            "\nDescripcion: " + this.Description +
            "\nDomicilio: " + this.Address + "" +
            "\nTelefono: " + this.Phone + "" +
            "\nTelefono Alternativo: " + this.AlternativePhone + "" +
            "\nVisible: " + this.Visible;
        }

        #endregion
    }
}
