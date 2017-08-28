using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using Datos;
using Entidades;
using Entidades.Clases;
using Estadisticas;
using Controles;

namespace myExplorer.Formularios
{
    public partial class frmEstadistica : Form
    {
        #region Atributos y Propiedades

        public classConsultas oConsulta { set; get; }
        public classUtiles oUtil { set; get; }
        private classTextos oTxt = new classTextos();

        private frmVisor fE;

        #endregion

        // OK 21/06/12
        #region Formulario

        public frmEstadistica()
        {
            InitializeComponent();
        }

        private void frmEstadistica_Load(object sender, EventArgs e)
        {
            if (oConsulta == null)
            {
                MessageBox.Show(oTxt.ErrorObjetoIndefinido);
                this.Close();
            }
            else
                dtpDesde.Value = DateTime.Now.AddMonths(-1);
        }

        #endregion

        // OK 21/06/12
        #region Botones

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            bool error = true;

            if (rbtObraSocial.Checked)
            {
                if (oConsulta.eObraSocial("dtObraSocial", this.dtpDesde.Value, this.dtpHasta.Value))
                {
                    error = false;
                    fE = new frmVisor(frmVisor.Reporte.ObraSocial, oConsulta.Table, this.oUtil.IdUsuario);
                    fE.Show();
                }
            }
            else if (rbtDiagnostico.Checked)
            {
                if (oConsulta.eDiagnosticos("dtDiagnostico", this.dtpDesde.Value, this.dtpHasta.Value))
                {
                    error = false;
                    fE = new frmVisor(frmVisor.Reporte.Diagnostico, oConsulta.Table, this.oUtil.IdUsuario);
                    fE.Show();
                }
            }
            else if (rbtPaciente.Checked)
            {
                if (oConsulta.ePacientes("dtPaciente", this.dtpDesde.Value, this.dtpHasta.Value))
                {
                    error = false;
                    fE = new frmVisor(frmVisor.Reporte.Paciente, oConsulta.Table, this.oUtil.IdUsuario);
                    fE.Show();
                }
            }
            else
            { }

            if (error)
                MessageBox.Show(oTxt.ErrorListaConsulta);
        }

        #endregion

        // OK 19/06/12
        #region Filtros

        // OK 19/06/12
        private void likAnual_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Se mostraran los datos del ultimo año vencido.", "Atencion",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.dtpDesde.Value = DateTime.Now.AddYears(-2);
                this.dtpHasta.Value = DateTime.Now.AddYears(-1);
            }
        }

        // OK 19/06/12
        private void likMensual_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Se mostraran los datos del ultimo mes vencido.", "Atencion",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.dtpDesde.Value = DateTime.Now.AddMonths(-2);
                this.dtpHasta.Value = DateTime.Now.AddMonths(-1);
            }
        }

        #endregion
    }
}
