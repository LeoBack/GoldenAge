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
        // OK 17/09/27
        #region Atributos y Propiedades

        public classProfessional oProfessional { set; get; }
        public enum Modo { Add, Select, Update, Delete }
        public Modo eModo { set; get; }
        public classQuery oQuery { set; get; }
        public classUtiles oUtil { set; get; }
        private classTextos oTxt;
        private int IdCountry = 0;
        private int IdProvince = 0;
        private int IdCity = 0;

        #endregion

        // OK 17/09/27
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
                if (eModo == Modo.Select && oUtil.oProfessional.IdProfessional != 0)
                {
                    oProfessional = (classProfessional)oQuery.AbmProfessional(new classProfessional(oUtil.oProfessional.IdProfessional), classQuery.eAbm.Select);
                    EnableFrm(false);
                    btnBloquear.Enabled = true;
                    EscribirEnFrm();
                    CheckedSpeciality();
                }
                else if (eModo == Modo.Update && oUtil.oProfessional.IdProfessional != 0)
                {
                    EnableFrm(true);
                    btnBloquear.Enabled = true;
                    EscribirEnFrm();
                    CheckedSpeciality();
                }
                else if (eModo == Modo.Add)
                {
                    oProfessional = new classProfessional();
                    EnableFrm(true);
                    btnBloquear.Enabled = false;
                    EscribirEnFrm();
                }
            }
            else
                Close();
        }

        #endregion

        #region Botones

        // OK 17/09/16
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                CargarObjeto();

                if (eModo == Modo.Add)
                {
                    if (0 != (int)oQuery.AbmProfessional(oProfessional, classQuery.eAbm.Insert))
                        MessageBox.Show(oTxt.AddProfessional);
                    else
                        MessageBox.Show(oTxt.ErrorQueryAdd);
                }
                else if (eModo == Modo.Update)
                {
                    if (0 != (int)oQuery.AbmProfessional(oProfessional, classQuery.eAbm.Update))
                        MessageBox.Show(oTxt.UpdateProfessional);
                    else
                        MessageBox.Show(oTxt.ErrorQueryUpdate);
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
            //if (oProfessional != null)
            //{
            //    if (btnBloquear.Text == oTxt.Bloquear)
            //    {
            //        oProfessional.Visible = true;
            //        btnBloquear.Text = oTxt.Desbloquear;
            //    }
            //    else
            //    {
            //        oProfessional.Visible = false;
            //        btnBloquear.Text = oTxt.Bloquear;
            //    }
            //    btnGuardar_Click(sender, e);
            //}
            GuardarSpeciality();
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

        #region Metodos

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

        private void GuardarSpeciality()
        {
            classProfessionalSpeciality oPs = new classProfessionalSpeciality();
            oPs.IdProfessional = oProfessional.IdProfessional;
            List<classProfessionalSpeciality> lConsulta = (List<classProfessionalSpeciality>)oQuery.AbmProfessionalSpeciality(oPs, classQuery.eAbm.SelectAll);
            
            List<classProfessionalSpeciality> oListaAgregar = new List<classProfessionalSpeciality>();
            List<classProfessionalSpeciality> oListaEliminar = new List<classProfessionalSpeciality>();
            List<classProfessionalSpeciality> oListaDepurada = new List<classProfessionalSpeciality>();

            oListaDepurada.AddRange(lConsulta);

            // Elimino lo que coincide entre BD y Frm
            //foreach (classProfessionalSpeciality iPs in lPs)
            //{
            //    foreach (int indexChecked in clbSpeciality.CheckedIndices)
            //    {
            //        DataRowView dataRow = clbSpeciality.Items[indexChecked] as DataRowView;
            //        if (iPs.IdSpeciality == Convert.ToInt32(dataRow[0]))
            //        {
            //            oListaDepurada.RemoveAt(indexChecked);
            //        }
            //    }
            //}
            for (int i = 0; i < lConsulta.Count; i++)
            {
                foreach (int indexChecked in clbSpeciality.CheckedIndices)
                {
                    DataRowView dataRow = clbSpeciality.Items[indexChecked] as DataRowView;
                    if (lConsulta[i].IdSpeciality == Convert.ToInt32(dataRow[0]))
                        oListaDepurada.Remove(lConsulta[i]);      // Elimino lo que coincide entre BD y Frm
                    break;
                }
            }

            // Agrego lo que NO coincide entre BD y Frm
            //foreach (classProfessionalSpeciality iPs in oListaDepurada)
            for (int i = 0; i < oListaDepurada.Count; i++)
            {
                foreach (int indexChecked in clbSpeciality.CheckedIndices)
                {
                    DataRowView dataRow = clbSpeciality.Items[indexChecked] as DataRowView;
                    if (oListaDepurada[i].IdSpeciality != Convert.ToInt32(dataRow[0]))
                    {
                        oListaAgregar.Add(oListaDepurada[i]);
                        oListaDepurada.Remove(oListaDepurada[i]);
                    }
                }
            }

            // Elimino lo que NO coincide entre BD y Frm
            //foreach (classProfessionalSpeciality iPs in oListaDepurada)
            //{
            //    oListaEliminar.Add(iPs);
            //    oListaDepurada.Remove(iPs);
            //}
            //for (int i = 0; i < lConsulta.Count; i++)
            //{
            //    oListaEliminar.Add(oListaDepurada[i]);
            //    oListaDepurada.Remove(oListaDepurada[i]);
            //}

            MessageBox.Show(
                "Add: " + oListaAgregar.Count.ToString() + 
                "Remove: " + oListaEliminar.Count.ToString() +
                "Depurado: " + oListaDepurada.Count.ToString());
        }

        /// <summary>
        /// OK 17/09/27
        /// </summary>
        private void CheckedSpeciality()
        {
            classProfessionalSpeciality oPs = new classProfessionalSpeciality();
            oPs.IdProfessional = oProfessional.IdProfessional;
            List<classProfessionalSpeciality> lPs = (List<classProfessionalSpeciality>)oQuery.AbmProfessionalSpeciality(oPs, classQuery.eAbm.SelectAll);

            foreach (classProfessionalSpeciality iPs in lPs)
            {
                for(int index = 0; index < clbSpeciality.Items.Count; index++)
                {
                    DataRowView dataRow = clbSpeciality.Items[index] as DataRowView;
                    clbSpeciality.SetItemChecked(index, (Convert.ToInt32(dataRow[0]) == iPs.IdSpeciality));
                }
            }
        }
    }
}
