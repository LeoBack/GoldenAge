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
        public string Names { set; get; }
        public string LastName { set; get; }
        public string Direccion { set; get; }
        public string Phone { set; get; }
        public string Mail { set; get; }
        public string User { set; get; }
        public string Password { set; get; }
        public int IdSpecialty { set; get; }
        public string SpecialtyDescription { set; get; }
        #endregion

        #region Constructores
        public classProfessional()
        {
            this.IdProfessional = 0;
            this.ProfessionalRegistration = 1;
            this.Names = "";
            this.LastName = "";
            this.Phone = "";
            this.Mail = "";
            this.User = "";
            this.Password = "";
            this.IdSpecialty = 0;
            this.SpecialtyDescription = "";
        }

        public classProfessional(int IdProfessional, int ProfessionalRegistration, string Names, string LastNames, string Phone, string Mail, string User, string Password, int IdSpecialty, string SpecialtyDescription)
        {
            this.IdProfessional = IdProfessional;
            this.ProfessionalRegistration = ProfessionalRegistration;
            this.Names = Names;
            this.LastName = LastName;
            this.Phone = Phone;
            this.Mail = Mail;
            this.User = User;
            this.Password = Password;
            this.IdSpecialty = IdSpecialty;
            this.SpecialtyDescription = SpecialtyDescription;
        }

        #endregion

        #region Metodos
        public string toString()
        {
            return
                "Id: " + this.IdProfessional +
                "\nMatriculaProfesional: " + this.ProfessionalRegistration +
                "\nApellido y Nombre: " + this.LastName + ", " + this.Names +
                "\nTelefono: " + this.Phone + "" +
                "\nE-Mail: " + this.Mail + "" +
                "\nUsuario: " + this.User + "" +
                "\nClave: " + this.Password + "" +
                "\nEspecialidad: " + this.SpecialtyDescription;
        }

        #endregion
    }
}
