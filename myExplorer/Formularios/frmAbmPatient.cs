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
        // OK - 17/09/30
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

        // OK - 17/11/14
        #region Formulario

        // OK 17/09/30
        public frmAbmPatient()
        {
            InitializeComponent();
            oTxt = new classTextos();
        }

        // OK 17/11/14
        private void frmAbmPatient_Load(object sender, EventArgs e)
        {
            if (oQuery != null)
            {
                Text = oTxt.TitleFichaPatient;
                initSocialWork();
                initTypeDocumentPatient();
                initTypeDocumentParent();
                initParentRelationship();
                initParentList();
                Permission();
                EnablePatient(eModo != Modo.Select);
                EnableParent(eModo != Modo.Select);

                if(eModo == Modo.Add)
                    oPatient = new classPatient();
                else
                    LoadFrmPatient();
            }
            else
                Close();
        }

        #endregion

        // OK - 17/11/16
        #region Botones

        // OK - 17/10/10
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (oUtil.oProfessional.IdPermission == 1)
            {
                if (SavePatient())
                    Close();
            }
            else
                Close();
        }

        // OK - 17/10/10
        private void btnAcceptParent_Click(object sender, EventArgs e)
        {
            SaveParent();
        }

        // OK - 17/10/12
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if(oParent != null)
            {
                classPatientParent oPp = new classPatientParent(
                    Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value));

                if (0 != (int)oQuery.AbmPatientParent(oPp, classQuery.eAbm.Delete))
                {
                    MessageBox.Show(oTxt.DeleteParent);
                    CleanParent();
                    initParentList();
                }
                else
                    MessageBox.Show(oTxt.ErrorQueryDelete);
            }
        }

        private void btnSearchParent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Busca por Tipo y Nº de Documento.");
        }

        // OK - 17/09/30
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

        // OK - 17/09/30
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

        // OK - 17/09/30
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
        private void btnNewParent_Click(object sender, EventArgs e)
        {
            bool Ok = true;

            if (eModo == Modo.Add)
            {
                if (MessageBox.Show("Es necesario guardar el paciente actual antes de continuar con la carga de parientes.\n¿Guardar paciente actual?"
                    , "Atencion", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Ok = SavePatient();
                    eModo = (Ok == true) ? Modo.Update : Modo.Add;
                }
                else
                    Ok = false;
            }

            if (Ok)
            {
                eModoParent = Modo.Add;
                oParent = new classParent();
                CleanParent();
                EnableParent(true);
            }
        }

        // OK - 17/11/16
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLista.RowCount >= 0)
            {
                SelectRow = e.RowIndex >= 0 ? e.RowIndex : SelectRow;
                SelectRow = dgvLista.RowCount == 1 ? 0 : SelectRow;

                oParent = oQuery.AbmParent(new classParent(
                    Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[1].Value)),
                    classQuery.eAbm.Select) as classParent;

                eModoParent = oParent != null ? Modo.Update : Modo.Add;
                oParent = oParent != null ? oParent : new classParent();

                LoadfrmParent();

                if (eModo != Modo.Select)
                    EnableParent(true);
            }
        }

        #endregion

        // OK - 17/11/14
        #region Metodos Patient

        /// <summary>
        /// ABM En base de datos Paciente.
        /// OK - 17/10/10
        /// </summary>
        /// <returns>True:Exito False:Error</returns>
        private bool SavePatient()
        {
            int IdQuery = 0;
            if (ValidateFieldsPatient())
            {
                LoadObjectPatient();

                switch (eModo)
                {
                    case Modo.Add:
                        IdQuery = (int)oQuery.AbmPatient(oPatient, classQuery.eAbm.Insert);
                        if (0 != IdQuery)
                        {
                            oPatient.IdPatient = IdQuery;
                            MessageBox.Show(oTxt.AddPatient);
                        }
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
                if(IdQuery == 0)
                    MessageBox.Show(oQuery.Menssage);
            }

            return (IdQuery != 0);
        }

        /// <summary>
        /// Inicializa componente Typo docuemento.
        /// OK - 17/09/30
        /// </summary>
        private void initTypeDocumentPatient()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbTypeDocumentPatient,
            (bool)oQuery.AbmTypeDocument(new classTypeDocument(), classQuery.eAbm.LoadCmb),
            oQuery.Table);
        }

        /// <summary>
        /// Inicializa compoente Obre Social.
        /// OK - 17/09/30
        /// </summary>
        private void initSocialWork()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbSocialWork,
            (bool)oQuery.AbmSocialWork(new classSocialWork(), classQuery.eAbm.LoadCmb),
            oQuery.Table);
        }

        /// <summary>
        /// Cargo objeto Pariente.
        /// OK - 17/09/30
        /// </summary>
        private void LoadObjectPatient()
        {
            oPatient.Name = txtName.Text.ToUpper();
            oPatient.LastName = txtLastName.Text.ToUpper();
            oPatient.Birthdate = dtpBirthdate.Value;
            oPatient.IdTypeDocument = Convert.ToInt32(cmbTypeDocumentPatient.SelectedValue);
            oPatient.NumberDocument = Convert.ToInt32(txtNumberDocument.Text);
            oPatient.Sex = rbtMale.Checked;
            oPatient.IdLocationCountry = IdCountry;
            oPatient.IdLocationProvince = IdProvince;
            oPatient.IdLocationCity = IdCity;
            oPatient.Address = txtAddress.Text.ToUpper();
            oPatient.Phone = txtPhone.Text;
            oPatient.IdSocialWork = Convert.ToInt32(cmbSocialWork.SelectedValue);
            oPatient.AffiliateNumber = txtAffiliateNumber.Text.ToUpper();
            oPatient.DateAdmission = dtpDateAdmission.Value;
            oPatient.EgressDate = dtpEgressDate.Value;
            oPatient.ReasonExit = txtReasonExit.Text.ToUpper();
            oPatient.Visible = Enable;
        }

        /// <summary>
        /// Carga los elementos de formulario desde objeto.
        /// OK - 17/09/30
        /// </summary>
        private void LoadFrmPatient()
        {
            txtName.Text = oPatient.Name.ToUpper();
            txtLastName.Text = oPatient.LastName.ToUpper();
            dtpBirthdate.Value = oPatient.Birthdate;
            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(cmbTypeDocumentPatient, oPatient.IdTypeDocument);
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
        /// OK - 17/09/30
        /// </summary>
        /// <returns></returns>
        private bool ValidateFieldsPatient()
        {
            bool V = false;

            if (txtName.Text.Length >= 50 || (txtName.Text == ""))
                MessageBox.Show("El Nombre esta vacio o supera los 50 caracteres");
            else if (txtLastName.Text.Length >= 50 || (txtLastName.Text == ""))
                MessageBox.Show("El Apellido esta vacio o supera los 50 caracteres");
            else if (txtPhone.Text.Length >= 20)
                MessageBox.Show("El Numero de Telefono supera los 20 caracteres");
            else if ((txtAffiliateNumber.Text.Length <2) || (txtAffiliateNumber.Text.Length >= 19) || (txtAffiliateNumber.Text == ""))
                MessageBox.Show("El Numero de Afiliado esta vacio o supera 19 caracteres.");
           // else if (txtAddress.Text.Length >= 50 || (txtAddress.Text == ""))
            else if (txtAddress.Text.Length >= 50)
                MessageBox.Show("La Direccion esta vacia o supera los 50 caracteres");
            else if ((IdCountry == 0) || (IdProvince == 0) || (IdCity == 0))
                MessageBox.Show("El Campo Localidad esta vacío o es Erroneo");
            else if (txtReasonExit.Text.Length >= 50)
                MessageBox.Show("El Motivo de Alta Debe tener como minimo 8 caracteres.");
            else if (cmbTypeDocumentPatient.SelectedIndex == -1)
                MessageBox.Show("Tipo Docuemento Invalido.");
            else if (cmbSocialWork.SelectedIndex == -1)
                MessageBox.Show("Obra Social Invalida.");
            else if ((txtNumberDocument.Text.Length > 9) || (txtNumberDocument.Text == ""))
                MessageBox.Show("El Numero de Documento esta vacio o no supera los 9 caracteres.");
            else
                V = true;

            return V;
        }

        /// <summary>
        /// Habilita TabFicha
        /// OK - 18/04/12
        /// </summary>
        /// <param name="X">True: Habilitado - False:Inhabilitado</param>
        private void EnablePatient(bool X)
        {
            foreach (Control C in this.tlpPanlData.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
        }

        #endregion

        // OK - 17/11/14
        #region Metodos Parent

        /// <summary>
        /// Limpia los componentes del pariente
        /// OK - 17/10/12
        /// </summary>
        private void CleanParent()
        {
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
        }

        /// <summary>
        /// ABM En base de datos Pariente.
        /// OK - 17/10/10
        /// </summary>
        /// <returns>True:Exito False:Error</returns>
        private bool SaveParent()
        {
            int IdQuery = 0;
            if (ValidateFieldsParent())
            {
                LoadObjectParent();

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
                            classPatientParent oPp = null;
                            foreach (classPatientParent iPp in lPatienParent)
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
            return (IdQuery != 0);
        }

        /// <summary>
        /// Inicializa componente Typo docuemento.
        /// OK - 17/09/30
        /// </summary>
        private void initTypeDocumentParent()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbTypeDocumentParent,
            (bool)oQuery.AbmTypeDocument(new classTypeDocument(), classQuery.eAbm.LoadCmb),
            oQuery.Table);
        }

        /// <summary>
        /// Habilita TabFicha
        /// OK - 18/04/12
        /// </summary>
        /// <param name="X">True: Habilitado - False: Inhabilitado</param>
        private void EnableParent(bool X)
        {
            foreach (Control C in this.tlpParent.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
            tsmiDelete.Enabled = X;
            dgvLista.Enabled = true;
        }

        /// <summary>
        /// Inicializa componente ListaParientes
        /// OK - 17/10/08
        /// </summary>
        private void initParentList()
        {
            if (eModo != Modo.Add)
            {
                classPatientParent oPp = new classPatientParent();
                oPp.IdPatient = oPatient.IdPatient;

                lPatienParent = oQuery.AbmPatientParent(oPp, classQuery.eAbm.SelectAll) as List<classPatientParent>;

                DataTable dT = new DataTable("AbmPatientParent");
                dT.Columns.Add("IdPatientParent", typeof(Int32));
                dT.Columns.Add("IdParent", typeof(Int32));
                dT.Columns.Add("Parentesco", typeof(string));
                dT.Columns.Add("Nombre", typeof(string));
                foreach (classPatientParent iPp in lPatienParent)
                {
                    classParent oP = oQuery.AbmParent(new classParent(iPp.IdParent), classQuery.eAbm.Select) as classParent;
                    classRelationship oR = oQuery.AbmRelationship(new classRelationship(iPp.IdRelationship), classQuery.eAbm.Select) as classRelationship;
                    dT.Rows.Add(new object[] { iPp.IdPatientParent, oP.IdParent, oR.Description, oP.LastName + ", " + oP.Name });
                }
                GenerarGrilla(dT);
            }
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
            dgvLista.ContextMenuStrip = cmsMenuEmergente;
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLista.MultiSelect = false;
            dgvLista.DataSource = Source;
#if (!DEBUG)
            dgvLista.Columns[0].Visible = false;
            dgvLista.Columns[1].Visible = false;
            //dgvLista.Columns[dgvLista.ColumnCount -1].Visible = false;
#endif
            return dgvLista.Rows.Count;
        }

        /// <summary>
        /// Inicializa compoente Relacion Pariente.
        /// OK 17/09/30
        /// </summary>
        private void initParentRelationship()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbParentRelationship,
            (bool)oQuery.AbmRelationship(new classRelationship(), classQuery.eAbm.LoadCmb),
            oQuery.Table);
        }

        /// <summary>
        /// CArga Objeto desde Formulario.
        /// OK 17/09/30
        /// </summary>
        private void LoadObjectParent()
        {
            oParent.Name = txtParentName.Text.ToUpper();
            oParent.LastName = txtParentLastName.Text.ToUpper();
            oParent.NumberDocument = Convert.ToInt32(txtParentNumberDocument.Text);
            oParent.IdTypeDocument = Convert.ToInt32(cmbTypeDocumentParent.SelectedValue);
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
        private void LoadfrmParent()
        {
            txtParentName.Text = oParent.Name.ToUpper();
            txtParentLastName.Text = oParent.LastName.ToUpper();
            txtParentNumberDocument.Text = Convert.ToString(oParent.NumberDocument);
            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(cmbTypeDocumentParent, oParent.IdTypeDocument);
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
        private bool ValidateFieldsParent()
        {
            bool V = false;
            classValidaciones oClassValidas = new classValidaciones();
            if (txtParentName.Text.Length >= 50 || (txtParentName.Text == ""))
                MessageBox.Show("El Nombre esta vacio o supera los 50 caracteres");
            else if (txtParentLastName.Text.Length >= 50 || (txtParentLastName.Text == ""))
                MessageBox.Show("El Apellido esta vacio o supera los 50 caracteres");
            //else if ((txtParentNumberDocument.Text.Length > 9) || (txtParentNumberDocument.Text == ""))
            else if ((txtParentNumberDocument.Text.Length > 9))
                MessageBox.Show("El Numero de Documento esta vacio o no supera los 9 caracteres.");
            //else if (txtParentAddress.Text.Length >= 50 || (txtParentAddress.Text == ""))
            else if (txtParentAddress.Text.Length >= 50)
                MessageBox.Show("La Direccion supera los 50 caracteres");
            else if ((IdCountryParent == 0) || (IdProvinceParent == 0) || (IdCityParent == 0))
                MessageBox.Show("El Campo Localidad esta vacío o es Erroneo");
            else if (txtParentPhone.Text.Length >= 15)
                MessageBox.Show("El Numero de Telefono supera los 20 caracteres");
            else if (txtParentAlternativePhone.Text.Length >= 20)
                MessageBox.Show("El Numero de Telefono Alternativo supera los 15 caracteres");
            //else if (txtParentEmail.Text.Length >= 50)
            //    MessageBox.Show("El E-mail supera los 50 caracteres");
            else if (oClassValidas.VerifyEmailAddressFormat(txtParentEmail.Text) == false)
                MessageBox.Show("Formato de Correo es: mi@correo.com.ar");
            else if (cmbParentRelationship.SelectedIndex== -1)
                MessageBox.Show("Parentesco Invalida.");
            else if (cmbTypeDocumentParent.SelectedIndex == -1)
                MessageBox.Show("Tipo documento Invalido.");
            else
                V = true;

            return V;
        }

        #endregion

        // OK - 17/11/14
        #region Validaciones

        /// <summary>
        /// OK - 17/11/11
        /// </summary>
        private void Permission()
        {
            bool isAdmin = (oUtil.oProfessional.IdPermission == 1);
            tsmiDelete.Visible = isAdmin;
            btnBlocked.Visible = isAdmin;
            btnNewParent.Visible = isAdmin;
            btnAcceptParent.Visible = isAdmin;
            btnSearchParent.Visible = isAdmin;
            btnLocalitation.Visible = isAdmin;
            btnLocalitationParent.Visible = isAdmin;
            cmsMenuEmergente.Visible = isAdmin;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            classValidaciones oClassValidas = new classValidaciones();
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back) && oClassValidas.isPhone(e.KeyChar))
                e.Handled = true;
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNumberDocument_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
                e.Handled = true;
        }

        private void ValidarCorreos(object sender, KeyPressEventArgs e)
        {
            classValidaciones oClassValidas = new classValidaciones();
            oClassValidas.EmailLostFocus(txtParentEmail, "La direccion de correo es invalida.");
        }

        #endregion
    }
}
