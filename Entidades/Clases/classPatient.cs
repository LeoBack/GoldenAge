using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class ClassPatient
    {
        #region Atributos y Metodos

        public int IdPatient { set; get; }
        public string Name { set; get; }
        public string LastName { set; get; }
        public DateTime Birthdate { set; get; }
        public int IdTypeDocument { set; get; }
        public int NumberDocument { set; get; }
        public bool Sex { set; get; }
        public int IdLocationCountry { set; get; }
        public int IdLocationProvince { set; get; }
        public int IdLocationCity { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public bool Visible { set; get; }

        #endregion

        #region Constructores

        public ClassPatient()
        {
            this.IdPatient = 0;
            this.Name = string.Empty;
            this.LastName = string.Empty;
            this.Birthdate = DateTime.Now.AddYears(-65);
            this.IdTypeDocument = 0;
            this.NumberDocument = 0;
            this.Sex = true;
            this.IdLocationCountry = 0;
            this.IdLocationProvince = 0;
            this.IdLocationCity = 0;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Visible = true;
        }

        public ClassPatient(int vIdPatient)
        {
            this.IdPatient = vIdPatient;
            this.Name = string.Empty;
            this.LastName = string.Empty;
            this.Birthdate = DateTime.Now.AddYears(-65);
            this.IdTypeDocument = 0;
            this.NumberDocument = 0;
            this.Sex = true;
            this.IdLocationCountry = 0;
            this.IdLocationProvince = 0;
            this.IdLocationCity = 0;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Visible = true;
        }

        public ClassPatient(int vIdPatient, string vName, string vLastName, DateTime vBirthdate,
            int vIdTypeDocument, int vNumberDocument, bool vSex, int IdLocationCountry, 
            int IdLocationProvince, int IdLocationCity, string vAddress, string vPhone, bool vVisible)
        {
            this.IdPatient = vIdPatient;
            this.Name = vName;
            this.LastName = vLastName;
            this.Birthdate = vBirthdate;
            this.IdTypeDocument = vIdTypeDocument;
            this.NumberDocument = vNumberDocument;
            this.Sex = vSex;
            this.IdLocationCountry = IdLocationCountry;
            this.IdLocationProvince = IdLocationProvince;
            this.IdLocationCity = IdLocationCity;
            this.Address = vAddress;
            this.Phone = vPhone;
            this.Visible = vVisible;
        }
        
        #endregion

        #region Methods

        public override string ToString()
        {
            return
                "Id: " + this.IdPatient.ToString() +
                "\nApellido y Nombre: " + this.LastName + ", " + this.Name +
                "\nFecha de Nacimiento: " +this.Birthdate.ToShortDateString() +
                "\nTipo y Nro Doc: " + this.IdTypeDocument.ToString() + "-" + this.NumberDocument.ToString() +
                "\nSexo: " + this.Sex.ToString() +
                "\nPais: " + this.IdLocationCountry +
                "\nProvincia: " + this.IdLocationProvince +
                "\nCiudad: " + this.IdLocationCity +
                "\nDomicilio: " + this.Address +
                "\nTelefono: " + this.Phone.ToString() +
                "\nVisible: " + this.Visible.ToString();
        }

        public int YearsOld()
        {
            return DateTime.Now.Year - this.Birthdate.Year;
        }

        #endregion
    }
}