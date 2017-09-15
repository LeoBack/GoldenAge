using System;
using System.Collections.Generic;
using System.Text;
//
using Entidades.Clases;

namespace Entidades
{
    public class classUtiles
    {
        public classProfessional oProfessional { set; get; }
        public int CantRegistrosGrilla { set; get; }

        public classUtiles()
        {
            this.oProfessional = null;
            this.CantRegistrosGrilla = 20;
        }

        public classUtiles(classProfessional vProfessional, int CantRegistrosGrilla)
        {
            this.oProfessional = vProfessional;
            this.CantRegistrosGrilla = CantRegistrosGrilla;
        }
    }
}
