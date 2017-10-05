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
using Controles;
using libLocalitation.Forms;

namespace myExplorer.Formularios
{
    public partial class frmAbmProfessional : Form
    {
        // OK 17/09/27
        #region Atributos y Propiedades

        public classProfessional oProfessional { set; get; }
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

        // OK 17/09/27
        public frmAbmProfessional()
        {
            InitializeComponent();
            oTxt = new classTextos();
        }

        // OK 17/09/27
        private void frmAbmProfessional_Load(object sender, EventArgs e)
        {
            if (oQuery != null)
            {
                Text = oTxt.TitleAdministradorUsuario;

                initAccess();
                initSpeciality();

                // Modo en el que se mostrara el formulario
                switch (eModo)
                {
                    case Modo.Select:
                        oProfessional = oQuery.AbmProfessional(new classProfessional(oUtil.oProfessional.IdProfessional), classQuery.eAbm.Select) as classProfessional;
                        EnableFrm(false);
                        btnBlocked.Enabled = true;
                        EscribirEnFrm();
                        setCheckedSpeciality();
                        break;
                    case Modo.Update:
                        EnableFrm(true);
                        btnBlocked.Visible = true;
                        EscribirEnFrm();
                        setCheckedSpeciality();
                        break;
                    case Modo.Add:
                        oProfessional = new classProfessional();
                        EnableFrm(true);
                        btnBlocked.Visible = false;
                        EscribirEnFrm();
                        break;
                    default:
                        MessageBox.Show(oTxt.ErrorObjetIndefinido);
                        break;
                }
            }
            else
                Close();
        }

        #endregion

        // OK 17/09/30
        #region Botones

        // OK 17/09/30
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                CargarObjeto();
                int IdQuery = 0;

                switch(eModo)
                {
                    case Modo.Add:
                        IdQuery = (int)oQuery.AbmProfessional(oProfessional, classQuery.eAbm.Insert);
                        if (0 != IdQuery)
                        {
                            SaveCheckedSpeciality(IdQuery);
                            MessageBox.Show(oTxt.AddProfessional);
                        }
                        else
                            MessageBox.Show(oTxt.ErrorQueryAdd);
                        break;
                    case Modo.Update:
                        IdQuery = (int)oQuery.AbmProfessional(oProfessional, classQuery.eAbm.Update);
                        if (0 != IdQuery)
                        {
                            SaveCheckedSpeciality(IdQuery);
                            MessageBox.Show(oTxt.UpdateProfessional);
                        }
                        else
                            MessageBox.Show(oTxt.ErrorQueryUpdate);
                        break;
                    default:
                        MessageBox.Show(oTxt.AccionIndefinida);
                        break;
                }

