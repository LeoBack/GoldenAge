using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class classProfessional
    {
        #region Atributos y Metodos
        public int IdProfessional { set; get; }
        public int ProfessionalRegistration{ set; get; }
        public string Name { set; get; }
        public string LastName { set; get; }
        public int IdLocationCountry { set; get; }
        public int IdLocationProvince { set; get; }
        public int IdLocationCity { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Mail { set; get; }
        public string User { set; get; }
        public string Password { set; get; }
        public bool Visible { set; get; }
        
        #endregion

        #region Constructores

        public classProfessional()
        {
            this.IdProfessional = 0;
            this.ProfessionalRegistration = 1;
            this.Name = string.Empty;
            this.LastName = string.Empty;
            this.IdLocationCountry = 0;
            this.IdLocationProvince = 0;
            this.IdLocationCity = 0;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Mail = string.Empty;
            this.User = string.Empty;
            this.Password = string.Empty;
            this.Visible = true;
        }

        public classProfessional(int vIdProfessional)
        {
            this.IdProfessional = vIdProfessional;
            this.ProfessionalRegistration = 1;
            this.Name = string.Empty;
            this.LastName = string.Empty;
            this.IdLocationCountry = 0;
            this.IdLocationProvince = 0;
            this.IdLocationCity = 0;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Mail = string.Empty;
            this.User = string.Empty;
            this.Password = string.Empty;
            this.Visible = true;
        }

        public classProfessional(int vIdProfessional, int vProfessionalRegistration, string vName, string vLastNames,
            int vIdLocationCountry, int vIdLocationProvince, int vIdLocationCity, string vAddress, string vPhone, 
            string vMail, string vUser, string vPassword, bool vVisible)
        {
            this.IdProfessional = vIdProfessional;
            this.ProfessionalRegistration = vProfessionalRegistration;
            this.Name = vName;
            this.LastName = LastName;
            this.IdLocationCountry = vIdLocationCountry;
            this.IdLocationProvince = vIdLocationProvince;
            this.IdLocationCity = vIdLocationCity;
            this.Address = vAddress;
            this.Phone = vPhone;
            this.Mail = vMail;
            this.User = vUser;
            this.Password = vPassword;
            this.Visible = vVisible;
        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            return
                "IdProfessional: " + this.IdProfessional.ToString() +
                "\nMatriculaProfesional: " + this.ProfessionalRegistration +
                "\nApellido y Nombre: " + this.LastName + ", " + this.Name +
                "\nPais: " + this.IdLocationCountry +
                "\nProvincia: " + this.IdLocationProvince +
                "\nCiudad: " + this.IdLocationCity +
                "\nDomicilio: " + this.Address + "" +
                "\nTelefono: " + this.Phone + "" +
                "\nE-Mail: " + this.Mail + "" +
                "\nUsuario: " + this.User + "" +
                "\nClave: " + this.Password + "" +
                "\nVisible: " + this.Visible.ToString();
        }

        #endregion
    }
}
