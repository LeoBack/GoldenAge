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
using libFeaturesComponents.fComboBox;

namespace GoldenAge.Formularios
{
    public partial class frmAbmPatient : Form
    {
        // OK - 18/02/07
        #region Atributos y Propiedades

        public classPatient oPatient { set; get; }
        private classParent oParent;
        private List<classPatientParent> lPatienParent;
        public enum Modo { Add, Select, Update, Delete }
        public Modo eModo { set; get; }
        public Modo eModoParent { set; get; }
        public classQuery ObjetQuery { set; get; }
        public classUtiles ObjetUtil { set; get; }
        private classTextos ObjetTxt;
        private bool Enable = true;
        private int SelectRow;
        private int IdCountry;
        private int IdProvince;
        private int IdCity;
        private int IdCountryParent;
        private int IdProvinceParent;
        private int IdCityParent;
        private List<classParent> lParent = null;
        private int Next = 0;
        private DataTable dtViewPatientSocialWork;
        private DataTable dtTempPatientSocialWork;
        private DataTable dtQuerySocialWorks;
        private int IdPatientSocialWorkSelected;

        #endregion

        // OK - 18/02/08
        #region Formulario

        // OK - 17/09/30
        public frmAbmPatient()
        {
            InitializeComponent();
            ObjetTxt = new classTextos();
        }

        // OK - 18/02/07
        private void frmAbmPatient_Load(object sender, EventArgs e)
        {
            if (ObjetQuery != null)
            {
                Text = ObjetTxt.TitleFichaPatient;
                Permission();
                // Patient
                initTypeDocumentPatient();
                EnablePatient(eModo != Modo.Select);
                // Parent
                InitTypeDocumentParent();
                InitParentRelationship();
                InitParentList();
                EnableParent(false);
                btnParentNew.Enabled = (eModo != Modo.Select);
                lblSearchParent.Text = string.Empty;
                // SocialWork
                InitSocialWork();
                EnableSocialWork(false);
                btnSocialWorkNew.Enabled = (eModo != Modo.Select);
                // State
                EnableState(eModo != Modo.Select);

                if (eModo == Modo.Add)
                    oPatient = new classPatient();
                else
                {
                    LoadFrmPatient();
                    LoadPatientSocialWork();
                }
            }
            else
                Close();
        }

