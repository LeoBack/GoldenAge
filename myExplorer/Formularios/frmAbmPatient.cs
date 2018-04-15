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
        // OK - 18/04/14
        #region Atributos y Propiedades

        public enum Modo { Select = 0, Add = 1, Update = 2, Delete = 3 }

        private classQuery ObjectQuery;
        private ClassUtiles ObjectUtil;
        private classTextos ObjetTxt;

        // Patient
        private ClassPatient ObjectPatient;
        private Modo ModoPatient;
        private int IdCountry;
        private int IdProvince;
        private int IdCity;
        private bool Enable = true;

        // Parent
        private ClassParent ObjetParent;
        private Modo ModoParent;
        private DataTable DtTempView;               // Tabla temporal de parientes.
        private DataTable DtQueryRelationships;
        private int IdPatientParentSelected;
        private int IdCountryParent;
        private int IdProvinceParent;
        private int IdCityParent;
        private int SelectRowParent;                // Pariente Seleccionado desde DataGridview.
        private List<ClassParent> ListParentSearch; // Lista de pariente resultante de la busqueda.
        private int NextIdexSearchParent = 0;       // Pariente Seleccionada si el resultado de la busque da mas de 1 coincidente.
        
        // SocialWorks
        private ClassPatientSocialWork ObjetPatientSocialWork;
        private Modo ModoSocialWork;
        private DataTable DtViewPatientSocialWork;
        private DataTable DtQuerySocialWorks;
        private int IdPatientSocialWorkSelected;

        // State
        private ClassPatientState ObjetPatientState;
        private Modo ModoPatientState;
        private DataTable DtViewPatientState;
        private DataTable DtTempState;
        private int IdPatientStateSelected;

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
        public FrmAbmPatient(ClassPatient Opatient, Modo Abm, classQuery Oquery, ClassUtiles Outiles)
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
                PatientInit();
                ParentInit();
                SocialWorkInit();
                StateInit();
                PatientLoad();
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
                PatientLoad();
            else if (e.TabPage == TbpParent && PatientCheckToSave())
                ParentLoad();
            else if (e.TabPage == TbpSocialWorks && PatientCheckToSave())
                SocialWorkLoad();
            else if (e.TabPage == TbpStatus && PatientCheckToSave())
                StateLoad();
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
                    PatientSave();
                else if (TabCarpeta.SelectedTab == TbpParent)
                    ParentSave(ObjectPatient.IdPatient);
                else if (TabCarpeta.SelectedTab == TbpSocialWorks)
                    SocialWorkSave(ObjectPatient.IdPatient);
                else if (TabCarpeta.SelectedTab == TbpStatus)
                    StateSave(ObjectPatient.IdPatient);
            }
        }

        /// <summary>
        /// Menu contextual Delete.
        /// OK - 18/04/13
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiDelete_Click(object sender, EventArgs e)
        {
            if (ObjectUtil.oProfessional.IdPermission == 1)
            {
                //if (TabCarpeta.SelectedTab == TbpPatient)
                //    PatientSave();
                if (TabCarpeta.SelectedTab == TbpParent && DgvParentList.Rows.Count != 0)
                    ParentDelete();
                else if (TabCarpeta.SelectedTab == TbpSocialWorks && DgvSocialWorksList.Rows.Count != 0)
                    SocialWorkDelete();
                else if (TabCarpeta.SelectedTab == TbpStatus && DgvStateList.Rows.Count != 0)
                    StateDelete();
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
            //MessageBox.Show("Cerrando");
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
            BtnPatientBlocked.Visible = isAdmin;
            BtnParentNew.Visible = isAdmin;
            BtnParentSearch.Visible = isAdmin;
            BtnPatientLocalitation.Visible = isAdmin;
            BtnParentLocalitation.Visible = isAdmin;
            CmsFrm.Visible = isAdmin;
            BtnSocialWorkNew.Visible = isAdmin;
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
        // OK - 18/04/09

        #region Metodos Patient

        #region Metodos

        /// <summary>
        /// Inicializa componente Typo docuemento.
        /// OK - 18/03/23
        /// </summary>
        private void PatientInit()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(CmbPatientTypeDocument,
            (bool)ObjectQuery.AbmTypeDocument(new ClassTypeDocument(), classQuery.eAbm.LoadCmb),
            ObjectQuery.Table);
        }

        /// <summary>
        /// Mostrar en formulario los datos del paciente.
        /// OK - 18/03/23
        /// </summary>
        private void PatientLoad()
        {
            PatientEnable(ModoPatient != Modo.Select);   // abm = Select > False (form disable) 
            BtnSave.Visible = ModoPatient != Modo.Select;

            if (ModoPatient == Modo.Add)
                ObjectPatient = new ClassPatient();
            else
                PatientLoadFrm();
        }

        /// <summary>
        /// Mensaje previo para agregar pariete o obrasocial cuando el paciente es nuevo.
        /// OK - 18/03/06
        /// </summary>
        /// <returns>True: Ok | False: Error</returns>
        private bool PatientCheckToSave()
        {
            bool Ok = true;

            if (ModoPatient == Modo.Add)
            {
                if (MessageBox.Show("Es necesario guardar el paciente actual antes de continuar.\n¿Guardar paciente actual?"
                , "Atencion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Ok = PatientSave();
                    ModoPatient = (Ok == true) ? Modo.Select : Modo.Add;
                    ParentEnable(!Ok);
                }
                else
                    Ok = false;
            }

            return Ok;
        }

        /// <summary>
        /// Cargo objeto Pariente.
        /// OK - 17/09/30
        /// </summary>
        private void PatientLoadObject()
        {
            ObjectPatient.Name = TxtPatientName.Text.ToUpper();
            ObjectPatient.LastName = TxtPatientLastName.Text.ToUpper();
            ObjectPatient.Birthdate = DtpPatientBirthdate.Value;
            ObjectPatient.IdTypeDocument = Convert.ToInt32(CmbPatientTypeDocument.SelectedValue);
            ObjectPatient.NumberDocument = Convert.ToInt32(TxtPatientNumberDocument.Text);
            ObjectPatient.Sex = RbtPatientMale.Checked;
            ObjectPatient.IdLocationCountry = IdCountry;
            ObjectPatient.IdLocationProvince = IdProvince;
            ObjectPatient.IdLocationCity = IdCity;
            ObjectPatient.Address = TxtPatientAddress.Text.ToUpper();
            ObjectPatient.Phone = TxtPatientPhone.Text;
            ObjectPatient.Visible = Enable;
        }

        /// <summary>
        /// Carga los elementos de formulario desde objeto.
        /// OK - 17/09/30
        /// </summary>
        private void PatientLoadFrm()
        {
            TxtPatientName.Text = ObjectPatient.Name.ToUpper();
            TxtPatientLastName.Text = ObjectPatient.LastName.ToUpper();
            DtpPatientBirthdate.Value = ObjectPatient.Birthdate;
            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(CmbPatientTypeDocument, ObjectPatient.IdTypeDocument);
            TxtPatientNumberDocument.Text = Convert.ToString(ObjectPatient.NumberDocument);
            RbtPatientMale.Checked = ObjectPatient.Sex;
            RbtPatientFemale.Checked = !ObjectPatient.Sex;
            IdCountry = ObjectPatient.IdLocationCountry;
            IdProvince = ObjectPatient.IdLocationProvince;
            IdCity = ObjectPatient.IdLocationCity;
            TxtPatientAddress.Text = ObjectPatient.Address.ToUpper();
            TxtPatientPhone.Text = ObjectPatient.Phone;
            Enable = ObjectPatient.Visible;
            TxtPatientYearOld.Text = Convert.ToString(ObjectPatient.YearsOld());

            TxtPatientLocationPatient.Text = frmLocation.toStringLocation(
                ObjectQuery.ConexionString, IdCountry, IdProvince, IdCity);

            if (Enable)
                BtnPatientBlocked.Text = ObjetTxt.Bloquear;
            else
                BtnPatientBlocked.Text = ObjetTxt.Desbloquear;
        }

        /// <summary>
        /// Valida los campos del Formulario.
        /// False -> Vacio - True -> Ok
        /// OK - 17/09/30
        /// </summary>
        /// <returns></returns>
        private bool PatientValidateFields()
        {
            bool V = false;

            if (TxtPatientName.Text.Length >= 50 || (TxtPatientName.Text == ""))
                MessageBox.Show("El Nombre esta vacio o supera los 50 caracteres");
            else if (TxtPatientLastName.Text.Length >= 50 || (TxtPatientLastName.Text == ""))
                MessageBox.Show("El Apellido esta vacio o supera los 50 caracteres");
            else if (TxtPatientPhone.Text.Length >= 20)
                MessageBox.Show("El Numero de Telefono supera los 20 caracteres");
            else if (TxtPatientAddress.Text.Length >= 50)
                MessageBox.Show("La Direccion esta vacia o supera los 50 caracteres");
            else if ((IdCountry == 0) || (IdProvince == 0) || (IdCity == 0))
                MessageBox.Show("El Campo Localidad esta vacío o es Erroneo");
            else if (TxtStateReason.Text.Length >= 50)
                MessageBox.Show("El Motivo de Alta Debe tener como minimo 8 caracteres.");
            else if (CmbPatientTypeDocument.SelectedIndex == -1)
                MessageBox.Show("Tipo Docuemento Invalido.");
            else if ((TxtPatientNumberDocument.Text.Length > 9) || (TxtPatientNumberDocument.Text == ""))
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
        private void PatientEnable(bool X)
        {
            foreach (Control C in this.TlpPatient.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
        }

        /// <summary>
        /// ABM En base de datos Paciente.
        /// OK - 18/03/07
        /// </summary>
        /// <returns>True:Exito False:Error</returns>
        private bool PatientSave()
        {
            int IdQueryStatus = 0;
            if (PatientValidateFields())
            {
                PatientLoadObject();

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
        /// Elimina de BD.
        /// OK - 18/04/13
        /// </summary>
        private void PatientDelete()
        {

        }

        #endregion

        // OK - 17/11/21
        private void btnPatientBlocked_Click(object sender, EventArgs e)
        {
            if (ObjectPatient != null)
            {
                Enable = BtnPatientBlocked.Text == ObjetTxt.Bloquear ? false : true;
                BtnPatientBlocked.Text = BtnPatientBlocked.Text == ObjetTxt.Bloquear ? ObjetTxt.Desbloquear : ObjetTxt.Bloquear;
            }
        }

        // OK - 17/09/30
        private void btnPatientLocalitation_Click(object sender, EventArgs e)
        {
            frmLocation fLocalitation = new frmLocation(ObjectQuery.ConexionString, frmLocation.eLocation.Select);
            if (DialogResult.OK == fLocalitation.ShowDialog())
            {
                TxtPatientLocationPatient.Text = fLocalitation.toStringLocation();
                IdCountry = fLocalitation.getIdCountry();
                IdProvince = fLocalitation.getIdProvince();
                IdCity = fLocalitation.getIdCity();
            }
        }

        #endregion

        //== # 04 =====================================================================
        // OK - 18/04/14

        #region Metodos Parent

        #region Metodos

        /// <summary>
        /// Inicializa componente ListaParientes
        /// OK - 18/03/23
        /// </summary>
        private void ParentInit()
        {
            ObjetParent = null;

            DtTempView = new DataTable("ViewParent");
            DtTempView.Columns.Add(new DataColumn("IdParent", typeof(Int32)));
            DtTempView.Columns.Add(new DataColumn("IdPatientParent", typeof(Int32)));
            DtTempView.Columns.Add(new DataColumn("IdRelationship", typeof(Int32)));
            DtTempView.Columns.Add(new DataColumn("Name", typeof(string)));
            DtTempView.Columns.Add(new DataColumn("LastName", typeof(string)));

            DtQueryRelationships = new DataTable();
            if ((bool)ObjectQuery.AbmRelationship(new ClassRelationship(), classQuery.eAbm.LoadCmb))
                DtQueryRelationships = ObjectQuery.Table;
            classControlComboBoxes.LoadCombo(CmbParentRelationship, DtQueryRelationships != null, DtQueryRelationships);

            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(CmbParentTypeDocument,
            (bool)ObjectQuery.AbmTypeDocument(new ClassTypeDocument(), classQuery.eAbm.LoadCmb),
            ObjectQuery.Table);
        }

        /// <summary>
        /// Mostrar en formulario los datos del pariente.
        /// OK - 18/04/14
        /// </summary>
        private void ParentLoad()
        {
            ParentEnable(false);
            BtnParentNew.Visible = ModoPatient != Modo.Select;
            CmsFrm.Enabled = ModoPatient != Modo.Select;
            LblParentSearch.Text = string.Empty;
            ParentGenerarGrilla();
        }

        /// <summary>
        /// Carga la Lista debuelve la cantidad de filas.
        /// OK - 18/04/09
        /// </summary>
        /// <param name="Source"></param>
        public void ParentGenerarGrilla()
        {
            if (DtTempView.Rows.Count != 0)
                DtTempView.Clear();
            //
            ClassPatientParent oPp = new ClassPatientParent();
            oPp.IdPatient = ObjectPatient.IdPatient;
            List<ClassPatientParent> ListPp = ObjectQuery.AbmPatientParent(oPp, classQuery.eAbm.SelectAll) as List<ClassPatientParent>;
            if (ListPp != null)
                foreach (ClassPatientParent Or in ListPp)
                {
                    ClassParent Op = ObjectQuery.AbmParent(new ClassParent(Or.IdParent), classQuery.eAbm.Select) as ClassParent;
                    DtTempView.Rows.Add(new object[] { Or.IdParent, Or.IdPatientParent, Or.IdRelationship, Op.Name, Op.LastName });
                }
            //
            if (DgvParentList.ColumnCount != 0)
                DgvParentList.Columns.Clear();
            //
            // Cargo la Grilla
            //
            DataGridViewTextBoxColumn colIdParent = new DataGridViewTextBoxColumn();
            colIdParent.Name = "IdParent";
            colIdParent.DataPropertyName = DtTempView.Columns[0].ColumnName;
            DgvParentList.Columns.Add(colIdParent);
            //
            DataGridViewTextBoxColumn colIdPatientParent = new DataGridViewTextBoxColumn();
            colIdPatientParent.Name = "IdParentPatient";
            colIdPatientParent.DataPropertyName = DtTempView.Columns[1].ColumnName;
            DgvParentList.Columns.Add(colIdPatientParent);
            //
            DataGridViewComboBoxColumn colRelationship = new DataGridViewComboBoxColumn();
            colRelationship.Name = "Relacion";
            colRelationship.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            colRelationship.ValueMember = "Id";
            colRelationship.DisplayMember = "Value";
            colRelationship.DataSource = DtQueryRelationships;
            colRelationship.DataPropertyName = DtTempView.Columns[2].ColumnName;
            DgvParentList.Columns.Add(colRelationship);
            //
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.Name = "Nombre";
            colName.DataPropertyName = DtTempView.Columns[3].ColumnName;
            DgvParentList.Columns.Add(colName);
            //
            DataGridViewTextBoxColumn colLastName = new DataGridViewTextBoxColumn();
            colLastName.Name = "Apellido";
            colLastName.DataPropertyName = DtTempView.Columns[4].ColumnName;
            DgvParentList.Columns.Add(colLastName);
            //
            //Configuracion del DataListView
            //
            DgvParentList.AutoGenerateColumns = false;
            DgvParentList.AllowUserToAddRows = false;
            DgvParentList.RowHeadersVisible = false;
            DgvParentList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DgvParentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvParentList.ReadOnly = true;
            DgvParentList.ScrollBars = ScrollBars.Both;
            DgvParentList.ContextMenuStrip = CmsFrm; //CmsParent;
            DgvParentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvParentList.MultiSelect = false;
            DgvParentList.DataSource = DtTempView;
#if (!DEBUG)
            DgvParentList.Columns[0].Visible = false;
            DgvParentList.Columns[1].Visible = false;
            //DgvParentList.Columns[2].Visible = false;
            //DgvParentList.Columns[3].Visible = false;
#endif
        }

        /// <summary>
        /// Limpia los componentes del pariente
        /// OK - 18/03/22
        /// </summary>
        private void ParentClean()
        {
            IdCountryParent = 0;
            IdProvinceParent = 0;
            IdCityParent = 0;
            LblParentSearch.Text = string.Empty;

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
        /// Habilita TabFicha
        /// OK - 18/03/22
        /// </summary>
        /// <param name="X">True: Habilitado - False: Inhabilitado</param>
        private void ParentEnable(bool X)
        {
            foreach (Control C in this.TlpParent.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
            DgvParentList.Enabled = true;
            BtnParentNew.Enabled = true;
        }

        /// <summary>
        /// Carga Objeto desde Formulario.
        /// OK 18/03/22
        /// </summary>
        private void ParentLoadObject()
        {
            ObjetParent.Name = TxtParentName.Text.ToUpper();
            ObjetParent.LastName = TxtParentLastName.Text.ToUpper();
            ObjetParent.NumberDocument = Convert.ToInt32(TxtParentNumberDocument.Text);
            ObjetParent.IdTypeDocument = Convert.ToInt32(CmbParentTypeDocument.SelectedValue);
            ObjetParent.Address = TxtParentAddress.Text.ToUpper();
            ObjetParent.IdLocationCountry = IdCountryParent;
            ObjetParent.IdLocationCity = IdCityParent;
            ObjetParent.IdLocationProvince = IdProvinceParent;
            ObjetParent.Phone = TxtParentPhone.Text;
            ObjetParent.AlternativePhone = TxtParentAlternativePhone.Text;
            ObjetParent.Email = TxtParentEmail.Text.ToUpper();
        }

        /// <summary>
        /// Carga los elementos de formulario desde objeto.
        /// OK 18/03/22
        /// </summary>
        private void ParentLoadFrm()
        {
            TxtParentName.Text = ObjetParent.Name.ToUpper();
            TxtParentLastName.Text = ObjetParent.LastName.ToUpper();
            TxtParentNumberDocument.Text = Convert.ToString(ObjetParent.NumberDocument);
            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(CmbParentTypeDocument, ObjetParent.IdTypeDocument);
            TxtParentAddress.Text = ObjetParent.Address.ToUpper();
            IdCountryParent = ObjetParent.IdLocationCountry;
            IdProvinceParent = ObjetParent.IdLocationProvince;
            IdCityParent = ObjetParent.IdLocationCity;
            TxtParentPhone.Text = ObjetParent.Phone;
            TxtParentAlternativePhone.Text = ObjetParent.AlternativePhone;
            TxtParentEmail.Text = ObjetParent.Email.ToUpper();

            TxtParentLocation.Text = frmLocation.toStringLocation(
                ObjectQuery.ConexionString, IdCountryParent, IdProvinceParent, IdCityParent);

            List<ClassPatientParent> ListPp = ObjectQuery.AbmPatientParent(new ClassPatientParent(), classQuery.eAbm.SelectAll) as List<ClassPatientParent>;
            foreach (ClassPatientParent iPp in ListPp)
            {
                if (iPp.IdParent == ObjetParent.IdParent)
                    libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(CmbParentRelationship, iPp.IdRelationship);
            }
        }

        /// <summary>
        /// Valida los campos del Formulario.
        /// False -> Vacio - True -> Ok
        /// OK 17/09/30
        /// </summary>
        /// <returns></returns>
        private bool ParentValidateFields()
        {
            bool V = false;
            classValidaciones oClassValidas = new classValidaciones();
            if (TxtParentName.Text.Length >= 50 || (TxtParentName.Text == ""))
                MessageBox.Show("El Nombre esta vacio o supera los 50 caracteres");
            else if (TxtParentLastName.Text.Length >= 50 || (TxtParentLastName.Text == ""))
                MessageBox.Show("El Apellido esta vacio o supera los 50 caracteres");
            //else if ((txtParentNumberDocument.Text.Length > 9) || (txtParentNumberDocument.Text == ""))
            else if ((TxtParentNumberDocument.Text.Length > 9))
                MessageBox.Show("El Numero de Documento esta vacio o no supera los 9 caracteres.");
            //else if (txtParentAddress.Text.Length >= 50 || (txtParentAddress.Text == ""))
            else if (TxtParentAddress.Text.Length >= 50)
                MessageBox.Show("La Direccion supera los 50 caracteres");
            else if ((IdCountryParent == 0) || (IdProvinceParent == 0) || (IdCityParent == 0))
                MessageBox.Show("El Campo Localidad esta vacío o es Erroneo");
            else if (TxtParentPhone.Text.Length >= 15)
                MessageBox.Show("El Numero de Telefono supera los 20 caracteres");
            else if (TxtParentAlternativePhone.Text.Length >= 20)
                MessageBox.Show("El Numero de Telefono Alternativo supera los 15 caracteres");
            //else if (txtParentEmail.Text.Length >= 50)
            //    MessageBox.Show("El E-mail supera los 50 caracteres");
            else if (oClassValidas.VerifyEmailAddressFormat(TxtParentEmail.Text) == false)
                MessageBox.Show("Formato de Correo es: mi@correo.com.ar");
            else if (CmbParentRelationship.SelectedIndex== -1)
                MessageBox.Show("Parentesco Invalida.");
            else if (CmbParentTypeDocument.SelectedIndex == -1)
                MessageBox.Show("Tipo documento Invalido.");
            else
                V = true;

            return V;
        }

        /// <summary>
        /// ABM En base de datos Pariente.
        /// OK - 18/04/09
        /// </summary>
        /// <returns>True:Exito False:Error</returns>
        private void ParentSave(int IdPatient)
        {
            if (ParentValidateFields())
            {
                ParentLoadObject();
                switch (ModoParent)
                {
                    case Modo.Add:
                        ObjetParent.IdParent = (int)ObjectQuery.AbmParent(ObjetParent, classQuery.eAbm.Insert);
                        if (0 == ObjetParent.IdParent)
                            MessageBox.Show(ObjetTxt.ErrorQueryAdd + " IdParent: " + ObjetParent.IdParent);
                        else
                        {
                            ClassPatientParent ObjectPatientParent = new ClassPatientParent();
                            ObjectPatientParent.IdRelationship = Convert.ToInt32(CmbParentRelationship.SelectedValue);
                            ObjectPatientParent.IdPatient = IdPatient;
                            ObjectPatientParent.IdParent = ObjetParent.IdParent;
                            int IdPatientParent = (int)ObjectQuery.AbmPatientParent(ObjectPatientParent, classQuery.eAbm.Insert);
                            if (0 == IdPatientParent)
                                MessageBox.Show(ObjetTxt.ErrorQueryAdd + " IdPatientParet: " + ObjectPatientParent.IdPatientParent);
                            else
                            {
                                ParentClean();
                                ObjetParent = new ClassParent();
                                ModoParent = Modo.Add;
                            }
                        }
                        break;
                    case Modo.Update:
                        ObjetParent.IdParent = (int)ObjectQuery.AbmParent(ObjetParent, classQuery.eAbm.Update);
                        if (0 == ObjetParent.IdParent)
                            MessageBox.Show(ObjetTxt.ErrorQueryUpdate + " IdParent: " + ObjetParent.IdParent);
                        else
                        {
                            ClassPatientParent ObjectPatientParent = new ClassPatientParent();
                            ObjectPatientParent.IdPatientParent = Convert.ToInt32(DgvParentList.Rows[SelectRowParent].Cells[1].Value);
                            ObjectPatientParent.IdRelationship = Convert.ToInt32(CmbParentRelationship.SelectedValue);
                            ObjectPatientParent.IdPatient = IdPatient;
                            ObjectPatientParent.IdParent = ObjetParent.IdParent;
                            int IdPatientParent = (int)ObjectQuery.AbmPatientParent(ObjectPatientParent, classQuery.eAbm.Update);
                            if (0 == IdPatientParent)
                                MessageBox.Show(ObjetTxt.ErrorQueryUpdate + " IdPatientParet: " + ObjectPatientParent.IdPatientParent);
                        }
                        break;
                    default:
                        break;
                }
                ParentLoad();
            }
        }

        /// <summary>
        /// Elimina de BD.
        /// OK - 18/04/13
        /// </summary>
        private void ParentDelete()
        {
            int IdPatientParent = (int)ObjectQuery.AbmPatientParent(new ClassPatientParent(IdPatientParentSelected), classQuery.eAbm.Delete);
            if (0 == IdPatientParent)
                MessageBox.Show(ObjetTxt.ErrorQueryDelete + " IdPatientParentSelected: " + IdPatientParentSelected);
            ParentGenerarGrilla();
        }

        #endregion

        // OK - 18/03/26
        private void BtnParentNew_Click(object sender, EventArgs e)
        {
            ParentClean();
            ParentEnable(true);
            ObjetParent = new ClassParent();
            ModoParent = Modo.Add;
        }

        // OK - 18/04/09
        private void TsmiParentDelete_Click(object sender, EventArgs e)
        {
            ParentDelete();
        }

        // OK - 17/09/30
        private void BtnParentLocalitation_Click(object sender, EventArgs e)
        {
            frmLocation fLocalitation = new frmLocation(ObjectQuery.ConexionString, frmLocation.eLocation.Select);
            if (DialogResult.OK == fLocalitation.ShowDialog())
            {
                TxtParentLocation.Text = fLocalitation.toStringLocation();
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
                if (TxtParentNumberDocument.Text != string.Empty)
                {
                    ClassParent oP = new ClassParent();
                    oP.IdTypeDocument = Convert.ToInt32(CmbParentTypeDocument.SelectedValue);
                    oP.NumberDocument = Convert.ToInt32(TxtParentNumberDocument.Text);
                    ListParentSearch = ObjectQuery.AbmParent(oP, classQuery.eAbm.SelectAll) as List<ClassParent>;
                }
            }

            if (ListParentSearch != null && ListParentSearch.Count != 0)
            {
                if (NextIdexSearchParent < ListParentSearch.Count)
                {
                    ObjetParent = ListParentSearch[NextIdexSearchParent++];
                    LblParentSearch.Text = NextIdexSearchParent.ToString() + "/" + ListParentSearch.Count.ToString() + " Encontrados";
                    ParentLoadFrm();
                    NextIdexSearchParent = NextIdexSearchParent == ListParentSearch.Count ? 0 : NextIdexSearchParent;
                    ModoParent = Modo.Update;
                }
            }
            else
                ParentClean();
        }

        // OK - 18/04/09
        private void DgvParentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvParentList.RowCount >= 0)
            {
                SelectRowParent = e.RowIndex >= 0 ? e.RowIndex : SelectRowParent;
                SelectRowParent = DgvParentList.RowCount == 1 ? 0 : SelectRowParent;

                IdPatientParentSelected = Convert.ToInt32(DgvParentList.Rows[SelectRowParent].Cells[1].Value);

                foreach (DataRow DrView in DtTempView.Rows)
                {
                    if (Convert.ToInt32(DrView[1]) == IdPatientParentSelected)
                    {
                        ObjetParent = ObjectQuery.AbmParent(new ClassParent(Convert.ToInt32(DrView[0])), classQuery.eAbm.Select) as ClassParent;
                        break;
                    }
                }

                ModoParent = ObjetParent.IdParent != 0 ? Modo.Update : Modo.Add; //ListParent != null ? Modo.Update : Modo.Add;
                ObjetParent = ObjetParent != null ? ObjetParent : new ClassParent();
                ParentEnable(ModoPatient != Modo.Select);
                ParentLoadFrm();
            }
        }

        #endregion

        //== # 05 =====================================================================
        // OK - 18/04/14

        #region Metodos SocialWork

        #region Metodos

        /// <summary>
        /// Inicializa campos de Obra Social.
        /// OK - 18/03/26
        /// </summary>
        private void SocialWorkInit()
        {
            ObjetPatientSocialWork = null;

            DtViewPatientSocialWork = new DataTable("ViewPatientSocialWork");
            DtViewPatientSocialWork.Columns.Add(new DataColumn("IdPatientSocialWork", typeof(Int32)));
            DtViewPatientSocialWork.Columns.Add(new DataColumn("IdSocialWork", typeof(Int32)));
            DtViewPatientSocialWork.Columns.Add(new DataColumn("AffiliateNumber", typeof(string)));

            DtQuerySocialWorks = new DataTable();
            if ((bool)ObjectQuery.AbmSocialWork(new ClassSocialWork(), classQuery.eAbm.LoadCmb))
                DtQuerySocialWorks = ObjectQuery.Table;
            classControlComboBoxes.LoadCombo(CmbSocialWorkName, DtQuerySocialWorks != null, DtQuerySocialWorks);
        }

        /// <summary>
        /// Mostrar en formulario los datos de la Obra social.
        /// OK - 18/04/09
        /// </summary>
        private void SocialWorkLoad()
        {
            SocialWorkEnable(false);
            BtnSocialWorkNew.Visible = ModoPatient != Modo.Select;
            CmsFrm.Enabled = ModoPatient != Modo.Select;
            SocialWorkGenerarGrilla();
        }

        /// <summary>
        /// Carga y muestra la grilla SocialWorks
        /// OK - 18/04/09
        /// </summary>
        private void SocialWorkGenerarGrilla()
        {
            if (DtViewPatientSocialWork.Rows.Count != 0)
                DtViewPatientSocialWork.Clear();
            //
            ClassPatientSocialWork oPp = new ClassPatientSocialWork();
            oPp.IdPatient = ObjectPatient.IdPatient;
            List<ClassPatientSocialWork> ListPp = ObjectQuery.AbmPatientSocialWork(oPp, classQuery.eAbm.SelectAll) as List<ClassPatientSocialWork>;
            if (ListPp != null)
                foreach (ClassPatientSocialWork Or in ListPp)
                    DtViewPatientSocialWork.Rows.Add(new object[] { Or.IdPatientSocialWork, Or.IdSocialWork, Or.AffiliateNumber });
            //
            if (DgvSocialWorksList.ColumnCount != 0)
                DgvSocialWorksList.Columns.Clear();
            //
            // Cargo la Grilla
            //
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "IdPatientSocialWork";
            colId.DataPropertyName = DtViewPatientSocialWork.Columns[0].ColumnName;
            DgvSocialWorksList.Columns.Add(colId);
            //
            DataGridViewComboBoxColumn colSocialWork = new DataGridViewComboBoxColumn();
            colSocialWork.Name = "Obra Social";
            colSocialWork.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            colSocialWork.ValueMember = "Id";
            colSocialWork.DisplayMember = "Value";
            colSocialWork.DataSource = DtQuerySocialWorks;
            colSocialWork.DataPropertyName = DtViewPatientSocialWork.Columns[1].ColumnName;
            DgvSocialWorksList.Columns.Add(colSocialWork);
            //
            DataGridViewTextBoxColumn colAffiliateNumber = new DataGridViewTextBoxColumn();
            colAffiliateNumber.Name = "Numero Afiliado";
            colAffiliateNumber.DataPropertyName = DtViewPatientSocialWork.Columns[2].ColumnName;
            DgvSocialWorksList.Columns.Add(colAffiliateNumber);
            //
            //Configuracion del DataListView
            //
            DgvSocialWorksList.AutoGenerateColumns = false;
            DgvSocialWorksList.AllowUserToAddRows = false;
            DgvSocialWorksList.RowHeadersVisible = false;
            DgvSocialWorksList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DgvSocialWorksList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvSocialWorksList.ReadOnly = true;
            DgvSocialWorksList.ScrollBars = ScrollBars.Both;
            DgvSocialWorksList.ContextMenuStrip = CmsFrm; //CmsSocialWork;
            DgvSocialWorksList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvSocialWorksList.MultiSelect = false;
            DgvSocialWorksList.DataSource = DtViewPatientSocialWork;
#if (!DEBUG)
            DgvSocialWorksList.Columns[0].Visible = false;
            //DgvSocialWorksList.Columns[1].Visible = false;
            //DgvSocialWorksList.Columns[dgvSocialWorks.ColumnCount -1].Visible = false;
#endif
        }

        /// <summary>
        /// Limpia formulario.
        /// OK - 18/03/06
        /// </summary>
        private void SocialWorkClean()
        {
            IdPatientSocialWorkSelected = -1;
            TxtSocialWorkAffiliateNumber.Text = string.Empty;
            CmbSocialWorkName.SelectedIndex = -1;
        }

        /// <summary>
        /// Habilita TabSocialWork
        /// OK - 18/04/09
        /// </summary>
        /// <param name="X">True: Habilitado - False:Inhabilitado</param>
        private void SocialWorkEnable(bool X)
        {
            foreach (Control C in this.TlpSocialWork.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
            DgvSocialWorksList.Enabled = true;
            BtnSocialWorkNew.Enabled = true;
        }

        /// <summary>
        /// Carga Objeto desde Formulario.
        /// OK 18/04/09
        /// </summary>
        private void SocialWorkLoadObject()
        {
            ObjetPatientSocialWork.IdSocialWork = Convert.ToInt32(CmbSocialWorkName.SelectedValue);
            ObjetPatientSocialWork.AffiliateNumber = TxtSocialWorkAffiliateNumber.Text.ToUpper();
            ObjetPatientSocialWork.IdPatient = ObjectPatient.IdPatient;
        }

        /// <summary>
        /// Inicializa componente Obre Social.
        /// OK - 18/04/04
        /// </summary>
        private void SocialWorkLoadFrm()
        {
            TxtSocialWorkAffiliateNumber.Text = ObjetPatientSocialWork.AffiliateNumber;
            classControlComboBoxes.IndexCombos(CmbSocialWorkName, ObjetPatientSocialWork.IdSocialWork);
        }

        /// <summary>
        /// Valida los campos del Formulario.
        /// False -> Vacio - True -> Ok
        /// OK - 18/04/04
        /// </summary>
        /// <returns></returns>
        private bool SocialWorkValidateFields()
        {
            bool V = false;

            if ((TxtSocialWorkAffiliateNumber.Text.Length < 2) || (TxtSocialWorkAffiliateNumber.Text.Length >= 19) || (TxtSocialWorkAffiliateNumber.Text == ""))
                MessageBox.Show("El Numero de Afiliado esta vacio o supera 19 caracteres.");
            else if (CmbSocialWorkName.SelectedIndex == -1)
                MessageBox.Show("Obra Social Invalida.");
            else
                V = true;

            return V;
        }

        /// <summary>
        /// Actualiza en BD -> SocialWork.
        /// OK - 18/02/08
        /// </summary>
        private void SocialWorkSave(int IdPatient)
        {
            if (SocialWorkValidateFields())
            {
                SocialWorkLoadObject();
                switch (ModoSocialWork)
                {
                    case Modo.Add:
                        ObjetPatientSocialWork.IdPatientSocialWork = (int)ObjectQuery.AbmPatientSocialWork(ObjetPatientSocialWork, classQuery.eAbm.Insert);
                        if (0 == ObjetPatientSocialWork.IdPatientSocialWork)
                            MessageBox.Show(ObjetTxt.ErrorQueryAdd + " IdPatientSocialWork: " + ObjetPatientSocialWork.IdPatientSocialWork);
                        else
                        {
                            SocialWorkClean();
                            ObjetPatientSocialWork = new ClassPatientSocialWork();
                            ModoSocialWork = Modo.Add;
                        }
                        break;
                    case Modo.Update:
                        ObjetPatientSocialWork.IdPatientSocialWork = (int)ObjectQuery.AbmPatientSocialWork(ObjetPatientSocialWork, classQuery.eAbm.Update);
                        if (0 == ObjetPatientSocialWork.IdPatientSocialWork)
                            MessageBox.Show(ObjetTxt.ErrorQueryAdd + " IdPatientSocialWork: " + ObjetPatientSocialWork.IdPatientSocialWork);
                        break;
                    default:
                        break;
                }
                SocialWorkLoad();
            }
        }

        /// <summary>
        /// Elimina de BD.
        /// OK - 18/04/13
        /// </summary>
        private void SocialWorkDelete()
        {
            int IdPatientSocialWork = (int)ObjectQuery.AbmPatientSocialWork(new ClassPatientSocialWork(IdPatientSocialWorkSelected), classQuery.eAbm.Delete);
            if (0 == IdPatientSocialWork)
                MessageBox.Show(ObjetTxt.ErrorQueryDelete + " IdPatientSocialWorkSelected: " + IdPatientSocialWorkSelected);
            SocialWorkGenerarGrilla();
        }

        #endregion

        // OK - 18/04/04
        private void BtnSocialWorkNew_Click(object sender, EventArgs e)
        {
            SocialWorkClean();
            SocialWorkEnable(true);
            ObjetPatientSocialWork = new ClassPatientSocialWork();
            ModoSocialWork = Modo.Add;
        }

        // OK - 18/04/09
        private void TsmiSocialWorkDelete_Click(object sender, EventArgs e)
        {
            SocialWorkDelete();
        }

        // OK - 18/04/09
        private void DgvSocialWorksList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Select = 0;
            if (DgvSocialWorksList.RowCount >= 0)
            {
                Select = e.RowIndex >= 0 ? e.RowIndex : Select;
                Select = DgvParentList.RowCount == 1 ? 0 : Select;

                IdPatientSocialWorkSelected = Convert.ToInt32(DgvSocialWorksList.Rows[Select].Cells[0].Value);
                ObjetPatientSocialWork = ObjectQuery.AbmPatientSocialWork(new ClassPatientSocialWork(IdPatientSocialWorkSelected), classQuery.eAbm.Select) as ClassPatientSocialWork;

                ModoSocialWork = ObjetPatientSocialWork.IdPatientSocialWork != 0 ? Modo.Update : Modo.Add;
                ObjetPatientSocialWork = ObjetPatientSocialWork != null ? ObjetPatientSocialWork : new ClassPatientSocialWork();
                SocialWorkEnable(ModoSocialWork != Modo.Select);
                SocialWorkLoadFrm();
            }
        }

        #endregion

        //== # 06 =====================================================================
        // OK - 18/04/14

        #region State

        #region Metodos

        /// <summary>
        /// OK - 18/04/13
        /// </summary>
        private void StateInit()
        {
            ObjetPatientState = null;

            DtViewPatientState = new DataTable("ViewPatientState");
            DtViewPatientState.Columns.Add(new DataColumn("IdPatientState", typeof(Int32)));
            DtViewPatientState.Columns.Add(new DataColumn("Date", typeof(DateTime)));
            DtViewPatientState.Columns.Add(new DataColumn("Estate", typeof(Int32)));
            DtViewPatientState.Columns.Add(new DataColumn("Description", typeof(string)));

            DtTempState = new DataTable("TempState");
            DtTempState.Columns.Add(new DataColumn("Id", typeof(Int32)));
            DtTempState.Columns.Add(new DataColumn("Value", typeof(string)));
            DtTempState.Rows.Add(new object[] { 1, "Ingreso" });
            DtTempState.Rows.Add(new object[] { 0, "Egreso" });
            classControlComboBoxes.LoadCombo(CmbState, true, DtTempState);
        }

        /// <summary>
        /// Mostrar en formulario los datos del Estado.
        /// OK - 18/04/14
        /// </summary>
        private void StateLoad()
        {
            StateEnable(false);
            BtnStateNew.Visible = ModoPatient != Modo.Select;
            CmsFrm.Enabled = ModoPatient != Modo.Select;
            StateGenerarGrilla();
        }

        /// <summary>
        /// Carga y muestra la grilla.
        /// OK - 18/04/14
        /// </summary>  
        private void StateGenerarGrilla()
        {
            if (DtViewPatientState.Rows.Count != 0)
                DtViewPatientState.Clear();

            ClassPatientState oPp = new ClassPatientState();
            oPp.IdPatient = ObjectPatient.IdPatient;
            List<ClassPatientState> ListPp = ObjectQuery.AbmPatientState(oPp, classQuery.eAbm.SelectAll) as List<ClassPatientState>;
            if (ListPp != null)
                foreach (ClassPatientState Or in ListPp)
                    DtViewPatientState.Rows.Add(new object[] { Or.IdPatientState, Or.Date, Or.State, Or.Description });
            //
            if (DgvStateList.ColumnCount != 0)
                DgvStateList.Columns.Clear();
            //
            // Cargo la Grilla
            //
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "IdPatientState";
            colId.DataPropertyName = DtViewPatientState.Columns[0].ColumnName;
            DgvStateList.Columns.Add(colId);
            //
            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
            colDate.Name = "Fecha";
            colDate.DataPropertyName = DtViewPatientState.Columns[1].ColumnName;
            DgvStateList.Columns.Add(colDate);
            //
            DataGridViewComboBoxColumn colState = new DataGridViewComboBoxColumn();
            colState.Name = "Estado";
            colState.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            colState.ValueMember = "Id";
            colState.DisplayMember = "Value";
            colState.DataSource = DtTempState;
            colState.DataPropertyName = DtViewPatientState.Columns[2].ColumnName;
            DgvStateList.Columns.Add(colState);
            //
            DataGridViewTextBoxColumn colDescription = new DataGridViewTextBoxColumn();
            colDescription.Name = "Descripcion";
            colDescription.DataPropertyName = DtViewPatientState.Columns[3].ColumnName;
            DgvStateList.Columns.Add(colDescription);
            //
            //Configuracion del DataListView
            //
            DgvStateList.AutoGenerateColumns = false;
            DgvStateList.AllowUserToAddRows = false;
            DgvStateList.RowHeadersVisible = false;
            DgvStateList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DgvStateList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvStateList.ReadOnly = true;
            DgvStateList.ScrollBars = ScrollBars.Both;
            DgvStateList.ContextMenuStrip = CmsFrm;
            DgvStateList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvStateList.MultiSelect = false;
            DgvStateList.DataSource = DtViewPatientState;
#if (!DEBUG)
            DgvStateList.Columns[0].Visible = false;
            //DgvStateList.Columns[1].Visible = false;
            //DgvStateList.Columns[dgvSocialWorks.ColumnCount -1].Visible = false;
#endif
        }

        /// <summary>
        /// Limpia formulario.
        /// OK - 18/04/14
        /// </summary>
        private void StateClean()
        {
            IdPatientStateSelected = -1;
            TxtStateReason.Text = string.Empty;
            DtpStateDate.Value = DateTime.Now;
        }

        /// <summary>
        /// Habilita TabFicha
        /// OK - 18/03/07
        /// </summary>
        /// <param name="X">True: Habilitado - False:Inhabilitado</param>
        private void StateEnable(bool X)
        {
            foreach (Control C in this.TlpStatus.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
            DgvStateList.Enabled = true;
            BtnStateNew.Enabled = true;
        }

        /// <summary>
        /// Carga Objeto desde Formulario.
        /// OK - 18/04/13
        /// </summary>
        private void StateLoadObjectPatient()
        {
            ObjetPatientState.State = Convert.ToBoolean(CmbState.SelectedValue);
            ObjetPatientState.Description = TxtStateReason.Text;
            ObjetPatientState.Date = DtpStateDate.Value;
            ObjetPatientState.IdPatient = ObjectPatient.IdPatient;
        }

        /// <summary>
        /// Inicializa componente.
        /// OK - 18/04/13
        /// </summary>
        private void StateLoadFrmPatient()
        {
            classControlComboBoxes.IndexCombos(CmbState, Convert.ToInt32(ObjetPatientState.State));
            TxtStateReason.Text = ObjetPatientState.Description;
            DtpStateDate.Value = ObjetPatientState.Date;
        }

        /// <summary>
        /// Valida los campos del Formulario.
        /// False -> Vacio - True -> Ok
        /// OK - 18/04/04
        /// </summary>
        /// <returns></returns>
        private bool StateValidateFields()
        {
            bool V = false;

            if ((TxtStateReason.Text.Length < 10) || (TxtStateReason.Text.Length >= 250) || (TxtStateReason.Text == ""))
                MessageBox.Show("El Numero de Afiliado no supera el minimo de 10 caracteres o supera los 250 caracteres.");
            else if (DtpStateDate.Value > DateTime.Now)
                MessageBox.Show("La fecha no puede ser mayor a la del dia en curso.");
            else
                V = true;

            return V;
        }

        /// <summary>
        /// Actualiza en BD.
        /// OK - 18/04/13
        /// </summary>
        /// <returns>True: Exito | False: Error</returns>
        private void StateSave(int IdPatient)
        {
            if (StateValidateFields())
            {
                StateLoadObjectPatient();
                switch (ModoPatientState)
                {
                    case Modo.Add:
                        ObjetPatientState.IdPatientState = (int)ObjectQuery.AbmPatientState(ObjetPatientState, classQuery.eAbm.Insert);
                        if (0 == ObjetPatientState.IdPatientState)
                            MessageBox.Show(ObjetTxt.ErrorQueryAdd + " IdPatientState: " + ObjetPatientState.IdPatientState);
                        else
                        {
                            StateClean();
                            ObjetPatientState = new ClassPatientState();
                            ModoPatientState = Modo.Add;
                        }
                        break;
                    case Modo.Update:
                        ObjetPatientState.IdPatientState = (int)ObjectQuery.AbmPatientState(ObjetPatientState, classQuery.eAbm.Update);
                        if (0 == ObjetPatientState.IdPatientState)
                            MessageBox.Show(ObjetTxt.ErrorQueryAdd + " IdPatientState: " + ObjetPatientState.IdPatientState);
                        break;
                    default:
                        break;
                }
                StateLoad();
            }
        }

        /// <summary>
        /// Elimina de BD.
        /// OK - 18/04/13
        /// </summary>
        private void StateDelete()
        {
            int IdPatientState = (int)ObjectQuery.AbmPatientState(new ClassPatientState(IdPatientStateSelected), classQuery.eAbm.Delete);
            if (0 == IdPatientState)
                MessageBox.Show(ObjetTxt.ErrorQueryDelete + " IdPatientStateSelected: " + IdPatientStateSelected);
            StateGenerarGrilla();
        }

        #endregion

        // OK - 18/04/13
        private void BtnStateNew_Click(object sender, EventArgs e)
        {
            StateClean();
            StateEnable(true);
            ObjetPatientState = new ClassPatientState();
            ModoPatientState = Modo.Add;
        }

        // OK - 18/04/13
        private void TsmiStateDelete_Click(object sender, EventArgs e)
        {
            StateDelete();
        }

        // OK - 18/04/13
        private void DgvStateList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Select = 0;
            if (DgvStateList.RowCount >= 0)
            {
                Select = e.RowIndex >= 0 ? e.RowIndex : Select;
                Select = DgvStateList.RowCount == 1 ? 0 : Select;

                IdPatientStateSelected = Convert.ToInt32(DgvStateList.Rows[Select].Cells[0].Value);
                ObjetPatientState = ObjectQuery.AbmPatientState(new ClassPatientState(IdPatientStateSelected), classQuery.eAbm.Select) as ClassPatientState;

                ModoPatientState = ObjetPatientState.IdPatientState != 0 ? Modo.Update : Modo.Add;
                ObjetPatientState = ObjetPatientState != null ? ObjetPatientState : new ClassPatientState();
                StateEnable(ModoPatientState != Modo.Select);
                StateLoadFrmPatient();
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