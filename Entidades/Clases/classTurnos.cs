using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Clases
{
    public class classTurnos
    {
        #region Atributos y Propiedades

        public int Id { set; get; }
        public DateTime Turno { set; get; }
        public int Estado { set; get; }
        public int IdPersona { set; get; }
        public int IdUsuario { set; get; }

        public classTurnos()
        {
            this.Id = 0;
            this.Turno = DateTime.Now;
            this.Estado = 1;
            this.IdPersona = 0;
            this.IdUsuario = 0;
        }

        public classTurnos(int Id, DateTime Turnos, int Estado, int IdPersona, int IdUsuario)
        {
            this.Id = Id;
            this.Turno = Turnos;
            this.Estado = Estado;
            this.IdPersona = IdPersona;
            this.IdUsuario = IdUsuario;
        }
        
        #endregion
    }
}
