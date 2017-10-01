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
        #region Atributos y Propiedades

        public enum Modo { Add, Select, Update, Delete }

        public Modo eModo { set; get; }
        public int IdPatient { set; get; }

        public classQuery oQuery { set; get; }
        public classUtiles oUtil { set; get; }

        public classPatient oPatient { set; get; }
        
        private classDiagnostic oDiagnostic;

        private classValidaciones oValidar;
        private classTextos oTxt = new classTextos();
        private int SelectRow;

        private int IdCountry;
        private int IdProvince;
        private int IdCity;

        private int IdCountryParent;
        private int IdProvinceParent;
        private int IdCityParent;

        #endregion

        //-----------------------------------------------------------------------
        #region Base Formulario
        //-----------------------------------------------------------------------
        // Finalizado
        #region Formulario

        //OK 24/05/12
        public frmAbmPatient()
        {
            InitializeComponent();
        }

        //OK 24/05/12
        private void frmAbmPatient_Load(object sender, EventArgs e)
        {
            this.Text = oTxt.TitleFichaPatient;
            if (oQuery != null)
            {
                oPatient = new classPatient();
                oDiagnostic = new classDiagnostic();
                oValidar = new classValidaciones();

                // Inicio Ficha
                this.ConfiguracionFicha();

                // Cargo los Combos
                libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbSocialWork,
                    (bool)oQuery.AbmSocialWork(new classSocialWork(), classQuery.eAbm.LoadCmb), 
                    oQuery.Table);
                libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbTypeDocument,
                    (bool)oQuery.AbmTypeDocument(new classTypeDocument(), classQuery.eAbm.LoadCmb), 
                    oQuery.Table);
                this.ini();
            }
            else
            {
                MessageBox.Show(oTxt.ErrorObjetIndefinido);
                this.Close();
            }
        }

        //OK 24/05/12
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        //-----------------------------------------------------------------------
        #endregion
        //-----------------------------------------------------------------------

        //-----------------------------------------------------------------------
        #region TabDiagnostico
        //-----------------------------------------------------------------------

        #region Botones

        //OK 21/06/12
        private void btnExportar_Click(object sender, EventArgs e)
        {
            //if (oQuery.rHistoriaClinica("dtHistoriaClinica", oGrandfather.IdGrandfather))
            //{
            //    frmVisor fReport = new frmVisor(frmVisor.Reporte.HistoriaClinica, oQuery.Table);
            //    fReport.Show();
            //}
            //else
            //    MessageBox.Show(oTxt.ErrorListaConsulta);
        }

        //OK 24/05/12
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDiagnostic.Rows.Count != 0)
            {
                classDiagnostic oDs = new classDiagnostic();
                Formularios.frmAbmDiagnostic frmD = new Formularios.frmAbmDiagnostic();

                // Traigo el diagnostico del paciente solicitado 
                oDs.IdDiagnostic = Convert.ToInt32(dgvDiagnostic.Rows[SelectRow].Cells["dgvID"].Value);
                //oDs = oQuery.SelectDiagnostic(oDs);

                // LLamo al formulario Diagnostico
                frmD.eModo = Formularios.frmAbmDiagnostic.Modo.Update;
               // frmD.oDiagnostic = oDs;
                frmD.oQuery = oQuery;
                frmD.oUtil = oUtil;
                frmD.ShowDialog();

                // Actualizo la grilla
                //this.GenerarGrillaDiagnostico(oQuery.SelectDiagnosticoGrandfather(oDiagnostic));
                this.CargarDiagnostico();
            }
        }

        //OK 24/05/12
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            classDiagnostic oDs = new classDiagnostic();
            Formularios.frmAbmDiagnostic frmD = new Formularios.frmAbmDiagnostic();
            frmD.oQuery = oQuery;
            frmD.oUtil = oUtil;

            if (dgvDiagnostic.Rows.Count != 0)
            {
                // Traigo el diagnostico del paciente solicitado 
                oDs.IdDiagnostic = Convert.ToInt32(dgvDiagnostic.Rows[SelectRow].Cells["dgvID"].Value);
                oDs = (classDiagnostic)oQuery.AbmDiagnostic(oDs, classQuery.eAbm.Select);
            }
            else
            {
                // No Existe Diagnostico Previo
               // oDs.IdGrandfather = oGrandfather.IdGrandfather;
            }

            // LLamo al formulario Diagnostico
            frmD.eModo = Formularios.frmAbmDiagnostic.Modo.Add;
           // frmD.oDiagnostic = oDs;
            frmD.ShowDialog();

            // Actualizo la grilla
            //this.GenerarGrillaDiagnostico(oQuery.SelectDiagnosticoGrandfather(oDiagnostic));
            this.CargarDiagnostico();
        }

        //OK 24/05/12
        private void dgvDiagnostico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelectRow = e.RowIndex;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Enlaza los datos al los controles del formulario.
        /// OK 26/05/12
        /// </summary>
        private void CargarDiagnostico()
        {
            // Carga Fechas
            //-------------------------------------------------
            //dtpUltimaVisita.Value = oQuery.UltimaVisita(oGrandfather);
            //dtpPrimeraVisita.Value = oQuery.PrimeraVisita(oGrandfather);
            //// Carga Visita
            ////-------------------------------------------------
            //txtNvisitas.Text = Convert.ToString(oQuery.CantidadVisitas(oGrandfather));
            //txtNvisitas.Enabled = false;
            //// Carga Grilla Paciente
            ////-------------------------------------------------
            //oDiagnostic.IdGrandfather = oGrandfather.IdGrandfather;
            //int C = this.GenerarGrillaDiagnostico(oQuery.SelectDiagnosticoGrandfather(oDiagnostic));

            //if (C == 0)
            //    btnExportar.Enabled = false;
            //else
            //    btnExportar.Enabled = true;
        }

        /// <summary>
        /// Habilita TabDiagnostico
        /// OK 18/04/12
        /// </summary>
        /// <param name="X"></param>
        private void EnableDiagnostico(bool X)
        {
            foreach (Control C in this.tlpPanelDiagnostico.Controls)
            {
                if (!(C is DateTimePicker || C is Label))
                    C.Enabled = X;
            }
        }

        /// <summary>
        /// Carga la La Lista devuelve la cantidad de filas
        /// OK 24/05/12
        /// </summary>
        /// <param name="Source"></param>
        public int GenerarGrillaDiagnostico(object Source)
        {
            if (dgvDiagnostic.Columns.Count != 0)
                dgvDiagnostic.Columns.Clear();
            //
            //Columna Oculta ID
            //
            dgvDiagnostic.Columns.Add("dgvId", "ID");
            dgvDiagnostic.Columns["dgvId"].DataPropertyName = "IdDiagnostic";
            dgvDiagnostic.Columns["dgvId"].Visible = false;
            dgvDiagnostic.Columns["dgvId"].DefaultCellStyle.NullValue = "0";
            //
            //Columna Nombre
            //
            dgvDiagnostic.Columns.Add("dgvFecha", "Fecha");
            dgvDiagnostic.Columns["dgvFecha"].DataPropertyName = "Fecha";
            dgvDiagnostic.Columns["dgvFecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDiagnostic.Columns["dgvFecha"].DefaultCellStyle.NullValue = "No especificado";
            dgvDiagnostic.Columns["dgvFecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //
            //Columna  Obra Social
            //
            dgvDiagnostic.Columns.Add("dgvDiagnostico", "Diagnostico");
            dgvDiagnostic.Columns["dgvDiagnostico"].DataPropertyName = "Diagnostico";
            dgvDiagnostic.Columns["dgvDiagnostico"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDiagnostic.Columns["dgvDiagnostico"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Configuracion del DataListView
            //
            dgvDiagnostic.AutoGenerateColumns = false;
            dgvDiagnostic.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvDiagnostic.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiagnostic.ReadOnly = true;
            dgvDiagnostic.ScrollBars = ScrollBars.Both;
            dgvDiagnostic.ContextMenuStrip = cmsMenuEmergente;
            dgvDiagnostic.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiagnostic.MultiSelect = false;
            dgvDiagnostic.DataSource = Source;

            return dgvDiagnostic.Rows.Count;
        }

        #endregion

        //-----------------------------------------------------------------------
        #endregion
        //-----------------------------------------------------------------------

        //-----------------------------------------------------------------------
        #region TabPerfil
        //-----------------------------------------------------------------------

        #region Botones

        // OK AGREGAR 26/05/12
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if (ValidarCampos())
            //{
            //    this.LeerDesdeFrm();

            //    if (Modo == Vista.Nuevo)
            //    {   // Guarda
            //        if (!oQuery.AddGrandfather(oGrandfather, oUtil.IdUsuario))
            //            MessageBox.Show(oQuery.Menssage);
            //        else
            //        {
            //            MessageBox.Show(oTxt.AgregarPaciente);
            //            this.Modo = Vista.Modificar;
            //            this.oGrandfather.IdGrandfather = oQuery.UltimoIdGrandfather();
            //            this.IdPaciente = 0;
            //            this.ini();
            //        }
            //    }
            //    else if (Modo == Vista.Modificar)
            //    {   // Actualiza
            //        if (!oQuery.ModificarPersona(oGrandfather))
            //            MessageBox.Show(oQuery.Menssage);
            //        else
            //        {
            //            MessageBox.Show(oTxt.ModificarPaciente);
            //            this.Modo = Vista.Modificar;
            //            this.ini();
            //        }
            //    }
            //    else
            //        MessageBox.Show(oTxt.AccionIndefinida);
            //}
            //else
            //    MessageBox.Show(oTxt.CaillasVacias);
        }

        private void btnModificarPerfil_Click(object sender, EventArgs e)
        {
            if (eModo == Modo.Select)
            {
                this.eModo = Modo.Update;
                this.frmAbmPatient_Load(sender, e);
            }
        }

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

        #region Validaciones

        private void txtNumeroAfiliado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (oValidar.isChar(e.KeyChar))
                e.Handled = true;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (oValidar.isNumeric(e.KeyChar))
                e.Handled = true;
        }

        private void dtpFechaNacimiento_CloseUp(object sender, EventArgs e)
        {
            //txtEdad.Text = Convert.ToString(oGrandfather.Edad(dtpFechaNacimiento.Value));
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Actualiza el formulario
        /// OK 24/05/12  REVISAR
        /// </summary>
        private void ini()
        {
            if (this.IdPatient != 0)
            {
                oPatient.IdPatient = this.IdPatient;
                //oGrandfather = oQuery.SelectPersona(oGrandfather);
            }

            // Modo en el que se mostrara el formulario
            if (eModo == Modo.Select && oPatient.IdPatient != 0)
            {
                this.EnableFicha(false, true);
                this.EnableDiagnostico(true);
                this.EscribirEnFrm();
                this.CargarDiagnostico();
            }
            else if (eModo == Modo.Update && oPatient.IdPatient != 0)
            {
                this.EnableFicha(true, false);
                this.EnableDiagnostico(true);
                this.EscribirEnFrm();
                this.CargarDiagnostico();
            }
            else if (eModo == Modo.Add)
            {
                oPatient = new classPatient();

                this.EnableFicha(true, false);
                this.EnableDiagnostico(false);
                this.EscribirEnFrm();
                btnExport.Enabled = false;
            }
            else
                MessageBox.Show("Error de typo");
        }

        
        /// <summary>
        /// Valida los campos del Formulario.
        /// False -> Vacio - True -> Ok
        /// OK 04/03/12
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
            else if ((txtAffiliateNumber.Text.Length >= 6) || (txtAffiliateNumber.Text == ""))
                MessageBox.Show("El Numero de Afiliado esta vacio o no supera los 6 caracteres.");
            else if (txtAddress.Text.Length >= 50 || (txtAddress.Text == ""))
                MessageBox.Show("La Direccion esta vacia o supera los 50 caracteres");
            else if ((IdCountry != 0) || (IdProvince != 0) || (IdCity!= 0))
                MessageBox.Show("El Campo Localidad esta vacío o es Erroneo");
            else if (txtReasonExit.Text.Length >= 50)
                MessageBox.Show("El Motivo de Alta Debe tener como minimo 8 caracteres.");
            else
                V = true;

            return V;
        }

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
            else if (txtParentPhone.Text.Length >= 15 )
                MessageBox.Show("El Numero de Telefono supera los 15 caracteres");
            else if (txtParentAlternativePhone.Text.Length >= 15)
                MessageBox.Show("El Numero de Telefono Alternativo supera los 15 caracteres");
            else if (txtParentEmail.Text.Length >= 50)
                MessageBox.Show("El E-mail supera los 50 caracteres");
            else if (txtParentEmail.Text.Length >= 50)
                MessageBox.Show("El E-mail supera los 50 caracteres");
            else
                V = true;

            return V;
        }

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

        // OK 04/03/12
        private void LeerDesdeFrmParent()
        {
            oParent.Name = txtParentName.Text;
            oParent.LastName = txtParentLastName.Text;
            oParent.NumberDocument = Convert.ToInt32(txtNumberDocument.Text);
            oParent.Address = txtParentAddress.Text;
            oParent.IdLocationCountry = Convert.ToInt32(IdCountryParent);
            oParent.IdLocationCity = Convert.ToInt32(IdCityParent);
            oParent.IdLocationProvince = Convert.ToInt32(IdProvinceParent);
            oParent.Phone = txtParentPhone.Text;
            oParent.AlternativePhone = txtParentAlternativePhone.Text;
            oParent.Email = txtParentEmail.Text;
            //oParent.IdTypeParent = Convert.ToInt32(IdTypeParent.text);
        }
        public classParent oParent { set; get; }
        public classPatientParent oTypeParent { set; get; }
        /// <summary>
        /// Carga los elementos de formulario desde objeto.
        /// OK 04/04/12
        /// </summary>
        private void EscribirEnFrmParent()
        {
            txtParentName.Text = oParent.Name;
            txtParentLastName.Text = oParent.LastName;
            txtParentNumberDocument.Text = Convert.ToString(oParent.NumberDocument);
            txtParentAddress.Text = oParent.Address;

            IdCountryParent = oParent.IdLocationCountry;
            IdProvinceParent = oParent.IdLocationProvince;
            IdCityParent = oParent.IdLocationCity;

            txtLocation.Text = frmLocation.toStringLocation(
            oQuery.ConexionString, IdCountry, IdProvince, IdCity);

            txtParentPhone.Text = oParent.Phone;
            txtParentAlternativePhone.Text = oParent.AlternativePhone;
            txtParentAlternativePhone.Text = oParent.AlternativePhone;
            txtParentEmail.Text = oParent.Email;
            
            // oComboBox.IndexCombos(cmbParentRelationship, oTypeParent.IdTypeParent);
           
        }

        /// <summary>
        /// Habilita TabFicha
        /// OK 18/04/12
        /// </summary>
        /// <param name="X"></param>
        private void EnableFicha(bool X, bool Ver)
        {
            foreach (Control C in this.tlpPanlData.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
            this.btnSave.Enabled = !Ver;
            this.btnEdit.Enabled = Ver;
        }

        /// <summary>
        /// Carga y estableze los limites y valores de los componentes.
        /// OK 04/04/12
        /// </summary>
        private void ConfiguracionFicha()
        {
            Size sBtn = new Size(75, 42);
            btnEdit.Size = sBtn;
            btnSave.Size = sBtn;
            btnClose.Size = sBtn;
        }

        #endregion



        //-----------------------------------------------------------------------
        #endregion
        //-----------------------------------------------------------------------
    }
}
