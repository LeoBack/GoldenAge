using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using Datos.Query;
using Entidades;
using Entidades.Clases;
using Reportes;
using Controles;
using libLocalitation.Forms;

namespace myExplorer.Formularios
{
    public partial class frmAbmPatient : Form
    {
        // OK 17/09/30
        #region Atributos y Propiedades

        public classPatient oPatient { set; get; }
        private classParent oParent;
        private List<classPatientParent> lPatienParent;
        public enum Modo { Add, Select, Update, Delete }
        public Modo eModo { set; get; }
        public Modo eModoParent { set; get; }
        public classQuery oQuery { set; get; }
        public classUtiles oUtil { set; get; }
        private classTextos oTxt;
        private bool Enable = true;
        private int SelectRow;
        private int IdCountry;
        private int IdProvince;
        private int IdCity;
        private int IdCountryParent;
        private int IdProvinceParent;
        private int IdCityParent;

        #endregion

        // OK 17/09/30
        #region Formulario

        // OK 17/09/30
        public frmAbmPatient()
        {
            InitializeComponent();
            oTxt = new classTextos();
        }

        // OK 17/09/30
        private void frmAbmPatient_Load(object sender, EventArgs e)
        {
            if (oQuery != null)
            {
                Text = oTxt.TitleFichaPatient;

                initSocialWork();
                initTypeDocument();
                initParentRelationship();
                initParentList();

                switch (eModo)
                {
                    case Modo.Select:
                        EnablePatient(false);
                        EnableParent(false);
                        EscribirEnFrmPatient();
                        break;
                    case Modo.Update:
                        EnablePatient(true);
                        EnableParent(false);
                        EscribirEnFrmPatient();
                        break;
                    case Modo.Add:
                        oPatient = new classPatient();
                        EnablePatient(true);
                        EnableParent(false);
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
            if (ValidarCamposPatient())
            {
                CargarObjetoPatient();
                int IdQuery = 0;

                switch (eModo)
                {
                    case Modo.Add:
                        IdQuery = (int)oQuery.AbmPatient(oPatient, classQuery.eAbm.Insert);
                        if (0 != IdQuery)
                            MessageBox.Show(oTxt.AddPatient);
                        else
                            MessageBox.Show(oTxt.ErrorQueryAdd);
                        break;
                    case Modo.Update:
                        IdQuery = (int)oQuery.AbmPatient(oPatient, classQuery.eAbm.Update);
                        if (0 != IdQuery)
                            MessageBox.Show(oTxt.UpdatePatient);
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
            if (oPatient != null)
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

        // OK 17/09/30
        private void btnLocalitationPatient_Click(object sender, EventArgs e)
        {
            frmLocation fLocalitation = new frmLocation(oQuery.ConexionString, frmLocation.eLocation.Select);
            if (DialogResult.OK == fLocalitation.ShowDialog())
            {
                txtLocationPatient.Text = fLocalitation.toStringLocation();
                IdCountry = fLocalitation.getIdCountry();
                IdProvince = fLocalitation.getIdProvince();
                IdCity = fLocalitation.getIdCity();
            }
        }

        // OK 17/09/30
        private void btnLocalitationParent_Click(object sender, EventArgs e)
        {
            frmLocation fLocalitation = new frmLocation(oQuery.ConexionString, frmLocation.eLocation.Select);
            if (DialogResult.OK == fLocalitation.ShowDialog())
            {
                txtLocationParent.Text = fLocalitation.toStringLocation();
                IdCountryParent = fLocalitation.getIdCountry();
                IdProvinceParent = fLocalitation.getIdProvince();
                IdCityParent = fLocalitation.getIdCity();
            }
        }

        // OK - 17/10/08
        private void btnAcceptParent_Click(object sender, EventArgs e)
        {
            if(ValidarCamposParent())
            {
                CargarObjetoParent();
                int IdQuery = 0;

                switch (eModoParent)
                {
                    case Modo.Add:
                        IdQuery = (int)oQuery.AbmParent(oParent, classQuery.eAbm.Insert);
                        if (0 != IdQuery)
                        {
                            classPatientParent oPp = new classPatientParent(0, oPatient.IdPatient, IdQuery, Convert.ToInt32(cmbParentRelationship.SelectedValue), true);
                            if (0 != (int)oQuery.AbmPatientParent(oPp, classQuery.eAbm.Insert))
                            {
                                MessageBox.Show(oTxt.AddParent);
                                initParentList();
                            }
                        }
                        else
                            MessageBox.Show(oTxt.ErrorQueryAdd);
                        break;
                    case Modo.Update:
                        IdQuery = (int)oQuery.AbmParent(oParent, classQuery.eAbm.Update);
                        if (0 != IdQuery)
                        {
                            classPatientParent oPp =null;
                            foreach(classPatientParent iPp in lPatienParent)
                            {
                                if ((iPp.IdParent == oParent.IdParent) & (iPp.IdPatient == oPatient.IdPatient))
                                    oPp = new classPatientParent(iPp.IdPatientParent, oPatient.IdPatient, IdQuery, Convert.ToInt32(cmbParentRelationship.SelectedValue), true);
                            }

                            if (0 != (int)oQuery.AbmPatientParent(oPp, classQuery.eAbm.Update))
                            {
                                MessageBox.Show(oTxt.UpdateParent);
                                initParentList();
                            }
                        }
                        else
                            MessageBox.Show(oTxt.ErrorQueryUpdate);
                        break;
                    case Modo.Delete:

                        break;
                    default:
                        MessageBox.Show(oTxt.AccionIndefinida);
                        break;
                }

                if (IdQuery == 0)
                    MessageBox.Show(oQuery.Menssage);
            }
        }

        // OK - 17/10/08
        private void btnNewParent_Click(object sender, EventArgs e)
        {
            eModoParent = Modo.Add;
            oParent = new classParent();
            IdCountryParent = 0;
            IdProvinceParent = 0;
            IdCityParent = 0;

            foreach (Control ctrl in tlpParent.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;
                    t.Text = string.Empty;
                }
            }
            EnableParent(true);
        }

        // OK - 17/10/08
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow = dgvLista.Rows.Count != 0 ? e.RowIndex : 0;

            oParent = oQuery.AbmParent(new classParent(
                Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value)),
                classQuery.eAbm.Select) as classParent;

            eModoParent = oParent != null ? Modo.Update : Modo.Add;
            oParent = oParent != null ? oParent : new classParent();

            EscribirEnFrmParent();
            EnableParent(true);
        }

        #endregion

        #region Metodos Patient

        // OK 17/09/30
        private void initTypeDocument()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbSocialWork,
            (bool)oQuery.AbmSocialWork(new classSocialWork(), classQuery.eAbm.LoadCmb),
            oQuery.Table);
        }

