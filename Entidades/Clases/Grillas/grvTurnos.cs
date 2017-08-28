using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Clases.Grillas
{
    public class grvTurnos
    {
        #region Atributos y Propiedades

        public int Id { set; get; }
        public string Dia { set; get; }
        public string Hora { set; get; }
        public string EstadoNombre { set; get; }
        public int IdPaciente { set; get; }
        public string Usuario { set; get; }
        public string Paciente { set; get; }

        public grvTurnos()
        {
            this.Id = 0;
            this.Dia = DateTime.Now.ToLongDateString();
            this.Hora = DateTime.Now.ToLongTimeString();
            this.EstadoNombre = "";
            this.IdPaciente = 0;
            this.Usuario = "";
            this.Paciente = "";
        }

        public grvTurnos(int Id, string Dia, string Hora, string EstadoNombre, int IdPaciente, string IdUsuario, string Paciente)
        {
            this.Id = Id;
            this.Dia = Dia;
            this.Hora = Hora;
            this.EstadoNombre = EstadoNombre;
            this.IdPaciente = IdPaciente;
            this.Usuario = IdUsuario;
            this.Paciente = Paciente;
        }

        #endregion
    }
}
