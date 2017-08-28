using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class classUtiles
    {
        public int IdUsuario { set; get; }
        public int CantRegistrosGrilla { set; get; }

        public classUtiles()
        {
            this.IdUsuario = 0;
            this.CantRegistrosGrilla = 20;
        }

        public classUtiles(int IdUsuario, int CantRegistrosGrilla)
        {
            this.IdUsuario = IdUsuario;
            this.CantRegistrosGrilla = CantRegistrosGrilla;
        }
    }
}
