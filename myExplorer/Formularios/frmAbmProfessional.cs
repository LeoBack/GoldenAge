using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Datos.Query;
using Entidades;
using Entidades.Clases;
//using Reportes;
using Controles;
using libLocalitation.Forms;

namespace myExplorer.Formularios
{
    public partial class frmAbmProfessional : Form
    {
        #region Atributos y Propiedades

        public enum Modo { Add, Select, Update, Delete }

        public Modo eModo { set; get; }
        public int IdProfessional { set; get; }

        public classQuery oQuery { set; get; }
        public classProfessional oProfessional { set; get; }
        public classUtiles oUtil { set; get; }

        private classValidaciones oValidar;
        private classTextos oTxt = new classTextos();

        private int IdCountry = 0;
        private int IdProvince = 0;
        private int IdCity = 0;

        #endregion

        #region Formulario

        public frmAbmProfessional()
        {
            InitializeComponent();
        }

        //OK 11/06/12
        private void frmAbmProfessional_Load(object sender, EventArgs e)
        {
            if (oQuery != null)
            {
                Text = oTxt.TitleAdministradorUsuario;
                oValidar = new classValidaciones();
                ini();
            }
            else
                Close();
        }

        #endregion

        #region Botones

        //OK 17/09/16
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                CargarObjeto();

