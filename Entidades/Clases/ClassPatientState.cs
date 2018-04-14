using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class ClassPatientState
    {
        #region Atributos y Metodos

        public int IdPatientState { set; get; }
        public int IdPatient { set; get; }
        public string Description { set; get; }
        public DateTime Date { set; get; }
        public bool State { set; get; }
        public bool Visible { set; get; }

        #endregion

        #region Constructores

        public ClassPatientState()
        {
            IdPatientState = 0;
            IdPatient = 0;
            Description = string.Empty;
            Date = DateTime.Now;
            State= true;
            Visible = true;
        }

        public ClassPatientState(int vIdPatientState)
        {
            IdPatientState = vIdPatientState;
            IdPatient = 0;
            Description = string.Empty;
            Date = DateTime.Now;
            State= true;
            Visible = true;
        }

        public ClassPatientState(int vIdPatientState,int vIdPatient, string vDescription, DateTime vDate, bool vState, bool vVisible)
        {
            IdPatientState = vIdPatientState;
            IdPatient = vIdPatient;
            Description = vDescription;
            Date = vDate;
            State = vState;
            Visible = vVisible;
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            return
            "IdPatientState: " + IdPatientState.ToString() +
            "IdPatient: " + IdPatient.ToString() +
            "\nDescription: " + Description +
            "\nDate: " + Date.ToString() +
            "\nState: " + State.ToString() +
            "\nVisible: " + Visible.ToString();
        }

        #endregion

    }
}
