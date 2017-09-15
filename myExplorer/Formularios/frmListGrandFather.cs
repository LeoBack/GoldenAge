using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Datos.Query;
using Entidades;
using Entidades.Clases;
using Entidades.Grillas;
using Reportes;
using Controles;


namespace myExplorer.Formularios
{
    public partial class frmListGrandfather : Form
    {
        // REVISADO - 17/09/09
        #region Atributos y Propiedades

        public classQuery oQuery { set; get; }
        public int IdGrandfather { set; get; }
        public classUtiles oUtil { set; get; }

        private List<grvGrandfather> lGrandfather;
        private classControlComboBoxes oCombos;
        private classValidaSqlite oValidarSql = new classValidaSqlite();
        private int SelectRow;

        private classTextos oTxt = new classTextos();

        private int Desde = 0;
        private int Hasta = 0;
        private int cantPag = 0;
        private int Pag = 1;

        #endregion

        // REVISADO - 17/09/09
        #region Formulario

        // REVISADO - 17/09/09
        public frmListGrandfather()
        {
            InitializeComponent();
        }

        // REVISADO - 17/09/09
        private void frmSearch_Load(object sender, EventArgs e)
        {
            if (oQuery != null)
            {
                this.ConfiguracionInicial();
                oCombos = new classControlComboBoxes();
                oCombos.CargaCombo(tcmbSocialWork.ComboBox, oQuery.ListSpecialty(true), oQuery.Table);

                this.Hasta = this.oUtil.CantRegistrosGrilla;
                this.tslPagina.Text = "Página: 0 de 0";
                this.tsbImprimir.Enabled = false;
            }
            else
                this.Close();
        }

        #endregion

        // REVISADO - 17/09/09
        #region Menu

        // REVISADO - 17/09/09
        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            classGrandfather oP = new classGrandfather();
            oP.LastName = this.oValidarSql.ValidaString(txtbApellido.Text);
            oP.AffiliateNumber = Convert.ToInt32(this.oValidarSql.ValidaString(txtbNafiliado.Text));
            oP.IdSocialWork = Convert.ToInt32(tcmbSocialWork.ComboBox.SelectedValue);

            if (oQuery.rListaGrandfatherLimite("dtPersona", oP, this.Desde, this.Hasta))
            {
                frmVisor fReport = new frmVisor(frmVisor.Reporte.ListaPacientes, oQuery.Table);
                fReport.Show();
            }
            else
                MessageBox.Show(oTxt.ErrorListaConsulta);
        }

        #endregion

        // REVISADO - 17/09/09
        #region Botones

