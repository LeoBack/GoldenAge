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

        public enum Reporte { ListaTurnos = 0, ListaPacientes = 1, HistoriaClinica = 2, PacienteXObraSocial = 4 }
        private DataTable Tabla { set; get; }
        private Reporte eReporte { set; get; }

        #endregion

        #region Formulario

        public frmVisor(Reporte eReport, DataTable oTabla)
        {
            InitializeComponent();
            this.eReporte = eReport;
            this.Tabla = oTabla;
        }

        private void frmVisor_Load(object sender, EventArgs e)
        {
            if (this.Tabla.Rows.Count != 0)
            {
                if (eReporte == Reporte.ListaTurnos)
                {
                    Reportes.crListaTurnos Doc = new Reportes.crListaTurnos();
                    Doc.SetDataSource(this.Tabla);
                    crVisor.ReportSource = Doc;
                }
                else if (eReporte == Reporte.ListaPacientes)
                {
                    Reportes.crListaPacientes Doc = new Reportes.crListaPacientes();
                    Doc.SetDataSource(this.Tabla);
                    crVisor.ReportSource = Doc;
                }
                else if (eReporte == Reporte.HistoriaClinica)
                {
                    Reportes.crHistoriaClinica Doc = new Reportes.crHistoriaClinica();
                    Doc.SetDataSource(this.Tabla);
                    crVisor.ReportSource = Doc;
                }
                else if (eReporte == Reporte.PacienteXObraSocial)
                {
                    Reportes.crObraSocialPacientes Doc = new Reportes.crObraSocialPacientes();
                    Doc.SetDataSource(this.Tabla);
                    crVisor.ReportSource = Doc;
                }
                else
                { }
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
