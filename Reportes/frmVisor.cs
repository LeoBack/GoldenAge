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

        private DataTable[] aTable { set; get; }
        private Reporte eReporte { set; get; }

        #endregion

        #region Formulario

        public frmVisor(Reporte eReport, DataTable[] ArrayTable)
        {
            InitializeComponent();
            this.eReporte = eReport;
            this.aTable = ArrayTable;
        }

        private void frmVisor_Load(object sender, EventArgs e)
        {
            if (this.aTable.Length != 0)
            {
                switch(eReporte)
                {
                    case Reporte.RpDiagnostic:
                        //MessageBox.Show("RpDiagnostic - Nº rows: " + oTable.Rows.Count.ToString());
                        crDiagnostic Diagnostic = new crDiagnostic();
                        foreach(DataTable dT in aTable)
                            Diagnostic.SetDataSource(dT);
                        crVisor.ReportSource = Diagnostic;
                        break;
                    case Reporte.RpClinicHistory:
                        //MessageBox.Show("RpClinicHistory - Nº rows: " + oTable.Rows.Count.ToString());
                        crClinicHistory ClinicHistory = new crClinicHistory();
                        foreach (DataTable dT in aTable)
                            ClinicHistory.SetDataSource(dT);
                        crVisor.ReportSource = ClinicHistory;
                        break;
                    case  Reporte.RpOnlyPatient:
                        //MessageBox.Show("RpOnlyPatient - Nº rows: " + oTable.Rows.Count.ToString());
                        crOnlyPatient OnlyPatient = new crOnlyPatient();
                        foreach (DataTable dT in aTable)
                            OnlyPatient.SetDataSource(dT);
                        crVisor.ReportSource = OnlyPatient;
                        break;
                    case  Reporte.RpPatientParent:
                        //MessageBox.Show("RpPatientParent - Nº rows: " + oTable.Rows.Count.ToString());
                        crPatientParent PatientParent = new crPatientParent();
                        foreach (DataTable dT in aTable)
                            PatientParent.SetDataSource(dT);
                        crVisor.ReportSource = PatientParent;
                        break;
                    case  Reporte.RpListPatient:
                        //MessageBox.Show("RpListPatient- Nº rows: " + oTable.Rows.Count.ToString());
                        crListPatient ListPatient = new crListPatient();
                        foreach (DataTable dT in aTable)
                            ListPatient.SetDataSource(dT);
                        crVisor.ReportSource = ListPatient;
                        break;
                    case  Reporte.RpOnlyProfessional:
                        //MessageBox.Show("RpOnlyProfessional - Nº rows: " + oTable.Rows.Count.ToString());
                        crOnlyProfessional OnlyProfessional = new crOnlyProfessional();
                        foreach (DataTable dT in aTable)
                            OnlyProfessional.SetDataSource(dT);
                        crVisor.ReportSource = OnlyProfessional;
                        break;                    
                    case  Reporte.RpListProfessional:
                        //MessageBox.Show("RpListProfessional - Nº rows: " + oTable.Rows.Count.ToString());
                        crListProfessional ListProfessional = new crListProfessional();
                        foreach (DataTable dT in aTable)
                            ListProfessional.SetDataSource(dT);
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
