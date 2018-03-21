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

        private enum Abm { Select = 0, Insert = 1, Update = 2, Delete = 3 }

        public classPatient oPatient { set; get; }
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
        //
        private int IdCountryParent;
        private int IdProvinceParent;
        private int IdCityParent;
        private int Next = 0;
        private int IdNewParent = 0;
        private int CountIdPatientParent = 0;
        private DataTable dtQueryRelationships;
        private List<classParent> ListParent;
        classParent ObjetParent = null;
        private DataTable dtView;
        private int IdPatientParentSelected;
        //
        private DataTable dtViewPatientSocialWork;
        private DataTable dtTempPatientSocialWork;
        private DataTable dtQuerySocialWorks;
        private int IdPatientSocialWorkSelected;

        #endregion

        #region Static Variables

        private static string DtView = "View";

        private static string ColAbm = "AbmPR";
        private static string ColAbmParent = "AbmP";
        private static string ColIdParent = "IdParent";
        private static string ColIdPatientParent = "IdPatientParent";
        private static string ColIdRelationship = "IdRelationship";
        private static string ColName = "Name";
        private static string ColLastName = "LastName";

        #endregion

        // OK - 18/03/20
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
                bool IsSelect = eModo != Modo.Select;

                Text = ObjetTxt.TitleFichaPatient;
                Permission();

                InitTypeDocumentPatient();
                InitParent();
                InitSocialWork();
                InitState();

                EnablePatient(IsSelect);

                btnSocialWorkNew.Enabled = eModo != Modo.Select;
                btnParentNew.Enabled = eModo != Modo.Select;
                lblSearchParent.Text = string.Empty;
                tabCarpeta.SelectedTab = tbpData;

                if (eModo == Modo.Add)
                    oPatient = new classPatient();
                else
                    LoadFrmPatient();
            }
            else
                Close();
        }

        // OK - 18/03/20
        private void tabCarpeta_Selected(object sender, TabControlEventArgs e)
        {
            // OK -  18/03/20
            if (e.TabPage == tbpResponsables)
            {
                if (CheckToSave())
                {
                    if (dtView.Rows.Count == 0)
                    {
                        classPatientParent oP = new classPatientParent();
                        oP.IdPatient = oPatient.IdPatient;
                        List<classPatientParent> ListPp = ObjetQuery.AbmPatientParent(oP, classQuery.eAbm.SelectAll) as List<classPatientParent>;
                        foreach (classPatientParent Or in ListPp)
                        {
                            classParent Op = ObjetQuery.AbmParent(new classParent(Or.IdParent), classQuery.eAbm.Select) as classParent;
                            DataRow dR = dtView.NewRow();
                            dR[ColAbm] = Abm.Select;
                            dR[ColAbmParent] = Abm.Select;
                            dR[ColIdParent] = Or.IdParent;
                            dR[ColIdPatientParent] = Or.IdPatientParent;
                            dR[ColIdRelationship] = Or.IdRelationship;
                            dR[ColName] = Op.Name;
                            dR[ColLastName] = Op.LastName;
                            dtView.Rows.Add(dR);
                        }
                        GenerarGrillaParent();
                        EnableParent(eModo != Modo.Select);
                    }
                }
                else
                    EnableParent(false);
            }

            if (e.TabPage == tbpSocialWorks)
            {
                if (CheckToSave())
                {
                    EnableSocialWork(eModo != Modo.Select);
                }
                EnableSocialWork(false);

            }

            if (e.TabPage == tbpStatus)
            {
                if (CheckToSave())
                {
                    EnableState(eModo != Modo.Select);
                }
                EnableState(false);
            }
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
        /// Mensaje previo para agregar pariete o obrasocial cuando el paciente es nuevo.
        /// OK - 18/03/06
        /// </summary>
        /// <returns>True: Ok | False: Error</returns>
        private bool CheckToSave()
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

                switch (eModo)
                {
                    case Modo.Add:
                        IdQueryStatus = (int)ObjetQuery.AbmPatient(oPatient, classQuery.eAbm.Insert);
                        if (0 != IdQueryStatus)
                        {
                            oPatient.IdPatient = IdQueryStatus;
                            //SaveParent(IdQueryStatus);
                            //SaveSocialWork(IdQueryStatus);
                            MessageBox.Show(ObjetTxt.AddPatient);
                        }
                        else
                            MessageBox.Show(ObjetTxt.ErrorQueryAdd);
                        break;

                    case Modo.Update:
                        IdQueryStatus = (int)ObjetQuery.AbmPatient(oPatient, classQuery.eAbm.Update);
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
                    MessageBox.Show(ObjetQuery.Menssage);
            }
            return (IdQueryStatus != 0);
        }

        /// <summary>
        /// Inicializa componente Typo docuemento.
        /// OK - 17/09/30
        /// </summary>
        private void InitTypeDocumentPatient()
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

        // VER - 18/03/18
        #region Metodos Parent

        // TEST - 18/03/18
        private void BtnParentNew_Click(object sender, EventArgs e)
        {
            CleanParent();
            EnableParent(true);
            IdPatientParentSelected = --IdNewParent;
            //-IdNewPatientParent;
        }

        // TEST - 18/03/18
        private void TsmiParentDelete_Click(object sender, EventArgs e)
        {
            foreach (DataRow DrView in dtView.Rows)
            {
                if (Convert.ToInt32(DrView[3]) == IdPatientParentSelected)
                { 
                    DrView[0] = Abm.Delete;
                    PaintRow(1, Color.LightGray);
                }
            }
            GenerarGrillaParent();
        }

        // no - 18/03/09
        private void BtnParentApply_Click(object sender, EventArgs e)
        {
            if (ListParent is null)
                ListParent = new List<classParent>();

            if (ValidateFieldsParent())
            {
                LoadObjectParent();
                // Nuevo
                if (IdPatientParentSelected < 0)
                {
                    ObjetParent.IdParent = IdNewParent;
                    ListParent.Add(ObjetParent);

                    dtView.Rows.Add(new object[] {
                        Abm.Insert,
                        Abm.Insert,
                        ObjetParent.IdParent,
                        0,
                        Convert.ToInt32(cmbParentRelationship.SelectedValue),
                        ObjetParent.Name,
                        ObjetParent.LastName });
                }
                else // Actualiza
                {
                    foreach (DataRow dtR in dtView.Rows)
                    {
                        foreach (classParent Parent in ListParent)
                        {
                            if (Parent.IdParent == Convert.ToInt32(dtR[ColIdParent]))
                            {
                                ObjetParent = Parent;
                                break;
                            }
                        }
  
                        if (Convert.ToInt32(dtR[ColIdPatientParent]) == IdPatientParentSelected)
                        {
                            dtR[ColAbm] = Abm.Update;
                            dtR[ColAbmParent] = Abm.Update;
                            dtR[ColIdRelationship] = Convert.ToInt32(cmbParentRelationship.SelectedValue);
                            dtR[ColName] = txtParentName.Text;
                            dtR[ColLastName] = txtParentLastName.Text;
                        }
                    }
                }
                GenerarGrillaParent();
            }
        }

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

        // no - 17/11/21
        private void BtnParentSearch_Click(object sender, EventArgs e)
        {
            //if (Next == 0)
            //{
            //    if (txtParentNumberDocument.Text != string.Empty)
            //    {
            //        classParent oP = new classParent();
            //        oP.IdTypeDocument = Convert.ToInt32(cmbTypeDocumentParent.SelectedValue);
            //        oP.NumberDocument = Convert.ToInt32(txtParentNumberDocument.Text);
            //        lParent = ObjetQuery.AbmParent(oP, classQuery.eAbm.SelectAll) as List<classParent>;
            //    }
            //}

            //if (lParent != null && lParent.Count != 0)
            //{
            //    if (Next < lParent.Count)
            //    {
            //        oParent = lParent[Next++];
            //        lblSearchParent.Text = Next.ToString() + "/" + lParent.Count.ToString() + " Encontrados";
            //        LoadFrmParent();
            //        Next = Next == lParent.Count ? 0 : Next;
            //        eModoParent = Modo.Update;
            //    }
            //}
            //else
            //    CleanParent();
        }

        // OK - 18/03/20
        private void DgvParentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvParentList.RowCount >= 0)
            {
                SelectRow = e.RowIndex >= 0 ? e.RowIndex : SelectRow;
                SelectRow = dgvParentList.RowCount == 1 ? 0 : SelectRow;

                IdPatientParentSelected = Convert.ToInt32(dgvParentList.Rows[SelectRow].Cells[3].Value);

                foreach (DataRow DrView in dtView.Rows)
                {
                    if (Convert.ToInt32(DrView[3]) == IdPatientParentSelected)
                    {
                        ObjetParent = ObjetQuery.AbmParent(new classParent(Convert.ToInt32(DrView[2])), classQuery.eAbm.Select) as classParent;
                        break;
                    }
                }

                eModoParent = ListParent != null ? Modo.Update : Modo.Add;
                ObjetParent = ObjetParent != null ? ObjetParent : new classParent();
                EnableParent(eModo != Modo.Select);
                LoadFrmParent();
            }
        }

        /// <summary>
        /// Inicializa componente ListaParientes
        /// OK - 18/03/20
        /// </summary>
        private void InitParent()
        {
            ListParent = null;

            dtView = new DataTable(DtView);
            dtView.Columns.Add(new DataColumn(ColAbm, typeof(Int32)));
            dtView.Columns.Add(new DataColumn(ColAbmParent, typeof(Int32)));
            dtView.Columns.Add(new DataColumn(ColIdParent, typeof(Int32)));
            dtView.Columns.Add(new DataColumn(ColIdPatientParent, typeof(Int32)));
            dtView.Columns.Add(new DataColumn(ColIdRelationship, typeof(Int32)));
            dtView.Columns.Add(new DataColumn(ColName, typeof(string)));
            dtView.Columns.Add(new DataColumn(ColLastName, typeof(string)));

            dtQueryRelationships = new DataTable();
            if ((bool)ObjetQuery.AbmRelationship(new classRelationship(), classQuery.eAbm.LoadCmb))
                dtQueryRelationships = ObjetQuery.Table;
            classControlComboBoxes.LoadCombo(cmbParentRelationship, dtQueryRelationships != null, dtQueryRelationships);

            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbTypeDocumentParent,
            (bool)ObjetQuery.AbmTypeDocument(new classTypeDocument(), classQuery.eAbm.LoadCmb),
            ObjetQuery.Table);
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
            DataGridViewTextBoxColumn colAbm = new DataGridViewTextBoxColumn();
            colAbm.Name = "Abm";
            colAbm.DataPropertyName = dtView.Columns[0].ColumnName;
            dgvParentList.Columns.Add(colAbm);
            //
            DataGridViewTextBoxColumn colAbmIdParent = new DataGridViewTextBoxColumn();
            colAbmIdParent.Name = "AbmParent";
            colAbmIdParent.DataPropertyName = dtView.Columns[1].ColumnName;
            dgvParentList.Columns.Add(colAbmIdParent);
            //
            DataGridViewTextBoxColumn colIdParent = new DataGridViewTextBoxColumn();
            colIdParent.Name = "IdParent";
            colIdParent.DataPropertyName = dtView.Columns[2].ColumnName;
            dgvParentList.Columns.Add(colIdParent);
            //
            DataGridViewTextBoxColumn colIdPatientParent = new DataGridViewTextBoxColumn();
            colIdPatientParent.Name = "IdParentPatient";
            colIdPatientParent.DataPropertyName = dtView.Columns[3].ColumnName;
            dgvParentList.Columns.Add(colIdPatientParent);
            //
            DataGridViewComboBoxColumn colRelationship = new DataGridViewComboBoxColumn();
            colRelationship.Name = "Relacion";
            colRelationship.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            colRelationship.ValueMember = "Id";
            colRelationship.DisplayMember = "Value";
            colRelationship.DataSource = dtQueryRelationships;
            colRelationship.DataPropertyName = dtView.Columns[4].ColumnName;
            dgvParentList.Columns.Add(colRelationship);
            //
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.Name = "Nombre";
            colName.DataPropertyName = dtView.Columns[5].ColumnName;
            dgvParentList.Columns.Add(colName);
            //
            DataGridViewTextBoxColumn colLastName = new DataGridViewTextBoxColumn();
            colLastName.Name = "Apellido";
            colLastName.DataPropertyName = dtView.Columns[6].ColumnName;
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
            dgvParentList.ContextMenuStrip = cmsParent;
            dgvParentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParentList.MultiSelect = false;
            dgvParentList.DataSource = dtView;
