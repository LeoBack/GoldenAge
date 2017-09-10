using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// De la solucion
using Datos;
using Entidades;
using Entidades.Clases;
using Controles;

namespace myExplorer.Formularios
{
    public partial class frmListSocialWorks : Form
    {
        // REVISADO - 17/09/09
        #region Atributos y Propiedades

        public classConsultas oConsulta { set; get; }
        public classUtiles oUtil { set; get; }
        private List<classSocialWork> lSocialWork;
        private classValidaSqlite oValidarSql = new classValidaSqlite();

        private classTextos oTxt = new classTextos();

        private int SelectRow;

        private int Desde = 0;
        private int Hasta = 0;
        private int cantPag = 0;
        private int Pag = 1;

        #endregion

        // REVISADO - 17/09/09
        #region Formulario

        // REVISADO - 17/09/09
        public frmListSocialWorks()
        {
            InitializeComponent();
        }

        // REVISADO - 17/09/09
        private void frmAux_Load(object sender, EventArgs e)
        {
            this.Text = oTxt.TituloSocialWorks;

            if (oConsulta != null)
            {
                this.SelectRow = 0;
                lblInfo.Text = "";

                this.Hasta = this.oUtil.CantRegistrosGrilla;
                this.tslPagina.Text = "Página: 0 de 0";
            }
            else
                this.Close();
        }

        #endregion

        // REVISADO - 17/09/09
        #region Botones

        // REVISADO - 17/09/09
        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count != 0)
            {
                frmDialogoImprecion fIm = new frmDialogoImprecion();
                fIm.oConsulta = this.oConsulta;
                fIm.oUtil = this.oUtil;
                fIm.IdSocialWork = Convert.ToInt32(dgvLista.Rows[this.SelectRow].Cells[0].Value);

                if (fIm.IdSocialWork != 0)
                    fIm.ShowDialog();
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
        private void tsbBuscar_Click(object sender, EventArgs e)
        {
           this.Filtrar();
        }

        // REVISADO - 17/09/09
        private void tsbAgregar_Click(object sender, EventArgs e)
        {
                frmAbmSocialWork frmA = new frmAbmSocialWork();
                frmA.oConsulta = this.oConsulta;
                frmA.oUtil = this.oUtil;
                frmA.Acto = frmAbmSocialWork.Accion.Nuevo;
                frmA.ShowDialog();

                frmAux_Load(sender, e);
        }

        // REVISADO - 17/09/09
        private void tsmiEliminar_Click(object sender, EventArgs e)
        {
            classSocialWork oSw = new classSocialWork();

            if (dgvLista.Rows.Count != 0)
            {
                oSw.IdSocialWork = Convert.ToInt32(dgvLista.Rows[this.SelectRow].Cells["grvId"].Value);
                oSw = oConsulta.SelectSocialWork(oSw);
            }

            if (oConsulta.Error)
            {
                frmAbmSocialWork frmA = new frmAbmSocialWork();
                frmA.oConsulta = this.oConsulta;
                frmA.oUtil = this.oUtil;
                frmA.oSocialWork = oSw;
                frmA.Acto = frmAbmSocialWork.Accion.Eliminar;
                frmA.ShowDialog();

                frmAux_Load(sender, e);
            }
            else
            {
                MessageBox.Show(oTxt.ErrorListaConsulta);
                this.Close();
            }
        }

        // REVISADO - 17/09/09
        private void tsmiModificar_Click(object sender, EventArgs e)
        {
            classSocialWork oOS = new classSocialWork();

            if (dgvLista.Rows.Count != 0)
            {
                oOS.IdSocialWork = Convert.ToInt32(dgvLista.Rows[this.SelectRow].Cells["grvId"].Value);
                oOS = oConsulta.SelectSocialWork(oOS);
            }

            if (oConsulta.Error)
            {
                frmAbmSocialWork frmA = new frmAbmSocialWork();
                frmA.oConsulta = this.oConsulta;
                frmA.oUtil = this.oUtil;
                frmA.oSocialWork = oOS;
                frmA.Acto = frmAbmSocialWork.Accion.Modificar;
                frmA.ShowDialog();

                frmAux_Load(sender, e);
            }
            else
            {
                MessageBox.Show(oTxt.ErrorListaConsulta);
                this.Close();
            }
        }

        // REVISADO - 17/09/09
        private void tsmiAgregar_Click(object sender, EventArgs e)
        {
            tsbAgregar_Click(sender, e);
        }

        // REVISADO - 17/09/09
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        // REVISADO - 17/09/09
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelectRow = e.RowIndex;
        }

        #endregion

        // REVISADO - 17/09/09
        #region Metodos

        /// <summary>
        /// Aplica Filtros de busqueda
        /// REVISADO - 17/09/09
        /// </summary>
        public void Filtrar()
        {
            lSocialWork = oConsulta.FiltroSocialWorkLimite(
                this.oValidarSql.ValidaString(tstxtNombre.TextBox.Text),
                this.Desde, this.Hasta);

            decimal Cont = oConsulta.CountSocialWork(tstxtNombre.TextBox.Text);
            decimal Div = Math.Ceiling((Cont / this.oUtil.CantRegistrosGrilla));
            this.cantPag = Convert.ToInt32(Math.Round(Div, MidpointRounding.ToEven));

            this.tslPagina.Text = "Página: " + Convert.ToString(this.Pag) + " de " + Convert.ToString(this.cantPag);

            if (oConsulta.Error)
            {
                dgvLista.Columns.Clear();
                this.GenerarGrilla(lSocialWork);
            }
            else
                MessageBox.Show(oTxt.ErrorListaConsulta);
        }

        /// <summary>
        /// Carga la Lista de Obras Sociales
        /// REVISADO - 17/09/09
        /// </summary>
        /// <param name="Source"></param>
        public void GenerarGrilla(object Source)
        {
            //
            //Columna Oculta ID
            //
            dgvLista.Columns.Add("grvId", "ID");
            dgvLista.Columns["grvId"].DataPropertyName = "IdSocialWork";
            dgvLista.Columns["grvId"].Visible = false;
            dgvLista.Columns["grvId"].DefaultCellStyle.NullValue = "0";
            //
            //Columna Nome
            //
            dgvLista.Columns.Add("grvNombre", "Nombre");
            dgvLista.Columns["grvNome"].DataPropertyName = "Name";
            dgvLista.Columns["grvNome"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvNome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLista.Columns["grvNome"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Columna Description
            //
            dgvLista.Columns.Add("grvDescription", "Descripcion");
            dgvLista.Columns["grvDescription"].DataPropertyName = "Descripcion";
            dgvLista.Columns["grvDescription"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvDescription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLista.Columns["grvDescription"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Configuracion del DataListView
            //
            dgvLista.AutoGenerateColumns = false;
            dgvLista.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLista.ReadOnly = true;
            dgvLista.ScrollBars = ScrollBars.Both;
            dgvLista.ContextMenuStrip = cmsMenuEmergente;
            //dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvLista.MultiSelect = false;
            dgvLista.DataSource = Source;
        }

        #endregion
    }
}