using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Clases
{
    public class classPersona
    {
        #region Atributos y Metodos

        public int IdPersona { set; get;}
        public int ObraSocial { set; get; }
        public int TipoPaciente { set; get; }
        public int IdCiudad { set; get; }
        public int IdBarrio{ set; get; }
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string Direccion { set; get; }
        public DateTime FechaNac { set; get; }
        public DateTime FechaAlta { set; get; }
        public int Sexo { set; get; }
        public string nAfiliado { set; get; }
        public string Telefono { set; get; }
        public string TelefonoParticular { set; get; }

        #endregion

        #region Constructores

        public classPersona()
        {
            this.IdPersona = 0;
            this.ObraSocial = 1;
            this.TipoPaciente = 1;
            this.IdCiudad = 0;
            this.IdBarrio = 0;
            this.Nombre = "";
            this.Apellido = "";
            this.Direccion = "";
            this.FechaNac = DateTime.Now.AddYears(-18);
            this.FechaAlta = DateTime.Now;
            this.Sexo = 1;
            this.nAfiliado = "";
            this.Telefono = "";
            this.TelefonoParticular = "";
        }

        public classPersona(int IdPersona, int ObraSocial,int TipoPaciente, int IdCiudad, int IdBarrio,
            string Nombre, string Apellido, string Direccion,
            DateTime FechaNac, DateTime FechaAlta, int Sexo, string nAfiliado, string Telefono, string TelefonoParticular)
        {
            this.IdPersona = IdPersona;
            this.ObraSocial = ObraSocial;
            this.TipoPaciente = TipoPaciente;
            this.IdCiudad = IdCiudad;
            this.IdBarrio = IdBarrio;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Direccion = Direccion;
            this.FechaNac = FechaNac;
            this.FechaAlta = FechaAlta;
            this.Sexo = Sexo;
            this.nAfiliado = nAfiliado;
            this.Telefono = Telefono;
            this.TelefonoParticular = TelefonoParticular;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Devuelme : 1-Femenino - 2-Masculino
        /// OK 20/06/12
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string toSexo(int s)
        {
            if (s == 0)
                return "Femenino";
            else if (s == 1)
                return "Masculino";
            else
                return "Indefinido";
        }

        public int Edad()
        {
            TimeSpan a = DateTime.Today.Subtract(this.FechaNac);
            double b = a.Days / 365.25;
            return Convert.ToInt32(b);
        }

        public int Edad(DateTime Fecha)
        {
            TimeSpan a = DateTime.Today.Subtract(Fecha);
            double b = a.Days / 365.25;
            return Convert.ToInt32(b);
        }

        #region Edad

        public string toMayorEdad(int Edad)
        {
            string De = "";
            int[] Filtro = new int[6];
            Filtro[0] = 5;
            Filtro[1] = 18;
            Filtro[2] = 21;
            Filtro[3] = 30;
            Filtro[4] = 40;
            Filtro[5] = 80;

            for (int V = 0; V <= Filtro.Length - 1; V++)
            {
                if (isEdadMayor(Edad, Filtro[V]))
                    De = "Edad Mayor de " + Filtro[V].ToString();
                else
                {
                    //De = "Edad menor o igual " + Filtro[V].ToString();
                    V = Filtro.Length;
                }
            }

            return De;
        }

        public string toMayorEdad(int Edad, int[] Filtro)
        {
            string De = "";

            for (int V = 0; V <= Filtro.Length - 1; V++)
            {
                if (isEdadMayor(Edad, Filtro[V]))
                    De = "Edad Mayor de " + Filtro[V].ToString();
                else
                {
                    De = "Edad menor o igual " + Filtro[V].ToString();
                    V = Filtro.Length;
                }
            }

            return De;
        }

        public string EdadMayor(int Edad, int Filtro)
        {
            if (Edad > Filtro)
                return "Mayor de " + Convert.ToString(Filtro);
            else
                return "Menor de " + Convert.ToString(Filtro);
        }

        public bool isEdadMayor(int Edad, int Filtro)
        {
            if (Edad > Filtro)
                return true;
            else
                return false;
        }

        public string EdadMenor(int Edad, int Filtro)
        {
            if (Edad < Filtro)
                return "Menor de " + Convert.ToString(Filtro);
            else
                return "Mayor de " + Convert.ToString(Filtro);
        }

        public bool isEdadMenor(int Edad, int Filtro)
        {
            if (Edad < Filtro)
                return true;
            else
                return false;
        }

        #endregion

        public string toString()
        {
            return
                "Id: " + this.IdPersona +
                "\nFecha de alta en el sistema: " + this.FechaAlta +
                "\nNombre: " + this.Apellido +", "+ this.Nombre +
                "\nSexo: " + this.Sexo + " Fecha Nacimiento: " + this.FechaNac +
                "\nDomiclio: " + this.Direccion +
                "\nTipo Paciente: " + this.TipoPaciente +
                "\nObra Social: " + this.ObraSocial + 
                " N° Afiliado: " + this.nAfiliado + "";
        }

        #endregion
    }
}