#if (!DEBUG)
            dgvParentList.Columns[0].Visible = false;
            dgvParentList.Columns[1].Visible = false;
            dgvParentList.Columns[2].Visible = false;
            dgvParentList.Columns[3].Visible = false;
#endif
        }


        private void PaintRow(int IndexRow, Color RowColor)
        {
            for (int C = 0; C < dgvParentList.Columns.Count; C++)
                dgvParentList.Rows[IndexRow].Cells[C].Style.BackColor = RowColor;
        }

        /// <summary>
        /// Limpia los componentes del pariente
        /// TEST - 18/03/18
        /// </summary>
        private void CleanParent()
        {
            IdCountryParent = 0;
            IdProvinceParent = 0;
            IdCityParent = 0;
            lblSearchParent.Text = string.Empty;

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
        /// TEST - 18/03/18
        /// </summary>
        /// <returns>True:Exito False:Error</returns>
        private void SaveParent(int IdPatient)
        {
            StringBuilder Error = new StringBuilder();
            int IdParet = 0;

            foreach (DataRow DrView in dtView.Rows)
            {
                // Tabla Parent
                switch ((Abm)DrView[ColAbmParent])
                {
                    case Abm.Select:
                        IdParet = Convert.ToInt32(DrView[ColIdParent]);
                        break;
                    case Abm.Insert:
                        foreach(classParent Parent in ListParent)
                        {
                            if (Parent.IdParent == Convert.ToInt32(DrView[ColIdParent]))
                            {
                                IdParet = (int)ObjetQuery.AbmParent(Parent, classQuery.eAbm.Insert);
                                if (0 == IdParet)
                                    Error.AppendLine(ObjetTxt.ErrorQueryAdd + "IdParent:" + IdParet);
                            }
                        }
                        break;
                    case Abm.Update:
                        foreach (classParent Parent in ListParent)
                        {
                            if (Parent.IdParent == Convert.ToInt32(DrView[ColIdParent]))
                            {
                                IdParet = (int)ObjetQuery.AbmParent(Parent, classQuery.eAbm.Insert);
                                if (0 == IdParet)
                                    Error.AppendLine(ObjetTxt.ErrorQueryUpdate + "IdParent:" + IdParet);
                            }
                        }
                        break;
                    case Abm.Delete:
                        foreach (classParent Parent in ListParent)
                        {
                            if (Parent.IdParent == Convert.ToInt32(DrView[ColIdParent]))
                            {
                                IdParet = (int)ObjetQuery.AbmParent(Parent, classQuery.eAbm.Insert);
                                if (0 == IdParet)
                                    Error.AppendLine(ObjetTxt.ErrorQueryDelete + "IdParent:" + IdParet);
                            }
                        }
                        break;
                    default:
                        break;
                }

                // Tabla Pariente Relacion
                classPatientParent oPp = new classPatientParent();
                oPp.IdPatientParent = Convert.ToInt32(DrView[ColIdPatientParent]);
                oPp.IdRelationship = Convert.ToInt32(DrView[ColIdRelationship]);
                oPp.IdPatient = IdPatient;
                oPp.IdParent = IdParet;

                switch ((Abm)DrView[ColAbm])
                {
                    case Abm.Select:

                        break;
                        case Abm.Insert:
                        if (0 == (int)ObjetQuery.AbmPatientParent(oPp, classQuery.eAbm.Insert))
                            Error.AppendLine(ObjetTxt.ErrorQueryAdd + "IdPatientParet: " + oPp.IdPatientParent);
                        break;
                    case Abm.Update:
                                if (0 == (int)ObjetQuery.AbmPatientParent(oPp, classQuery.eAbm.Update))
                            Error.AppendLine(ObjetTxt.ErrorQueryUpdate + "IdPatientParet: " + oPp.IdPatientParent);
                        break;
                        case Abm.Delete:
                                if (0 == (int)ObjetQuery.AbmPatientParent(oPp, classQuery.eAbm.Delete))
                            Error.AppendLine(ObjetTxt.ErrorQueryDelete + "IdPatientParet: " + oPp.IdPatientParent);
                        break;
                    default:
                        break;
                }
                    if (Error != null)
                        MessageBox.Show(Error.ToString());
            }
        }

        /// <summary>
        /// Habilita TabFicha
        /// TEST - 18/04/18
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
        /// Carga Objeto desde Formulario.
        /// TEST 18/03/18
        /// </summary>
        private void LoadObjectParent()
        {
            ObjetParent.Name = txtParentName.Text.ToUpper();
            ObjetParent.LastName = txtParentLastName.Text.ToUpper();
            ObjetParent.NumberDocument = Convert.ToInt32(txtParentNumberDocument.Text);
            ObjetParent.IdTypeDocument = Convert.ToInt32(cmbTypeDocumentParent.SelectedValue);
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
        ///VER 18/03/18
        /// </summary>
        private void LoadFrmParent()
        {
            txtParentName.Text = ObjetParent.Name.ToUpper();
            txtParentLastName.Text = ObjetParent.LastName.ToUpper();
            txtParentNumberDocument.Text = Convert.ToString(ObjetParent.NumberDocument);
            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(cmbTypeDocumentParent, ObjetParent.IdTypeDocument);
            txtParentAddress.Text = ObjetParent.Address.ToUpper();
            IdCountryParent = ObjetParent.IdLocationCountry;
            IdProvinceParent = ObjetParent.IdLocationProvince;
            IdCityParent = ObjetParent.IdLocationCity;
            txtParentPhone.Text = ObjetParent.Phone;
            txtParentAlternativePhone.Text = ObjetParent.AlternativePhone;
            txtParentEmail.Text = ObjetParent.Email.ToUpper();

            txtLocationParent.Text = frmLocation.toStringLocation(
                ObjetQuery.ConexionString, IdCountryParent, IdProvinceParent, IdCityParent);

            //foreach (classPatientParent iPp in ObjetParent)
            //{
            //    if (iPp.IdParent == ObjetParent.IdParent)
            //        libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(
            //            cmbParentRelationship, iPp.IdRelationship);
            //}
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
        private void BtnSocialWorkNew_Click(object sender, EventArgs e)
        {
            CleanSocialWork();
            EnableSocialWork(true);
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

        /// <summary>
        /// Inicializa componente Obre Social.
        /// OK - 18/03/02
        /// </summary>
        private void LoadFrmPatientSocialWork()
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

        // EN CONSTRUCCION
        #region State

        /// <summary>
        /// VER - 18/03/07 
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