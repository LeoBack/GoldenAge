using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using Datos;
using Entidades;
using Entidades.Clases;
using Reportes;
using Controles;

namespace myExplorer.Formularios
{
    public partial class frmGrandfather : Form
    {
        #region Atributos y Propiedades

        public enum Vista { Nuevo, Ver, Modificar }

        public Vista Modo { set; get; }
        public int IdPaciente { set; get; }

        public classConsultas oConsulta { set; get; }
        public classUtiles oUtil { set; get; }

        public classGrandfather oGrandfather { set; get; }
        private classDiagnostic oDiagnostic;

        private classControlComboBoxes oComboBox;
        private classValidaciones oValidar;
        private classValidaSqlite oValidarSql = new classValidaSqlite();
        private classTextos oTxt = new classTextos();
        private int SelectRow;

        #endregion

        //-----------------------------------------------------------------------
        #region Base Formulario
        //-----------------------------------------------------------------------
        // Finalizado
        #region Formulario

        //OK 24/05/12
        public frmGrandfather()
        {
            InitializeComponent();
        }

        //OK 24/05/12
        private void frmGrandfather_Load(object sender, EventArgs e)
        {
            this.Text = oTxt.TituloFichaPaciente;
            if (oConsulta != null)
            {
                oGrandfather = new classGrandfather();
                oDiagnostic = new classDiagnostic();
                oValidar = new classValidaciones();

                // Inicio Ficha
                this.ConfiguracionFicha();

                // Cargo los Combos
                oComboBox = new classControlComboBoxes();
                oComboBox.CargaCombo(cmbSocialWork, oConsulta.ListSpecialty(false), oConsulta.Table);
                //oComboBox.CargaCombo(cmbTipoPaciente, oConsulta.ListaTipoDePersonas(), oConsulta.Table);

                //this.CargarCombosCiudadBarrio();

                this.ini();
            }
            else
            {
                MessageBox.Show(oTxt.ErrorObjetoIndefinido);
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
            //if (oConsulta.rHistoriaClinica("dtHistoriaClinica", oGrandfather.IdGrandfather))
            //{
            //    frmVisor fReport = new frmVisor(frmVisor.Reporte.HistoriaClinica, oConsulta.Table);
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
                //oDs = oConsulta.SelectDiagnostic(oDs);

                // LLamo al formulario Diagnostico
                frmD.Modo = Formularios.frmAbmDiagnostic.Vista.Modificar;
               // frmD.oDiagnostic = oDs;
                frmD.oConsulta = this.oConsulta;
                frmD.oUtil = this.oUtil;
                frmD.ShowDialog();

                // Actualizo la grilla
                //this.GenerarGrillaDiagnostico(oConsulta.SelectDiagnosticoGrandfather(oDiagnostic));
                this.CargarDiagnostico();
            }
        }

        //OK 24/05/12
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            classDiagnostic oDs = new classDiagnostic();
            Formularios.frmAbmDiagnostic frmD = new Formularios.frmAbmDiagnostic();
            frmD.oConsulta = this.oConsulta;
            frmD.oUtil = this.oUtil;

            if (dgvDiagnostic.Rows.Count != 0)
            {
                // Traigo el diagnostico del paciente solicitado 
                oDs.IdDiagnostic = Convert.ToInt32(dgvDiagnostic.Rows[SelectRow].Cells["dgvID"].Value);
                oDs = oConsulta.SelectDiagnostic(oDs);
            }
            else
            {
                // No Existe Diagnostico Previo
               // oDs.IdGrandfather = oGrandfather.IdGrandfather;
            }

            // LLamo al formulario Diagnostico
            frmD.Modo = Formularios.frmAbmDiagnostic.Vista.Nuevo;
           // frmD.oDiagnostic = oDs;
            frmD.ShowDialog();

