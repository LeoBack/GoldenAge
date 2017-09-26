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
using Datos.Query;
using libLocalitation.Forms;

namespace myExplorer.Formularios
{
    public partial class frmAbmSocialWork : Form
    {
        #region Atributos y Propiedades

        public enum Modo { Add, Select, Update, Delete }

        public Modo eModo { set; get; }
        public classQuery oQuery { set; get; }
        public classUtiles oUtil { set; get; }
        public classSocialWork oSocialWork { set; get; }
        public int IdSocialWork { set; get; }

        private classTextos oTxt = new classTextos();

        private int IdCountry = 0;
        private int IdProvince = 0;
        private int IdCity = 0;

        #endregion

        // OK 03/06/12
        #region Formulario

        // OK 25/05/12
        public frmAbmSocialWork()
        {
            InitializeComponent();
        }

        // OK 03/06/12
        private void frmAbmSocialWork_Load(object sender, EventArgs e)
        {
            Text = oTxt.TitleSocialWork;

            if (oQuery != null)
            {   //-------------------------------------------------
                if (eModo == Modo.Add)
                {   //***************Nuevo****************************
                    btnAgregar.Text = oTxt.Aplicar;
                    // Cargo el Formulario Limpio
                    LimpiarFrm();
                }   //****************Fin*****************************
                else if (eModo == Modo.Update)
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
                else if (eModo == Modo.Delete)
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
                if (eModo == Modo.Add)
                {   //-------------------------------------------------
                    if (btnAgregar.Text == oTxt.Limpiar)
                    {
                        btnAgregar.Text = oTxt.Aplicar;
                        LimpiarFrm();
                        eModo = Modo.Add;
                    }
                    else
                    {
                        oSocialWork = new classSocialWork();
                        CargarObjeto();

                        // INSERTAR OBJETO;
                        if (0 != (int)oQuery.AbmSocialWork(oSocialWork, classQuery.eAbm.Insert))
                        {
                            MessageBox.Show(oTxt.AgregarSocialWork);
                            btnAgregar.Text = oTxt.Limpiar;
                        }
                        else
                            MessageBox.Show(oQuery.Menssage);
                    }
                }   //-------------------------------------------------
                else if (eModo == Modo.Update)
                {   //-------------------------------------------------
                    if (btnAgregar.Text == oTxt.Editar)
                    {
                        btnAgregar.Text = oTxt.Aplicar;
                        EnableFrm(true);
                        eModo = Modo.Update;
                    }
                    else
                    {
                        CargarObjeto();
                        // Modifica OBJETO;
                        if (0 != (int)oQuery.AbmSocialWork(oSocialWork, classQuery.eAbm.Update))
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

        // OK 17/09/09
        private void btnLocalitation_Click(object sender, EventArgs e)
        {
            frmLocation fLocalitation = new frmLocation(oQuery.ConexionString, frmLocation.eLocation.Select);
            if(DialogResult.OK == fLocalitation.ShowDialog())
            {
                txtLocation.Text = fLocalitation.toStringLocation();
                IdCountry = fLocalitation.getIdCountry();
                IdProvince = fLocalitation.getIdProvince();
                IdCity = fLocalitation.getIdCity();
            }
        }

        #endregion

        // OK 17/09/16
        #region Metodos

        /// <summary>
        /// Valida Campos
        /// OK 17/09/16
        /// </summary>
        /// <returns></returns>
        private bool ValidarCampos()
        {
            if ((txtName.Text == "") ||
                (txtDescription.Text == "") ||
                (txtAddress.Text == "") ||
                (txtPhone.Text == ""))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Carga objeto
        /// OK 17/09/16
        /// </summary>
        private void CargarObjeto()
        {
            //oSocialWork.IdSocialWork = 0;
            oSocialWork.Name = txtName.Text.ToUpper();
            oSocialWork.Description = txtDescription.Text;
            oSocialWork.IdLocationCountry = IdCountry;
            oSocialWork.IdLocationProvince = IdProvince;
            oSocialWork.IdLocationCity = IdCity;
            oSocialWork.Address = txtAddress.Text;
            oSocialWork.Phone = txtPhone.Text;
            oSocialWork.Contact = txtAlternativePhone.Text;
            //oSocialWork.Visible = true;
        }

        /// <summary>
        /// Carga el Formulario
        /// OK 17/09/16
        /// </summary>
        private void CargarFrm()
        {
            txtName.Text = oSocialWork.Name;
            txtDescription.Text = oSocialWork.Description;
            txtAddress.Text = oSocialWork.Address;
            txtPhone.Text = oSocialWork.Phone;
            txtAlternativePhone.Text = oSocialWork.Contact;
            
            txtLocation.Text = frmLocation.toStringLocation(
                oQuery.ConexionString,
                oSocialWork.IdLocationCountry,
                oSocialWork.IdLocationProvince,
                oSocialWork.IdLocationCity);
        }

        /// <summary>
        /// Habilita el formulario
        /// OK 17/09/16
        /// </summary>
        private void EnableFrm(bool X)
        {
            foreach (Control oC in tlpPanel.Controls)
                oC.Enabled = X;
        }

        /// <summary>
        /// Limpia el formulario
        /// OK 17/09/16
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
