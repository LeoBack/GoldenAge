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
        // OK 17/09/27
        #region Atributos y Propiedades

        public classSocialWork oSocialWork { set; get; }
        public enum Modo { Add, Select, Update, Delete }
        public Modo eModo { set; get; }
        public classQuery oQuery { set; get; }
        public classUtiles oUtil { set; get; }
        private classTextos oTxt;
        private bool Enable = true;
        private int IdCountry = 0;
        private int IdProvince = 0;
        private int IdCity = 0;

        #endregion

        // OK 17/09/30
        #region Formulario

        // OK 17/09/30
        public frmAbmSocialWork()
        {
            InitializeComponent();
            oTxt = new classTextos();
        }

        // OK 17/09/30
        private void frmAbmSocialWork_Load(object sender, EventArgs e)
        {
            if (oQuery != null)
            {
                Text = oTxt.TitleSocialWork;
                initIvaType();

                // Modo en el que se mostrara el formulario
                switch (eModo)
                {
                    case Modo.Update:
                        EnableFrm(false);
                        EscribirEnFrm();
                        break;
                    case Modo.Add:
                        LimpiarFrm();
                        break;
                }
            }
            else
                Close();
        }

        #endregion

        // OK 03/06/12
        #region Botones

        // OK 17/09/30
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                CargarObjeto();
                int IdQuery = 0;

                switch (eModo)
                {
                    case Modo.Add:
                        IdQuery = (int)oQuery.AbmSocialWork(oSocialWork, classQuery.eAbm.Insert);
                        if (0 != IdQuery)
                            MessageBox.Show(oTxt.AddSocialWork);
                        else
                            MessageBox.Show(oTxt.ErrorQueryAdd);
                        break;
                    case Modo.Update:
                        IdQuery = (int)oQuery.AbmSocialWork(oSocialWork, classQuery.eAbm.Update);
                        if (0 != IdQuery)
                            MessageBox.Show(oTxt.UpdateSocialWork);
                        else
                            MessageBox.Show(oTxt.ErrorQueryUpdate);
                        break;
                    default:
                        MessageBox.Show(oTxt.AccionIndefinida);
                        break;
                }

                if (IdQuery == 0)
                    MessageBox.Show(oQuery.Menssage);
            }
        }

        // OK 17/09/30
        private void btnClosed_Click(object sender, EventArgs e)
        {
            Close();
        }

        // OK 17/09/30
        private void btnBloquear_Click(object sender, EventArgs e)
        {
            if (oSocialWork != null)
            {
                if (btnBloquear.Text == oTxt.Bloquear)
                {
                    Enable = false;
                    btnBloquear.Text = oTxt.Desbloquear;
                }
                else
                {
                    Enable = true;
                    btnBloquear.Text = oTxt.Bloquear;
                }
            }
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
        /// OK - 17/09/30
        /// </summary>
        private void initIvaType()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbIvaType,
                (bool)oQuery.AbmIvaType(new classIvaType(), classQuery.eAbm.LoadCmb),
                oQuery.Table);
        }

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
        /// OK 17/09/30
        /// </summary>
        private void CargarObjeto()
        {
            oSocialWork.Name = txtName.Text.ToUpper();
            oSocialWork.Description = txtDescription.Text;
            oSocialWork.IdLocationCountry = IdCountry;
            oSocialWork.IdLocationProvince = IdProvince;
            oSocialWork.IdLocationCity = IdCity;
            oSocialWork.Address = txtAddress.Text.ToUpper();
            oSocialWork.Phone = txtPhone.Text;
            oSocialWork.Contact = txtContact.Text.ToUpper();
            oSocialWork.Visible = Enable;
            oSocialWork.IdIvaType = Convert.ToInt32(cmbIvaType.SelectedValue);
        }

        /// <summary>
        /// Carga el Formulario
        /// OK 17/09/30
        /// </summary>
        private void EscribirEnFrm()
        {
            txtName.Text = oSocialWork.Name.ToUpper();
            txtDescription.Text = oSocialWork.Description;
            txtAddress.Text = oSocialWork.Address.ToUpper();
            txtPhone.Text = oSocialWork.Phone;
            txtContact.Text = oSocialWork.Contact.ToUpper();
            IdCountry = oSocialWork.IdLocationCountry;
            IdProvince = oSocialWork.IdLocationProvince;
            IdCity = oSocialWork.IdLocationCity;
            
            txtLocation.Text = frmLocation.toStringLocation(
                oQuery.ConexionString, IdCountry, IdProvince, IdCity);

            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(cmbIvaType, oSocialWork.IdIvaType);

            if (Enable)
                btnBloquear.Text = "Bloquear";
            else
                btnBloquear.Text = "Desbloquear";
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
