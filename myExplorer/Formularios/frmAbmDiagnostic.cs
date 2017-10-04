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
using Datos.Query;

namespace myExplorer.Formularios
{
    public partial class frmAbmDiagnostic : Form
    {
        #region Atributos y Propiedades

        public classPatient oPatient { set; get; }
        public enum Modo { Add, Select, Update, Delete }
        public Modo eModo { set; get; }
        public classQuery oQuery { set; get; }
        public classUtiles oUtil { set; get; }
        private classTextos oTxt;
        private int SelectRow;

        #endregion

        // OK 03/06/12
        #region Formulario

        //OK 24/05/12
        public frmAbmDiagnostic()
        {
            InitializeComponent();
            oTxt = new classTextos();
        }

        //OK 24/05/12
        private void frmAbmDiagnostic_Load(object sender, EventArgs e)
        {
            //if (oQuery != null)
            //{
            //    //oCombo.CargaCombo(cmbPatologia, oQuery.ListaPatologias(), oQuery.Table);

            //    if (eModo == Modo.Update)
            //    {
            //        if (this.oDiagnostico != null)
            //        {
            //            //oCombo.IndexCombos(cmbPatologia, this.oDiagnostico.IdDetalle);
            //            rtxtDiagnostico.Text = this.oDiagnostico.Detail;
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(oTxt.ErrorObjetIndefinido);
            //    this.Close();
            //}
        }

        #endregion

        // OK 03/06/12
        #region Botones

        // OK 03/06/12
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //bool error = false;
            //// Eliminar el Diagnostico
            //if (MessageBox.Show(oTxt.MsgEliminarDiagnostico, oTxt.MsgTituloDiagnostico, 
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //    //error = oQuery.DeleteDiagnostic(oDiagnostico, false);
            //error = (bool)oQuery.AbmDiagnostic(oDiagnostico, classQuery.eAbm.Delete);

            //if (!error)
            //    MessageBox.Show(oTxt.ErrorQueryDelete);
            //else
            //    this.Close();
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
            //        error = oQuery.AgregarDiagnostico(oDiagnostico);
            //    }
            //    if (Modo == Vista.Modificar)
            //    {
            //        this.oDiagnostico.Diagnostico = this.oValidarSql.ValidaString(rtxtDiagnostico.Text);
            //        this.oDiagnostico.IdDetalle = Convert.ToInt32(cmbPatologia.SelectedValue);
            //        error = oQuery.ModificarDiagnostico(oDiagnostico);
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
            Close();
        }

        // OK 03/06/12
        private void btnAddPatologia_Click(object sender, EventArgs e)
        {
            //frmAuxiliar frmA = new frmAuxiliar();
            //frmA.oQuery = this.oQuery;
            //frmA.tipoObjeto = frmAuxiliar.Tipo.Patologias;
            //frmA.Id = Convert.ToInt32(cmbPatologia.SelectedValue);

            //if (frmA.ShowDialog() == DialogResult.OK)
            //{
            //    oCombo.CargaCombo(
            //        cmbPatologia,
            //        oQuery.ListaPatologias(),
            //        oQuery.Table);
            //}
        }

        #endregion
    }
}
