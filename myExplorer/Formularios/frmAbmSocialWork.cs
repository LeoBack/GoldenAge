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
using Controles;
using Datos;
using libLocalitation.Forms;

namespace myExplorer.Formularios
{
    public partial class frmAbmSocialWork : Form
    {
        #region Atributos y Propiedades

        public classConsultas oConsulta { set; get; }
        public classUtiles oUtil { set; get; }
        public classSocialWork oSocialWork { set; get; }

        public enum Accion { Nuevo = 1, Modificar = 2, Eliminar = 3 }
        public Accion Acto { set; get; }
        public int IdSocialWork { set; get; }

        private classControlComboBoxes oComboBox;
        private classTextos oTxt = new classTextos();
        private classValidaSqlite oValidarSql = new classValidaSqlite();

        #endregion

        // OK 03/06/12
        #region Formulario

        //OK 25/05/12
        public frmAbmSocialWork()
        {
            InitializeComponent();
        }

        // OK 03/06/12
        private void frmAuxABM_Load(object sender, EventArgs e)
        {
            this.Text = oTxt.TituloSocialWork;

            oComboBox = new classControlComboBoxes();

            if (oConsulta != null)
            {   //-------------------------------------------------
                if (this.Acto == Accion.Nuevo)
                {   //***************Nuevo****************************
                    this.btnAgregar.Text = oTxt.Aplicar;
                    // Cargo el Formulario Limpio
                    this.LimpiarFrm();
                    //this.CargarCombosCiudadBarrio();
                }   //****************Fin*****************************
                else if (this.Acto == Accion.Modificar)
                {
                    if (this.IdSocialWork != 0)
                    {   //***********Modifica*************************
                        this.EnableFrm(false);
                        btnAgregar.Enabled = true;
                        btnCancelar.Enabled = true;
                        this.btnAgregar.Text = oTxt.Editar;
                        // Traigo la Obra Social
                        //oSocialWork = oConsulta.SelectSocialWork(
                        //    new classSocialWork(this.IdSocialWork,"","","","","",true));
                        // Cargo el Formulario
                        //this.CargarCombosCiudadBarrio();
                        this.CargarFrm();
                    }   //*************Fin****************************
                    else if (oSocialWork != null)
                    {
                        {   //***********Modifica*************************
                            this.EnableFrm(false);
                            btnAgregar.Enabled = true;
                            btnCancelar.Enabled = true;
                            this.btnAgregar.Text = oTxt.Editar;
                            // Cargo el Formulario
                            //this.CargarCombosCiudadBarrio();
                            this.CargarFrm();
                        }   //*************Fin****************************
                    }
                    else
                    {
                        MessageBox.Show(oTxt.ErrorObjetoIndefinido);
                        this.Close();
                    }
                }
                else if (this.Acto == Accion.Eliminar)
                {   //***********Eliminar*************************
                    if (this.IdSocialWork != 0)
                    {   // Consulta de eliminacion
                        //oConsulta.DeleteSocialWork(
                        //    new classSocialWork(
                        //        this.IdSocialWork, "", "", "", "", "", true), false);
                    }
                    else if (oSocialWork != null)
                    {   // Consulta de eliminacion
                        oConsulta.DeleteSocialWork(oSocialWork, false);
                    }
                    else
                    {
                        MessageBox.Show(oTxt.ErrorObjetoIndefinido);
                        this.Close();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show(oTxt.ErrorObjetoIndefinido);
                    this.Close();
                }
            }   //-------------------------------------------------
            else
                this.Close();
        }

        #endregion

        // OK 03/06/12
        #region Botones

        // OK 03/06/12
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.ValidarCampos())
            {
                if (this.Acto == Accion.Nuevo)
                {   //-------------------------------------------------
                    if (btnAgregar.Text == oTxt.Limpiar)
                    {
                        btnAgregar.Text = oTxt.Aplicar;
                        this.LimpiarFrm();
                        this.Acto = Accion.Nuevo;
                    }
                    else
                    {
                        oSocialWork = new classSocialWork();
                        this.CargarObjeto();

                        // INSERTAR OBJETO;
                        if (oConsulta.AddSocialWork(oSocialWork))
                        {
                            MessageBox.Show(oTxt.AgregarSocialWork);
                            btnAgregar.Text = oTxt.Limpiar;
                        }
                        else
                            MessageBox.Show(oConsulta.Menssage);
                    }
                }   //-------------------------------------------------
                else if (this.Acto == Accion.Modificar)
                {   //-------------------------------------------------
                    if (btnAgregar.Text == oTxt.Editar)
                    {
                        btnAgregar.Text = oTxt.Aplicar;
                        this.EnableFrm(true);
                        this.Acto = Accion.Modificar;
                    }
                    else
                    {
                        this.CargarObjeto();
                        // Modifica OBJETO;
                        if (oConsulta.UpdateSocialWork(oSocialWork))
                        {
                            MessageBox.Show(oTxt.ModificarSocialWork);
                            this.Close();
                        }
                        else
                            MessageBox.Show(oConsulta.Menssage);
                    }
                }   //-------------------------------------------------
                else
                {
                    MessageBox.Show(oTxt.AccionIndefinida);
                    this.Close();
                }
            }
            else
                MessageBox.Show(oTxt.CaillasVacias);
        }

