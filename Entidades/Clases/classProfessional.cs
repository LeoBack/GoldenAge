using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class ClassProfessional
    {
        #region Atributos y Metodos
        public int IdProfessional { set; get; }
        public string Name { set; get; }
        public string LastName { set; get; }
        public string ProfessionalRegistration { set; get; }
        public int IdLocationCountry { set; get; }
        public int IdLocationProvince { set; get; }
        public int IdLocationCity { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Mail { set; get; }
        public string User { set; get; }
        public string Password { set; get; }
        public int IdPermission { set; get; }
        public bool Visible { set; get; }
        
        #endregion

        #region Constructores

        public ClassProfessional()
        {
            this.IdProfessional = 0;
            this.Name = string.Empty;
            this.LastName = string.Empty;
            this.ProfessionalRegistration = string.Empty;
            this.IdLocationCountry = 0;
            this.IdLocationProvince = 0;
            this.IdLocationCity = 0;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Mail = string.Empty;
            this.User = string.Empty;
            this.Password = string.Empty;
            this.IdPermission = 0;
            this.Visible = true;
        }

        public ClassProfessional(int vIdProfessional)
        {
            this.IdProfessional = vIdProfessional;
            this.Name = string.Empty;
            this.LastName = string.Empty;
            this.ProfessionalRegistration = string.Empty;
            this.IdLocationCountry = 0;
            this.IdLocationProvince = 0;
            this.IdLocationCity = 0;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Mail = string.Empty;
            this.User = string.Empty;
            this.Password = string.Empty;
            this.IdPermission = 0;
            this.Visible = true;
        }

        public ClassProfessional(int vIdProfessional, string vName, string vLastName, string vProfessionalRegistration, 
            int vIdLocationCountry, int vIdLocationProvince, int vIdLocationCity, string vAddress, string vPhone,
            string vMail, string vUser, string vPassword, int vIdPermission, bool vVisible)
        {
            this.IdProfessional = vIdProfessional;
            this.Name = vName;
            this.LastName = vLastName;
            this.ProfessionalRegistration = vProfessionalRegistration;
            this.IdLocationCountry = vIdLocationCountry;
            this.IdLocationProvince = vIdLocationProvince;
            this.IdLocationCity = vIdLocationCity;
            this.Address = vAddress;
            this.Phone = vPhone;
            this.Mail = vMail;
            this.User = vUser;
            this.Password = vPassword;
            this.IdPermission = vIdPermission;
            this.Visible = vVisible;
        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            return
                "IdProfessional: " + this.IdProfessional.ToString() +
                "\nApellido y Nombre: " + this.LastName + ", " + this.Name +
                "\nMatriculaProfesional: " + this.ProfessionalRegistration +
                "\nPais: " + this.IdLocationCountry.ToString() +
                "\nProvincia: " + this.IdLocationProvince.ToString() +
                "\nCiudad: " + this.IdLocationCity.ToString() +
                "\nDomicilio: " + this.Address + "" +
                "\nTelefono: " + this.Phone + "" +
                "\nE-Mail: " + this.Mail + "" +
                "\nUsuario: " + this.User + "" +
                "\nClave: " + this.Password + "" +
                "\nIdPermission: " + this.IdPermission.ToString() + "" +
                "\nVisible: " + this.Visible.ToString();
        }

        #endregion
    }
}
