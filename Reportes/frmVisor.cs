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
                switch(eReporte)
                {
                    case Reporte.RpDiagnostic:
                        MessageBox.Show("RpDiagnostic - Nº rows: " + oTable.Rows.Count.ToString());
                        Reportes.crClinicHistory DocQ = new Reportes.crClinicHistory();
                        //DocA.SetDataSource(oTable);
                        crVisor.ReportSource = DocQ;
                        break;
                    case Reporte.RpClinicHistory:
                        MessageBox.Show("RpClinicHistory - Nº rows: " + oTable.Rows.Count.ToString());
                        Reportes.crClinicHistory DocA = new Reportes.crClinicHistory();
                        //DocA.SetDataSource(oTable);
                        crVisor.ReportSource = DocA;
                        break;
                    case  Reporte.RpOnlyPatient:
                        MessageBox.Show("RpOnlyPatient - Nº rows: " + oTable.Rows.Count.ToString());
                        Reportes.crOnlyPatient DocB = new Reportes.crOnlyPatient();
                        //DocB.SetDataSource(oTable);
                        crVisor.ReportSource = DocB;
                        break;
                    case  Reporte.RpPatientParent:
                        MessageBox.Show("RpPatientParent - Nº rows: " + oTable.Rows.Count.ToString());
                        Reportes.crPatientParent DocC = new Reportes.crPatientParent();
                        //DocC.SetDataSource(oTable);
                        crVisor.ReportSource = DocC;
                        break;
                    case  Reporte.RpListPatient:
                        MessageBox.Show("RpListPatient- Nº rows: " + oTable.Rows.Count.ToString());
                        Reportes.crListPatient DocD = new Reportes.crListPatient();
                        //DocD.SetDataSource(oTable);
                        crVisor.ReportSource = DocD;
                        break;
                    case  Reporte.RpOnlyProfessional:
                        MessageBox.Show("RpOnlyProfessional - Nº rows: " + oTable.Rows.Count.ToString());
                        Reportes.crOnlyProfessional DocE = new Reportes.crOnlyProfessional();
                        //DocE.SetDataSource(oTable);
                        crVisor.ReportSource = DocE;
                        break;                    
                    case  Reporte.RpListProfessional:
                        MessageBox.Show("RpListProfessional - Nº rows: " + oTable.Rows.Count.ToString());
                        Reportes.crListProfessional DocF = new Reportes.crListProfessional();
                        //DocF.SetDataSource(oTable);
                        crVisor.ReportSource = DocF;
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
