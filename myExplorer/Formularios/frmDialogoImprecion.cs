using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Datos;
using Entidades;
using Entidades.Clases;
using Reportes;
using Controles;

namespace myExplorer.Formularios
{
    public partial class frmDialogoImprecion : Form
    {
        #region Atributos y Propiedades

        public classConsultas oConsulta { set; get; }
        public classUtiles oUtil { set; get; }
        public int IdObraSocial { set; get; }
        private classTextos oTxt = new classTextos();

        private frmVisor fE;

        #endregion

        public frmDialogoImprecion()
        {
            InitializeComponent();
        }

        private void frmDialogoImprecion_Load(object sender, EventArgs e)
        {
            this.Text = "Dialogo de Imprecion - Obra social: " +
                oConsulta.SelectObraSocial(new classObraSocial(this.IdObraSocial, "", "", 0, 0, "", "", "", 1)).Nombre;

            this.rbtPacientesAtendidosXOS.Checked = true;
            this.dtpDesde.Value = DateTime.Now.AddMonths(-1);
            this.dtpHasta.Value = DateTime.Now.AddMonths(-2);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            bool error = true;

            if (rbtPacientesAtendidosXOS.Checked)
            {
                if (oConsulta.listaPacientesObraSocial("dtObraSocial", this.dtpDesde.Value, this.dtpHasta.Value, true))
                {
                    error = false;
                    fE = new frmVisor(frmVisor.Reporte.PacienteXObraSocial, oConsulta.Table);
                    fE.Show();
                }
            }

            if (rbtTodosLosPacientes.Checked)
            {
                if (oConsulta.listaPacientesObraSocial("dtObraSocial", this.dtpDesde.Value, this.dtpHasta.Value, false))
                {
                    error = false;
                    fE = new frmVisor(frmVisor.Reporte.PacienteXObraSocial, oConsulta.Table);
                    fE.Show();
                }
            }

            if (error)
                MessageBox.Show(oTxt.ErrorListaConsulta);
        }
    }
}
