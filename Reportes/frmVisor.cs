using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using Reportes.Reportes;

namespace Reportes
{
    public partial class frmVisor : Form
    {
        #region Atributos y Propiedades

        public enum Reporte 
        { 
            RpDiagnostic = 0, 
            RpClinicHistory = 1, 
            RpOnlyPatient = 2, 
            RpPatientParent = 3, 
            RpListPatient = 4, 
            RpListProfessional = 5, 
            RpOnlyProfessional = 6 
        }

        private DataSet dS;
        private Reporte eReporte;
        private string PathReport; 

        #endregion

        #region Formulario

        public frmVisor(string pathReport, Reporte eReport, DataSet dtsTables)
        {
            InitializeComponent();
            PathReport = pathReport;
            eReporte = eReport;
            dS = dtsTables;
        }

        private void frmVisor_Load(object sender, EventArgs e)
        {
            if (dS.Tables.Count != 0)
            {
                switch(eReporte)
                {
                    case Reporte.RpDiagnostic:
                        crDiagnostic Diagnostic = new crDiagnostic();
                        Diagnostic.Load(PathReport);
                        Diagnostic.SetDataSource(dS);
                        crVisor.ReportSource = Diagnostic;
                        break;
                    case Reporte.RpClinicHistory:
                        crClinicHistory ClinicHistory = new crClinicHistory();
                        ClinicHistory.Load(PathReport);
                        ClinicHistory .SetDataSource(dS);
                        crVisor.ReportSource = ClinicHistory;
                        break;
                    case  Reporte.RpOnlyPatient:
                        crOnlyPatient OnlyPatient = new crOnlyPatient();
                        OnlyPatient.Load(PathReport);
                        OnlyPatient.SetDataSource(dS);
                        crVisor.ReportSource = OnlyPatient;
                        break;
                    case  Reporte.RpPatientParent:
                        crPatientParent PatientParent = new crPatientParent();
                        PatientParent.Load(PathReport);
                        PatientParent.SetDataSource(dS);
                        crVisor.ReportSource = PatientParent;
                        break;
                    case  Reporte.RpListPatient:
                        crListPatient ListPatient = new crListPatient();
                        ListPatient.Load(PathReport);
                        ListPatient.SetDataSource(dS);
                        crVisor.ReportSource = ListPatient;
                        break;
                    case  Reporte.RpOnlyProfessional:
                        crOnlyProfessional OnlyProfessional = new crOnlyProfessional();
                        OnlyProfessional.Load(PathReport);
                        OnlyProfessional.SetDataSource(dS);
                        crVisor.ReportSource = OnlyProfessional;
                        break;                    
                    case  Reporte.RpListProfessional:
                        crListProfessional ListProfessional = new crListProfessional();
                        ListProfessional.Load(PathReport);
                        ListProfessional.SetDataSource(dS);
                        crVisor.ReportSource = ListProfessional;
                        break;
                    default:
                        MessageBox.Show("Reporte no Existe");
                        break;
                }
            }
            else
            {
                MessageBox.Show("No se encontraron registros", "Atencion");
                this.Close();
            }
        }

        #endregion
    }
}
