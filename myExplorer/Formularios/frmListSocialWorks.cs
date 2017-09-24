using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// De la solucion
using Datos.Query;
using Entidades;
using Entidades.Clases;
using Controles;

namespace myExplorer.Formularios
{
    public partial class frmListSocialWorks : Form
    {
        // REVISADO - 17/09/09
        #region Atributos y Propiedades

        public classQuery oQuery { set; get; }
        public classUtiles oUtil { set; get; }
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
            Text = oTxt.TituloSocialWorks;

            if (oQuery != null)
            {
                SelectRow = 0;
                lblInfo.Text = "";

                Hasta = oUtil.CantRegistrosGrilla;
                tslPagina.Text = "Página: 0 de 0";
            }
            else
                Close();
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
                fIm.oQuery = oQuery;
                fIm.oUtil = oUtil;
                fIm.IdSocialWork = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value);

                if (fIm.IdSocialWork != 0)
                    fIm.ShowDialog();
            }
        }

        // REVISADO - 17/09/09
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (Pag < cantPag)
            {
                Pag++;
                Desde = Desde + oUtil.CantRegistrosGrilla;
                Filtrar();
            }
        }

        // REVISADO - 17/09/09
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (Pag > 1)
            {
                Pag--;
                Desde = Desde - oUtil.CantRegistrosGrilla;
                Filtrar();
            }
        }

        // REVISADO - 17/09/09
        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        // REVISADO - 17/09/09
        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmAbmSocialWork frmA = new frmAbmSocialWork();
            frmA.oQuery = oQuery;
            frmA.oUtil = oUtil;
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
                oSw.IdSocialWork = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells["grvId"].Value);
                oSw = (classSocialWork)oQuery.AbmSocialWork(oSw, classQuery.eAbm.Select);
            }

            if (oQuery.Error)
            {
                frmAbmSocialWork frmA = new frmAbmSocialWork();
                frmA.oQuery = oQuery;
                frmA.oUtil = oUtil;
                frmA.oSocialWork = oSw;
                frmA.Acto = frmAbmSocialWork.Accion.Eliminar;
                frmA.ShowDialog();

                frmAux_Load(sender, e);
            }
            else
            {
                MessageBox.Show(oTxt.ErrorListaConsulta);
                Close();
            }
        }

        // REVISADO - 17/09/09
        private void tsmiModificar_Click(object sender, EventArgs e)
        {
            classSocialWork oOS = new classSocialWork();

            if (dgvLista.Rows.Count != 0)
            {
                oOS.IdSocialWork = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells["grvId"].Value);
                oOS = (classSocialWork)oQuery.AbmSocialWork(oOS, classQuery.eAbm.Select);
            }

            if (oQuery.Error)
            {
                frmAbmSocialWork frmA = new frmAbmSocialWork();
                frmA.oQuery = oQuery;
                frmA.oUtil = oUtil;
                frmA.oSocialWork = oOS;
                frmA.Acto = frmAbmSocialWork.Accion.Modificar;
                frmA.ShowDialog();

                frmAux_Load(sender, e);
            }
            else
            {
                MessageBox.Show(oTxt.ErrorListaConsulta);
                Close();
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
            //Close();
        }

        // REVISADO - 17/09/09
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow = e.RowIndex;
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
            if (oQuery.FiltroSocialWorkLimite(tstxtNombre.TextBox.Text, Desde, Hasta))
            {
                //decimal Cont = oQuery.CountSocialWork(tstxtNombre.TextBox.Text);
                //decimal Div = Math.Ceiling((Cont / oUtil.CantRegistrosGrilla));
                //cantPag = Convert.ToInt32(Math.Round(Div, MidpointRounding.ToEven));

                //tslPagina.Text = "Página: " + Convert.ToString(Pag) + " de " + Convert.ToString(cantPag);

                dgvLista.Columns.Clear();
                GenerarGrilla(oQuery.Table);
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
            ////
            ////Columna Oculta ID
            ////
            //dgvLista.Columns.Add("grvId", "ID");
            //dgvLista.Columns["grvId"].DataPropertyName = "IdSocialWork";
            //dgvLista.Columns["grvId"].Visible = false;
            //dgvLista.Columns["grvId"].DefaultCellStyle.NullValue = "0";
            ////
            ////Columna Nome
            ////
            //dgvLista.Columns.Add("grvNombre", "Nombre");
            //dgvLista.Columns["grvNome"].DataPropertyName = "Name";
            //dgvLista.Columns["grvNome"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dgvLista.Columns["grvNome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dgvLista.Columns["grvNome"].DefaultCellStyle.NullValue = "No especificado";
            ////
            ////Columna Description
            ////
            //dgvLista.Columns.Add("grvDescription", "Descripcion");
            //dgvLista.Columns["grvDescription"].DataPropertyName = "Descripcion";
            //dgvLista.Columns["grvDescription"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dgvLista.Columns["grvDescription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvLista.Columns["grvDescription"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Configuracion del DataListView
            //
            dgvLista.AutoGenerateColumns = true;
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