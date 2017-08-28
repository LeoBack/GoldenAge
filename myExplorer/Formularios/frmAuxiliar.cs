using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// De la solucion
using Entidades;
using Entidades.Clases;
using Entidades.Clases.ComboBox;
using Controles;
using Datos;


namespace myExplorer.Formularios
{
    public partial class frmAuxiliar : Form
    {
        #region Atributos y Propiedades

        public enum Tipo { Ciudad=1, Barrio=2, Patologias=3 };
        public Tipo tipoObjeto { set; get; }
        public int Id { set; get; }
        public classConsultas oConsulta { set; get; }
        public classUtiles oUtil { set; get; }

        private enum Accion { Modificar=1, Nuevo=2}
        private Accion Acto;

        private int saveId = 0;
        private classCiudad oCiudad;
        private classBarrio oBarrio;
        private classPatologia oPatologia;
        private classControlComboBoxes oControl;
        private classValidaSqlite oValidarSql = new classValidaSqlite();
        private classTextos oTxt = new classTextos();

        #endregion

        #region Formulario

        // Ini
        public frmAuxiliar()
        {
            InitializeComponent();
        }

        // Load
        private void frmAuxiliar_Load(object sender, EventArgs e)
        {
            oControl = new classControlComboBoxes();
            btnAplicar.DialogResult = DialogResult.OK;
            btnEliminar.DialogResult = DialogResult.OK;

            if(Tipo.Barrio == this.tipoObjeto)
            {
                lblNombre.Text = oTxt.Barrio;
                lblCombo.Text = oTxt.Ciudad;
                
                // Habilaciones
                lblCombo.Visible = true;
                cmbCombo.Visible = true;

                oControl.CargaCombo(cmbCombo, oConsulta.ListaCiudades(), oConsulta.Table);
                
                // Accion
                if (Id != 0)
                {
                    lblTitulo.Text = oTxt.ModificarBarrio;
                    oBarrio = oConsulta.SelectBarrio(new classBarrio(0, this.Id, ""));
                    txtNombre.Text = oBarrio.Nombre;
                    this.saveId = oBarrio.IdCiudad;
                    oControl.IndexCombos(cmbCombo, oBarrio.IdCiudad);

                    this.Acto = Accion.Modificar;
                }
                else
                {
                    lblTitulo.Text = oTxt.AgregarBarrio;
                    oControl.IndexCombos(cmbCombo, this.saveId);
                    this.Acto = Accion.Nuevo;
                }
            }
            else if (Tipo.Ciudad == this.tipoObjeto)
            {
                lblNombre.Text = oTxt.Ciudad;
                lblCombo.Text = oTxt.None;
                
                // Habilaciones
                lblCombo.Visible = false;
                cmbCombo.Visible = false;
                
                // Accion
                if (Id != 0)
                {
                    lblTitulo.Text = oTxt.ModificarCiudad;
                    oCiudad = oConsulta.SelectCiudad(new classCiudad(this.Id, ""));
                    txtNombre.Text = oCiudad.Nombre;

                    this.Acto = Accion.Modificar;
                }
                else
                {
                    lblTitulo.Text = oTxt.AgregarCiudad;
                    this.Acto = Accion.Nuevo;
                }
            }
            else if (Tipo.Patologias == this.tipoObjeto)
            {
                lblTitulo.Text = oTxt.Patología;
                lblNombre.Text = oTxt.Nombre;
                lblCombo.Text = oTxt.None;
                
                // Habilaciones
                lblCombo.Visible = false;
                cmbCombo.Visible = false;

                // Accion
                if (Id != 0)
                {
                    lblTitulo.Text = oTxt.ModificarPatología;                
                    oControl.CargaCombo(cmbCombo, oConsulta.ListaPatologias(), oConsulta.Table);
                    oPatologia = oConsulta.SelectPatologia(new classPatologia(this.Id, ""));
                    txtNombre.Text = oPatologia.Detalle;

                    this.Acto = Accion.Modificar;
                }
                else
                {
                    lblTitulo.Text = oTxt.AgregarPatología;
                    this.Acto = Accion.Nuevo;
                }
            }
            else
            {
                MessageBox.Show(oTxt.ErrorObjetoIndefinido);
            }
        }

        #endregion

        #region Botones

        // OK 03/06/12
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (this.ValidarCampos())
            {
                if (this.Acto == Accion.Modificar)
                {
                    if (tipoObjeto == Tipo.Ciudad)
                    {
                        oConsulta.ModificarCiudad(new classCiudad(this.Id,
                            this.oValidarSql.ValidaString(txtNombre.Text)), true);
                    }
                    else if (tipoObjeto == Tipo.Barrio)
                    {
                        oConsulta.ModificarBarrio(new classBarrio(
                            Convert.ToInt32(cmbCombo.SelectedValue), this.Id,
                            this.oValidarSql.ValidaString(txtNombre.Text)), true);
                    }
                    else if (tipoObjeto == Tipo.Patologias)
                    {
                        oConsulta.ModificarPatologia(new classPatologia(this.Id, 
                            this.oValidarSql.ValidaString(txtNombre.Text)), true);
                    }
                    else
                        MessageBox.Show(oTxt.ErrorActualizarConsulta);

                }
                else if (this.Acto == Accion.Nuevo)
                {
                    if (tipoObjeto == Tipo.Ciudad)
                        oConsulta.AgregarCiudad(new classCiudad(0, 
                            this.oValidarSql.ValidaString(txtNombre.Text)));
                    else if (tipoObjeto == Tipo.Barrio)
                    {
                        oConsulta.AgregarBarrio(new classBarrio(
                            Convert.ToInt32(cmbCombo.SelectedValue),
                            0, this.oValidarSql.ValidaString(txtNombre.Text)));
                    }
                    else if (tipoObjeto == Tipo.Patologias)
                        oConsulta.AgregarPatologia(new classPatologia(0, 
                            this.oValidarSql.ValidaString(txtNombre.Text)));
                    else
                        MessageBox.Show(oTxt.ErrorAgregarConsulta);
                }
                else
                    MessageBox.Show(oTxt.AccionIndefinida);
            }
        }

        // OK 03/06/12
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Id = 0;
            this.Acto = Accion.Nuevo;
            frmAuxiliar_Load(sender, e);
            this.Nuevo();
        }

        // OK 03/06/12
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.ValidarCampos())
            {
                if (tipoObjeto == Tipo.Ciudad)
                {
                    oConsulta.EliminarCiudad(new classCiudad(this.Id, txtNombre.Text), false);
                }
                else if (tipoObjeto == Tipo.Barrio)
                {
                    oConsulta.EliminarBarrio(new classBarrio( Convert.ToInt32(cmbCombo.SelectedValue),
                        this.Id, txtNombre.Text), false);
                }
                else if (tipoObjeto == Tipo.Patologias)
                {
                    oConsulta.EliminarPatologia(new classPatologia(this.Id, txtNombre.Text), false);
                }
                else
                    MessageBox.Show(oTxt.AccionIndefinida);
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Valida los campos. True si son correctos
        /// </summary>
        /// <returns></returns>
        private bool ValidarCampos()
        {
            if (txtNombre.Text == "")
                return false;
            else
                return true;
        }

        /// <summary>
        /// Limpia el formulario
        /// </summary>
        private void Nuevo()
        {
            foreach (Control oC in this.tlpPanel.Controls)
            {
                if (oC is TextBox)
                    oC.Text = "";
            }
        }

        #endregion

    }
}