        // OK 03/06/12
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        // REVISAR 17/09/09
        #region Botones Auxiliares

        // REVISAR 17/09/09
        private void btnLocalitation_Click(object sender, EventArgs e)
        {
            frmLocation fLocalitation = new frmLocation("", frmLocation.eLocation.Select);
            if(DialogResult.OK == fLocalitation.ShowDialog())
            {
                txtLocation.Text = fLocalitation.toStringLocation();
                oSocialWork.IdLocationCountry = fLocalitation.getIdCountry();
                oSocialWork.IdLocationProvince = fLocalitation.getIdProvince();
                oSocialWork.IdLocationCity = fLocalitation.getIdCity();
            }
        }

        #endregion

        // OK 03/06/12
        #region Metodos

        /// <summary>
        /// Valida Campos
        /// OK 03/06/12
        /// </summary>
        /// <returns></returns>
        private bool ValidarCampos()
        {
            if ((txtName.Text == "") ||
                (txtAddress.Text == "") ||
                (txtPhone.Text == ""))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Carga objeto
        /// OK 03/06/12
        /// </summary>
        private void CargarObjeto()
        {
            //oSocialWork.Id = 0;
            //oSocialWork.Visible = 0;
            oSocialWork.Name = oValidarSql.ValidaString(txtName.Text.ToUpper());
            oSocialWork.Description = oValidarSql.ValidaString(txtDescription.Text);
            oSocialWork.Address = oValidarSql.ValidaString(txtAddress.Text);
            oSocialWork.Phone = oValidarSql.ValidaString(txtPhone.Text);
            oSocialWork.AlternativePhone = oValidarSql.ValidaString(txtAlternativePhone.Text);
            
            //oSocialWork.IdCiudad = Convert.ToInt32(cmbCiudad.SelectedValue);
            //oSocialWork.IdBarrio = Convert.ToInt32(cmbBarrio.SelectedValue);
        }

        /// <summary>
        /// Carga el Formulario
        /// OK 03/06/12
        /// </summary>
        private void CargarFrm()
        {
            txtName.Text = oSocialWork.Name;
            txtDescription.Text = oSocialWork.Description;
            txtAddress.Text = oSocialWork.Address;
            txtPhone.Text = oSocialWork.Phone;
            txtAlternativePhone.Text = oSocialWork.AlternativePhone;
            
            

            //oComboBox.IndexCombos(cmbCiudad, oSocialWork.IdCiudad);
            //oComboBox.IndexCombos(cmbBarrio, oSocialWork.IdBarrio);
        }

        /// <summary>
        /// Carga los Combos de Ciudad y Barrios
        /// 03/02/12
        /// </summary>
        //private void CargarCombosCiudadBarrio()
        //{
        //    oComboBox.CargaCombo(cmbCiudad,
        //        oConsulta.ListaCiudades(), 
        //        oConsulta.Table);

        //    oComboBox.CargaCombo(cmbBarrio,
        //        oConsulta.ListaBarrios(Convert.ToInt32(cmbCiudad.SelectedValue)),
        //        oConsulta.Table);
        //}

        /// <summary>
        /// Habilita el formulario
        /// OK 03/06/12
        /// </summary>
        private void EnableFrm(bool X)
        {
            foreach (Control oC in this.tlpPanel.Controls)
                oC.Enabled = X;
        }

        /// <summary>
        /// Limpia el formulario
        /// OK 03/06/12
        /// </summary>
        private void LimpiarFrm()
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