            // Actualizo la grilla
            //this.GenerarGrillaDiagnostico(oConsulta.SelectDiagnosticoGrandfather(oDiagnostic));
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
            //dtpUltimaVisita.Value = oConsulta.UltimaVisita(oGrandfather);
            //dtpPrimeraVisita.Value = oConsulta.PrimeraVisita(oGrandfather);
            //// Carga Visita
            ////-------------------------------------------------
            //txtNvisitas.Text = Convert.ToString(oConsulta.CantidadVisitas(oGrandfather));
            //txtNvisitas.Enabled = false;
            //// Carga Grilla Paciente
            ////-------------------------------------------------
            //oDiagnostic.IdGrandfather = oGrandfather.IdGrandfather;
            //int C = this.GenerarGrillaDiagnostico(oConsulta.SelectDiagnosticoGrandfather(oDiagnostic));

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
            //        if (!oConsulta.AddGrandfather(oGrandfather, oUtil.IdUsuario))
            //            MessageBox.Show(oConsulta.Menssage);
            //        else
            //        {
            //            MessageBox.Show(oTxt.AgregarPaciente);
            //            this.Modo = Vista.Modificar;
            //            this.oGrandfather.IdGrandfather = oConsulta.UltimoIdGrandfather();
            //            this.IdPaciente = 0;
            //            this.ini();
            //        }
            //    }
            //    else if (Modo == Vista.Modificar)
            //    {   // Actualiza
            //        if (!oConsulta.ModificarPersona(oGrandfather))
            //            MessageBox.Show(oConsulta.Menssage);
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
            if (Modo == Vista.Ver)
            {
                this.Modo = Vista.Modificar;
                this.frmGrandfather_Load(sender, e);
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
            if (this.IdPaciente != 0)
            {
                oGrandfather.IdGrandfather = this.IdPaciente;
                //oGrandfather = oConsulta.SelectPersona(oGrandfather);
            }

            // Modo en el que se mostrara el formulario
            if (Modo == Vista.Ver && oGrandfather.IdGrandfather != 0)
            {
                this.EnableFicha(false, true);
                this.EnableDiagnostico(true);
                this.EscribirEnFrm();
                this.CargarDiagnostico();
            }
            else if (Modo == Vista.Modificar && oGrandfather.IdGrandfather != 0)
            {
                this.EnableFicha(true, false);
                this.EnableDiagnostico(true);
                this.EscribirEnFrm();
                this.CargarDiagnostico();
            }
            else if (Modo == Vista.Nuevo)
            {
                oGrandfather = new classGrandfather();

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
        private bool ValidarCampos()
        {
            if ((txtLastName.Text == "") ||
                (txtName.Text == "") ||
                (txtAddress.Text == "") ||
                (txtAffiliateNumber.Text == ""))
                return false;
            else
                return true;
        }

        // OK 04/03/12
        private void LeerDesdeFrm()
        {
            //oGrandfather.nAfiliado = this.oValidarSql.ValidaString(txtNumeroAfiliado.Text);
            //oGrandfather.Apellido = this.oValidarSql.ValidaString(txtApellido.Text);
            //oGrandfather.Nombre = this.oValidarSql.ValidaString(txtNombre.Text);
            //oGrandfather.FechaNac = dtpFechaNacimiento.Value;
            //oGrandfather.FechaAlta = DateTime.Now;
            //oGrandfather.Sexo = Convert.ToInt32(rbtMasculino.Checked);
            //oGrandfather.Direccion = this.oValidarSql.ValidaString(txtDomicilio.Text);
            //oGrandfather.SocialWork = Convert.ToInt32(cmbSocialWork.SelectedValue);
            //oGrandfather.TipoPaciente = Convert.ToInt32(cmbTipoPaciente.SelectedValue);
            //oGrandfather.IdCiudad = Convert.ToInt32(cmbCiudad.SelectedValue);
            //oGrandfather.IdBarrio = Convert.ToInt32(cmbBarrio.SelectedValue);
            //oGrandfather.Telefono = this.oValidarSql.ValidaString(txtTelefono.Text);
            //oGrandfather.TelefonoParticular = this.oValidarSql.ValidaString(txtTelefonoParticular.Text);
        }

        /// <summary>
        /// Carga los elementos de formulario desde objeto.
        /// OK 04/04/12
        /// </summary>
        private void EscribirEnFrm()
        {
            //txtNumeroAfiliado.Text = oGrandfather.nAfiliado;
            //txtApellido.Text = oGrandfather.Apellido;
            //txtNombre.Text = oGrandfather.Nombre;
            //dtpFechaNacimiento.Value = oGrandfather.FechaNac;
            //rbtMasculino.Checked = Convert.ToBoolean(oGrandfather.Sexo);
            //rbtFemenino.Checked = !Convert.ToBoolean(oGrandfather.Sexo);
            //txtDomicilio.Text = oGrandfather.Direccion;
            //txtEdad.Text = Convert.ToString(oGrandfather.Edad());

            //oComboBox.IndexCombos(cmbSocialWork, oGrandfather.SocialWork);
            //oComboBox.IndexCombos(cmbTipoPaciente, oGrandfather.TipoPaciente);
            //oComboBox.IndexCombos(cmbCiudad, oGrandfather.IdCiudad);
            //oComboBox.IndexCombos(cmbBarrio, oGrandfather.IdBarrio);

            //txtTelefono.Text = oGrandfather.Telefono;
            //txtTelefonoParticular.Text = oGrandfather.TelefonoParticular;

            //txtIdentificacion.Text = oGrandfather.Apellido + ", " + oGrandfather.Nombre;
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