        // OK - 17/10/10
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ObjetUtil.oProfessional.IdPermission == 1)
            {
                SavePatient();
                Close();
            }
        }

        /// <summary>
        /// ABM En base de datos Paciente.
        /// OK - 18/02/07
        /// </summary>
        /// <returns>True:Exito False:Error</returns>
        private bool SavePatient()
        {
            int IdQueryStatus = 0;
            if (ValidateFieldsPatient())
            {
                LoadObjectPatient();

                switch (eModo)
                {
                    case Modo.Add:
                        IdQueryStatus = (int)ObjetQuery.AbmPatient(oPatient, classQuery.eAbm.Insert);
                        if (0 != IdQueryStatus)
                        {
                            oPatient.IdPatient = IdQueryStatus;
                            SaveSocialWork(IdQueryStatus);
                            MessageBox.Show(ObjetTxt.AddPatient);
                        }
                        else
                            MessageBox.Show(ObjetTxt.ErrorQueryAdd);
                        break;

                    case Modo.Update:
                        IdQueryStatus = (int)ObjetQuery.AbmPatient(oPatient, classQuery.eAbm.Update);
                        if (0 != IdQueryStatus)
                        {
                            SaveSocialWork(IdQueryStatus);
                            MessageBox.Show(ObjetTxt.UpdatePatient);
                        }
                        else
                            MessageBox.Show(ObjetTxt.ErrorQueryUpdate);
                        break;

                    case Modo.Select:
                        IdQueryStatus = 1;
                        break;
                    default:
                        MessageBox.Show(ObjetTxt.AccionIndefinida);
                        break;
                }
                if (IdQueryStatus == 0)
                    MessageBox.Show(ObjetQuery.Menssage);
            }

            return (IdQueryStatus != 0);
        }

        /// <summary>
        /// Mensaje previo para agregar pariete o obrasocial cuando el paciente es nuevo.
        /// OK - 18/03/06
        /// </summary>
        /// <returns>True: Ok | False: Error</returns>
        private bool PreviousMessageToSave()
        {
            bool Ok = true;
            if (eModo == Modo.Add)
            {
                if (MessageBox.Show("Es necesario guardar el paciente actual antes de continuar.\n¿Guardar paciente actual?"
                , "Atencion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Ok = SavePatient();
                    eModo = (Ok == true) ? Modo.Update : Modo.Add;
                }
                else
                    Ok = false;
            }
            return Ok;
        }

        #endregion

        // OK - 17/11/14
        #region Metodos Patient

        // OK - 17/11/21
        private void btnPatientBlocked_Click(object sender, EventArgs e)
        {
            if (oPatient != null)
            {
                Enable = btnPatientBlocked.Text == ObjetTxt.Bloquear ? false : true;
                btnPatientBlocked.Text = btnPatientBlocked.Text == ObjetTxt.Bloquear ? ObjetTxt.Desbloquear : ObjetTxt.Bloquear;
            }
        }

        // OK - 17/09/30
        private void btnPatientLocalitation_Click(object sender, EventArgs e)
        {
            frmLocation fLocalitation = new frmLocation(ObjetQuery.ConexionString, frmLocation.eLocation.Select);
            if (DialogResult.OK == fLocalitation.ShowDialog())
            {
                txtLocationPatient.Text = fLocalitation.toStringLocation();
                IdCountry = fLocalitation.getIdCountry();
                IdProvince = fLocalitation.getIdProvince();
                IdCity = fLocalitation.getIdCity();
            }
        }

        /// <summary>
        /// Inicializa componente Typo docuemento.
        /// OK - 17/09/30
        /// </summary>
        private void initTypeDocumentPatient()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbTypeDocumentPatient,
            (bool)ObjetQuery.AbmTypeDocument(new classTypeDocument(), classQuery.eAbm.LoadCmb),
            ObjetQuery.Table);
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
            oPatient.Visible = Enable;


            oPatient.DateAdmission = dtpDate.Value;
            oPatient.EgressDate = DateTime.Now;
            oPatient.ReasonExit = txtReason.Text.ToUpper();
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
            Enable = oPatient.Visible;
            txtYearOld.Text = Convert.ToString(oPatient.YearsOld());

            txtLocationPatient.Text = frmLocation.toStringLocation(
                ObjetQuery.ConexionString, IdCountry, IdProvince, IdCity);

            if (Enable)
                btnPatientBlocked.Text = ObjetTxt.Bloquear;
            else
                btnPatientBlocked.Text = ObjetTxt.Desbloquear;

            dtpDate.Value = oPatient.DateAdmission;
            //dtpEgressDate.Value = oPatient.EgressDate;
            txtReason.Text = oPatient.ReasonExit.ToUpper();
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
            else if (txtAddress.Text.Length >= 50)
                MessageBox.Show("La Direccion esta vacia o supera los 50 caracteres");
            else if ((IdCountry == 0) || (IdProvince == 0) || (IdCity == 0))
                MessageBox.Show("El Campo Localidad esta vacío o es Erroneo");
            else if (txtReason.Text.Length >= 50)
                MessageBox.Show("El Motivo de Alta Debe tener como minimo 8 caracteres.");
            else if (cmbTypeDocumentPatient.SelectedIndex == -1)
                MessageBox.Show("Tipo Docuemento Invalido.");
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
            foreach (Control C in this.tlpDataPersonal.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
        }

        #endregion

        // OK - 17/11/23
        #region Metodos Parent

        // OK - 17/09/30
        private void BtnParentLocalitation_Click(object sender, EventArgs e)
        {
            frmLocation fLocalitation = new frmLocation(ObjetQuery.ConexionString, frmLocation.eLocation.Select);
            if (DialogResult.OK == fLocalitation.ShowDialog())
            {
                txtLocationParent.Text = fLocalitation.toStringLocation();
                IdCountryParent = fLocalitation.getIdCountry();
                IdProvinceParent = fLocalitation.getIdProvince();
                IdCityParent = fLocalitation.getIdCity();
            }
        }

        // OK - 17/11/21
        private void BtnParentSearch_Click(object sender, EventArgs e)
        {
            if (Next == 0)
            {
                if (txtParentNumberDocument.Text != string.Empty)
                {
                    classParent oP = new classParent();
                    oP.IdTypeDocument = Convert.ToInt32(cmbTypeDocumentParent.SelectedValue);
                    oP.NumberDocument = Convert.ToInt32(txtParentNumberDocument.Text);
                    lParent = ObjetQuery.AbmParent(oP, classQuery.eAbm.SelectAll) as List<classParent>;
                }
            }

            if (lParent != null && lParent.Count != 0)
            {
                if (Next < lParent.Count)
                {
                    oParent = lParent[Next++];
                    lblSearchParent.Text = Next.ToString() + "/" + lParent.Count.ToString() + " Encontrados";
                    LoadfrmParent();
                    Next = Next == lParent.Count ? 0 : Next;
                    eModoParent = Modo.Update;
                }
            }
            else
                CleanParent();
        }

        // OK - 17/10/08
        private void BtnParentNew_Click(object sender, EventArgs e)
        {
            if (PreviousMessageToSave())
            {
                eModoParent = Modo.Add;
                oParent = new classParent();
                CleanParent();
                EnableParent(true);
            }
        }

        // OK - 17/10/10
        private void BtnParentAccept_Click(object sender, EventArgs e)
        {
            SaveParent();
        }

        // OK - 17/10/12
        private void TsmiParentDelete_Click(object sender, EventArgs e)
        {
            if (oParent != null)
            {
                classPatientParent oPp = new classPatientParent(
                    Convert.ToInt32(dgvParentList.Rows[SelectRow].Cells[0].Value));

                if (0 != (int)ObjetQuery.AbmPatientParent(oPp, classQuery.eAbm.Delete))
                {
                    MessageBox.Show(ObjetTxt.DeleteParent);
                    CleanParent();
                    InitParentList();
                }
                else
                    MessageBox.Show(ObjetTxt.ErrorQueryDelete);
            }
        }

        // OK - 17/11/16
        private void DgvParentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvParentList.RowCount >= 0)
            {
                SelectRow = e.RowIndex >= 0 ? e.RowIndex : SelectRow;
                SelectRow = dgvParentList.RowCount == 1 ? 0 : SelectRow;

                oParent = ObjetQuery.AbmParent(new classParent(
                    Convert.ToInt32(dgvParentList.Rows[SelectRow].Cells[1].Value)),
                    classQuery.eAbm.Select) as classParent;

                eModoParent = oParent != null ? Modo.Update : Modo.Add;
                oParent = oParent != null ? oParent : new classParent();
                EnableParent(eModo != Modo.Select);
                LoadfrmParent();
            }
        }

        /// <summary>
        /// Limpia los componentes del pariente
        /// OK - 17/11/21
        /// </summary>
        private void CleanParent()
        {
            IdCountryParent = 0;
            IdProvinceParent = 0;
            IdCityParent = 0;
            lblSearchParent.Text = string.Empty;
            lParent = null;

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
        /// OK - 17/11/23
        /// </summary>
        /// <returns>True:Exito False:Error</returns>
        private bool SaveParent()
        {
            int IdQueryStatus = 0;
            if (ValidateFieldsParent())
            {
                LoadObjectParent();

                switch (eModoParent)
                {
                    case Modo.Add:
                        IdQueryStatus = (int)ObjetQuery.AbmParent(oParent, classQuery.eAbm.Insert);
                        if (0 != IdQueryStatus)
                        {
                            classPatientParent oPp = new classPatientParent(0, oPatient.IdPatient, IdQueryStatus, Convert.ToInt32(cmbParentRelationship.SelectedValue), true);
                            if (0 != (int)ObjetQuery.AbmPatientParent(oPp, classQuery.eAbm.Insert))
                            {
                                MessageBox.Show(ObjetTxt.AddParent);
                                InitParentList();
                            }
                        }
                        else
                            MessageBox.Show(ObjetTxt.ErrorQueryAdd);
                        break;
                    case Modo.Update:
                        IdQueryStatus = (int)ObjetQuery.AbmParent(oParent, classQuery.eAbm.Update);
                        if (0 != IdQueryStatus)
                        {
                            classPatientParent oPp = null;
                            classQuery.eAbm Accion = classQuery.eAbm.Update;

                            foreach (classPatientParent iPp in lPatienParent)
                            {
                                if ((iPp.IdParent == oParent.IdParent) & (iPp.IdPatient == oPatient.IdPatient))
                                    oPp = new classPatientParent(iPp.IdPatientParent, oPatient.IdPatient, IdQueryStatus, Convert.ToInt32(cmbParentRelationship.SelectedValue), true);
                            }

                            if (oPp == null)
                            {
                                oPp = new classPatientParent();
                                oPp.IdPatient = oPatient.IdPatient;
                                oPp.IdParent = IdQueryStatus;
                                oPp.IdRelationship = Convert.ToInt32(cmbParentRelationship.SelectedValue);
                                Accion = classQuery.eAbm.Insert;
                            }

                            if (0 != (int)ObjetQuery.AbmPatientParent(oPp, Accion))
                            {
                                MessageBox.Show(oPp != null ? ObjetTxt.UpdateParent : ObjetTxt.AddParent);
                                InitParentList();
                            }
                        }
                        else
                            MessageBox.Show(ObjetTxt.ErrorQueryUpdate);
                        break;
                    case Modo.Delete:
                        break;
                    default:
                        MessageBox.Show(ObjetTxt.AccionIndefinida);
                        break;
                }

                if (IdQueryStatus == 0)
                    MessageBox.Show(ObjetQuery.Menssage);
            }
            return (IdQueryStatus != 0);
        }

        /// <summary>
        /// Inicializa componente Typo docuemento.
        /// OK - 17/09/30
        /// </summary>
        private void InitTypeDocumentParent()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbTypeDocumentParent,
            (bool)ObjetQuery.AbmTypeDocument(new classTypeDocument(), classQuery.eAbm.LoadCmb),
            ObjetQuery.Table);
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
            tsmiParentDelete.Enabled = X;
            dgvParentList.Enabled = true;
        }

        /// <summary>
        /// Inicializa componente ListaParientes
        /// OK - 17/10/08
        /// </summary>
        private void InitParentList()
        {
            if (eModo != Modo.Add)
            {
                classPatientParent oPp = new classPatientParent();
                oPp.IdPatient = oPatient.IdPatient;

                lPatienParent = ObjetQuery.AbmPatientParent(oPp, classQuery.eAbm.SelectAll) as List<classPatientParent>;

                DataTable dT = new DataTable("AbmPatientParent");
                dT.Columns.Add("IdPatientParent", typeof(Int32));
                dT.Columns.Add("IdParent", typeof(Int32));
                dT.Columns.Add("Parentesco", typeof(string));
                dT.Columns.Add("Nombre", typeof(string));
                foreach (classPatientParent iPp in lPatienParent)
                {
                    classParent oP = ObjetQuery.AbmParent(new classParent(iPp.IdParent), classQuery.eAbm.Select) as classParent;
                    classRelationship oR = ObjetQuery.AbmRelationship(new classRelationship(iPp.IdRelationship), classQuery.eAbm.Select) as classRelationship;
                    dT.Rows.Add(new object[] { iPp.IdPatientParent, oP.IdParent, oR.Description, oP.LastName + ", " + oP.Name });
                }
                GenerarGrillaParent(dT);
            }
        }

        /// <summary>
        /// Carga la Lista debuelve la cantidad de filas.
        /// OK - 17/11/23
        /// </summary>
        /// <param name="Source"></param>
        public void GenerarGrillaParent(object Source)
        {
            //
            //Configuracion del DataListView
            //
            dgvParentList.AutoGenerateColumns = true;
            dgvParentList.AllowUserToAddRows = false;
            dgvParentList.RowHeadersVisible = false;
            dgvParentList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvParentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParentList.ReadOnly = true;
            dgvParentList.ScrollBars = ScrollBars.Both;
            dgvParentList.ContextMenuStrip = cmsParent;
            dgvParentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParentList.MultiSelect = false;
            dgvParentList.DataSource = Source;
#if (!DEBUG)
            dgvParentList.Columns[0].Visible = false;
            dgvParentList.Columns[1].Visible = false;
            //dgvLista.Columns[dgvLista.ColumnCount -1].Visible = false;
#endif
        }

        /// <summary>
        /// Inicializa compoente Relacion Pariente.
        /// OK 17/09/30
        /// </summary>
        private void InitParentRelationship()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbParentRelationship,
            (bool)ObjetQuery.AbmRelationship(new classRelationship(), classQuery.eAbm.LoadCmb),
            ObjetQuery.Table);
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
                ObjetQuery.ConexionString, IdCountryParent, IdProvinceParent, IdCityParent);

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

        // OK - 18/03/02
        #region Metodos SocialWork

        // OK - 18/03/02
        private void BtnSocialWorkAdd_Click(object sender, EventArgs e)
        {
            if (PreviousMessageToSave())
            {
                CleanSocialWork();
                EnableSocialWork(true);
            }
        }

        // OK - 18/03/02
        private void TsmiSocialWorkDelete_Click(object sender, EventArgs e)
        {
            // Lo borra de la Tabla Vista
            DataRow rDelete = dtViewPatientSocialWork.NewRow();
            foreach (DataRow dRv in dtViewPatientSocialWork.Rows)
            {
                if (Convert.ToInt32(dRv[0]) == IdPatientSocialWorkSelected)
                    rDelete = dRv;
            }
            dtViewPatientSocialWork.Rows.Remove(rDelete);

            // Actualiza la Tabla Temporal con la fila al Id 0 para eliminar
            foreach (DataRow dRt in dtTempPatientSocialWork.Rows)
            {
                if(Convert.ToInt32(dRt[1]) == IdPatientSocialWorkSelected)
                    dRt[0] = 0;
            }

            GenerarGrillaPatientSocialWork();
        }

        // OK - 18/03/02
        // btnApply -> Confirma todo los cambios
        // -1 Insert | 0 Delete | +1 Update
        private void BtnSocialWorkApply_Click(object sender, EventArgs e)
        {
            if (ValidateFieldsSocialWorks())
            {
                // Agrega
                if (IdPatientSocialWorkSelected == -1)
                {
                    dtViewPatientSocialWork.Rows.Add(new object[] { IdPatientSocialWorkSelected, txtAffiliateNumber.Text, Convert.ToInt32(cmbSocialWork.SelectedValue) });
                    dtTempPatientSocialWork.Rows.Add(new object[] { -1, IdPatientSocialWorkSelected, txtAffiliateNumber.Text, Convert.ToInt32(cmbSocialWork.SelectedValue) });
                }
                // Elimina
                else if (IdPatientSocialWorkSelected == 0)
                {
                    // Ver evento SaveSocialWork. 
                }
                // Actualiza
                else
                {
                    foreach (DataRow dtR in dtViewPatientSocialWork.Rows)
                    {
                        if (Convert.ToInt32(dtR[0]) == IdPatientSocialWorkSelected)
                        {
                            dtR[1] = txtAffiliateNumber.Text;
                            dtR[2] = Convert.ToInt32(cmbSocialWork.SelectedValue);
                        }
                    }
                    foreach (DataRow dtR in dtTempPatientSocialWork.Rows)
                    {
                        if (Convert.ToInt32(dtR[1]) == IdPatientSocialWorkSelected)
                        {
                            dtR[0] = 1;
                            dtR[2] = txtAffiliateNumber.Text;
                            dtR[3] = Convert.ToInt32(cmbSocialWork.SelectedValue);
                        }
                    }
                }
                GenerarGrillaPatientSocialWork();
            }
        }

        /// <summary>
        /// Actualiza en BD -> SocialWork.
        /// OK - 18/02/08
        /// -1 Insert | 0 Delete | +1 Update
        /// </summary>
        /// <returns>True: Exito | False: Error</returns>
        private void SaveSocialWork(int IdPatient)
        {
            string Error;
            foreach (DataRow dR in dtTempPatientSocialWork.Rows)
            {
                Error = null;
                classPatientSocialWork oSw = new classPatientSocialWork();
                oSw.IdPatientSocialWork = Convert.ToInt32(dR[1]);
                oSw.IdPatient = IdPatient;
                oSw.AffiliateNumber = Convert.ToString(dR[2]);
                oSw.IdSocialWork = Convert.ToInt32(dR[3]);

                if (Convert.ToInt32(dR[0]) == -1)
                {
                    if (0 == (int)ObjetQuery.AbmPatientSocialWork(oSw, classQuery.eAbm.Insert))
                        Error = ObjetTxt.ErrorQueryAdd;
                }
                else if (Convert.ToInt32(dR[0]) == 0)
                {
                    if (0 == (int)ObjetQuery.AbmPatientSocialWork(oSw, classQuery.eAbm.Delete))
                        Error = ObjetTxt.ErrorQueryDelete;
                }
                else if (Convert.ToInt32(dR[0]) == 1)
                {
                    if (0 == (int)ObjetQuery.AbmPatientSocialWork(oSw, classQuery.eAbm.Update))
                        Error = ObjetTxt.ErrorQueryUpdate;
                }
                else
                {
                    // Nada. Lo deja como esta.
                }

                if(Error != null)
                    MessageBox.Show("No se pudo realizar la accion.\nN Afiliado " + oSw.AffiliateNumber , Error);
            }
        }

        // OK - 18/02/07
        private void DgvSocialWorksList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Select = 0;
            if (dgvSocialWorksList.RowCount >= 0)
            {
                Select = e.RowIndex >= 0 ? e.RowIndex : Select;
                Select = dgvParentList.RowCount == 1 ? 0 : Select;

                IdPatientSocialWorkSelected = Convert.ToInt32(dgvSocialWorksList.Rows[Select].Cells[0].Value);
                txtAffiliateNumber.Text = Convert.ToString(dgvSocialWorksList.Rows[Select].Cells[1].Value);
                classControlComboBoxes.IndexCombos(cmbSocialWork, Convert.ToInt32(dgvSocialWorksList.Rows[Select].Cells[2].Value));
            }
        }

        /// <summary>
        /// Limpia formulario.
        /// OK - 18/03/06
        /// </summary>
        private void CleanSocialWork()
        {
            IdPatientSocialWorkSelected = -1;
            txtAffiliateNumber.Text = string.Empty;
            cmbSocialWork.SelectedIndex = -1;
        }

        /// <summary>
        /// Inicializa campos de Obra Social.
        /// OK - 18/03/02
        /// </summary>
        private void InitSocialWork()
        {
            dtViewPatientSocialWork = new DataTable("ViewPatientSocialWork");
            dtViewPatientSocialWork.Columns.Add(new DataColumn("IdPatientSocialWork", typeof(Int32)));
            dtViewPatientSocialWork.Columns.Add(new DataColumn("AffiliateNumber", typeof(string)));
            dtViewPatientSocialWork.Columns.Add(new DataColumn("IdSocialWork", typeof(Int32)));

            dtTempPatientSocialWork = new DataTable("TempPatientSocialWork");
            dtTempPatientSocialWork.Columns.Add(new DataColumn("Abm", typeof(Int32)));
            dtTempPatientSocialWork.Columns.Add(new DataColumn("IdPatientSocialWork", typeof(Int32)));
            dtTempPatientSocialWork.Columns.Add(new DataColumn("AffiliateNumber", typeof(string)));
            dtTempPatientSocialWork.Columns.Add(new DataColumn("IdSocialWork", typeof(Int32)));

            dtQuerySocialWorks = new DataTable();
            if ((bool)ObjetQuery.AbmSocialWork(new classSocialWork(), classQuery.eAbm.LoadCmb))
                dtQuerySocialWorks = ObjetQuery.Table;
            classControlComboBoxes.LoadCombo(cmbSocialWork, dtQuerySocialWorks != null, dtQuerySocialWorks);
        }

        /// <summary>
        /// Inicializa componente Obre Social.
        /// OK - 18/03/02
        /// </summary>
        private void LoadPatientSocialWork()
        {
            // Inicializa Patient-SocialWork 
            classPatientSocialWork oPw = new classPatientSocialWork();
            oPw.IdPatient = oPatient.IdPatient;

            // Trar todo los Patient-SocialWork relacionados al Patient
            List<classPatientSocialWork> lPw =
                ObjetQuery.AbmPatientSocialWork(oPw, classQuery.eAbm.SelectAll) as List<classPatientSocialWork>;

            // Recorro todos los Patient-SocialWork para cargar la Tabla
            foreach (classPatientSocialWork iPw in lPw)
            {
                dtViewPatientSocialWork.Rows.Add(new object[] { iPw.IdPatientSocialWork, iPw.AffiliateNumber, iPw.IdSocialWork });
                dtTempPatientSocialWork.Rows.Add(new object[] { 2, iPw.IdPatientSocialWork, iPw.AffiliateNumber, iPw.IdSocialWork });
            }

            tsmiSocialWorkDelete.Enabled = dtViewPatientSocialWork.Rows.Count != 0;

            GenerarGrillaPatientSocialWork();
        }

        /// <summary>
        /// Carga y muestra la grilla SocialWorks
        /// OK - 18/02/07
        /// </summary>
        private void GenerarGrillaPatientSocialWork()
        {
            if (dgvSocialWorksList.ColumnCount != 0)
                dgvSocialWorksList.Columns.Clear();
            // Cargo la Grilla
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "IdDataTable";
            colId.DataPropertyName = dtViewPatientSocialWork.Columns[0].ColumnName;
            dgvSocialWorksList.Columns.Add(colId);
            //
            DataGridViewTextBoxColumn colNumber = new DataGridViewTextBoxColumn();
            colNumber.Name = "Numero";
            colNumber.DataPropertyName = dtViewPatientSocialWork.Columns[1].ColumnName;
            dgvSocialWorksList.Columns.Add(colNumber);
            //
            DataGridViewComboBoxColumn colSocialWork = new DataGridViewComboBoxColumn();
            colSocialWork.Name = "Obra Social";
            colSocialWork.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            colSocialWork.ValueMember = "Id";
            colSocialWork.DisplayMember = "Value";
            colSocialWork.DataSource = dtQuerySocialWorks;
            colSocialWork.DataPropertyName = dtViewPatientSocialWork.Columns[2].ColumnName;
            dgvSocialWorksList.Columns.Add(colSocialWork);
            //
            //Configuracion del DataListView
            //
            dgvSocialWorksList.AutoGenerateColumns = false;
            dgvSocialWorksList.AllowUserToAddRows = false;
            dgvSocialWorksList.RowHeadersVisible = false;
            dgvSocialWorksList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvSocialWorksList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSocialWorksList.ReadOnly = true;
            dgvSocialWorksList.ScrollBars = ScrollBars.Both;
            dgvSocialWorksList.ContextMenuStrip = cmsSocialWork;
            dgvSocialWorksList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSocialWorksList.MultiSelect = false;
            dgvSocialWorksList.DataSource = dtViewPatientSocialWork;
#if (!DEBUG)
            dgvSocialWorksList.Columns[0].Visible = false;
            //dgvSocialWorksList.Columns[1].Visible = false;
            //dgvSocialWorksList.Columns[dgvSocialWorks.ColumnCount -1].Visible = false;
#endif
        }

        /// <summary>
        /// Valida los campos del Formulario.
        /// False -> Vacio - True -> Ok
        /// OK - 18/02/07
        /// </summary>
        /// <returns></returns>
        private bool ValidateFieldsSocialWorks()
        {
            bool V = false;

            if ((txtAffiliateNumber.Text.Length < 2) || (txtAffiliateNumber.Text.Length >= 19) || (txtAffiliateNumber.Text == ""))
                MessageBox.Show("El Numero de Afiliado esta vacio o supera 19 caracteres.");
            else if (cmbSocialWork.SelectedIndex == -1)
                MessageBox.Show("Obra Social Invalida.");
            else
                V = true;

            return V;
        }

        /// <summary>
        /// Habilita TabSocialWork
        /// OK - 18/02/17
        /// </summary>
        /// <param name="X">True: Habilitado - False:Inhabilitado</param>
        private void EnableSocialWork(bool X)
        {
            foreach (Control C in this.tlpSocialWork.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
            tsmiSocialWorkDelete.Enabled = X;
            dgvSocialWorksList.Enabled = true;
        }

        #endregion

        // EN CONSTRUCCION
        #region State

        /// <summary>
        /// Habilita TabFicha
        /// OK - 18/03/07
        /// </summary>
        /// <param name="X">True: Habilitado - False:Inhabilitado</param>
        private void EnableState(bool X)
        {
            foreach (Control C in this.tlpStatus.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
        }

        #endregion

        // OK - 17/11/14
        #region Validaciones

        /// <summary>
        /// OK - 17/11/11
        /// </summary>
        private void Permission()
        {
            bool isAdmin = (ObjetUtil.oProfessional.IdPermission == 1);
            tsmiParentDelete.Visible = isAdmin;
            btnPatientBlocked.Visible = isAdmin;
            btnParentNew.Visible = isAdmin;
            btnParentAccept.Visible = isAdmin;
            btnParentSearch.Visible = isAdmin;
            btnPatientLocalitation.Visible = isAdmin;
            btnParentLocalitation.Visible = isAdmin;
            cmsParent.Visible = isAdmin;
            btnSocialWorkNew.Visible = isAdmin;
            btnSocialWorkApply.Visible = isAdmin;
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
            //classValidaciones oClassValidas = new classValidaciones();
            //oClassValidas.EmailLostFocus(txtParentEmail, "La direccion de correo es invalida.");
        }

        #endregion
    }
}