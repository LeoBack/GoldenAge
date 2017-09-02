using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.newClases
{
    public class classProfessional
    {
        #region Atributos y Metodos
        public int IdProfessional { set; get; }
        public int ProfessionalRegistration{ set; get; }
        public string Names { set; get; }
        public string LastName { set; get; }
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
            this.Names = "";
            this.LastName = "";
            this.Address = "";
            this.Phone = "";
            this.Mail = "";
            this.User = "";
            this.Password = "";
            this.Visible = true;
        }

        public classProfessional(int IdProfessional, int ProfessionalRegistration, string Names, string LastNames, string Address, string Phone, string Mail, string User, string Password, bool Visible)
        {
            this.IdProfessional = IdProfessional;
            this.ProfessionalRegistration = ProfessionalRegistration;
            this.Names = Names;
            this.LastName = LastName;
            this.Address = Address;
            this.Phone = Phone;
            this.Mail = Mail;
            this.User = User;
            this.Password = Password;
            this.Visible = Visible;
        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            return
                "Id: " + this.IdProfessional.ToString() +
                "\nMatriculaProfesional: " + this.ProfessionalRegistration +
                "\nApellido y Nombre: " + this.LastName + ", " + this.Names +
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
