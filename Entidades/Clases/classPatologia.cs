using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Clases
{
    public class classPatologia
    {
        public int IdDetalle { set; get; }
        public string Detalle { set; get; }

        public classPatologia()
        {
            this.IdDetalle = 0;
            this.Detalle = "";
        }

        public classPatologia(int IdDetalle, string Detalle)
        {
            this.IdDetalle = IdDetalle;
            this.Detalle = Detalle;
        }
    }
}