                if (IdQuery == 0)
                    MessageBox.Show(oQuery.Menssage);
                else
                    Close();
            }
            
        }

        // OK 17/09/30
        private void btnBlocked_Click(object sender, EventArgs e)
        {
            if (oProfessional != null)
            {
                if (btnBlocked.Text == oTxt.Bloquear)
                {
                    Enable = false;
                    btnBlocked.Text = oTxt.Desbloquear;
                }
                else
                {
                    Enable = true;
                    btnBlocked.Text = oTxt.Bloquear;
                }
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

        // OK 17/09/27
        private void btnUpdateSpeciality_Click(object sender, EventArgs e)
        {
            bool Error = false;

            if (txtDescription.Text != string.Empty)
            {
                classSpecialty oS;
                switch ((Modo)clbSpeciality.Tag)
                {
                    case Modo.Add:
                        oS = new classSpecialty(0, txtDescription.Text, true);
                        Error = ((int)oQuery.AbmSpeciality(oS, classQuery.eAbm.Insert) == 0);
                        break;
                    case Modo.Update:
                        oS = new classSpecialty(Convert.ToInt32(clbSpeciality.SelectedValue), txtDescription.Text, true);
                        Error = ((int)oQuery.AbmSpeciality(oS, classQuery.eAbm.Update) == 0);
                        break;
                }
            }
            else
                MessageBox.Show("Campo vacio");

            if (Error)
                MessageBox.Show(oQuery.Menssage);
            else
                initSpeciality();
        }

        // OK 17/09/27
        private void clbSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Convert.ToString(clbSpeciality.SelectedValue) != "") &
                (Convert.ToInt32(clbSpeciality.SelectedValue) != 0))
            {
                clbSpeciality.Tag = Modo.Update;
                txtDescription.Text = clbSpeciality.Text;
            }
            else
            {
                clbSpeciality.Tag = Modo.Add;
                txtDescription.Text = string.Empty;
            }
        }

        #endregion

        // OK 17/09/30
        #region Metodos

        /// <summary>
        /// OK 17/09/28
        /// </summary>
        private void SaveCheckedSpeciality(int IdProfessional)
        {
            classProfessionalSpeciality oPs = new classProfessionalSpeciality();
            oPs.IdProfessional = IdProfessional;
            List<classProfessionalSpeciality> lConsulta = oQuery.AbmProfessionalSpeciality(oPs, classQuery.eAbm.SelectAll) as List<classProfessionalSpeciality>;
            List<classProfessionalSpeciality> lDelete = new List<classProfessionalSpeciality>();
            List<classProfessionalSpeciality> lAdd = new List<classProfessionalSpeciality>();
            lDelete.AddRange(lConsulta);

            foreach (DataRowView dRa in clbSpeciality.CheckedItems)
            {
                lAdd.Add(new classProfessionalSpeciality(
                    1, IdProfessional, Convert.ToInt32(dRa[0]), true));
            }

            for (int iA = 0; iA < lDelete.Count; iA++)
            {
                classProfessionalSpeciality oA = lDelete[iA];
                for (int iB = 0; iB < lAdd.Count; iB++)
                {
                    classProfessionalSpeciality oB = lAdd[iB];
                    if (oA.IdSpeciality == oB.IdSpeciality)
                    {
                        lDelete.Remove(oA);
                        lAdd.Remove(oB);
                        iA = -1;
                        break;
                    }
                }

            }

            foreach (classProfessionalSpeciality oI in lDelete)
            {
                if (0 == (int)oQuery.AbmProfessionalSpeciality(oI, classQuery.eAbm.Delete))
                    MessageBox.Show(oQuery.Menssage);
            }

            foreach (classProfessionalSpeciality oI in lAdd)
            {
                if (0 == (int)oQuery.AbmProfessionalSpeciality(oI, classQuery.eAbm.Insert))
                    MessageBox.Show(oQuery.Menssage);
            }
#if DEBUG
            MessageBox.Show(
                "# Checked: " + clbSpeciality.CheckedIndices.Count.ToString() +
                "\n# Query: " + lConsulta.Count.ToString() +
                "\nBD->Delete: " + lDelete.Count.ToString() +
                "\nBD->Add: " + lAdd.Count.ToString());
#endif
        }

        /// <summary>
        /// OK 17/09/27
        /// </summary>
        private void setCheckedSpeciality()
        {
            classProfessionalSpeciality oPs = new classProfessionalSpeciality();
            oPs.IdProfessional = oProfessional.IdProfessional;
            List<classProfessionalSpeciality> lPs = oQuery.AbmProfessionalSpeciality(oPs, classQuery.eAbm.SelectAll) as List<classProfessionalSpeciality>;

            foreach (classProfessionalSpeciality iPs in lPs)
            {
                for (int index = 0; index < clbSpeciality.Items.Count; index++)
                {
                    DataRowView dataRow = clbSpeciality.Items[index] as DataRowView;
                    if ((Convert.ToInt32(dataRow[0]) == iPs.IdSpeciality))
                        clbSpeciality.SetItemChecked(index, true);
                }
            }
        }

        /// <summary>
        /// Inicializa Speciality.
        /// OK 17/09/27
        /// </summary>
        private void initSpeciality()
        {
            clbSpeciality.SelectedIndexChanged -= clbSpeciality_SelectedIndexChanged;
            clbSpeciality.DataSource = null;
            if ((bool)oQuery.AbmSpeciality(new classSpecialty(), classQuery.eAbm.LoadCmb))
            {
                DataTable dT = oQuery.Table;
                dT.Rows.Add(new object[] { 0, "Nuevo" });
                clbSpeciality.DataSource = dT;
                clbSpeciality.DisplayMember = "Value";
                clbSpeciality.ValueMember = "Id";
            }
            clbSpeciality.SelectedIndexChanged += clbSpeciality_SelectedIndexChanged;
        }

        /// <summary>
        /// Inicializa Access.
        /// OK 17/09/27
        /// </summary>
        private void initAccess()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbTypeAccess,
                (bool)oQuery.AbmPermission(new classPermission(), classQuery.eAbm.LoadCmb),
                oQuery.Table);
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
            oProfessional.Name = txtName.Text.ToUpper();
            oProfessional.LastName = txtLastName.Text.ToUpper();
            oProfessional.IdLocationCountry = IdCountry;
            oProfessional.IdLocationProvince = IdProvince;
            oProfessional.IdLocationCity = IdCity;
            oProfessional.Address = txtAddress.Text.ToUpper();
            oProfessional.Phone = txtPhone.Text;
            oProfessional.Mail = txtMail.Text.ToUpper();
            oProfessional.User = txtUser.Text;
            oProfessional.Admin = Convert.ToInt32(cmbTypeAccess.SelectedValue);
            oProfessional.Password = txtPassword.Text;
            oProfessional.Visible = Enable;
        }

        /// <summary>
        /// Carga los elementos de formulario desde objeto.
        /// OK 17/09/14
        /// </summary>
        private void EscribirEnFrm()
        {
            txtProfessionalRegistration.Text = Convert.ToString(oProfessional.ProfessionalRegistration);
            txtName.Text = oProfessional.Name.ToUpper();
            txtLastName.Text = oProfessional.LastName.ToUpper();
            txtAddress.Text = oProfessional.Address;
            txtPhone.Text = oProfessional.Phone;
            txtMail.Text = oProfessional.Mail.ToUpper();
            txtUser.Text = oProfessional.User;
            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(cmbTypeAccess, oProfessional.Admin);
            txtPassword.Text = oProfessional.Password;
            IdCountry = oProfessional.IdLocationCountry;
            IdProvince = oProfessional.IdLocationProvince;
            IdCity = oProfessional.IdLocationCity;
            Enable = oProfessional.Visible;

            txtLocation.Text = frmLocation.toStringLocation(
                oQuery.ConexionString, IdCountry, IdProvince, IdCity);

            if (Enable)
                btnBlocked.Text = "Bloquear";
            else
                btnBlocked.Text = "Desbloquear";
        }

        /// <summary>
        /// Valida los campos del Formulario.
        /// False -> Vacio - True -> Ok
        /// OK 30/09/17
        /// </summary>
        /// <returns></returns>
        private bool ValidarCampos()
        {
            bool V = false;

            if (txtName.Text.Length >= 50 || (txtName.Text == ""))
                MessageBox.Show("El Nombre esta vacio o supera los 50 caracteres");
            else if (txtLastName.Text.Length >= 50 || (txtLastName.Text == ""))
                MessageBox.Show("El Apellido esta vacio o supera los 50 caracteres");
            else if (txtMail.Text.Length >= 50 || (txtMail.Text == ""))
                MessageBox.Show("La direccion de Correo esta vacia o supera los 50 caracteres");
            else if (txtAddress.Text.Length >= 50 || (txtAddress.Text == ""))
                MessageBox.Show("La Direccion esta vacia o supera los 50 caracteres");
            else if ((txtPassword.Text.Length < 8) || (txtPassword.Text.Length >= 20) || (txtPassword.Text == ""))
                MessageBox.Show("La Contraseña esta vacia y//o debe tener como minimo 8 caracteres.");
            else if ((txtProfessionalRegistration.Text.Length < 6) || (txtProfessionalRegistration.Text == ""))
                MessageBox.Show("El Numero de Registro esta vacio o no supera los 6 caracteres.");
            else if (txtPhone.Text.Length >= 20)
                MessageBox.Show("El Numero de Telefono supera los 20 caracteres");
            else if (txtUser.Text.Length >= 20 || txtUser.Text == "")
                MessageBox.Show("El Nombre de Usuario esta vacio o supera los 20 caracteres");
            else if ((IdCountry == 0) || (IdProvince == 0) || (IdCity == 0))
                MessageBox.Show("La Localidad no esta seleccionada.");
            else if (cmbTypeAccess.SelectedIndex == -1)
                MessageBox.Show("Tipo de Aceso Invalida.");
            else
                V = true;

            return V;
        }

        #endregion

        #region Validaciones
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        
        private void txtNameE_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}