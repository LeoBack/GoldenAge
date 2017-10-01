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
        private classDiagnostic oDiagnostic;
        private classParent oParent;
        public enum Modo { Add, Select, Update, Delete }
        public Modo eModo { set; get; }
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

                // Modo en el que se mostrara el formulario
                switch (eModo)
                {
                    case Modo.Select:
                        btnEdit.Visible = true;
                        EnablePatient(false);
                        EscribirEnFrmPatient();
                        //EnableDiagnostico(true);
                        //CargarDiagnostico();
                        break;
                    case Modo.Update:
                        btnEdit.Visible = false;
                        EnablePatient(true);
                        EscribirEnFrmPatient();
                        //EnableDiagnostico(true);
                        //CargarDiagnostico();
                        break;
                    case Modo.Add:
                        btnEdit.Visible = false;
                        oPatient = new classPatient();
                        EnablePatient(true);
                        //EscribirEnFrmPatient();
                        //EnableDiagnostico(false);
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (eModo == Modo.Select)
            {
                eModo = Modo.Update;
                EnablePatient(true);
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

        private void btnApplyParent_Click(object sender, EventArgs e)
        {
            if(ValidarCamposParent())
            {
                CargarObjetoParent();
                int IdQuery = 0;

                //switch (eModo)
                //{
                //    case Modo.Add:
                //        IdQuery = (int)oQuery.AbmParent(oParent, classQuery.eAbm.Insert);
                //        if (0 != IdQuery)
                //            MessageBox.Show(oTxt.AddParent);
                //        else
                //            MessageBox.Show(oTxt.ErrorQueryAdd);
                //        break;
                //    case Modo.Update:
                //        IdQuery = (int)oQuery.AbmParent(oParent, classQuery.eAbm.Update);
                //        if (0 != IdQuery)
                //            MessageBox.Show(oTxt.UpdateParent);
                //        else
                //            MessageBox.Show(oTxt.ErrorQueryUpdate);
                //        break;
                //    default:
                //        MessageBox.Show(oTxt.AccionIndefinida);
                //        break;
                //}

                if (IdQuery == 0)
                    MessageBox.Show(oQuery.Menssage);
            }
        }

        #endregion

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
            else if ((txtAffiliateNumber.Text.Length >= 6) || (txtAffiliateNumber.Text == ""))
                MessageBox.Show("El Numero de Afiliado esta vacio o no supera los 6 caracteres.");
            else if (txtAddress.Text.Length >= 50 || (txtAddress.Text == ""))
                MessageBox.Show("La Direccion esta vacia o supera los 50 caracteres");
            else if ((IdCountry == 0) || (IdProvince == 0) || (IdCity == 0))
                MessageBox.Show("El Campo Localidad esta vacío o es Erroneo");
            else if (txtReasonExit.Text.Length >= 50)
                MessageBox.Show("El Motivo de Alta Debe tener como minimo 8 caracteres.");
            else if (cmbTypeDocument.SelectedIndex == -1)
                MessageBox.Show("Typo Docuemnte Invalido.");
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
            oParent.NumberDocument = Convert.ToInt32(txtNumberDocument.Text);
            oParent.Address = txtParentAddress.Text.ToUpper();
            oParent.IdLocationCountry = Convert.ToInt32(IdCountryParent);
            oParent.IdLocationCity = Convert.ToInt32(IdCityParent);
            oParent.IdLocationProvince = Convert.ToInt32(IdProvinceParent);
            oParent.Phone = txtParentPhone.Text;
            oParent.AlternativePhone = txtParentAlternativePhone.Text;
            oParent.Email = txtParentEmail.Text.ToUpper();
            oParent.IdTypeParent = Convert.ToInt32(cmbParentRelationship.SelectedValue);
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
            txtParentAlternativePhone.Text = oParent.AlternativePhone;
            txtParentEmail.Text = oParent.Email.ToUpper();
            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(cmbParentRelationship, oParent.IdTypeParent);

            txtLocationParent.Text = frmLocation.toStringLocation(
                oQuery.ConexionString, IdCountryParent, IdProvinceParent, IdCityParent);
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

        #endregion
    }
}
