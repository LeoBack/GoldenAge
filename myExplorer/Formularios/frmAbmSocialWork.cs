﻿using System;
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
using Datos.Query;
using libLocalitation.Forms;

namespace myExplorer.Formularios
{
    public partial class frmAbmSocialWork : Form
    {
        #region Atributos y Propiedades

        public classQuery oQuery { set; get; }
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
            Text = oTxt.TituloSocialWork;

            oComboBox = new classControlComboBoxes();

            if (oQuery != null)
            {   //-------------------------------------------------
                if (Acto == Accion.Nuevo)
                {   //***************Nuevo****************************
                    btnAgregar.Text = oTxt.Aplicar;
                    // Cargo el Formulario Limpio
                    LimpiarFrm();
                }   //****************Fin*****************************
                else if (Acto == Accion.Modificar)
                {
                    if (IdSocialWork != 0)
                    {   //***********Modifica*************************
                        EnableFrm(false);
                        btnAgregar.Enabled = true;
                        btnCancelar.Enabled = true;
                        btnAgregar.Text = oTxt.Editar;
                        // Traigo la Obra Social
                        oSocialWork = (classSocialWork)oQuery.AbmSocialWork(
                            new classSocialWork(IdSocialWork), classQuery.eAbm.Select);
                        // Cargo el Formulario
                        CargarFrm();
                    }   //*************Fin****************************
                    else if (oSocialWork != null)
                    {
                        {   //***********Modifica*************************
                            EnableFrm(false);
                            btnAgregar.Enabled = true;
                            btnCancelar.Enabled = true;
                            btnAgregar.Text = oTxt.Editar;
                            // Cargo el Formulario
                            CargarFrm();
                        }   //*************Fin****************************
                    }
                    else
                    {
                        MessageBox.Show(oTxt.ErrorObjetoIndefinido);
                        Close();
                    }
                }
                else if (Acto == Accion.Eliminar)
                {   //***********Eliminar*************************
                    if (IdSocialWork != 0)
                    {   // Consulta de eliminacion
                        oQuery.AbmSocialWork(new classSocialWork(IdSocialWork), classQuery.eAbm.Delete);
                    }
                    else if (oSocialWork != null)
                    {   // Consulta de eliminacion
                        oQuery.AbmSocialWork(oSocialWork, classQuery.eAbm.Delete);
                    }
                    else
                    {
                        MessageBox.Show(oTxt.ErrorObjetoIndefinido);
                        Close();
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show(oTxt.ErrorObjetoIndefinido);
                    Close();
                }
            }   //-------------------------------------------------
            else
                Close();
        }

        #endregion

        // OK 03/06/12
        #region Botones

        // OK 03/06/12
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (Acto == Accion.Nuevo)
                {   //-------------------------------------------------
                    if (btnAgregar.Text == oTxt.Limpiar)
                    {
                        btnAgregar.Text = oTxt.Aplicar;
                        LimpiarFrm();
                        Acto = Accion.Nuevo;
                    }
                    else
                    {
                        oSocialWork = new classSocialWork();
                        CargarObjeto();

                        // INSERTAR OBJETO;
                        if ((bool)oQuery.AbmSocialWork(oSocialWork, classQuery.eAbm.Insert))
                        {
                            MessageBox.Show(oTxt.AgregarSocialWork);
                            btnAgregar.Text = oTxt.Limpiar;
                        }
                        else
                            MessageBox.Show(oQuery.Menssage);
                    }
                }   //-------------------------------------------------
                else if (Acto == Accion.Modificar)
                {   //-------------------------------------------------
                    if (btnAgregar.Text == oTxt.Editar)
                    {
                        btnAgregar.Text = oTxt.Aplicar;
                        EnableFrm(true);
                        Acto = Accion.Modificar;
                    }
                    else
                    {
                        CargarObjeto();
                        // Modifica OBJETO;
                        if ((bool)oQuery.AbmSocialWork(oSocialWork, classQuery.eAbm.Update))
                        {
                            MessageBox.Show(oTxt.ModificarSocialWork);
                            Close();
                        }
                        else
                            MessageBox.Show(oQuery.Menssage);
                    }
                }   //-------------------------------------------------
                else
                {
                    MessageBox.Show(oTxt.AccionIndefinida);
                    Close();
                }
            }
            else
                MessageBox.Show(oTxt.CaillasVacias);
        }

        // OK 03/06/12
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
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
            //oSocialWork.IdSocialWork = 0;
            oSocialWork.Name = txtName.Text.ToUpper();
            oSocialWork.Description = txtDescription.Text;
            oSocialWork.IdLocationCountry = 0;
            oSocialWork.IdLocationProvince = 0;
            oSocialWork.IdLocationCity = 0;
            oSocialWork.Address = oValidarSql.ValidaString(txtAddress.Text);
            oSocialWork.Phone = oValidarSql.ValidaString(txtPhone.Text);
            oSocialWork.AlternativePhone = oValidarSql.ValidaString(txtAlternativePhone.Text);
            //oSocialWork.Visible = true;
        }

        /// <summary>
        /// Carga el Formulario
        /// OK 03/06/12
        /// </summary>
        private void CargarFrm()
        {
            txtName.Text = oSocialWork.Name;
            txtDescription.Text = oSocialWork.Description;
            oSocialWork.IdLocationCountry = 0;
            oSocialWork.IdLocationProvince = 0;
            oSocialWork.IdLocationCity = 0;
            txtAddress.Text = oSocialWork.Address;
            txtPhone.Text = oSocialWork.Phone;
            txtAlternativePhone.Text = oSocialWork.AlternativePhone;
        }

        /// <summary>
        /// Habilita el formulario
        /// OK 03/06/12
        /// </summary>
        private void EnableFrm(bool X)
        {
            foreach (Control oC in tlpPanel.Controls)
                oC.Enabled = X;
        }

        /// <summary>
        /// Limpia el formulario
        /// OK 03/06/12
        /// </summary>
        private void LimpiarFrm()
        {
            foreach (Control oC in tlpPanel.Controls)
            {
                if (oC is TextBox)
                    oC.Text = "";
            }
        }

        #endregion
    }
}
