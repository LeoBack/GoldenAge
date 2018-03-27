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
    public partial class FrmAbmPatient : Form
    {
        // VER - 18/03/23
        #region Atributos y Propiedades

        public enum Modo { Select = 0, Add = 1, Update = 2, Delete = 3 }

        private classQuery ObjectQuery;
        private classUtiles ObjectUtil;
        private classTextos ObjetTxt;
        // Patient
        private classPatient ObjectPatient;
        private Modo ModoPatient;
        private int IdCountry;
        private int IdProvince;
        private int IdCity;
        private bool Enable = true;

        // Parent
        private classParent ObjetParent;
        private Modo ModoParent;
        private int IdCountryParent;
        private int IdProvinceParent;
        private int IdCityParent;
        private int SelectRowParent;                // Pariente Seleccionado desde DataGridview.
        private List<classParent> ListParentSearch; // Lista de pariente resultante de la busqueda.
        private int NextIdexSearchParent = 0;       // Pariente Seleccionada si el resultado de la busque da mas de 1 coincidente.
        private List<classParent> ListParent;       // Lista de parientes que se tiene que agregar.
        private DataTable DtTempView;               // Tabla temporal de parientes.
        private int IdPatientParentSelected;
        private DataTable DtQueryRelationships;

        // SocialWorks
        private classPatientSocialWork ObjetPatientSocialWork;
        private Modo ModoSocialWork;
        private DataTable DtViewPatientSocialWork;  //
        private DataTable dtTempPatientSocialWork;
        private DataTable DtQuerySocialWorks;
        private int IdPatientSocialWorkSelected;

        // State

        #endregion

        #region Static Variables

        private static string DtView = "View";
        private static string ColIdParent = "IdParent";
        private static string ColIdPatientParent = "IdPatientParent";
        private static string ColIdRelationship = "IdRelationship";
        private static string ColName = "Name";
        private static string ColLastName = "LastName";

        #endregion

        //== # 01 =====================================================================
        // OK - 18/03/23
        #region Formulario

        /// <summary>
        /// Inicializador del formulario.
        /// OK - 18/03/23
        /// </summary>
        /// <param name="Opatient"></param>
        /// <param name="Abm"></param>
        /// <param name="Oquery"></param>
        /// <param name="Outiles"></param>
        public FrmAbmPatient(classPatient Opatient, Modo Abm, classQuery Oquery, classUtiles Outiles)
        {
            InitializeComponent();
            ObjetTxt = new classTextos();
            ObjectPatient = Opatient;
            ModoPatient = Abm;
            ObjectQuery = Oquery;
            ObjectUtil = Outiles;
        }

        /// <summary>
        /// Carga de datos inicial del formulario.
        /// OK - 18/03/23
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAbmPatient_Load(object sender, EventArgs e)
        {
            if (ObjectQuery == null | ObjectUtil == null)
            {
                MessageBox.Show("ObjectQuery o ObjectUtil is null");
                Close();
            }
            else
            {
                Text = ObjetTxt.TitleFichaPatient;
                SetFormPermission();
                InitTypeDocumentPatient();
                InitParent();
                InitSocialWork();
                InitState();
                LoadPatient();
            }
        }

        /// <summary>
        /// Evento: cuando se selecciona una Pestana.
        /// OK - 18/03/23
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabCarpeta_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == TbpPatient)
                LoadPatient();
            else if (e.TabPage == TbpParent && CheckToSavePatient())
                LoadParent();
            else if (e.TabPage == TbpSocialWorks && CheckToSavePatient())
                LoadSocialWork();
            else if (e.TabPage == tbpStatus && CheckToSavePatient())
                LoadState();
            else
                TabCarpeta.SelectedTab = TbpPatient;
        }

        /// <summary>
        /// Evento: Boton Guardar en una Pestana.
        /// OK - 18/03/23
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ObjectUtil.oProfessional.IdPermission == 1)
            {
                if (TabCarpeta.SelectedTab == TbpPatient)
                {
                    SavePatient();
                }

                if (TabCarpeta.SelectedTab == TbpParent)
                {
                    SaveParent(ObjectPatient.IdPatient);
                }

                if (TabCarpeta.SelectedTab == TbpSocialWorks)
                {
                    SaveSocialWork(ObjectPatient.IdPatient);
                }

                if (TabCarpeta.SelectedTab == tbpStatus)
                {
                    SaveState(ObjectPatient.IdPatient);
                }
            }
        }

        /// <summary>
        /// Evento: Botn Cerrar formulario.
        /// OK - 18/03/23
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClosed_Click(object sender, EventArgs e) => Close();

        /// <summary>
        /// Dsiparado cuando se cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAbmPatient_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Cerrando");
        }

        #endregion

        //== # 02 =====================================================================
        // OK - 18/03/23

        #region Metodos Genericos

        /// <summary>
        /// Permisos del usuario logueado para este formulario.
        /// OK - 18/03/23
        /// </summary>
        private void SetFormPermission()
        {
            bool isAdmin = (ObjectUtil.oProfessional.IdPermission == 1);
            TsmiParentDelete.Visible = isAdmin;
            btnPatientBlocked.Visible = isAdmin;
            btnParentNew.Visible = isAdmin;
            btnParentSearch.Visible = isAdmin;
            btnPatientLocalitation.Visible = isAdmin;
            btnParentLocalitation.Visible = isAdmin;
            CmsParent.Visible = isAdmin;
            btnSocialWorkNew.Visible = isAdmin;
        }

        /// <summary>
        /// Pinta la fila de la grilla de color.
        /// OK - 18/03/22
        /// </summary>
        /// <param name="Dgv"></param>
        /// <param name="IndexRow"></param>
        /// <param name="RowColor"></param>
        private void PaintRow(DataGridView Dgv, int IndexRow, Color RowColor)
        {
            for (int C = 0; C < Dgv.Columns.Count; C++)
                Dgv.Rows[IndexRow].Cells[C].Style.BackColor = RowColor;
        }

        #endregion

        //== # 03 =====================================================================
        // VER - 18/03/23 - Ver metodo Save

        #region Metodos Patient

        /// <summary>
        /// Inicializa componente Typo docuemento.
        /// OK - 18/03/23
        /// </summary>
        private void InitTypeDocumentPatient()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbTypeDocumentPatient,
            (bool)ObjectQuery.AbmTypeDocument(new classTypeDocument(), classQuery.eAbm.LoadCmb),
            ObjectQuery.Table);
        }

        /// <summary>
        /// Mostrar en formulario los datos del paciente.
        /// OK - 18/03/23
        /// </summary>
        private void LoadPatient()
        {
            EnablePatient(ModoPatient != Modo.Select);   // abm = Select > False (form disable) 
            BtnSave.Visible = ModoPatient != Modo.Select;

            if (ModoPatient == Modo.Add)
                ObjectPatient = new classPatient();
            else
                LoadFrmPatient();
        }

        /// <summary>
        /// Mensaje previo para agregar pariete o obrasocial cuando el paciente es nuevo.
        /// OK - 18/03/06
        /// </summary>
        /// <returns>True: Ok | False: Error</returns>
        private bool CheckToSavePatient()
        {
            bool Ok = true;

            if (ModoPatient == Modo.Add)
            {
                if (MessageBox.Show("Es necesario guardar el paciente actual antes de continuar.\n¿Guardar paciente actual?"
                , "Atencion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Ok = SavePatient();
                    ModoPatient = (Ok == true) ? Modo.Select : Modo.Add;
                    EnableParent(!Ok);
                }
                else
                    Ok = false;
            }

            return Ok;
        }

        // OK - 17/11/21
        private void btnPatientBlocked_Click(object sender, EventArgs e)
        {
            if (ObjectPatient != null)
            {
                Enable = btnPatientBlocked.Text == ObjetTxt.Bloquear ? false : true;
                btnPatientBlocked.Text = btnPatientBlocked.Text == ObjetTxt.Bloquear ? ObjetTxt.Desbloquear : ObjetTxt.Bloquear;
            }
        }

        // OK - 17/09/30
        private void btnPatientLocalitation_Click(object sender, EventArgs e)
        {
            frmLocation fLocalitation = new frmLocation(ObjectQuery.ConexionString, frmLocation.eLocation.Select);
            if (DialogResult.OK == fLocalitation.ShowDialog())
            {
                txtLocationPatient.Text = fLocalitation.toStringLocation();
                IdCountry = fLocalitation.getIdCountry();
                IdProvince = fLocalitation.getIdProvince();
                IdCity = fLocalitation.getIdCity();
            }
        }

        /// <summary>
        /// ABM En base de datos Paciente.
        /// OK - 18/03/07
        /// </summary>
        /// <returns>True:Exito False:Error</returns>
        private bool SavePatient()
        {
            int IdQueryStatus = 0;
            if (ValidateFieldsPatient())
            {
                LoadObjectPatient();

                switch (ModoPatient)
                {
                    case Modo.Add:
                        IdQueryStatus = (int)ObjectQuery.AbmPatient(ObjectPatient, classQuery.eAbm.Insert);
                        if (0 != IdQueryStatus)
                        {
                            ObjectPatient.IdPatient = IdQueryStatus;
                            //SaveParent(IdQueryStatus);
                            //SaveSocialWork(IdQueryStatus);
                            MessageBox.Show(ObjetTxt.AddPatient);
                        }
                        else
                            MessageBox.Show(ObjetTxt.ErrorQueryAdd);
                        break;

                    case Modo.Update:
                        IdQueryStatus = (int)ObjectQuery.AbmPatient(ObjectPatient, classQuery.eAbm.Update);
                        if (0 != IdQueryStatus)
                        {
                            //SaveParent(IdQueryStatus);
                            //SaveSocialWork(IdQueryStatus);
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
                    MessageBox.Show(ObjectQuery.Menssage);
            }
            return (IdQueryStatus != 0);
        }

        /// <summary>
        /// Cargo objeto Pariente.
        /// OK - 17/09/30
        /// </summary>
        private void LoadObjectPatient()
        {
            ObjectPatient.Name = txtName.Text.ToUpper();
            ObjectPatient.LastName = txtLastName.Text.ToUpper();
            ObjectPatient.Birthdate = dtpBirthdate.Value;
            ObjectPatient.IdTypeDocument = Convert.ToInt32(cmbTypeDocumentPatient.SelectedValue);
            ObjectPatient.NumberDocument = Convert.ToInt32(txtNumberDocument.Text);
            ObjectPatient.Sex = rbtMale.Checked;
            ObjectPatient.IdLocationCountry = IdCountry;
            ObjectPatient.IdLocationProvince = IdProvince;
            ObjectPatient.IdLocationCity = IdCity;
            ObjectPatient.Address = txtAddress.Text.ToUpper();
            ObjectPatient.Phone = txtPhone.Text;
            ObjectPatient.Visible = Enable;


            ObjectPatient.DateAdmission = dtpDate.Value;
            ObjectPatient.EgressDate = DateTime.Now;
            ObjectPatient.ReasonExit = txtReason.Text.ToUpper();
        }

        /// <summary>
        /// Carga los elementos de formulario desde objeto.
        /// OK - 17/09/30
        /// </summary>
        private void LoadFrmPatient()
        {
            txtName.Text = ObjectPatient.Name.ToUpper();
            txtLastName.Text = ObjectPatient.LastName.ToUpper();
            dtpBirthdate.Value = ObjectPatient.Birthdate;
            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(cmbTypeDocumentPatient, ObjectPatient.IdTypeDocument);
            txtNumberDocument.Text = Convert.ToString(ObjectPatient.NumberDocument);
            rbtMale.Checked = ObjectPatient.Sex;
            rbtFemale.Checked = !ObjectPatient.Sex;
            IdCountry = ObjectPatient.IdLocationCountry;
            IdProvince = ObjectPatient.IdLocationProvince;
            IdCity = ObjectPatient.IdLocationCity;
            txtAddress.Text = ObjectPatient.Address.ToUpper();
            txtPhone.Text = ObjectPatient.Phone;
            Enable = ObjectPatient.Visible;
            txtYearOld.Text = Convert.ToString(ObjectPatient.YearsOld());

            txtLocationPatient.Text = frmLocation.toStringLocation(
                ObjectQuery.ConexionString, IdCountry, IdProvince, IdCity);

            if (Enable)
                btnPatientBlocked.Text = ObjetTxt.Bloquear;
            else
                btnPatientBlocked.Text = ObjetTxt.Desbloquear;

            dtpDate.Value = ObjectPatient.DateAdmission;
            //dtpEgressDate.Value = oPatient.EgressDate;
            txtReason.Text = ObjectPatient.ReasonExit.ToUpper();
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
            foreach (Control C in this.TlpPatient.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
        }

        #endregion

        //== # 04 =====================================================================
        // EN CONSTRUCCION
        
        #region Metodos Parent

        /// <summary>
        /// Inicializa componente ListaParientes
        /// OK - 18/03/23
        /// </summary>
        private void InitParent()
        {
            ObjetParent = null;
            ListParent = null;

            DtTempView = new DataTable(DtView);
            DtTempView.Columns.Add(new DataColumn(ColIdParent, typeof(Int32)));
            DtTempView.Columns.Add(new DataColumn(ColIdPatientParent, typeof(Int32)));
            DtTempView.Columns.Add(new DataColumn(ColIdRelationship, typeof(Int32)));
            DtTempView.Columns.Add(new DataColumn(ColName, typeof(string)));
            DtTempView.Columns.Add(new DataColumn(ColLastName, typeof(string)));

            DtQueryRelationships = new DataTable();
            if ((bool)ObjectQuery.AbmRelationship(new classRelationship(), classQuery.eAbm.LoadCmb))
                DtQueryRelationships = ObjectQuery.Table;
            classControlComboBoxes.LoadCombo(cmbParentRelationship, DtQueryRelationships != null, DtQueryRelationships);

            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(CmbTypeDocumentParent,
            (bool)ObjectQuery.AbmTypeDocument(new classTypeDocument(), classQuery.eAbm.LoadCmb),
            ObjectQuery.Table);
        }

        /// <summary>
        /// Mostrar en formulario los datos del pariente.
        /// SELECT: OK - 18/03/26
        /// </summary>
        private void LoadParent()
        {
            EnableParent(ModoPatient != Modo.Select);
            btnParentNew.Visible = ModoPatient != Modo.Select;
            lblSearchParent.Text = string.Empty;

            if (DtTempView.Rows.Count != 0)
                DtTempView.Clear();

            classPatientParent oPp = new classPatientParent();
            oPp.IdPatient = ObjectPatient.IdPatient;
            List<classPatientParent> ListPp = ObjectQuery.AbmPatientParent(oPp, classQuery.eAbm.SelectAll) as List<classPatientParent>;
            foreach (classPatientParent Or in ListPp)
            {
                classParent Op = ObjectQuery.AbmParent(new classParent(Or.IdParent), classQuery.eAbm.Select) as classParent;
                DtTempView.Rows.Add(new object[] { Or.IdParent, Or.IdPatientParent, Or.IdRelationship, Op.Name, Op.LastName });
            }       
            GenerarGrillaParent();
        }

        /// <summary>
        /// Evento boton nuevo pariente.
        /// OK - 18/03/26
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnParentNew_Click(object sender, EventArgs e)
        {
            CleanParent();
            EnableParent(true);
            ObjetParent = new classParent();
            ModoParent = Modo.Add;
        }

        // OK - 18/03/22
        private void TsmiParentDelete_Click(object sender, EventArgs e)
        {
            int IdPatientParent = (int)ObjectQuery.AbmPatientParent(new classPatientParent(IdPatientParentSelected), classQuery.eAbm.Delete);
            if (0 == IdPatientParent)
                MessageBox.Show(ObjetTxt.ErrorQueryDelete + " IdPatientParentSelected: " + IdPatientParentSelected);
            GenerarGrillaParent();
        }

        // OK - 17/09/30
        private void BtnParentLocalitation_Click(object sender, EventArgs e)
        {
            frmLocation fLocalitation = new frmLocation(ObjectQuery.ConexionString, frmLocation.eLocation.Select);
            if (DialogResult.OK == fLocalitation.ShowDialog())
            {
                txtLocationParent.Text = fLocalitation.toStringLocation();
                IdCountryParent = fLocalitation.getIdCountry();
                IdProvinceParent = fLocalitation.getIdProvince();
                IdCityParent = fLocalitation.getIdCity();
            }
        }

        // OK - 18/03/22
        private void BtnParentSearch_Click(object sender, EventArgs e)
        {
            if (NextIdexSearchParent == 0)
            {
                if (txtParentNumberDocument.Text != string.Empty)
                {
                    classParent oP = new classParent();
                    oP.IdTypeDocument = Convert.ToInt32(CmbTypeDocumentParent.SelectedValue);
                    oP.NumberDocument = Convert.ToInt32(txtParentNumberDocument.Text);
                    ListParentSearch = ObjectQuery.AbmParent(oP, classQuery.eAbm.SelectAll) as List<classParent>;
                }
            }

            if (ListParentSearch != null && ListParentSearch.Count != 0)
            {
                if (NextIdexSearchParent < ListParentSearch.Count)
                {
                    ObjetParent = ListParentSearch[NextIdexSearchParent++];
                    lblSearchParent.Text = NextIdexSearchParent.ToString() + "/" + ListParentSearch.Count.ToString() + " Encontrados";
                    LoadFrmParent();
                    NextIdexSearchParent = NextIdexSearchParent == ListParentSearch.Count ? 0 : NextIdexSearchParent;
                    ModoParent = Modo.Update;
                }
            }
            else
                CleanParent();
        }

        // OK - 18/03/26
        private void DgvParentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvParentList.RowCount >= 0)
            {
                SelectRowParent = e.RowIndex >= 0 ? e.RowIndex : SelectRowParent;
                SelectRowParent = dgvParentList.RowCount == 1 ? 0 : SelectRowParent;

                IdPatientParentSelected = Convert.ToInt32(dgvParentList.Rows[SelectRowParent].Cells[1].Value);

                foreach (DataRow DrView in DtTempView.Rows)
                {
                    if (Convert.ToInt32(DrView[1]) == IdPatientParentSelected)
                    {
                        ObjetParent = ObjectQuery.AbmParent(new classParent(Convert.ToInt32(DrView[0])), classQuery.eAbm.Select) as classParent;
                        break;
                    }
                }

                ModoParent = ListParent != null ? Modo.Update : Modo.Add;
                ObjetParent = ObjetParent != null ? ObjetParent : new classParent();
                EnableParent(ModoPatient != Modo.Select);
                LoadFrmParent();
            }
        }

        /// <summary>
        /// Carga la Lista debuelve la cantidad de filas.
        /// OK - 18/03/20
        /// </summary>
        /// <param name="Source"></param>
        public void GenerarGrillaParent()
        {
            if (dgvParentList.ColumnCount != 0)
                dgvParentList.Columns.Clear();
            //
            // Cargo la Grilla
            //
            DataGridViewTextBoxColumn colIdParent = new DataGridViewTextBoxColumn();
            colIdParent.Name = "IdParent";
            colIdParent.DataPropertyName = DtTempView.Columns[0].ColumnName;
            dgvParentList.Columns.Add(colIdParent);
            //
            DataGridViewTextBoxColumn colIdPatientParent = new DataGridViewTextBoxColumn();
            colIdPatientParent.Name = "IdParentPatient";
            colIdPatientParent.DataPropertyName = DtTempView.Columns[1].ColumnName;
            dgvParentList.Columns.Add(colIdPatientParent);
            //
            DataGridViewComboBoxColumn colRelationship = new DataGridViewComboBoxColumn();
            colRelationship.Name = "Relacion";
            colRelationship.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            colRelationship.ValueMember = "Id";
            colRelationship.DisplayMember = "Value";
            colRelationship.DataSource = DtQueryRelationships;
            colRelationship.DataPropertyName = DtTempView.Columns[2].ColumnName;
            dgvParentList.Columns.Add(colRelationship);
            //
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.Name = "Nombre";
            colName.DataPropertyName = DtTempView.Columns[3].ColumnName;
            dgvParentList.Columns.Add(colName);
            //
            DataGridViewTextBoxColumn colLastName = new DataGridViewTextBoxColumn();
            colLastName.Name = "Apellido";
            colLastName.DataPropertyName = DtTempView.Columns[4].ColumnName;
            dgvParentList.Columns.Add(colLastName);
            //
            //Configuracion del DataListView
            //
            dgvParentList.AutoGenerateColumns = false;
            dgvParentList.AllowUserToAddRows = false;
            dgvParentList.RowHeadersVisible = false;
            dgvParentList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvParentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParentList.ReadOnly = true;
            dgvParentList.ScrollBars = ScrollBars.Both;
            dgvParentList.ContextMenuStrip = CmsParent;
            dgvParentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParentList.MultiSelect = false;
            dgvParentList.DataSource = DtTempView;
#if (!DEBUG)
            dgvParentList.Columns[0].Visible = false;
            dgvParentList.Columns[1].Visible = false;
            //dgvParentList.Columns[2].Visible = false;
            //dgvParentList.Columns[3].Visible = false;
#endif
        }

        /// <summary>
        /// Limpia los componentes del pariente
        /// OK - 18/03/22
        /// </summary>
        private void CleanParent()
        {
            IdCountryParent = 0;
            IdProvinceParent = 0;
            IdCityParent = 0;
            lblSearchParent.Text = string.Empty;

            foreach (Control ctrl in TlpParent.Controls)
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
        /// TEST - 18/03/18
        /// </summary>
        /// <returns>True:Exito False:Error</returns>
        private void SaveParent(int IdPatient)
        {
            switch (ModoParent)
            {
                case Modo.Add:
                    if (ValidateFieldsParent())
                    {
                        LoadObjectParent();
                        ObjetParent.IdParent = (int)ObjectQuery.AbmParent(ObjetParent, classQuery.eAbm.Insert);
                        if (0 == ObjetParent.IdParent)
                            MessageBox.Show(ObjetTxt.ErrorQueryAdd + " IdParent: " + ObjetParent.IdParent);
                        else
                        {
                            classPatientParent ObjectPatientParent = new classPatientParent();
                            ObjectPatientParent.IdRelationship = Convert.ToInt32(cmbParentRelationship.SelectedValue);
                            ObjectPatientParent.IdPatient = IdPatient;
                            ObjectPatientParent.IdParent = ObjetParent.IdParent;
                            int IdPatientParent = (int)ObjectQuery.AbmPatientParent(ObjectPatientParent, classQuery.eAbm.Insert);
                            if (0 == IdPatientParent)
                                MessageBox.Show(ObjetTxt.ErrorQueryAdd + " IdPatientParet: " + ObjectPatientParent.IdPatientParent);
                        }
                    }
                    break;
                case Modo.Update:
                    if (ValidateFieldsParent())
                    {
                        LoadObjectParent();
                        ObjetParent.IdParent = (int)ObjectQuery.AbmParent(ObjetParent, classQuery.eAbm.Update);
                        if (0 == ObjetParent.IdParent)
                            MessageBox.Show(ObjetTxt.ErrorQueryUpdate + " IdParent: " + ObjetParent.IdParent);
                        else
                        {
                            classPatientParent ObjectPatientParent = new classPatientParent();
                            ObjectPatientParent.IdRelationship = Convert.ToInt32(cmbParentRelationship.SelectedValue);
                            ObjectPatientParent.IdPatient = IdPatient;
                            ObjectPatientParent.IdParent = ObjetParent.IdParent;
                            int IdPatientParent = (int)ObjectQuery.AbmPatientParent(ObjectPatientParent, classQuery.eAbm.Update);
                            if (0 == IdPatientParent)
                                MessageBox.Show(ObjetTxt.ErrorQueryUpdate + " IdPatientParet: " + ObjectPatientParent.IdPatientParent);
                        }
                    }
                    break;
                default:
                    break;
            }
            LoadParent();
        }

        /// <summary>
        /// Habilita TabFicha
        /// OK - 18/03/22
        /// </summary>
        /// <param name="X">True: Habilitado - False: Inhabilitado</param>
        private void EnableParent(bool X)
        {
            foreach (Control C in this.TlpParent.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
            TsmiParentDelete.Enabled = X;
            dgvParentList.Enabled = true;
        }

        /// <summary>
        /// Carga Objeto desde Formulario.
        /// OK 18/03/22
        /// </summary>
        private void LoadObjectParent()
        {
            ObjetParent.Name = txtParentName.Text.ToUpper();
            ObjetParent.LastName = txtParentLastName.Text.ToUpper();
            ObjetParent.NumberDocument = Convert.ToInt32(txtParentNumberDocument.Text);
            ObjetParent.IdTypeDocument = Convert.ToInt32(CmbTypeDocumentParent.SelectedValue);
            ObjetParent.Address = txtParentAddress.Text.ToUpper();
            ObjetParent.IdLocationCountry = IdCountryParent;
            ObjetParent.IdLocationCity = IdCityParent;
            ObjetParent.IdLocationProvince = IdProvinceParent;
            ObjetParent.Phone = txtParentPhone.Text;
            ObjetParent.AlternativePhone = txtParentAlternativePhone.Text;
            ObjetParent.Email = txtParentEmail.Text.ToUpper();
        }

        /// <summary>
        /// Carga los elementos de formulario desde objeto.
        /// OK 18/03/22
        /// </summary>
        private void LoadFrmParent()
        {
            txtParentName.Text = ObjetParent.Name.ToUpper();
            txtParentLastName.Text = ObjetParent.LastName.ToUpper();
            txtParentNumberDocument.Text = Convert.ToString(ObjetParent.NumberDocument);
            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(CmbTypeDocumentParent, ObjetParent.IdTypeDocument);
            txtParentAddress.Text = ObjetParent.Address.ToUpper();
            IdCountryParent = ObjetParent.IdLocationCountry;
            IdProvinceParent = ObjetParent.IdLocationProvince;
            IdCityParent = ObjetParent.IdLocationCity;
            txtParentPhone.Text = ObjetParent.Phone;
            txtParentAlternativePhone.Text = ObjetParent.AlternativePhone;
            txtParentEmail.Text = ObjetParent.Email.ToUpper();

            txtLocationParent.Text = frmLocation.toStringLocation(
                ObjectQuery.ConexionString, IdCountryParent, IdProvinceParent, IdCityParent);

            List<classPatientParent> ListPp = ObjectQuery.AbmPatientParent(new classPatientParent(), classQuery.eAbm.SelectAll) as List<classPatientParent>;
            foreach (classPatientParent iPp in ListPp)
            {
                if (iPp.IdParent == ObjetParent.IdParent)
                    libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(cmbParentRelationship, iPp.IdRelationship);
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
            else if (CmbTypeDocumentParent.SelectedIndex == -1)
                MessageBox.Show("Tipo documento Invalido.");
            else
                V = true;

            return V;
        }

        #endregion

        //== # 05 =====================================================================
        // EN CONSTRUCCION

        #region Metodos SocialWork

        /// <summary>
        /// Inicializa campos de Obra Social.
        /// OK - 18/03/26
        /// </summary>
        private void InitSocialWork()
        {
            ObjetPatientSocialWork = null;

            DtViewPatientSocialWork = new DataTable("ViewPatientSocialWork");
            DtViewPatientSocialWork.Columns.Add(new DataColumn("IdPatientSocialWork", typeof(Int32)));
            DtViewPatientSocialWork.Columns.Add(new DataColumn("IdSocialWork", typeof(Int32)));
            DtViewPatientSocialWork.Columns.Add(new DataColumn("AffiliateNumber", typeof(string)));
            DtViewPatientSocialWork.Columns.Add(new DataColumn("SocialWork", typeof(string)));

            DtQuerySocialWorks = new DataTable();
            if ((bool)ObjectQuery.AbmSocialWork(new classSocialWork(), classQuery.eAbm.LoadCmb))
                DtQuerySocialWorks = ObjectQuery.Table;
            classControlComboBoxes.LoadCombo(cmbSocialWork, DtQuerySocialWorks != null, DtQuerySocialWorks);
        }

        /// <summary>
        /// Mostrar en formulario los datos de la Obra social.
        /// VER - 18/03/23
        /// </summary>
        private void LoadSocialWork()
        {
            EnableSocialWork(ModoPatient != Modo.Select);
            btnSocialWorkNew.Visible = ModoPatient != Modo.Select;

            if (DtViewPatientSocialWork.Rows.Count != 0)
                DtViewPatientSocialWork.Clear();

            classPatientSocialWork oPp = new classPatientSocialWork();
            oPp.IdPatient = ObjectPatient.IdPatient;
            List<classPatientSocialWork> ListPp = ObjectQuery.AbmPatientSocialWork(oPp, classQuery.eAbm.SelectAll) as List<classPatientSocialWork>;
            foreach (classPatientSocialWork Or in ListPp)
            {
                classSocialWork Op = ObjectQuery.AbmSocialWork(new classSocialWork(Or.IdSocialWork), classQuery.eAbm.Select) as classSocialWork;
                DtViewPatientSocialWork.Rows.Add(new object[] { Or.IdPatientSocialWork, Or.IdSocialWork, Or.AffiliateNumber, Op.Name });
            }
            GenerarGrillaParent();
        }

        // OK - 18/03/26
        private void BtnSocialWorkNew_Click(object sender, EventArgs e)
        {
            CleanSocialWork();
            EnableSocialWork(true);
            ObjetPatientSocialWork = new classPatientSocialWork();
            ModoSocialWork = Modo.Add;
        }

        // OK - 18/03/02
        private void TsmiSocialWorkDelete_Click(object sender, EventArgs e)
        {
            // Lo borra de la Tabla Vista
            DataRow rDelete = DtViewPatientSocialWork.NewRow();
            foreach (DataRow dRv in DtViewPatientSocialWork.Rows)
            {
                if (Convert.ToInt32(dRv[0]) == IdPatientSocialWorkSelected)
                    rDelete = dRv;
            }
            DtViewPatientSocialWork.Rows.Remove(rDelete);

            // Actualiza la Tabla Temporal con la fila al Id 0 para eliminar
            foreach (DataRow dRt in dtTempPatientSocialWork.Rows)
            {
                if(Convert.ToInt32(dRt[1]) == IdPatientSocialWorkSelected)
                    dRt[0] = 0;
            }

            GenerarGrillaPatientSocialWork();
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
            colId.DataPropertyName = DtViewPatientSocialWork.Columns[0].ColumnName;
            dgvSocialWorksList.Columns.Add(colId);
            //
            DataGridViewTextBoxColumn colNumber = new DataGridViewTextBoxColumn();
            colNumber.Name = "Numero";
            colNumber.DataPropertyName = DtViewPatientSocialWork.Columns[1].ColumnName;
            dgvSocialWorksList.Columns.Add(colNumber);
            //
            DataGridViewComboBoxColumn colSocialWork = new DataGridViewComboBoxColumn();
            colSocialWork.Name = "Obra Social";
            colSocialWork.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            colSocialWork.ValueMember = "Id";
            colSocialWork.DisplayMember = "Value";
            colSocialWork.DataSource = DtQuerySocialWorks;
            colSocialWork.DataPropertyName = DtViewPatientSocialWork.Columns[2].ColumnName;
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
            dgvSocialWorksList.ContextMenuStrip = CmsSocialWork;
            dgvSocialWorksList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSocialWorksList.MultiSelect = false;
            dgvSocialWorksList.DataSource = DtViewPatientSocialWork;
#if (!DEBUG)
            dgvSocialWorksList.Columns[0].Visible = false;
            //dgvSocialWorksList.Columns[1].Visible = false;
            //dgvSocialWorksList.Columns[dgvSocialWorks.ColumnCount -1].Visible = false;
#endif
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
        /// Actualiza en BD -> SocialWork.
        /// OK - 18/02/08
        /// -1 Insert | 0 Delete | +1 Update
        /// </summary>
        /// <returns>True: Exito | False: Error</returns>
        private void SaveSocialWork(int IdPatient)
        {
            //if (ValidateFieldsSocialWorks())
            //{
            //    // Agrega
            //    if (IdPatientSocialWorkSelected == -1)
            //    {
            //        dtViewPatientSocialWork.Rows.Add(new object[] { IdPatientSocialWorkSelected, txtAffiliateNumber.Text, Convert.ToInt32(cmbSocialWork.SelectedValue) });
            //        dtTempPatientSocialWork.Rows.Add(new object[] { -1, IdPatientSocialWorkSelected, txtAffiliateNumber.Text, Convert.ToInt32(cmbSocialWork.SelectedValue) });
            //    }
            //    // Elimina
            //    else if (IdPatientSocialWorkSelected == 0)
            //    {
            //        // Ver evento SaveSocialWork. 
            //    }
            //    // Actualiza
            //    else
            //    {
            //        foreach (DataRow dtR in dtViewPatientSocialWork.Rows)
            //        {
            //            if (Convert.ToInt32(dtR[0]) == IdPatientSocialWorkSelected)
            //            {
            //                dtR[1] = txtAffiliateNumber.Text;
            //                dtR[2] = Convert.ToInt32(cmbSocialWork.SelectedValue);
            //            }
            //        }
            //        foreach (DataRow dtR in dtTempPatientSocialWork.Rows)
            //        {
            //            if (Convert.ToInt32(dtR[1]) == IdPatientSocialWorkSelected)
            //            {
            //                dtR[0] = 1;
            //                dtR[2] = txtAffiliateNumber.Text;
            //                dtR[3] = Convert.ToInt32(cmbSocialWork.SelectedValue);
            //            }
            //        }
            //    }
            //    GenerarGrillaPatientSocialWork();
            //}
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
                    if (0 == (int)ObjectQuery.AbmPatientSocialWork(oSw, classQuery.eAbm.Insert))
                        Error = ObjetTxt.ErrorQueryAdd;
                }
                else if (Convert.ToInt32(dR[0]) == 0)
                {
                    if (0 == (int)ObjectQuery.AbmPatientSocialWork(oSw, classQuery.eAbm.Delete))
                        Error = ObjetTxt.ErrorQueryDelete;
                }
                else if (Convert.ToInt32(dR[0]) == 1)
                {
                    if (0 == (int)ObjectQuery.AbmPatientSocialWork(oSw, classQuery.eAbm.Update))
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

        /// <summary>
        /// Habilita TabSocialWork
        /// OK - 18/02/17
        /// </summary>
        /// <param name="X">True: Habilitado - False:Inhabilitado</param>
        private void EnableSocialWork(bool X)
        {
            foreach (Control C in this.TlpSocialWork.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
            TsmiSocialWorkDelete.Enabled = X;
            dgvSocialWorksList.Enabled = true;
        }

        /// <summary>
        /// Inicializa componente Obre Social.
        /// OK - 18/03/02
        /// </summary>
        private void LoadFrmPatientSocialWork()
        {
            // Inicializa Patient-SocialWork 
            classPatientSocialWork oPw = new classPatientSocialWork();
            oPw.IdPatient = ObjectPatient.IdPatient;

            // Trar todo los Patient-SocialWork relacionados al Patient
            List<classPatientSocialWork> lPw =
                ObjectQuery.AbmPatientSocialWork(oPw, classQuery.eAbm.SelectAll) as List<classPatientSocialWork>;

            // Recorro todos los Patient-SocialWork para cargar la Tabla
            foreach (classPatientSocialWork iPw in lPw)
            {
                DtViewPatientSocialWork.Rows.Add(new object[] { iPw.IdPatientSocialWork, iPw.AffiliateNumber, iPw.IdSocialWork });
                dtTempPatientSocialWork.Rows.Add(new object[] { 2, iPw.IdPatientSocialWork, iPw.AffiliateNumber, iPw.IdSocialWork });
            }

            TsmiSocialWorkDelete.Enabled = DtViewPatientSocialWork.Rows.Count != 0;

            GenerarGrillaPatientSocialWork();
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

        #endregion

        //== # 06 =====================================================================
        // EN CONSTRUCCION

        #region State

        /// <summary>
        /// OK - 18/03/23
        /// </summary>
        private void InitState()
        {
            //dtViewPatientSocialWork = new DataTable("ViewPatientSocialWork");
            //dtViewPatientSocialWork.Columns.Add(new DataColumn("IdPatientSocialWork", typeof(Int32)));
            //dtViewPatientSocialWork.Columns.Add(new DataColumn("AffiliateNumber", typeof(string)));
            //dtViewPatientSocialWork.Columns.Add(new DataColumn("IdSocialWork", typeof(Int32)));

            //dtTempPatientSocialWork = new DataTable("TempPatientSocialWork");
            //dtTempPatientSocialWork.Columns.Add(new DataColumn("Abm", typeof(Int32)));
            //dtTempPatientSocialWork.Columns.Add(new DataColumn("IdPatientSocialWork", typeof(Int32)));
            //dtTempPatientSocialWork.Columns.Add(new DataColumn("AffiliateNumber", typeof(string)));
            //dtTempPatientSocialWork.Columns.Add(new DataColumn("IdSocialWork", typeof(Int32)));

            //dtQuerySocialWorks = new DataTable();
            //if ((bool)ObjetQuery.AbmSocialWork(new classSocialWork(), classQuery.eAbm.LoadCmb))
            //    dtQuerySocialWorks = ObjetQuery.Table;
            //classControlComboBoxes.LoadCombo(cmbSocialWork, dtQuerySocialWorks != null, dtQuerySocialWorks);
        }

        /// <summary>
        /// Mostrar en formulario los datos del Estado.
        /// VER - 18/03/23
        /// </summary>
        private void LoadState()
        {
            EnableState(ModoPatient != Modo.Select);
            btnStateNew.Visible = ModoPatient != Modo.Select;
        }

        /// <summary>
        /// Limpia formulario.
        /// VER - 18/03/07
        /// </summary>
        private void CleanState()
        {
            //IdPatientSocialWorkSelected = -1;
            //txtAffiliateNumber.Text = string.Empty;
            //cmbSocialWork.SelectedIndex = -1;
        }

        /// <summary>
        /// Actualiza en BD.
        /// VER - 18/03/07
        /// -1 Insert | 0 Delete | +1 Update
        /// </summary>
        /// <returns>True: Exito | False: Error</returns>
        private void SaveState(int IdPatient)
        {
            //string Error;
            //foreach (DataRow dR in dtTempPatientSocialWork.Rows)
            //{
            //    Error = null;
            //    classPatientSocialWork oSw = new classPatientSocialWork();
            //    oSw.IdPatientSocialWork = Convert.ToInt32(dR[1]);
            //    oSw.IdPatient = IdPatient;
            //    oSw.AffiliateNumber = Convert.ToString(dR[2]);
            //    oSw.IdSocialWork = Convert.ToInt32(dR[3]);

            //    if (Convert.ToInt32(dR[0]) == -1)
            //    {
            //        if (0 == (int)ObjetQuery.AbmPatientSocialWork(oSw, classQuery.eAbm.Insert))
            //            Error = ObjetTxt.ErrorQueryAdd;
            //    }
            //    else if (Convert.ToInt32(dR[0]) == 0)
            //    {
            //        if (0 == (int)ObjetQuery.AbmPatientSocialWork(oSw, classQuery.eAbm.Delete))
            //            Error = ObjetTxt.ErrorQueryDelete;
            //    }
            //    else if (Convert.ToInt32(dR[0]) == 1)
            //    {
            //        if (0 == (int)ObjetQuery.AbmPatientSocialWork(oSw, classQuery.eAbm.Update))
            //            Error = ObjetTxt.ErrorQueryUpdate;
            //    }
            //    else
            //    {
            //        // Nada. Lo deja como esta.
            //    }

            //    if (Error != null)
            //        MessageBox.Show("No se pudo realizar la accion.\nN Afiliado " + oSw.AffiliateNumber, Error);
            //}
        }

        /// <summary>
        /// Habilita TabFicha
        /// OK - 18/03/07
        /// </summary>
        /// <param name="X">True: Habilitado - False:Inhabilitado</param>
        private void EnableState(bool X)
        {
            foreach (Control C in this.TlpStatus.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
        }

        #endregion

        //== # 07 =====================================================================
        // OK - 17/11/14

        #region Validaciones

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