        // REVISADO - 17/09/09
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count != 0)
            {
                this.IdGrandfather = Convert.ToInt32(dgvLista.Rows[this.SelectRow].Cells[0].Value);
                txtEstado.Text = oTxt.PacienteSeleccionado + dgvLista.Rows[this.SelectRow].Cells["dgvLastName"].Value.ToString();
            }

        }

        // REVISADO - 17/09/09
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.Pag < this.cantPag)
            {
                this.Pag++;
                this.Desde = this.Desde + this.oUtil.CantRegistrosGrilla;
                this.Filtrar();
            }
        }

        // REVISADO - 17/09/09
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (this.Pag > 1)
            {
                this.Pag--;
                this.Desde = this.Desde - this.oUtil.CantRegistrosGrilla;
                this.Filtrar();
            }
        }

        // REVISADO - 17/09/09
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Filtrar();
        }

        // REVISADO - 17/09/09
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IdGrandfather = 0;
            this.Close();
        }

        // REVISADO - 17/09/09
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLista.Rows.Count != 0)
                this.SelectRow = e.RowIndex;
        }

        #endregion

        // REVISADO - 17/09/09
        #region MenuEmergente

        // REVISADO - 17/09/09
        private void tsmiVerFicha_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count != 0)
            {
                this.IdGrandfather = Convert.ToInt32(dgvLista.Rows[this.SelectRow].Cells[0].Value);
                txtEstado.Text = "Paciente Seleccionado : " + dgvLista.Rows[this.SelectRow].Cells["dgvLastName"].Value.ToString();

                frmGrandfather frmGrandfatherulario = new frmGrandfather();
                frmGrandfatherulario.Modo = frmGrandfather.Vista.Ver;
                frmGrandfatherulario.oQuery = this.oQuery;
                frmGrandfatherulario.IdPaciente = this.IdGrandfather;
                frmGrandfatherulario.oUtil = this.oUtil;
                frmGrandfatherulario.ShowDialog();

                this.frmSearch_Load(sender, e);
            }
        }

        #endregion

        // REVISADO - 17/09/09
        #region Metodos

        /// <summary>
        /// Configura el formulario.
        /// REVISADO - 17/09/09
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
        /// REVISADO - 17/09/09
        /// </summary>
        public void Filtrar()
        {
            this.SelectRow = 0;

            if (dgvLista.Columns.Count != 0)
                dgvLista.Columns.Clear();

            classGrandfather oGrandfather = new classGrandfather();
            oGrandfather.LastName = this.oValidarSql.ValidaString(txtbApellido.Text);
            oGrandfather.AffiliateNumber = Convert.ToInt32(this.oValidarSql.ValidaString(txtbNafiliado.Text));
            oGrandfather.IdSocialWork = Convert.ToInt32(tcmbSocialWork.ComboBox.SelectedValue);

            lGrandfather = oQuery.FiltroGrandfatherLimite(oGrandfather, this.Desde, this.Hasta);

            decimal Cont = oQuery.CountGrandfather(oGrandfather);
            decimal Div = Math.Ceiling((Cont / this.oUtil.CantRegistrosGrilla));
            this.cantPag = Convert.ToInt32(Math.Round(Div, MidpointRounding.ToEven));

            this.tslPagina.Text = "Página: " + Convert.ToString(this.Pag) + " de " + Convert.ToString(this.cantPag);

            this.GenerarGrilla(lGrandfather);

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
        /// REVISADO - 17/09/09
        /// </summary>
        /// <param name="Source"></param>
        public int GenerarGrilla(object Source)
        {
            if (dgvLista.Columns.Count != 0)

                dgvLista.Columns.Clear();
            //
            // Columna Oculta ID
            //
            dgvLista.Columns.Add("grvId", "ID");
            dgvLista.Columns["grvId"].DataPropertyName = "IdGrandfather";
            dgvLista.Columns["grvId"].Visible = false;
            dgvLista.Columns["grvId"].DefaultCellStyle.NullValue = "0";
            //
            // Columna SocialWork
            //
            dgvLista.Columns.Add("drvSocialWork", "Obra Social");
            dgvLista.Columns["drvSocialWork"].DataPropertyName = "SocialWork";
            dgvLista.Columns["drvSocialWork"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["drvSocialWork"].DefaultCellStyle.NullValue = "No especificado";
            dgvLista.Columns["drvSocialWork"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //
            //Columna AffiliateNumber
            //
            dgvLista.Columns.Add("grvAffiliateNumber", "N° Afiliado");
            dgvLista.Columns["grvAffiliateNumber"].DataPropertyName = "AffiliateNumber";
            dgvLista.Columns["grvAffiliateNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvAffiliateNumber"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Columna LastName
            //
            dgvLista.Columns.Add("dgvLastName", "Apellido");
            dgvLista.Columns["dgvLastName"].DataPropertyName = "LastName";
            dgvLista.Columns["dgvLastName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["dgvLastName"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Columna Nome
            //
            dgvLista.Columns.Add("grvNome", "Nombre");
            dgvLista.Columns["grvNome"].DataPropertyName = "Name";
            dgvLista.Columns["grvNome"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvNome"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Columna Sex
            //
            dgvLista.Columns.Add("grvSex", "Sexo");
            dgvLista.Columns["grvSex"].DataPropertyName = "Sex";
            dgvLista.Columns["grvSex"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvSex"].DefaultCellStyle.NullValue = "No especificado";
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