                if (eModo == Modo.Add)
                {   //-------------------------------------------------
                    // Guarda
                    if (0 != (int)oQuery.AbmProfessional(oProfessional, classQuery.eAbm.Insert))
                    {
                        MessageBox.Show(oTxt.AgregarProfesional);
                        eModo = Modo.Update;
                        oProfessional.IdProfessional = oQuery.UltimoIdProfessional();
                        IdProfessional = 0;
                        ini();
                    }
                    else
                        MessageBox.Show(oTxt.ErrorAgregarConsulta);

                }   //-------------------------------------------------
                else if (eModo == Modo.Update)
                {   //-------------------------------------------------
                    // Actualiza
                    if (0 != (int)oQuery.AbmProfessional(oProfessional, classQuery.eAbm.Update))
                    {
                        MessageBox.Show(oTxt.ModificarProfesional);
                        eModo = Modo.Update;
                        ini();
                    }
                    else
                        MessageBox.Show(oTxt.ErrorActualizarConsulta);
                }
                else
                    MessageBox.Show(oTxt.AccionIndefinida);
            }
        }

        // OK 11/06/12
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            LimpiarFrm();
            eModo = Modo.Add;
        }

        // OK 11/06/12
        private void btnBloquear_Click(object sender, EventArgs e)
        {
            if (oProfessional != null)
            {
                if (btnBloquear.Text == oTxt.Bloquear)
                {
                    oProfessional.Visible = true;
                    btnBloquear.Text = oTxt.Desbloquear;
                }
                else
                {
                    oProfessional.Visible = false;
                    btnBloquear.Text = oTxt.Bloquear;
                }
                btnGuardar_Click(sender, e);
            }
        }

        // OK 17/09/09
        private void btnLocalitation_Click(object sender, EventArgs e)
        {
            frmLocation fLocalitation = new frmLocation(oQuery.ConexionString, frmLocation.eLocation.Select);
            if (DialogResult.OK == fLocalitation.ShowDialog())
            {
                txtLocation.Text = fLocalitation.toStringLocation();
                IdCountry = fLocalitation.getIdCountry();
                IdProvince = fLocalitation.getIdProvince();
                IdCity = fLocalitation.getIdCity();
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Actualiza el formulario
        /// OK 07/06/12  REVISAR
        /// </summary>
        private void ini()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbTypeAccess,
                (bool)oQuery.AbmPermission(new classPermission(), classQuery.eAbm.LoadCmb),
                oQuery.Table);

            clbSpeciality.SelectedIndexChanged -= clbSpeciality_SelectedIndexChanged;
            if ((bool)oQuery.AbmSpeciality(new classSpecialty(), classQuery.eAbm.LoadCmb))
            {
                DataTable dT = oQuery.Table;
                dT.Rows.Add(new object[] { 0, "Nuevo" });
                clbSpeciality.DataSource = dT;
                clbSpeciality.DisplayMember = "Value";
                clbSpeciality.ValueMember = "Id";
            }
            clbSpeciality.SelectedIndexChanged += clbSpeciality_SelectedIndexChanged;

            // Modo en el que se mostrara el formulario
            if (eModo == Modo.Select && oUtil.oProfessional.IdProfessional != 0)
            {
                oProfessional = (classProfessional)oQuery.AbmProfessional(new classProfessional(oUtil.oProfessional.IdProfessional), classQuery.eAbm.Select);
                EnableFrm(false);
                btnBloquear.Enabled = true;
                EscribirEnFrm();
            }
            else if (eModo == Modo.Update && oUtil.oProfessional.IdProfessional != 0)
            {
                EnableFrm(true);
                btnBloquear.Enabled = true;
                EscribirEnFrm();
            }
            else if (eModo == Modo.Add)
            {
                oProfessional = new classProfessional();
                EnableFrm(true);
                btnBloquear.Enabled = false;
                EscribirEnFrm();
            }
        }

        /// <summary>
        /// Limpia el formulario
        /// OK 03/06/12
        /// </summary>
        private void LimpiarFrm()
        {
            foreach (Control oC in tlpTab.Controls)
            {
                if (oC is TextBox)
                    oC.Text = "";
            }
        }

        /// <summary>
        /// Habilita TabFicha
        /// OK 07/06/12
        /// </summary>
        /// <param name="X"></param>
        private void EnableFrm(bool X)
        {
            foreach (Control C in tlpPanel.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
        }

        /// <summary>
        /// OK 17/09/14
        /// </summary>
        private void CargarObjeto()
        {
            oProfessional.ProfessionalRegistration = Convert.ToInt32(txtProfessionalRegistration.Text);
            oProfessional.Name = txtName.Text;
            oProfessional.LastName = txtLastName.Text;
            oProfessional.IdLocationCountry = IdCountry;
            oProfessional.IdLocationProvince = IdProvince;
            oProfessional.IdLocationCity = IdCity;
            oProfessional.Address = txtAddress.Text;
            oProfessional.Phone = txtPhone.Text;
            oProfessional.Mail = txtMail.Text;
            oProfessional.User = txtUser.Text;
            oProfessional.Admin = Convert.ToInt32(cmbTypeAccess.SelectedValue);
            oProfessional.Password = txtPassword.Text;
        }

        /// <summary>
        /// Carga los elementos de formulario desde objeto.
        /// OK 17/09/14
        /// </summary>
        private void EscribirEnFrm()
        {
            txtProfessionalRegistration.Text = Convert.ToString(oProfessional.ProfessionalRegistration);
            txtName.Text = oProfessional.Name;
            txtLastName.Text = oProfessional.LastName;
            txtAddress.Text = oProfessional.Address;
            txtPhone.Text = oProfessional.Phone;
            txtMail.Text = oProfessional.Mail;
            txtUser.Text = oProfessional.User;
            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(cmbTypeAccess, oProfessional.Admin);
            txtPassword.Text = oProfessional.Password;

            txtLocation.Text = frmLocation.toStringLocation(
                oQuery.ConexionString,
                oProfessional.IdLocationCountry,
                oProfessional.IdLocationProvince,
                oProfessional.IdLocationCity);

            if (oProfessional.Visible)
                btnBloquear.Text = "Desbloquear";
            else
                btnBloquear.Text = "Bloquear";
        }

        /// <summary>
        /// Valida los campos del Formulario.
        /// False -> Vacio - True -> Ok
        /// OK 04/03/12
        /// </summary>
        /// <returns></returns>
        private bool ValidarCampos()
        {
            bool V = true;

            if ((txtLastName.Text == "") || (txtName.Text == "") ||
                (txtPassword.Text == "") || (txtMail.Text == ""))
            {
                V = false;
                MessageBox.Show("Se encontraron casillas vacias.");
            }
            else if (txtPassword.TextLength <= 7)
            {
                V = false;
                MessageBox.Show("La contraseña debe tener como minimo 8 caracteres.");
            }
            else
            { }

            return V;
        }

        #endregion

        private void btnUpdateSpeciality_Click(object sender, EventArgs e)
        {
            bool Error = false;
            Error = (bool)oQuery.AbmSpeciality(new classSpecialty(), classQuery.eAbm.Update);

            Error = (bool)oQuery.AbmSpeciality(new classSpecialty(0, txtDescription.Text, true), classQuery.eAbm.Insert);

        }

        private void clbSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {

            //MessageBox.Show(Convert.ToString(clbSpeciality.SelectedItem) + " - " + Convert.ToString(clbSpeciality.SelectedValue) + " - " + clbSpeciality.SelectedIndex.ToString());

            if (Convert.ToString(clbSpeciality.SelectedValue) != "" &
                Convert.ToInt32(clbSpeciality.SelectedValue) != 0)
                txtDescription.Text = Convert.ToString(clbSpeciality.SelectedItem);
            else
                txtDescription.Text = string.Empty;

        }

    }
}
