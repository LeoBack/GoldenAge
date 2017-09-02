using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Datos;
using Entidades;
using Entidades.Clases;
using Entidades.Clases.Grillas;
using Reportes;
using Controles;


namespace myExplorer.Formularios
{
    public partial class frmSearch : Form
    {
        #region Atributos y Propiedades

        public classConsultas oConsulta { set; get; }
        public int IdPersona { set; get; }
        public classUtiles oUtil { set; get; }

        private List<grvPersona> lPersonas;
        private classControlComboBoxes oCombos;
        private classValidaSqlite oValidarSql = new classValidaSqlite();
        private int SelectRow;

        private classTextos oTxt = new classTextos();

        private int Desde = 0;
        private int Hasta = 0;
        private int cantPag = 0;
        private int Pag = 1;

        #endregion

        #region Formulario

        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            if (oConsulta != null)
            {
                this.ConfiguracionInicial();
                oCombos = new classControlComboBoxes();
                oCombos.CargaCombo(tcmbObraSocial.ComboBox, oConsulta.ListSpecialty(true), oConsulta.Table);

                this.Hasta = this.oUtil.CantRegistrosGrilla;
                this.tslPagina.Text = "Página: 0 de 0";
                this.tsbImprimir.Enabled = false;
            }
            else
                this.Close();
        }

        #endregion

        #region Menu

        //OK 21/06/12
        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            classPersona oP = new classPersona();
            oP.Apellido = this.oValidarSql.ValidaString(txtbApellido.Text);
            oP.nAfiliado = this.oValidarSql.ValidaString(txtbNafiliado.Text);
            oP.ObraSocial = Convert.ToInt32(tcmbObraSocial.ComboBox.SelectedValue);

