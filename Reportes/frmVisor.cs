using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using Reportes.Reportes;
using System.IO;

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
            if (dS == null || dS.Tables.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Atencion");
                this.Close();
            }

            switch (eReporte)
            {
                case Reporte.RpDiagnostic:
                    crDiagnostic Diagnostic = new crDiagnostic();
                    Diagnostic.Load(Path.Combine(PathReport, "crDiagnostic.rpt"));
                    Diagnostic.SetDataSource(dS);
                    crVisor.ReportSource = Diagnostic;
                    break;
                case Reporte.RpClinicHistory:
                    crClinicHistory ClinicHistory = new crClinicHistory();
                    ClinicHistory.Load(Path.Combine(PathReport, "crClinicHistory.rpt"));
                    ClinicHistory.SetDataSource(dS);
                    crVisor.ReportSource = ClinicHistory;
                    break;
                case Reporte.RpOnlyPatient:
                    crOnlyPatient OnlyPatient = new crOnlyPatient();
                    OnlyPatient.Load(Path.Combine(PathReport, "crOnlyPatient.rpt"));
                    OnlyPatient.SetDataSource(dS);
                    crVisor.ReportSource = OnlyPatient;
                    break;
                case Reporte.RpPatientParent:
                    crPatientParent PatientParent = new crPatientParent();
                    PatientParent.Load(Path.Combine(PathReport, "crPatientParent.rpt"));
                    PatientParent.SetDataSource(dS);
                    crVisor.ReportSource = PatientParent;
                    break;
                case Reporte.RpListPatient:
                    crListPatient ListPatient = new crListPatient();
                    ListPatient.Load(Path.Combine(PathReport, "crListPatient.rpt"));
                    ListPatient.SetDataSource(dS);
                    crVisor.ReportSource = ListPatient;
                    break;
                case Reporte.RpOnlyProfessional:
                    crOnlyProfessional OnlyProfessional = new crOnlyProfessional();
                    OnlyProfessional.Load(Path.Combine(PathReport, "crOnlyProfessional.rpt"));
                    OnlyProfessional.SetDataSource(dS);
                    crVisor.ReportSource = OnlyProfessional;
                    break;
                case Reporte.RpListProfessional:
                    crListProfessional ListProfessional = new crListProfessional();
                    ListProfessional.Load(Path.Combine(PathReport, "crListProfessional.rpt"));
                    ListProfessional.SetDataSource(dS);
                    crVisor.ReportSource = ListProfessional;
                    break;
                default:
                    MessageBox.Show("Reporte no Existe");
                    break;
            }
        }

        #endregion
    }
}
