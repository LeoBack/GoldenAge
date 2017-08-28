using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Estadisticas
{
    public partial class frmVisor : Form
    {
        #region Atributos y Propiedades

        public enum Reporte { none = 0, ObraSocial = 1, Diagnostico = 2, Paciente = 3}
        private DataTable Tabla { set; get; }
        private Reporte eReporte { set; get; }
        private int IdUsuario { set; get; }

        #endregion

        #region Formulario

        public frmVisor(Reporte eReport, DataTable oTabla, int IdUsuario)
        {
            InitializeComponent();
            this.eReporte = eReport;
            this.Tabla = oTabla;
            this.IdUsuario = IdUsuario;
        }

        private void frmVisorE_Load(object sender, EventArgs e)
        {
            if (this.Tabla.Rows.Count != 0)
            {
                if (eReporte == Reporte.ObraSocial)
                {
                    Reportes.crObraSocial1 Doc = new Reportes.crObraSocial1();
                    Doc.SetDataSource(this.Tabla);
                    crVisor.ReportSource = Doc;
                }
                else if (eReporte == Reporte.Diagnostico)
                {
                    Reportes.crDiagnosticos Doc = new Reportes.crDiagnosticos();
                    Doc.SetDataSource(this.Tabla);
                    crVisor.ReportSource = Doc;
                }
                else if (eReporte == Reporte.Paciente)
                {
                    Reportes.crPacientes Doc = new Reportes.crPacientes();
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