            if (oConsulta.rListaPacientesLimite("dtPersona", oP, this.Desde, this.Hasta))
            {
                frmVisor fReport = new frmVisor(frmVisor.Reporte.ListaPacientes, oConsulta.Table);
                fReport.Show();
            }
            else
                MessageBox.Show(oTxt.ErrorListaConsulta);
        }

        #endregion

        #region Botones

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count != 0)
            {
                this.IdPersona = Convert.ToInt32(dgvLista.Rows[this.SelectRow].Cells[0].Value);
                txtEstado.Text = oTxt.PacienteSeleccionado + dgvLista.Rows[this.SelectRow].Cells["dgvApellido"].Value.ToString();
            }

        }

        // OK 24/06/12
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.Pag < this.cantPag)
            {
                this.Pag++;
                this.Desde = this.Desde + this.oUtil.CantRegistrosGrilla;
                this.Filtrar();
            }
        }

        // OK 24/06/12
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (this.Pag > 1)
            {
                this.Pag--;
                this.Desde = this.Desde - this.oUtil.CantRegistrosGrilla;
                this.Filtrar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Filtrar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IdPersona = 0;
            this.Close();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLista.Rows.Count != 0)
                this.SelectRow = e.RowIndex;
        }

        #endregion

        #region MenuEmergente

        private void tsmiVerFicha_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count != 0)
            {
                this.IdPersona = Convert.ToInt32(dgvLista.Rows[this.SelectRow].Cells[0].Value);
                txtEstado.Text = "Paciente Seleccionado : " + dgvLista.Rows[this.SelectRow].Cells["dgvApellido"].Value.ToString();

                frmForm frmFormulario = new frmForm();
                frmFormulario.Modo = frmForm.Vista.Ver;
                frmFormulario.oConsulta = this.oConsulta;
                frmFormulario.IdPaciente = this.IdPersona;
                frmFormulario.oUtil = this.oUtil;
                frmFormulario.ShowDialog();

                this.frmSearch_Load(sender, e);
            }
        }

        private void tsmiTurnos_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count != 0)
            {
                this.IdPersona = Convert.ToInt32(dgvLista.Rows[this.SelectRow].Cells[0].Value);
                txtEstado.Text = "Paciente Seleccionado : " + dgvLista.Rows[this.SelectRow].Cells["dgvApellido"].Value.ToString();

                frmTurno fTurno = new frmTurno();
                fTurno.oConsulta = this.oConsulta;
                fTurno.oUtil = this.oUtil;
                fTurno.oPersona = oConsulta.SelectPersona(
                    new classPersona(this.IdPersona, 0, 0, 0, 0, "", "", "", DateTime.Now, DateTime.Now, 0, "", "", ""));
                fTurno.ShowDialog();
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Configura el formulario.
        /// OK 18/05/12
        /// </summary>
        public void ConfiguracionInicial()
        {
            Size sBtn = new Size(75, 42);
            btnBuscar.Size = sBtn;
            btnSeleccionar.Size = sBtn;
            btnCancelar.Size = sBtn;
        }

        /// <summary>
        /// Aplica Filtros de busqueda
        /// OK 21/05/12
        /// </summary>
        public void Filtrar()
        {
            this.SelectRow = 0;

            if (dgvLista.Columns.Count != 0)
                dgvLista.Columns.Clear();

            classPersona oPersona = new classPersona();
            oPersona.Apellido = this.oValidarSql.ValidaString(txtbApellido.Text);
            oPersona.nAfiliado = this.oValidarSql.ValidaString(txtbNafiliado.Text);
            oPersona.ObraSocial = Convert.ToInt32(tcmbObraSocial.ComboBox.SelectedValue);

            //lPersonas = oConsulta.FiltroPersona(oPersona);
            lPersonas = oConsulta.FiltroPersonaLimite(oPersona, this.Desde, this.Hasta);

            decimal Cont = oConsulta.CountPersona(oPersona);
            decimal Div = Math.Ceiling((Cont / this.oUtil.CantRegistrosGrilla));
            this.cantPag = Convert.ToInt32(Math.Round(Div, MidpointRounding.ToEven));

            this.tslPagina.Text = "Página: " + Convert.ToString(this.Pag) + " de " + Convert.ToString(this.cantPag);

            this.GenerarGrilla(lPersonas);

            if (dgvLista.Rows.Count == 0)
            {
                tsbImprimir.Enabled = false;
                btnSeleccionar.Enabled = false;
                tsmiTurnos.Enabled = false;
                tsmiVerFicha.Enabled = false;
            }
            else
            {
                tsmiTurnos.Enabled = true;
                tsmiVerFicha.Enabled = true;
                    tsbImprimir.Enabled = true;
                btnSeleccionar.Enabled = true;
            }
        }

        /// <summary>
        /// Carga la Lista debuelve la cantidad de filas.
        /// OK 25/05/12
        /// </summary>
        /// <param name="Source"></param>
        public int GenerarGrilla(object Source)
        {
            if (dgvLista.Columns.Count != 0)

                dgvLista.Columns.Clear();
            //
            //Columna Oculta ID
            //
            dgvLista.Columns.Add("grvId", "ID");
            dgvLista.Columns["grvId"].DataPropertyName = "IdPersona";
            dgvLista.Columns["grvId"].Visible = false;
            dgvLista.Columns["grvId"].DefaultCellStyle.NullValue = "0";
            //
            //Columna  Obra Social
            //
            dgvLista.Columns.Add("drvObraSocial", "Obra Social");
            dgvLista.Columns["drvObraSocial"].DataPropertyName = "ObraSocial";
            dgvLista.Columns["drvObraSocial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["drvObraSocial"].DefaultCellStyle.NullValue = "No especificado";
            dgvLista.Columns["drvObraSocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //
            //Columna nAfiliado
            //
            dgvLista.Columns.Add("grvnAfiliado", "N° Afiliado");
            dgvLista.Columns["grvnAfiliado"].DataPropertyName = "nAfiliado";
            dgvLista.Columns["grvnAfiliado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvnAfiliado"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Columna Apellido
            //
            dgvLista.Columns.Add("dgvApellido", "Apellido");
            dgvLista.Columns["dgvApellido"].DataPropertyName = "Apellido";
            dgvLista.Columns["dgvApellido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["dgvApellido"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Columna Nombre
            //
            dgvLista.Columns.Add("grvNombre", "Nombre");
            dgvLista.Columns["grvNombre"].DataPropertyName = "Nombre";
            dgvLista.Columns["grvNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvNombre"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Columna Nombre
            //
            dgvLista.Columns.Add("grvSexo", "Sexo");
            dgvLista.Columns["grvSexo"].DataPropertyName = "Sexo";
            dgvLista.Columns["grvSexo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvSexo"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Configuracion del DataListView
            //
            dgvLista.AutoGenerateColumns = false;
            dgvLista.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLista.ReadOnly = true;
            dgvLista.ScrollBars = ScrollBars.Both;
            dgvLista.ContextMenuStrip = cmsMenuEmergente;
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLista.MultiSelect = false;
            dgvLista.DataSource = Source;

            return dgvLista.Rows.Count;
        }

        #endregion

    }
}
