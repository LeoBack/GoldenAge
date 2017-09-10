using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Controles;
using Entidades;
using Entidades.Clases;
using Datos;

namespace myExplorer.Formularios
{
    public partial class frmAbmDiagnostic : Form
    {
        #region Atributos y Propiedades

        public enum Vista { Nuevo, Ver, Modificar }

        public Vista Modo { set; get; }
        public classDiagnostic oDiagnostico { set; get; }
        public classConsultas oConsulta { set; get; }
        public classUtiles oUtil { set; get; }

        private classControlComboBoxes oCombo;
        private classValidaSqlite oValidarSql = new classValidaSqlite();
        private classTextos oTxt = new classTextos();

        #endregion

        // OK 03/06/12
        #region Formulario

        //OK 24/05/12
        public frmAbmDiagnostic()
        {
            InitializeComponent();
        }

        //OK 24/05/12
        private void frmDiagnostic_Load(object sender, EventArgs e)
        {
            if (oConsulta != null)
            {
                oCombo = new classControlComboBoxes();

                Size sBtn = new Size(75, 42);
                btnCerrar.Size = sBtn;
                btnEliminar.Size = sBtn;
                btnGuardar.Size = sBtn;

                //oCombo.CargaCombo(cmbPatologia, oConsulta.ListaPatologias(), oConsulta.Table);

                if (Modo == Vista.Modificar)
                {
                    if (this.oDiagnostico != null)
                    {
                        //oCombo.IndexCombos(cmbPatologia, this.oDiagnostico.IdDetalle);
                        rtxtDiagnostico.Text = this.oDiagnostico.Detail;
                    }
                }
            }
            else
            {
                MessageBox.Show(oTxt.ErrorObjetoIndefinido);
                this.Close();
            }
        }

        #endregion

        // OK 03/06/12
        #region Botones

        // OK 03/06/12
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool error = false;
            // Eliminar el Diagnostico
            if (MessageBox.Show(oTxt.MsgEliminarDiagnostico, oTxt.MsgTituloDiagnostico, 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                error = oConsulta.DeleteDiagnostic(oDiagnostico, false);

            if (!error)
                MessageBox.Show(oTxt.ErrorEliminarConsulta);
            else
                this.Close();
        }

        // OK 03/06/12
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //bool error = false;
            //// Guardar el nuevo diagnostico.
            //if ((rtxtDiagnostico.Text != ""))
            //{
            //    if (Modo == Vista.Nuevo)
            //    {
            //        this.oDiagnostico.Diagnostico = this.oValidarSql.ValidaString(rtxtDiagnostico.Text);
            //        this.oDiagnostico.IdDetalle = Convert.ToInt32(cmbPatologia.SelectedValue);
            //        this.oDiagnostico.Fecha = DateTime.Now;
            //        error = oConsulta.AgregarDiagnostico(oDiagnostico);
            //    }
            //    if (Modo == Vista.Modificar)
            //    {
            //        this.oDiagnostico.Diagnostico = this.oValidarSql.ValidaString(rtxtDiagnostico.Text);
            //        this.oDiagnostico.IdDetalle = Convert.ToInt32(cmbPatologia.SelectedValue);
            //        error = oConsulta.ModificarDiagnostico(oDiagnostico);
            //    }
            //}

            //if (!error)
            //    MessageBox.Show(oTxt.ErrorAgregarConsulta);
            //else
            //    this.Close();
        }

        // OK 03/06/12
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // OK 03/06/12
        private void btnAddPatologia_Click(object sender, EventArgs e)
        {
            //frmAuxiliar frmA = new frmAuxiliar();
            //frmA.oConsulta = this.oConsulta;
            //frmA.tipoObjeto = frmAuxiliar.Tipo.Patologias;
            //frmA.Id = Convert.ToInt32(cmbPatologia.SelectedValue);

            //if (frmA.ShowDialog() == DialogResult.OK)
            //{
            //    oCombo.CargaCombo(
            //        cmbPatologia,
            //        oConsulta.ListaPatologias(),
            //        oConsulta.Table);
            //}
        }

        #endregion
    }
}
