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
    public partial class frmForm : Form
    {
        #region Atributos y Propiedades

        public enum Vista { Nuevo, Ver, Modificar }

        public Vista Modo { set; get; }
        public int IdPaciente { set; get; }

        public classConsultas oConsulta { set; get; }
        public classUtiles oUtil { set; get; }

        public classPersona oPersona { set; get; }
        private classDiagnostico oDiagnostico;

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
        public frmForm()
        {
            InitializeComponent();
        }

        //OK 24/05/12
        private void frmForm_Load(object sender, EventArgs e)
        {
            this.Text = oTxt.TituloFichaPaciente;
            if (oConsulta != null)
            {
                oPersona = new classPersona();
                oDiagnostico = new classDiagnostico();
                oValidar = new classValidaciones();

                // Inicio Ficha
                this.ConfiguracionFicha();

                // Cargo los Combos
                oComboBox = new classControlComboBoxes();
                oComboBox.CargaCombo(cmbObraSocial, oConsulta.ListSpecialty(false), oConsulta.Table);
                oComboBox.CargaCombo(cmbTipoPaciente, oConsulta.ListaTipoDePersonas(), oConsulta.Table);

                this.CargarCombosCiudadBarrio();

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
            if (oConsulta.rHistoriaClinica("dtHistoriaClinica", oPersona.IdPersona))
            {
                frmVisor fReport = new frmVisor(frmVisor.Reporte.HistoriaClinica, oConsulta.Table);
                fReport.Show();
            }
            else
                MessageBox.Show(oTxt.ErrorListaConsulta);
        }

        //OK 24/05/12
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDiagnostico.Rows.Count != 0)
            {
                classDiagnostico oDs = new classDiagnostico();
                Formularios.frmDiagnostico frmD = new Formularios.frmDiagnostico();

                // Traigo el diagnostico del paciente solicitado 
                oDs.IdDiagnostico = Convert.ToInt32(dgvDiagnostico.Rows[SelectRow].Cells["dgvID"].Value);
                oDs = oConsulta.SelectDiagnostico(oDs);

                // LLamo al formulario Diagnostico
                frmD.Modo = Formularios.frmDiagnostico.Vista.Modificar;
                frmD.oDiagnostico = oDs;
                frmD.oConsulta = this.oConsulta;
                frmD.oUtil = this.oUtil;
                frmD.ShowDialog();

                // Actualizo la grilla
                this.GenerarGrillaDiagnostico(oConsulta.SelectDiagnosticoPersona(oDiagnostico));
                this.CargarDiagnostico();
            }
        }

        //OK 24/05/12
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            classDiagnostico oDs = new classDiagnostico();
            Formularios.frmDiagnostico frmD = new Formularios.frmDiagnostico();
            frmD.oConsulta = this.oConsulta;
            frmD.oUtil = this.oUtil;

            if (dgvDiagnostico.Rows.Count != 0)
            {
                // Traigo el diagnostico del paciente solicitado 
                oDs.IdDiagnostico = Convert.ToInt32(dgvDiagnostico.Rows[SelectRow].Cells["dgvID"].Value);
                oDs = oConsulta.SelectDiagnostico(oDs);
            }
            else
            {
                // No Existe Diagnostico Previo
                oDs.IdPersona = oPersona.IdPersona;
            }

            // LLamo al formulario Diagnostico
            frmD.Modo = Formularios.frmDiagnostico.Vista.Nuevo;
            frmD.oDiagnostico = oDs;
            frmD.ShowDialog();

            // Actualizo la grilla
            this.GenerarGrillaDiagnostico(oConsulta.SelectDiagnosticoPersona(oDiagnostico));
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
            dtpUltimaVisita.Value = oConsulta.UltimaVisita(oPersona);
            dtpPrimeraVisita.Value = oConsulta.PrimeraVisita(oPersona);
            // Carga Visita
            //-------------------------------------------------
            txtNvisitas.Text = Convert.ToString(oConsulta.CantidadVisitas(oPersona));
            txtNvisitas.Enabled = false;
            // Carga Grilla Paciente
            //-------------------------------------------------
            oDiagnostico.IdPersona = oPersona.IdPersona;
            int C = this.GenerarGrillaDiagnostico(oConsulta.SelectDiagnosticoPersona(oDiagnostico));

            if (C == 0)
                btnExportar.Enabled = false;
            else
                btnExportar.Enabled = true;
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
            if (dgvDiagnostico.Columns.Count != 0)
                dgvDiagnostico.Columns.Clear();
            //
            //Columna Oculta ID
            //
            dgvDiagnostico.Columns.Add("dgvId", "ID");
            dgvDiagnostico.Columns["dgvId"].DataPropertyName = "IdDiagnostico";
            dgvDiagnostico.Columns["dgvId"].Visible = false;
            dgvDiagnostico.Columns["dgvId"].DefaultCellStyle.NullValue = "0";
            //
            //Columna Nombre
            //
            dgvDiagnostico.Columns.Add("dgvFecha", "Fecha");
            dgvDiagnostico.Columns["dgvFecha"].DataPropertyName = "Fecha";
            dgvDiagnostico.Columns["dgvFecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDiagnostico.Columns["dgvFecha"].DefaultCellStyle.NullValue = "No especificado";
            dgvDiagnostico.Columns["dgvFecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //
            //Columna  Obra Social
            //
            dgvDiagnostico.Columns.Add("dgvDiagnostico", "Diagnostico");
            dgvDiagnostico.Columns["dgvDiagnostico"].DataPropertyName = "Diagnostico";
            dgvDiagnostico.Columns["dgvDiagnostico"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDiagnostico.Columns["dgvDiagnostico"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Configuracion del DataListView
            //
            dgvDiagnostico.AutoGenerateColumns = false;
            dgvDiagnostico.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvDiagnostico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiagnostico.ReadOnly = true;
            dgvDiagnostico.ScrollBars = ScrollBars.Both;
            dgvDiagnostico.ContextMenuStrip = cmsMenuEmergente;
            dgvDiagnostico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiagnostico.MultiSelect = false;
            dgvDiagnostico.DataSource = Source;

            return dgvDiagnostico.Rows.Count;
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
            if (ValidarCampos())
            {
                this.LeerDesdeFrm();

                if (Modo == Vista.Nuevo)
                {   // Guarda
                    if (!oConsulta.AgregarPersona(oPersona, oUtil.IdUsuario))
                        MessageBox.Show(oConsulta.Menssage);
                    else
                    {
                        MessageBox.Show(oTxt.AgregarPaciente);
                        this.Modo = Vista.Modificar;
                        this.oPersona.IdPersona = oConsulta.UltimoIdPersona();
                        this.IdPaciente = 0;
                        this.ini();
                    }
                }
                else if (Modo == Vista.Modificar)
                {   // Actualiza
                    if (!oConsulta.ModificarPersona(oPersona))
                        MessageBox.Show(oConsulta.Menssage);
                    else
                    {
                        MessageBox.Show(oTxt.ModificarPaciente);
                        this.Modo = Vista.Modificar;
                        this.ini();
                    }
                }
                else
                    MessageBox.Show(oTxt.AccionIndefinida);
            }
            else
                MessageBox.Show(oTxt.CaillasVacias);
        }

        private void btnModificarPerfil_Click(object sender, EventArgs e)
        {
            if (Modo == Vista.Ver)
            {
                this.Modo = Vista.Modificar;
                this.frmForm_Load(sender, e);
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
            txtEdad.Text = Convert.ToString(oPersona.Edad(dtpFechaNacimiento.Value));
        }

        #endregion

        //Revisar
        #region Plus

        private void btnPlusBarrio_Click(object sender, EventArgs e)
        {
            frmAuxiliar frmA = new frmAuxiliar();
            frmA.oConsulta = this.oConsulta;
            frmA.tipoObjeto = frmAuxiliar.Tipo.Barrio;
            frmA.Id = Convert.ToInt32(cmbBarrio.SelectedValue);

            if (frmA.ShowDialog() == DialogResult.OK)
            {
                oComboBox.CargaCombo(
                    cmbBarrio,
                    oConsulta.ListaBarrios(Convert.ToInt32(cmbCiudad.SelectedValue)),
                    oConsulta.Table);
            }
        }

        private void btnPlusCiudad_Click(object sender, EventArgs e)
        {
            frmAuxiliar frmA = new frmAuxiliar();
            frmA.oConsulta = this.oConsulta;
            frmA.tipoObjeto = frmAuxiliar.Tipo.Ciudad;
            frmA.Id = Convert.ToInt32(cmbCiudad.SelectedValue);

            if (frmA.ShowDialog() == DialogResult.OK)
            {
                oComboBox.CargaCombo(
                    cmbCiudad,
                    oConsulta.ListaCiudades(),
                    oConsulta.Table);
            }
        }

        private void cmbCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            oComboBox.CargaCombo(cmbBarrio,
                oConsulta.ListaBarrios(Convert.ToInt32(cmbCiudad.SelectedValue)),
                oConsulta.Table);
        }

        private void btnPlusObraSocial_Click(object sender, EventArgs e)
        {
            frmVerObraSocial frmA = new frmVerObraSocial();
            frmA.oConsulta = this.oConsulta;

            if (frmA.ShowDialog() == DialogResult.OK)
            {
                // Cargo los Combos pero no lo selecciona
                oComboBox.CargaCombo(
                    cmbObraSocial,
                    oConsulta.ListSpecialty(false),
                    oConsulta.Table);
            }
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
                oPersona.IdPersona = this.IdPaciente;
                oPersona = oConsulta.SelectPersona(oPersona);
            }

            // Modo en el que se mostrara el formulario
            if (Modo == Vista.Ver && oPersona.IdPersona != 0)
            {
                this.EnableFicha(false, true);
                this.EnableDiagnostico(true);
                this.EscribirEnFrm();
                this.CargarDiagnostico();
            }
            else if (Modo == Vista.Modificar && oPersona.IdPersona != 0)
            {
                this.EnableFicha(true, false);
                this.EnableDiagnostico(true);
                this.EscribirEnFrm();
                this.CargarDiagnostico();
            }
            else if (Modo == Vista.Nuevo)
            {
                oPersona = new classPersona();

                this.EnableFicha(true, false);
                this.EnableDiagnostico(false);
                this.EscribirEnFrm();
                btnExportar.Enabled = false;
            }
            else
                MessageBox.Show("Error de typo");
        }

        /// <summary>
        /// Carga los Combos de Ciudad y Barrios
        /// 03/02/12
        /// </summary>
        private void CargarCombosCiudadBarrio()
        {
            oComboBox.CargaCombo(cmbCiudad,
                oConsulta.ListaCiudades(),
                oConsulta.Table);

            oComboBox.CargaCombo(cmbBarrio,
                oConsulta.ListaBarrios(Convert.ToInt32(cmbCiudad.SelectedValue)),
                oConsulta.Table);
        }

        /// <summary>
        /// Valida los campos del Formulario.
        /// False -> Vacio - True -> Ok
        /// OK 04/03/12
        /// </summary>
        /// <returns></returns>
        private bool ValidarCampos()
        {
            if ((txtApellido.Text == "") ||
                (txtNombre.Text == "") ||
                (txtDomicilio.Text == "") ||
                (txtNumeroAfiliado.Text == ""))
                return false;
            else
                return true;
        }

        // OK 04/03/12
        private void LeerDesdeFrm()
        {
            oPersona.nAfiliado = this.oValidarSql.ValidaString(txtNumeroAfiliado.Text);
            oPersona.Apellido = this.oValidarSql.ValidaString(txtApellido.Text);
            oPersona.Nombre = this.oValidarSql.ValidaString(txtNombre.Text);
            oPersona.FechaNac = dtpFechaNacimiento.Value;
            oPersona.FechaAlta = DateTime.Now;
            oPersona.Sexo = Convert.ToInt32(rbtMasculino.Checked);
            oPersona.Direccion = this.oValidarSql.ValidaString(txtDomicilio.Text);
            oPersona.ObraSocial = Convert.ToInt32(cmbObraSocial.SelectedValue);
            oPersona.TipoPaciente = Convert.ToInt32(cmbTipoPaciente.SelectedValue);
            oPersona.IdCiudad = Convert.ToInt32(cmbCiudad.SelectedValue);
            oPersona.IdBarrio = Convert.ToInt32(cmbBarrio.SelectedValue);
            oPersona.Telefono = this.oValidarSql.ValidaString(txtTelefono.Text);
            oPersona.TelefonoParticular = this.oValidarSql.ValidaString(txtTelefonoParticular.Text);
        }

        /// <summary>
        /// Carga los elementos de formulario desde objeto.
        /// OK 04/04/12
        /// </summary>
        private void EscribirEnFrm()
        {
            txtNumeroAfiliado.Text = oPersona.nAfiliado;
            txtApellido.Text = oPersona.Apellido;
            txtNombre.Text = oPersona.Nombre;
            dtpFechaNacimiento.Value = oPersona.FechaNac;
            rbtMasculino.Checked = Convert.ToBoolean(oPersona.Sexo);
            rbtFemenino.Checked = !Convert.ToBoolean(oPersona.Sexo);
            txtDomicilio.Text = oPersona.Direccion;
            txtEdad.Text = Convert.ToString(oPersona.Edad());

            oComboBox.IndexCombos(cmbObraSocial, oPersona.ObraSocial);
            oComboBox.IndexCombos(cmbTipoPaciente, oPersona.TipoPaciente);
            oComboBox.IndexCombos(cmbCiudad, oPersona.IdCiudad);
            oComboBox.IndexCombos(cmbBarrio, oPersona.IdBarrio);

            txtTelefono.Text = oPersona.Telefono;
            txtTelefonoParticular.Text = oPersona.TelefonoParticular;

            txtIdentificacion.Text = oPersona.Apellido + ", " + oPersona.Nombre;
        }

        /// <summary>
        /// Habilita TabFicha
        /// OK 18/04/12
        /// </summary>
        /// <param name="X"></param>
        private void EnableFicha(bool X, bool Ver)
        {
            foreach (Control C in this.tlpPanel.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
            this.btnGuardar.Enabled = !Ver;
            this.btnModificarPerfil.Enabled = Ver;
        }

        /// <summary>
        /// Carga y estableze los limites y valores de los componentes.
        /// OK 04/04/12
        /// </summary>
        private void ConfiguracionFicha()
        {
            Size sBtn = new Size(75, 42);
            btnModificarPerfil.Size = sBtn;
            btnGuardar.Size = sBtn;
            btnCerrar.Size = sBtn;

            dtpFechaNacimiento.MaxDate = DateTime.Now.AddDays(1);
            dtpUltimaVisita.MaxDate = DateTime.Now.AddDays(1);
        }

        #endregion

        //-----------------------------------------------------------------------
        #endregion
        //-----------------------------------------------------------------------

        /* 04/04/12: La falla no se presento.
        * Tiene un comportamiento anormal cuando en la grilla seleccionas una fila y
        * queres modificar un texto, Siempre selecciona un mismo ID paraece ser.
        * Tenes que si o si precionar editar para que no ocurra Bugs.
        * 
        */
    }
}
