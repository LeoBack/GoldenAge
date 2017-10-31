using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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

        private DataTable oTable { set; get; }
        private Reporte eReporte { set; get; }

        #endregion

        #region Formulario

        public frmVisor(Reporte eReport, DataTable oTabla)
        {
            InitializeComponent();
            this.eReporte = eReport;
            this.oTable = oTabla;
        }

        private void frmVisor_Load(object sender, EventArgs e)
        {
            if (this.oTable.Rows.Count != 0)
            {
                object DocReport;
                switch(eReporte)
                {
                    case Reporte.RpDiagnostic:
                        MessageBox.Show("RpDiagnostic - Nº rows: " + oTable.Rows.Count.ToString());
                        DocReport = new Reportes.crClinicHistory();
                        //DocReport.SetDataSource(oTable);
                        crVisor.ReportSource = DocReport;
                        break;
                    case Reporte.RpClinicHistory:
                        MessageBox.Show("RpClinicHistory - Nº rows: " + oTable.Rows.Count.ToString());
                        DocReport = new Reportes.crClinicHistory();
                        //DocReport.SetDataSource(oTable);
                        crVisor.ReportSource = DocReport;
                        break;
                    case  Reporte.RpOnlyPatient:
                        MessageBox.Show("RpOnlyPatient - Nº rows: " + oTable.Rows.Count.ToString());
                        DocReport = new Reportes.crOnlyPatient();
                        //DocReport.SetDataSource(oTable);
                        crVisor.ReportSource = DocReport;
                        break;
                    case  Reporte.RpPatientParent:
                        MessageBox.Show("RpPatientParent - Nº rows: " + oTable.Rows.Count.ToString());
                        DocReport = new Reportes.crPatientParent();
                        //DocReport.SetDataSource(oTable);
                        crVisor.ReportSource = DocReport;
                        break;
                    case  Reporte.RpListPatient:
                        MessageBox.Show("RpListPatient- Nº rows: " + oTable.Rows.Count.ToString());
                        DocReport = new Reportes.crListPatient();
                        //DocReport.SetDataSource(oTable);
                        crVisor.ReportSource = DocReport;
                        break;
                    case  Reporte.RpOnlyProfessional:
                        MessageBox.Show("RpOnlyProfessional - Nº rows: " + oTable.Rows.Count.ToString());
                        DocReport = new Reportes.crOnlyProfessional();
                        //DocReport.SetDataSource(oTable);
                        crVisor.ReportSource = DocReport;
                        break;                    
                    case  Reporte.RpListProfessional:
                        MessageBox.Show("RpListProfessional - Nº rows: " + oTable.Rows.Count.ToString());
                        DocReport = new Reportes.crListProfessional();
                        //DocReport.SetDataSource(oTable);
                        crVisor.ReportSource = DocReport;
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