        // OK 17/09/30
        private void initSocialWork()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbTypeDocument,
            (bool)oQuery.AbmTypeDocument(new classTypeDocument(), classQuery.eAbm.LoadCmb),
            oQuery.Table);
        }

        // OK 17/09/30
        private void CargarObjetoPatient()
        {
            oPatient.Name = txtName.Text.ToUpper();
            oPatient.LastName = txtLastName.Text.ToUpper();
            oPatient.Birthdate = dtpBirthdate.Value;
            oPatient.IdTypeDocument = Convert.ToInt32(cmbTypeDocument.SelectedValue);
            oPatient.NumberDocument = Convert.ToInt32(txtNumberDocument.Text);
            oPatient.Sex = rbtMale.Checked;
            oPatient.IdLocationCountry = IdCountry;
            oPatient.IdLocationProvince = IdProvince;
            oPatient.IdLocationCity = IdCity;
            oPatient.Address = txtAddress.Text.ToUpper();
            oPatient.Phone = txtPhone.Text;
            oPatient.IdSocialWork = Convert.ToInt32(cmbSocialWork.SelectedValue);
            oPatient.AffiliateNumber = Convert.ToInt32(txtAffiliateNumber.Text);
            oPatient.DateAdmission = dtpDateAdmission.Value;
            oPatient.EgressDate = dtpEgressDate.Value;
            oPatient.ReasonExit = txtReasonExit.Text.ToUpper();
            oPatient.Visible = Enable;
        }

        /// <summary>
        /// Carga los elementos de formulario desde objeto.
        /// OK 17/09/30
        /// </summary>
        private void EscribirEnFrmPatient()
        {
            txtName.Text = oPatient.Name.ToUpper();
            txtLastName.Text = oPatient.LastName.ToUpper();
            dtpBirthdate.Value = oPatient.Birthdate;
            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(cmbTypeDocument, oPatient.IdTypeDocument);
            txtNumberDocument.Text = Convert.ToString(oPatient.NumberDocument);
            rbtMale.Checked = oPatient.Sex;
            rbtFemale.Checked = !oPatient.Sex;
            IdCountry = oPatient.IdLocationCountry;
            IdProvince = oPatient.IdLocationProvince;
            IdCity = oPatient.IdLocationCity;
            txtAddress.Text = oPatient.Address.ToUpper();
            txtPhone.Text = oPatient.Phone;
            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(cmbSocialWork, oPatient.IdSocialWork);
            txtAffiliateNumber.Text = Convert.ToString(oPatient.AffiliateNumber);
            dtpDateAdmission.Value = oPatient.DateAdmission;
            dtpEgressDate.Value = oPatient.EgressDate;
            txtReasonExit.Text = oPatient.ReasonExit.ToUpper();
            Enable = oPatient.Visible;
            txtYearOld.Text = Convert.ToString(oPatient.YearsOld());

            txtLocationPatient.Text = frmLocation.toStringLocation(
                oQuery.ConexionString, IdCountry, IdProvince, IdCity);

            if (Enable)
                btnBlocked.Text = oTxt.Bloquear;
            else
                btnBlocked.Text = oTxt.Desbloquear;
        }

        /// <summary>
        /// Valida los campos del Formulario.
        /// False -> Vacio - True -> Ok
        /// OK 17/09/30
        /// </summary>
        /// <returns></returns>
        private bool ValidarCamposPatient()
        {
            bool V = false;

            if (txtName.Text.Length >= 50 || (txtName.Text == ""))
                MessageBox.Show("El Nombre esta vacio o supera los 50 caracteres");
            else if (txtLastName.Text.Length >= 50 || (txtLastName.Text == ""))
                MessageBox.Show("El Apellido esta vacio o supera los 50 caracteres");
            else if (txtPhone.Text.Length >= 20)
                MessageBox.Show("El Numero de Telefono supera los 20 caracteres");
            else if ((txtAffiliateNumber.Text.Length < 8) || (txtAffiliateNumber.Text == ""))
                MessageBox.Show("El Numero de Afiliado esta vacio o no supera los 7 caracteres.");
           // else if (txtAddress.Text.Length >= 50 || (txtAddress.Text == ""))
            else if (txtAddress.Text.Length >= 50)
                MessageBox.Show("La Direccion esta vacia o supera los 50 caracteres");
            else if ((IdCountry == 0) || (IdProvince == 0) || (IdCity == 0))
                MessageBox.Show("El Campo Localidad esta vacío o es Erroneo");
            else if (txtReasonExit.Text.Length >= 50)
                MessageBox.Show("El Motivo de Alta Debe tener como minimo 8 caracteres.");
            else if (cmbTypeDocument.SelectedIndex == -1)
                MessageBox.Show("Tipo Docuemento Invalido.");
            else if (cmbSocialWork.SelectedIndex == -1)
                MessageBox.Show("Obra Social Invalida.");
            else
                V = true;

            return V;
        }

        
        /// <summary>
        /// Habilita TabFicha
        /// OK 18/04/12
        /// </summary>
        /// <param name="X"></param>
        private void EnablePatient(bool X)
        {
            foreach (Control C in this.tlpPanlData.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
        }

        #endregion

        #region Metodos Parent

        /// <summary>
        /// Habilita TabFicha
        /// OK 18/04/12
        /// </summary>
        /// <param name="X"></param>
        private void EnableParent(bool X)
        {
            foreach (Control C in this.tlpParent.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
            btnNewParent.Enabled = true;
            dgvLista.Enabled = true;
        }

        // OK - 17/10/08
        private void initParentList()
        {
            classPatientParent oPp = new classPatientParent();
            oPp.IdPatient = oPatient.IdPatient;

            lPatienParent = oQuery.AbmPatientParent(oPp, classQuery.eAbm.SelectAll) as List<classPatientParent>;

            DataTable dT = new DataTable("AbmPatientParent");
            dT.Columns.Add("Id", typeof(Int32));
            dT.Columns.Add("Parentesco", typeof(string));
            dT.Columns.Add("Nombre", typeof(string));
            foreach (classPatientParent iPp in lPatienParent)
            {
                classParent oP = oQuery.AbmParent(new classParent(iPp.IdParent), classQuery.eAbm.Select) as classParent;
                classRelationship oR = oQuery.AbmRelationship(new classRelationship(iPp.IdRelationship), classQuery.eAbm.Select) as classRelationship;
                dT.Rows.Add(new object[] { oP.IdParent, oR.Description, oP.LastName + ", " + oP.Name });
            }
            GenerarGrilla(dT);
        }

        /// <summary>
        /// Carga la Lista debuelve la cantidad de filas.
        /// OK - 17/10/03
        /// </summary>
        /// <param name="Source"></param>
        public int GenerarGrilla(object Source)
        {
            //
            //Configuracion del DataListView
            //
            dgvLista.AutoGenerateColumns = true;
            dgvLista.AllowUserToAddRows = false;
            dgvLista.RowHeadersVisible = false;
            dgvLista.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLista.ReadOnly = true;
            dgvLista.ScrollBars = ScrollBars.Both;
            //dgvLista.ContextMenuStrip = cmsMenuEmergente;
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLista.MultiSelect = false;
            dgvLista.DataSource = Source;
#if RELEASE
            dgvLista.Columns[0].Visible = false;
            dgvLista.Columns[dgvLista.ColumnCount -1].Visible = false;
#endif
            return dgvLista.Rows.Count;
        }

        // OK 17/09/30
        private void initParentRelationship()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbParentRelationship,
            (bool)oQuery.AbmRelationship(new classRelationship(), classQuery.eAbm.LoadCmb),
            oQuery.Table);
        }

        // OK 17/09/30
        private void CargarObjetoParent()
        {
            oParent.Name = txtParentName.Text.ToUpper();
            oParent.LastName = txtParentLastName.Text.ToUpper();
            oParent.NumberDocument = Convert.ToInt32(txtParentNumberDocument.Text);
            oParent.Address = txtParentAddress.Text.ToUpper();
            oParent.IdLocationCountry = IdCountryParent;
            oParent.IdLocationCity = IdCityParent;
            oParent.IdLocationProvince = IdProvinceParent;
            oParent.Phone = txtParentPhone.Text;
            oParent.AlternativePhone = txtParentAlternativePhone.Text;
            oParent.Email = txtParentEmail.Text.ToUpper();
        }

        /// <summary>
        /// Carga los elementos de formulario desde objeto.
        /// OK 17/09/30
        /// </summary>
        private void EscribirEnFrmParent()
        {
            txtParentName.Text = oParent.Name.ToUpper();
            txtParentLastName.Text = oParent.LastName.ToUpper();
            txtParentNumberDocument.Text = Convert.ToString(oParent.NumberDocument);
            txtParentAddress.Text = oParent.Address.ToUpper();
            IdCountryParent = oParent.IdLocationCountry;
            IdProvinceParent = oParent.IdLocationProvince;
            IdCityParent = oParent.IdLocationCity;
            txtParentPhone.Text = oParent.Phone;
            txtParentAlternativePhone.Text = oParent.AlternativePhone;
            txtParentEmail.Text = oParent.Email.ToUpper();

            txtLocationParent.Text = frmLocation.toStringLocation(
                oQuery.ConexionString, IdCountryParent, IdProvinceParent, IdCityParent);

            foreach (classPatientParent iPp in lPatienParent)
            {
                if(iPp.IdParent == oParent.IdParent)
                    libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(
                        cmbParentRelationship, iPp.IdRelationship);
            }
        }

        /// <summary>
        /// Valida los campos del Formulario.
        /// False -> Vacio - True -> Ok
        /// OK 17/09/30
        /// </summary>
        /// <returns></returns>
        private bool ValidarCamposParent()
        {
            bool V = false;

            if (txtParentName.Text.Length >= 50 || (txtParentName.Text == ""))
                MessageBox.Show("El Nombre esta vacio o supera los 50 caracteres");
            else if (txtParentLastName.Text.Length >= 50 || (txtParentLastName.Text == ""))
                MessageBox.Show("El Apellido esta vacio o supera los 50 caracteres");
            else if ((txtParentNumberDocument.Text.Length > 9) || (txtParentNumberDocument.Text == ""))
                MessageBox.Show("El Numero de Documento esta vacio o no supera los 9 caracteres.");
            else if (txtParentAddress.Text.Length >= 50 || (txtParentAddress.Text == ""))
                MessageBox.Show("La Direccion esta vacia o supera los 50 caracteres");
            else if ((IdCountryParent == 0) || (IdProvinceParent == 0) || (IdCityParent == 0))
                MessageBox.Show("El Campo Localidad esta vacío o es Erroneo");
            else if (txtParentPhone.Text.Length >= 15)
                MessageBox.Show("El Numero de Telefono supera los 15 caracteres");
            else if (txtParentAlternativePhone.Text.Length >= 15)
                MessageBox.Show("El Numero de Telefono Alternativo supera los 15 caracteres");
            else if (txtParentEmail.Text.Length >= 50)
                MessageBox.Show("El E-mail supera los 50 caracteres");
            else if (cmbParentRelationship.SelectedIndex== -1)
                MessageBox.Show("Parentesco Invalida.");

            else
                V = true;

            return V;
        }

        #endregion

        #region Validaciones

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }
            
        }

        private void txtParentPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }

        }

        private void txtParentAlternativePhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }

        }

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

        #endregion
    }
}
